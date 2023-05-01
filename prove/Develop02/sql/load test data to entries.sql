INSERT INTO entries (Date, PromptID, Response)
VALUES(datetime('0001-01-01 00:00:00'), (SELECT Id FROM prompts where value = 'test'), 'test');
