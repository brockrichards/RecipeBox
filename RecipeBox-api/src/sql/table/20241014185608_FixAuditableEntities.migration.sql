PRINT 'Before TRY'
BEGIN TRY
	BEGIN TRAN
	PRINT 'First Statement in the TRY block'
BEGIN TRANSACTION;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD [CreatedSubjectSubjectId] uniqueidentifier NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD [LastModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD [LastModifiedSubjectSubjectId] uniqueidentifier NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    DECLARE @description AS sql_variant;
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'RecipeTag', 'COLUMN', N'CreatedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD [CreatedSubjectId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD [LastModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    SET @description = N'Date and time entity was last modified';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'RecipeTag', 'COLUMN', N'LastModifiedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD [LastModifiedSubjectId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'RecipeIngredient', 'COLUMN', N'CreatedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD [CreatedSubjectId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD [LastModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    SET @description = N'Date and time entity was last modified';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'RecipeIngredient', 'COLUMN', N'LastModifiedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD [LastModifiedSubjectId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    CREATE INDEX [IX_User_CreatedSubjectSubjectId] ON [dbo].[User] ([CreatedSubjectSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    CREATE INDEX [IX_User_LastModifiedSubjectSubjectId] ON [dbo].[User] ([LastModifiedSubjectSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    CREATE INDEX [IX_RecipeTag_CreatedSubjectId] ON [dbo].[RecipeTag] ([CreatedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    CREATE INDEX [IX_RecipeTag_LastModifiedSubjectId] ON [dbo].[RecipeTag] ([LastModifiedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    CREATE INDEX [IX_RecipeIngredient_CreatedSubjectId] ON [dbo].[RecipeIngredient] ([CreatedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    CREATE INDEX [IX_RecipeIngredient_LastModifiedSubjectId] ON [dbo].[RecipeIngredient] ([LastModifiedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD CONSTRAINT [FK_RecipeIngredient_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD CONSTRAINT [FK_RecipeIngredient_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD CONSTRAINT [FK_RecipeTag_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD CONSTRAINT [FK_RecipeTag_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_Subject_CreatedSubjectSubjectId] FOREIGN KEY ([CreatedSubjectSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    ALTER TABLE [dbo].[User] ADD CONSTRAINT [FK_User_Subject_LastModifiedSubjectSubjectId] FOREIGN KEY ([LastModifiedSubjectSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014185608_FixAuditableEntities'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241014185608_FixAuditableEntities', N'8.0.8');
END;

COMMIT;

	PRINT 'Last Statement in the TRY block'
	COMMIT TRAN
END TRY
BEGIN CATCH
    PRINT 'In CATCH Block'
    IF(@@TRANCOUNT > 0)
        ROLLBACK TRAN;

    THROW; -- Raise error to the client.
END CATCH
PRINT 'After END CATCH'
GO
