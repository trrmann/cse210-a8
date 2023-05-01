DROP VIEW IF EXISTS EntriesView;
CREATE VIEW IF NOT EXISTS EntriesView (ID, Date, Prompt, Response, PromptID, TimesUsedPrompt, LastUsedPrompt) AS
    SELECT [Entries].[Id],
        [Entries].[Date],
        [Prompts].[Value],
        [Entries].[Response],
        [Entries].[PromptID],
        [Prompts].[TimesUsed],
        [Prompts].[LastUsed]
    FROM [Entries]
    LEFT OUTER JOIN [Prompts] ON [Entries].[PromptID] = [Prompts].[ID];