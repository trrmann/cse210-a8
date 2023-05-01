DROP VIEW IF EXISTS EntriesView;
CREATE VIEW IF NOT EXISTS EntriesView (ID, Date, Prompt, Response, PromptID, TimesUsedPrompt, LastUsedPrompt) AS SELECT entries.[Id]
, entries.[Date]
, prompts.[Value]
, entries.[Response]
, entries.[PromptID]
, prompts.[TimesUsed]
, prompts.[LastUsed]
FROM entries 
LEFT OUTER JOIN prompts;