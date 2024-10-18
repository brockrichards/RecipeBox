-- Idempotent insert for seeding common ingredients into the Ingredient table
DECLARE @subject uniqueidentifier = (SELECT SubjectId FROM Subject WHERE Name = 'System');

BEGIN TRANSACTION;

-- Insert 'Tomato'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Tomato')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Tomato', 'A red, juicy fruit commonly used as a vegetable in cooking. Rich in vitamins and antioxidants.');
END

-- Insert 'Onion'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Onion')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Onion', 'A versatile vegetable with a pungent flavor used in a wide variety of dishes, known for its layers.');
END

-- Insert 'Garlic'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Garlic')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Garlic', 'A strongly flavored bulbous plant often used for seasoning, with antioxidant properties.');
END

-- Insert 'Carrot'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Carrot')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Carrot', 'A crunchy, orange vegetable rich in beta-carotene and good for eyesight.');
END

-- Insert 'Basil'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Basil')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Basil', 'A fragrant herb used in cooking, especially in Italian cuisine. Known for its sweet, savory flavor.');
END

-- Insert 'Salt'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Salt')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Salt', 'A mineral essential for life, commonly used to enhance the flavor of foods.');
END

-- Insert 'Pepper'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Pepper')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Pepper', 'A commonly used spice with a sharp, pungent flavor. Comes in black, white, and green varieties.');
END

-- Insert 'Olive Oil'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Olive Oil')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Olive Oil', 'A healthy oil extracted from olives, widely used in cooking and dressings. Rich in healthy fats.');
END

-- Insert 'Lemon'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Lemon')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Lemon', 'A sour, yellow citrus fruit used for its juice and zest in various dishes and beverages.');
END

-- Insert 'Sugar'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Sugar')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Sugar', 'A sweet substance commonly used in baking and to sweeten beverages and foods.');
END

-- Insert 'Butter'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Butter')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Butter', 'A dairy product made from churning cream, used in cooking and baking for rich flavor.');
END

-- Insert 'Flour'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Flour')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Flour', 'A powdery substance made by grinding grains, typically wheat, used for baking and thickening.');
END

-- Insert 'Egg'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Egg')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Egg', 'A versatile ingredient from poultry, rich in protein, used in a variety of dishes from baking to cooking.');
END

-- Insert 'Milk'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Milk')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Milk', 'A nutrient-rich liquid produced by mammals, widely used in cooking and baking.');
END

-- Insert 'Chicken'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Chicken')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Chicken', 'A common poultry ingredient, high in protein and used in many types of cuisine.');
END

-- Insert 'Beef'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Beef')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Beef', 'Meat from cattle, used in a variety of dishes. It is rich in protein and iron.');
END

-- Insert 'Potato'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Potato')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Potato', 'A starchy tuber used in a variety of cuisines, often boiled, fried, or mashed.');
END

-- Insert 'Parsley'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Parsley')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Parsley', 'A fresh, green herb used as a garnish and flavor enhancer in many dishes.');
END

-- Insert 'Cucumber'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Cucumber')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cucumber', 'A crisp, watery vegetable often used in salads and pickling.');
END

-- Insert 'Cheese'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Cheese')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cheese', 'A dairy product made from curdled milk, available in various flavors and textures.');
END

-- Insert 'Rice'
IF NOT EXISTS (SELECT 1 FROM Ingredient WHERE Name = 'Rice')
BEGIN
    INSERT INTO Ingredient (IngredientResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Name, Description)
    VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Rice', 'A staple grain in many cuisines, commonly boiled or steamed and served as a side or main dish.');
END

COMMIT TRANSACTION;
