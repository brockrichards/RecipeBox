PRINT 'Before TRY'
BEGIN TRY
	BEGIN TRAN
	PRINT 'First Statement in the TRY block'
BEGIN TRANSACTION;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [FK_RecipeIngredient_Units_UnitId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [FK_RecipeTag_Tags_TagId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_Tags_Subject_CreatedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_Tags_Subject_LastModifiedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Units] DROP CONSTRAINT [FK_Units_Subject_CreatedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Units] DROP CONSTRAINT [FK_Units_Subject_LastModifiedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Units] DROP CONSTRAINT [PK_Units];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [PK_Tags];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    EXEC sp_rename N'[dbo].[Units]', N'Unit';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    EXEC sp_rename N'[dbo].[Tags]', N'Tag';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    EXEC sp_rename N'[dbo].[Unit].[IX_Units_LastModifiedSubjectId]', N'IX_Unit_LastModifiedSubjectId', N'INDEX';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    EXEC sp_rename N'[dbo].[Unit].[IX_Units_CreatedSubjectId]', N'IX_Unit_CreatedSubjectId', N'INDEX';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    EXEC sp_rename N'[dbo].[Tag].[IX_Tags_LastModifiedSubjectId]', N'IX_Tag_LastModifiedSubjectId', N'INDEX';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    EXEC sp_rename N'[dbo].[Tag].[IX_Tags_CreatedSubjectId]', N'IX_Tag_CreatedSubjectId', N'INDEX';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    DECLARE @description AS sql_variant;
    SET @description = N'Units of measurement for Ingredients';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Unit';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    SET @description = N'Tags for organizing recipes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Tag';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Unit] ADD CONSTRAINT [PK_Unit] PRIMARY KEY ([UnitId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Tag] ADD CONSTRAINT [PK_Tag] PRIMARY KEY ([TagId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD CONSTRAINT [FK_RecipeIngredient_Unit_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Unit] ([UnitId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] ADD CONSTRAINT [FK_RecipeTag_Tag_TagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([TagId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Tag] ADD CONSTRAINT [FK_Tag_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Tag] ADD CONSTRAINT [FK_Tag_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Unit] ADD CONSTRAINT [FK_Unit_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    ALTER TABLE [dbo].[Unit] ADD CONSTRAINT [FK_Unit_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017222108_FixTableNames'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241017222108_FixTableNames', N'8.0.8');
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
