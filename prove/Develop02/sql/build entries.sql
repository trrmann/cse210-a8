-- Script Date: 4/30/2023 9:43 AM  - ErikEJ.SqlCeScripting version 3.5.2.94
DROP VIEW IF EXISTS EntriesView;
DROP TABLE IF EXISTS [Entries];
CREATE TABLE [Entries] (
  [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [Date] datetime default (datetime()) NOT NULL
, [PromptID] bigint NOT NULL
, [Response] text NOT NULL
, FOREIGN KEY(PromptID) REFERENCES prompts(id)
);
