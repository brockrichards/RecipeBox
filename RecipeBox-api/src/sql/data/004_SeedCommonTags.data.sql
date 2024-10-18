BEGIN TRANSACTION;
DECLARE @subject uniqueidentifier = (SELECT SubjectId FROM Subject WHERE Name = 'System');

-- Meal Types
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'MealType')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Breakfast');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Lunch');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Dinner');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Snack');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Dessert');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Brunch');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Appetizer');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'SideDish');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealType', 'Beverage');
END

-- Cuisine Types
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Cuisine')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'American');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Italian');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Mexican');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Chinese');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Indian');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'French');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Japanese');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Mediterranean');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Vegan');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Vegetarian');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Paleo');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Cuisine', 'Keto');
END

-- Dietary Restrictions
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'DietaryRestriction')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'GlutenFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'DairyFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'NutFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'LowCarb');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'LowSodium');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'LowFat');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'SugarFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'Whole30');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'Pescatarian');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'Halal');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'DietaryRestriction', 'Kosher');
END

-- Cooking Methods
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'CookingMethod')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Baking');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Grilling');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Frying');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Roasting');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Steaming');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'SlowCooking');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'PressureCooking');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'StirFrying');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Blending');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'SousVide');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Boiling');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'Sauteing');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'CookingMethod', 'AirFrying');
END

-- Time to Prepare
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'PreparationTime')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationTime', 'Under15Minutes');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationTime', 'Minutes15To30');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationTime', 'Minutes30To60');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationTime', 'Over1Hour');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationTime', 'QuickAndEasy');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationTime', 'SlowCooked');
END

-- Difficulty Level
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Difficulty')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Difficulty', 'Easy');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Difficulty', 'Intermediate');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Difficulty', 'Advanced');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Difficulty', 'BeginnerFriendly');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Difficulty', 'KidFriendly');
END

-- Seasonal/Occasion
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Seasonal')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Christmas');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Thanksgiving');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Halloween');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Summer');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Winter');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Fall');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Spring');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Easter');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'ValentinesDay');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'NewYearsEve');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'BBQ');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Potluck');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Party');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Seasonal', 'Picnic');
END

-- Course
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Course')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'MainCourse');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Salad');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Soup');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Bread');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Sandwich');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Sauce');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Dip');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Course', 'Drink');
END

-- Health & Wellness
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'HealthAndWellness')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'HighProtein');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'LowCalorie');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'HeartHealthy');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'DiabeticFriendly');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'WeightLoss');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'AntiInflammatory');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'HealthAndWellness', 'ImmuneBoosting');
END

-- Ingredient-Based
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Ingredient')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Chicken');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Beef');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Seafood');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Pork');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Vegetables');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Fruits');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Pasta');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Legumes');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Grains');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Eggs');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Tofu');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Cheese');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Chocolate');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Ingredient', 'Dairy');
END

-- Serving Size
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'ServingSize')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingSize', 'SingleServing');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingSize', 'FamilySize');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingSize', 'PartySize');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingSize', 'ForTwo');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingSize', 'ForKids');
END

-- Spiciness Level
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'SpicinessLevel')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpicinessLevel', 'Mild');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpicinessLevel', 'Medium');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpicinessLevel', 'Hot');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpicinessLevel', 'ExtraSpicy');
END

-- Occasions/Events
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Occasion')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Occasion', 'DateNight');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Occasion', 'FamilyGathering');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Occasion', 'KidsBirthday');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Occasion', 'GameDay');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Occasion', 'BrunchParty');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Occasion', 'BabyShower');
END

-- Preparation Type
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'PreparationType')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'OnePot');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'MakeAhead');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'MealPrep');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'NoBake');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'NoCook');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'FreezerFriendly');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'FiveIngredientsOrLess');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'PreparationType', 'LeftoversFriendly');
END

-- Allergens
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Allergens')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Allergens', 'SoyFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Allergens', 'EggFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Allergens', 'LactoseFree');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Allergens', 'ShellfishFree');
END

-- Serving Temperature
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'ServingTemperature')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingTemperature', 'Cold');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingTemperature', 'Warm');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingTemperature', 'RoomTemperature');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingTemperature', 'Chilled');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingTemperature', 'Frozen');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'ServingTemperature', 'Hot');
END

-- Budget
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Budget')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Budget', 'BudgetFriendly');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Budget', 'Gourmet');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Budget', 'Fancy');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Budget', 'Under10Dollars');
END

-- Special Equipment
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'SpecialEquipment')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'Blender');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'AirFryer');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'InstantPot');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'FoodProcessor');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'Mixer');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'Grill');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'CastIron');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'Wok');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'SpecialEquipment', 'StandMixer');
END

-- Region-Specific Cuisine
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'Regional')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'TexMex');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'Southern');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'NewEngland');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'Caribbean');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'MiddleEastern');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'SoutheastAsian');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'Nordic');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'EastAfrican');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'Regional', 'WestAfrican');
END

-- Meal Planning
IF NOT EXISTS (SELECT 1 FROM Tag WHERE Category = 'MealPlanning')
BEGIN
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealPlanning', 'WeeknightDinners');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealPlanning', 'WeekendSpecial');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealPlanning', 'LeftoverMakeovers');
	INSERT INTO Tag (TagResourceId, CreatedDate, CreatedSubjectId, LastModifiedDate, LastModifiedSubjectId, Category, Name) VALUES (NEWID(), GETUTCDATE(), @subject, GETUTCDATE(), @subject, 'MealPlanning', 'BatchCooking');
END

COMMIT TRANSACTION;
