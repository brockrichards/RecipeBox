PRINT 'Before TRY'
BEGIN TRY
	BEGIN TRAN
	PRINT 'First Statement in the TRY block'
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

BEGIN TRANSACTION;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Outbox] (
        [OutboxId] int NOT NULL IDENTITY,
        [MessageId] nvarchar(36) NOT NULL,
        [CorrelationId] nvarchar(250) NULL,
        [EventType] nvarchar(250) NOT NULL,
        [Topic] nvarchar(100) NOT NULL,
        [RoutingKey] nvarchar(100) NOT NULL,
        [Body] nvarchar(max) NOT NULL,
        [Status] nvarchar(10) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [ScheduledDate] datetime2 NOT NULL,
        [PublishedDate] datetime2 NULL,
        [LockId] nvarchar(36) NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [PublishCount] int NOT NULL,
        CONSTRAINT [PK_Outbox] PRIMARY KEY ([OutboxId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Subject] (
        [SubjectId] uniqueidentifier NOT NULL,
        [Name] nvarchar(100) NULL,
        [GivenName] nvarchar(100) NULL,
        [FamilyName] nvarchar(100) NULL,
        [UserPrincipalName] nvarchar(100) NULL,
        [CreatedDate] datetime2 NOT NULL,
        CONSTRAINT [PK_Subject] PRIMARY KEY ([SubjectId])
    );
    DECLARE @description AS sql_variant;
    SET @description = N'Subject primary key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Subject', 'COLUMN', N'SubjectId';
    SET @description = N'Subject primary key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Subject', 'COLUMN', N'Name';
    SET @description = N'Subject primary key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Subject', 'COLUMN', N'GivenName';
    SET @description = N'Subject Surname ()';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Subject', 'COLUMN', N'FamilyName';
    SET @description = N'Username (upn claim)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Subject', 'COLUMN', N'UserPrincipalName';
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Subject', 'COLUMN', N'CreatedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE TABLE [dbo].[User] (
        [UserId] int NOT NULL IDENTITY,
        [UserResourceId] uniqueidentifier NOT NULL,
        [Id] nvarchar(max) NULL,
        [UserName] nvarchar(max) NULL,
        [NormalizedUserName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [NormalizedEmail] nvarchar(max) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Recipe] (
        [RecipeId] int NOT NULL IDENTITY,
        [RecipeResourceId] uniqueidentifier NOT NULL,
        [Name] nvarchar(50) NULL,
        [Description] nvarchar(500) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedSubjectId] uniqueidentifier NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedSubjectId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Recipe] PRIMARY KEY ([RecipeId]),
        CONSTRAINT [FK_Recipe_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
        CONSTRAINT [FK_Recipe_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId])
    );
    SET @description = N'Recipes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Recipe';
    SET @description = N'Primary Key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Recipe', 'COLUMN', N'RecipeId';
    SET @description = N'Public unique identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Recipe', 'COLUMN', N'RecipeResourceId';
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Recipe', 'COLUMN', N'CreatedDate';
    SET @description = N'Date and time entity was last modified';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Recipe', 'COLUMN', N'LastModifiedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Ingredient] (
        [IngredientId] int NOT NULL IDENTITY,
        [RecipeId] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedSubjectId] uniqueidentifier NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedSubjectId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Ingredient] PRIMARY KEY ([IngredientId]),
        CONSTRAINT [FK_Ingredient_Recipe_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]),
        CONSTRAINT [FK_Ingredient_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
        CONSTRAINT [FK_Ingredient_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId])
    );
    SET @description = N'Ingredients that belong to an Recipe';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient';
    SET @description = N'Primary Key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'IngredientId';
    SET @description = N'FK to Recipe that the Ingredient belongs to';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'RecipeId';
    SET @description = N'FK to Recipe that the Ingredient belongs to';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'Name';
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'CreatedDate';
    SET @description = N'Date and time entity was last modified';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Ingredient', 'COLUMN', N'LastModifiedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE TABLE [dbo].[Tags] (
        [TagId] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NULL,
        [RecipeId] int NULL,
        [CreatedDate] datetime2 NOT NULL,
        [CreatedSubjectId] uniqueidentifier NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [LastModifiedSubjectId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Tags] PRIMARY KEY ([TagId]),
        CONSTRAINT [FK_Tags_Recipe_RecipeId] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId]),
        CONSTRAINT [FK_Tags_Subject_CreatedSubjectId] FOREIGN KEY ([CreatedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId]),
        CONSTRAINT [FK_Tags_Subject_LastModifiedSubjectId] FOREIGN KEY ([LastModifiedSubjectId]) REFERENCES [dbo].[Subject] ([SubjectId])
    );
    SET @description = N'Date and time entity was created';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'CreatedDate';
    SET @description = N'Date and time entity was last modified';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'LastModifiedDate';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Ingredient_CreatedSubjectId] ON [dbo].[Ingredient] ([CreatedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Ingredient_LastModifiedSubjectId] ON [dbo].[Ingredient] ([LastModifiedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Ingredient_RecipeId] ON [dbo].[Ingredient] ([RecipeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Outbox_MessageId] ON [dbo].[Outbox] ([MessageId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_ScheduleDate_Status] ON [dbo].[Outbox] ([ScheduledDate], [Status]) INCLUDE ([EventType]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Status_LockId_ScheduleDate] ON [dbo].[Outbox] ([Status], [LockId], [ScheduledDate]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Recipe_CreatedSubjectId] ON [dbo].[Recipe] ([CreatedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Recipe_LastModifiedSubjectId] ON [dbo].[Recipe] ([LastModifiedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Recipe_RecipeResourceId] ON [dbo].[Recipe] ([RecipeResourceId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Tags_CreatedSubjectId] ON [dbo].[Tags] ([CreatedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Tags_LastModifiedSubjectId] ON [dbo].[Tags] ([LastModifiedSubjectId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    CREATE INDEX [IX_Tags_RecipeId] ON [dbo].[Tags] ([RecipeId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241012220507_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241012220507_Initial', N'8.0.8');
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
