-- Idempotent insert for seeding common units of measurement into the Unit table
DECLARE @subject uniqueidentifier = (SELECT SubjectId FROM Subject WHERE Name = 'System');

BEGIN TRANSACTION;

-- Insert 'Teaspoon'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Teaspoon')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Teaspoon');
END

-- Insert 'Tablespoon'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Tablespoon')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Tablespoon');
END

-- Insert 'Cup'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Cup')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cup');
END

-- Insert 'Milliliter'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Milliliter')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Milliliter');
END

-- Insert 'Liter'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Liter')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Liter');
END

-- Insert 'Gram'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Gram')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Gram');
END

-- Insert 'Kilogram'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Kilogram')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Kilogram');
END

-- Insert 'Ounce'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Ounce')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ounce');
END

-- Insert 'Pound'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Pound')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Pound');
END

-- Insert 'Pinch'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Pinch')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Pinch');
END

-- Insert 'Dash'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Dash')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Dash');
END

-- Insert 'Quart'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Quart')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Quart');
END

-- Insert 'Pint'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Pint')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Pint');
END

-- Insert 'Gallon'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Gallon')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Gallon');
END

-- Insert 'Fluid Ounce'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Fluid Ounce')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Fluid Ounce');
END

-- Insert 'Centiliter'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Centiliter')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Centiliter');
END

-- Insert 'Deciliter'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Deciliter')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Deciliter');
END

-- Insert 'Milligram'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Milligram')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Milligram');
END

-- Insert 'Stone'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Stone')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Stone');
END

-- Insert 'Ton'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Ton')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ton');
END

-- Insert 'Stick'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Stick')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Stick');
END

-- Insert 'Clove'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Clove')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Clove');
END

-- Insert 'Bunch'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Bunch')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Bunch');
END

-- Insert 'Slice'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Slice')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Slice');
END

-- Insert 'Piece'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Piece')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Piece');
END

-- Insert 'Drop'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Drop')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Drop');
END

-- Insert 'Bag'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Bag')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Bag');
END

-- Insert 'Can'
IF NOT EXISTS (SELECT 1 FROM Unit WHERE Name = 'Can')
BEGIN
    INSERT INTO Unit (UnitResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Can');
END

COMMIT TRANSACTION;
