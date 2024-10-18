BEGIN TRANSACTION;

-- Insert 'System'
IF NOT EXISTS (SELECT 1 FROM Subject WHERE Name = 'System')
BEGIN
    INSERT INTO [Subject] (SubjectId, Name, CreatedDate)
    VALUES (NEWID(), 'System', GETUTCDATE());
END

COMMIT TRANSACTION;
