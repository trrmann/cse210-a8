-- Script Date: 4/30/2023 9:43 AM  - ErikEJ.SqlCeScripting version 3.5.2.94
DROP VIEW IF EXISTS EntriesView;
DROP TABLE IF EXISTS [Entries];
DROP TABLE IF EXISTS [Prompts];
CREATE TABLE [Prompts] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Value] test not null
, [TimesUsed] int default 0 not null
, [LastUsed] datetime default (datetime('0001-01-01 00:00:00')) NOT NULL
);
CREATE TABLE [Entries] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Date] datetime default (datetime()) NOT NULL
, [PromptID] bigint NOT NULL
, [Response] text NOT NULL
, FOREIGN KEY(PromptID) REFERENCES prompts(id)
);
CREATE VIEW IF NOT EXISTS EntriesView (ID, Date, Prompt, Response, PromptID, TimesUsedPrompt, LastUsedPrompt) AS SELECT entries.[Id]
, entries.[Date]
, prompts.[Value]
, entries.[Response]
, entries.[PromptID]
, prompts.[TimesUsed]
, prompts.[LastUsed]
FROM entries 
LEFT OUTER JOIN prompts;
--INSERT INTO prompts (Value, timesused, lastused)
--VALUES('test', 0 , datetime('0001-01-01 00:00:00'));
--INSERT INTO prompts (Value)
--VALUES('test');
--INSERT INTO entries (Date, PromptID, Response)
--VALUES(datetime('0001-01-01 00:00:00'), (SELECT Id FROM prompts where value = 'test'), 'test');
--INSERT INTO entries (PromptID, Response)
--VALUES((SELECT Id FROM prompts where value = 'test'), 'test');
--select * from entries;
--select * from prompts;
--select * from entriesview;
--DELETE FROM entries where PromptID = (SELECT Id FROM prompts where value = 'test');
--DELETE FROM prompts where value = 'test';
select * from entriesview;

