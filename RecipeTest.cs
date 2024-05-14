
//Testing the ingredient class
public class IngredientTest
{
    [Fact]
    public void CreateIngredient_ValidInput_SetsPropertiesCorrectly()
    {
        // Arrange
        string name = "Sugar";
        double quantity = 2.5;
        string measure = "cups";
        double calories = 50;

        // Act
        Ingredient ingredient = new Ingredient(name, quantity, measure, calories);

        // Assert
        Assert.Equal(name, ingredient.Name);
        Assert.Equal(quantity, ingredient.Quantity);
        Assert.Equal(measure, ingredient.Measure);
        Assert.Equal(calories, ingredient.Calories);
    }

    [Fact]
    public void CreateIngredient_EmptyName_ThrowsArgumentException()
    {
        // Arrange
        string name = "";
        double quantity = 2.5;
        string measure = "cups";
        double calories = 50;

        // Assert
        Assert.Throws<ArgumentException>(() => new Ingredient(name, quantity, measure, calories));
    }

    [Fact]
    public void CreateIngredient_InvalidQuantity_ThrowsArgumentException()
    {
        // Arrange
        string name = "Sugar";
        double quantity = -1.0;
        string measure = "cups";
        double calories = 50;

        // Assert
        Assert.Throws<ArgumentException>(() => new Ingredient(name, quantity, measure, calories));
    }

    [Fact]
    public void CreateIngredient_InvalidCalories_ThrowsArgumentException()
    {
        // Arrange
        string name = "Sugar";
        double quantity = 2.5;
        string measure = "cups";
        double calories = -10;

        // Assert
        Assert.Throws<ArgumentException>(() => new Ingredient(name, quantity, measure, calories));
    }



        public class NamedRecipeTest
    {
        [Fact]
        public void CreateNamedRecipe_ValidInput_SetsPropertiesCorrectly()
        {
            // Arrange
            string name = "Chocolate Chip Cookies";
            List<Ingredient> ingredients = new List<Ingredient>();
            List<string> steps = new List<string>();
            double totalCalories = 1000;

            // Act
            NamedRecipe recipe = new NamedRecipe(name, ingredients, steps, totalCalories);

            // Assert
            Assert.Equal(name, recipe.Name);
            Assert.Equal(ingredients, recipe.Ingredients);
            Assert.Equal(steps, recipe.Steps);
            Assert.Equal(totalCalories, recipe.TotalCalories);
        }
    }
}