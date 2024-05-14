using System;
using System.Collections.Generic;

class Recipe
{

    public delegate void NotifyUser(double totalCalories);
    static void Main(string[] args)
    {
        List<Ingredient> ingredientList = new List<Ingredient>(); // Stores ingredient objects
        List<string> stepList = new List<string>();           // Stores step descriptions

        List<NamedRecipe> recipes = new List<NamedRecipe>(); // List to store named recipes

        while (true)
        {
            Console.WriteLine("Enter a name for this recipe (or 'q' to quit):");
            string recipeName = Console.ReadLine();

            if (recipeName.ToLower() == "q")
            {
                Console.WriteLine("Exiting recipe program.");
                break;
            }

            // Get ingredients and steps 
            ingredientList.Clear(); // Clear for new recipe
            stepList.Clear();

            while (true)
            {
                Console.WriteLine("Enter ingredient details (name quantity unit calories, or 'done'):");
                string ingredientInput = Console.ReadLine();

                if (ingredientInput.ToLower() == "done")
                {
                    break;
                }

                string[] parts = ingredientInput.Split(' ');
                if (parts.Length != 5)
                {
                    Console.WriteLine("Invalid ingredient format. Please use 'name quantity unit calories'.");
                    continue;
                }

                double quantity;
                if (!double.TryParse(parts[1], out quantity))
                {
                    Console.WriteLine("Invalid quantity. Please enter a number.");
                    continue;
                }

                double calories;
                if (!double.TryParse(parts[4], out calories))
                {
                    Console.WriteLine("Invalid calories. Please enter a number.");
                    continue;
                }

                Ingredient ingredient = new Ingredient(parts[0], quantity, parts[2], calories);
                ingredientList.Add(ingredient);
            }

            // Get step descriptions
            while (true)
            {
                Console.WriteLine("Enter a step description (or 'done'):");
                string stepInput = Console.ReadLine();

                if (stepInput.ToLower() == "done")
                {
                    break;
                }

                stepList.Add(stepInput);
            }

            // Calculate total calories
            double totalCalories = 0;
            foreach (Ingredient ingredient in ingredientList)
            {
                totalCalories += ingredient.Calories * ingredient.Quantity;
            }

            // Create and add NamedRecipe to list
            NamedRecipe recipe = new NamedRecipe(recipeName, ingredientList, stepList, totalCalories);
            recipes.Add(recipe);

            ingredientList.Clear(); // Clear for next recipe
            stepList.Clear();       // Clear for next recipe

            // Reset option (optional)
            Console.WriteLine("\nWould you like to enter a new recipe? (y/n)");
            string resetInput = Console.ReadLine().ToLower();

            if (resetInput != "y")
            {
                break; // Exit loop if user doesn't want a new recipe
            }
        }

        // Sort recipes alphabetically by name (optional)
        // recipes.Sort((r1, r2) => r1.Name.CompareTo(r2.Name));

        // Display all recipes or choose one
        if (recipes.Count > 0)
        {
            Console.WriteLine("\nYour Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
        }

        while (true)
{
Console.WriteLine("Select a recipe to display (or 'q' to quit:");
string recipeChoice = Console.ReadLine();
if (recipeChoice.ToLower()== "q")
{
break;
}
int recipeIndex;
if (int.TryParse(recipeChoice, out recipeIndex) && recipeIndex> 0 && recipeIndex <= recipes.Count)
{
// Display chosen recipe
NamedRecipe chosenRecipe = recipes[recipeIndex - 1];
Console.WriteLine($"{chosenRecipe.Name}:");
                    Console.WriteLine("Ingredients:");
                    foreach (Ingredient ingredient in chosenRecipe.Ingredients)
                    {
                        Console.WriteLine($"{ingredient.Quantity} {ingredient.Measure} of {ingredient.Name} ({ingredient.Calories} calories per unit)");

                        
                    }
}
}
    }

internal class NamedRecipe
{
    private string recipeName;
    private List<Ingredient> ingredientList;
    private List<string> stepList;
    private double totalCalories;

    public NamedRecipe(string recipeName, List<Ingredient> ingredientList, List<string> stepList, double totalCalories)
    {
        this.recipeName = recipeName;
        this.ingredientList = ingredientList;
        this.stepList = stepList;
        this.totalCalories = totalCalories;
    }

     public void CalculateCalories()
    {
        TotalCalories = 0;
        foreach (Ingredient ingredient in Ingredients)
        {
            TotalCalories += ingredient.Calories * ingredient.Quantity;
        }

        // Check for exceeding calories and notify user if delegate assigned
        if (TotalCalories > 300 && CalorieAlert != null)
        {
            CalorieAlert($"Warning: Total calories exceed 300 ({TotalCalories} calories)");
        }

        public object Name { get; internal set; }
        public IEnumerable<Ingredient> Ingredients { get; internal set; }
    }

internal class Ingredient
{
    private string v1;
    private double quantity;
    private string v2;
    private double calories;

    public Ingredient(string v1, double quantity, string v2, double calories)
    {
        this.v1 = v1;
        this.quantity = quantity;
        this.v2 = v2;
        this.calories = calories;
    }

    public int Calories { get; internal set; }
        public object Measure { get; internal set; }
        public object Quantity { get; internal set; }
        public object Name { get; internal set; }
    }


        }
}
    

