PRINT 'Before TRY'
BEGIN TRY
	BEGIN TRAN
	PRINT 'First Statement in the TRY block'
BEGIN TRANSACTION;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [FK_RecipeIngredient_Subject_CreatedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [FK_RecipeIngredient_Subject_LastModifiedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [FK_RecipeTag_Subject_CreatedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [FK_RecipeTag_Subject_LastModifiedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DROP INDEX [IX_RecipeTag_CreatedSubjectId] ON [dbo].[RecipeTag];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DROP INDEX [IX_RecipeTag_LastModifiedSubjectId] ON [dbo].[RecipeTag];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DROP INDEX [IX_RecipeIngredient_CreatedSubjectId] ON [dbo].[RecipeIngredient];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DROP INDEX [IX_RecipeIngredient_LastModifiedSubjectId] ON [dbo].[RecipeIngredient];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeTag]') AND [c].[name] = N'CreatedDate');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [dbo].[RecipeTag] DROP COLUMN [CreatedDate];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeTag]') AND [c].[name] = N'CreatedSubjectId');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [dbo].[RecipeTag] DROP COLUMN [CreatedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeTag]') AND [c].[name] = N'LastModifiedDate');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [dbo].[RecipeTag] DROP COLUMN [LastModifiedDate];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeTag]') AND [c].[name] = N'LastModifiedSubjectId');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeTag] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [dbo].[RecipeTag] DROP COLUMN [LastModifiedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeIngredient]') AND [c].[name] = N'CreatedDate');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [dbo].[RecipeIngredient] DROP COLUMN [CreatedDate];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeIngredient]') AND [c].[name] = N'CreatedSubjectId');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [dbo].[RecipeIngredient] DROP COLUMN [CreatedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeIngredient]') AND [c].[name] = N'LastModifiedDate');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [dbo].[RecipeIngredient] DROP COLUMN [LastModifiedDate];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[RecipeIngredient]') AND [c].[name] = N'LastModifiedSubjectId');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[RecipeIngredient] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [dbo].[RecipeIngredient] DROP COLUMN [LastModifiedSubjectId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Ingredient]') AND [c].[name] = N'RecipeId');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Ingredient] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [dbo].[Ingredient] DROP COLUMN [RecipeId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[Tags] ADD [Category] nvarchar(50) NOT NULL DEFAULT N'';
    DECLARE @description AS sql_variant;
    SET @description = N'Tag category';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'Category';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD [UnitId] int NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    CREATE TABLE [dbo].[Units] (
        [UnitId] int NOT NULL IDENTITY,
        [UnitResourceId] uniqueidentifier NOT NULL,
        [Name] nvarchar(50) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedSubjectId] uniqueidentifier NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedSubjectId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Units] PRIMARY KEY ([UnitId]),
        CONSTRAINT [FK_Units_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
        CONSTRAINT [FK_Units_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId])
    );
    SET @description = N'Public unique identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Units', 'COLUMN', N'UnitResourceId';
    SET @description = N'Unit name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Units', 'COLUMN', N'Name';
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Units', 'COLUMN', N'CreatedDate';
    SET @description = N'Date and time entity was last modified';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Units', 'COLUMN', N'LastModifiedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    CREATE INDEX [IX_RecipeIngredient_UnitId] ON [dbo].[RecipeIngredient] ([UnitId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    CREATE INDEX [IX_Units_CreatedSubjectId] ON [dbo].[Units] ([CreatedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    CREATE INDEX [IX_Units_LastModifiedSubjectId] ON [dbo].[Units] ([LastModifiedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    ALTER TABLE [dbo].[RecipeIngredient] ADD CONSTRAINT [FK_RecipeIngredient_Units_UnitId] FOREIGN KEY ([UnitId]) REFERENCES [dbo].[Units] ([UnitId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241017214357_AddCategoryToTag'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241017214357_AddCategoryToTag', N'8.0.8');
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
