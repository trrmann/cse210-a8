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

