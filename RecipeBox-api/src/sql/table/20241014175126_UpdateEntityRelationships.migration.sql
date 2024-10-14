PRINT 'Before TRY'
BEGIN TRY
	BEGIN TRAN
	PRINT 'First Statement in the TRY block'
BEGIN TRANSACTION;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Ingredient] DROP CONSTRAINT [FK_Ingredient_Recipe_RecipeId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [FK_Tags_Recipe_RecipeId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    DROP INDEX [IX_Tags_RecipeId] ON [dbo].[Tags];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    DROP INDEX [IX_Ingredient_RecipeId] ON [dbo].[Ingredient];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Tags]') AND [c].[name] = N'RecipeId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Tags] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [dbo].[Tags] DROP COLUMN [RecipeId];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Recipe]') AND [c].[name] = N'Name');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Recipe] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [dbo].[Recipe] DROP COLUMN [Name];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    DECLARE @description AS sql_variant;
    SET @description = N'Tag name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'Name';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Tags] ADD [TagResourceId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
    SET @description = N'Public unique identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'TagResourceId';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[dbo].[Recipe]') AND [c].[name] = N'Description');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [dbo].[Recipe] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [dbo].[Recipe] ALTER COLUMN [Description] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Recipe] ADD [ImageUrl] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Recipe] ADD [IsPublic] bit NOT NULL DEFAULT CAST(0 AS bit);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Recipe] ADD [Title] nvarchar(max) NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    EXEC sp_dropextendedproperty 'MS_Description', 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'Name';
    SET @description = N'Name of the ingredient';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'Name';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Ingredient] ADD [Description] nvarchar(max) NULL;
    SET @description = N'Description of the ingredient';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'Description';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    ALTER TABLE [dbo].[Ingredient] ADD [IngredientResourceId] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
    SET @description = N'Public unique identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'IngredientResourceId';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    CREATE TABLE [dbo].[RecipeIngredient] (
        [RecipeIngredientId] int NOT NULL IDENTITY,
        [RecipeIngredientResourceId] uniqueidentifier NOT NULL,
        [RecipeId] int NULL,
        [IngredientId] int NULL,
        [Quantity] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY ([RecipeIngredientId]),
        CONSTRAINT [FK_RecipeIngredient_Ingredient_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [dbo].[Ingredient] ([IngredientId]),
        CONSTRAINT [FK_RecipeIngredient_Recipe_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId])
    );
    SET @description = N'Public unique identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'RecipeIngredient', 'COLUMN', N'RecipeIngredientResourceId';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    CREATE TABLE [dbo].[RecipeTag] (
        [RecipeTagId] int NOT NULL IDENTITY,
        [RecipeTagResourceId] uniqueidentifier NOT NULL,
        [RecipeId] int NULL,
        [TagId] int NULL,
        CONSTRAINT [PK_RecipeTag] PRIMARY KEY ([RecipeTagId]),
        CONSTRAINT [FK_RecipeTag_Recipe_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]),
        CONSTRAINT [FK_RecipeTag_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([TagId])
    );
    SET @description = N'Public unique identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'RecipeTag', 'COLUMN', N'RecipeTagResourceId';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    CREATE INDEX [IX_RecipeIngredient_IngredientId] ON [dbo].[RecipeIngredient] ([IngredientId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    CREATE INDEX [IX_RecipeIngredient_RecipeId] ON [dbo].[RecipeIngredient] ([RecipeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    CREATE INDEX [IX_RecipeTag_RecipeId] ON [dbo].[RecipeTag] ([RecipeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    CREATE INDEX [IX_RecipeTag_TagId] ON [dbo].[RecipeTag] ([TagId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241014175126_UpdateEntityRelationships'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241014175126_UpdateEntityRelationships', N'8.0.8');
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
