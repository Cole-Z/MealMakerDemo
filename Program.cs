using Newtonsoft.Json;
using System.Text.Json.Serialization;

// data from https://www.themealdb.com/api.php

// All credit and data is from the "TheMealDb" www.themealdb.com

namespace MealApiDemo
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            List<string> mealCategories = new List<string>();
            mealCategories.Add("Beef");
            mealCategories.Add("Chicken");
            mealCategories.Add("Dessert");
            mealCategories.Add("Lamb");
            mealCategories.Add("Miscellaneous");
            mealCategories.Add("Pasta");
            mealCategories.Add("Pork");
            mealCategories.Add("Seafood");
            mealCategories.Add("Side");
            mealCategories.Add("Starter");
            mealCategories.Add("Vegan");
            mealCategories.Add("Vegetarian");
            mealCategories.Add("Breakfast");
            mealCategories.Add("Goat");

            MealService.DisplayDailyMessage();
            Console.WriteLine("Categories in case you have forgot!\n");

            const int CATEGORY = 1;
            const int RANDOM = 2;
            const int NAME = 3;

            while (true)
            {
                foreach (string category in mealCategories)
                {
                    Console.WriteLine(category);
                }
                Console.WriteLine("\n");

                DisplayMenu();
                string userInput = Console.ReadLine()?.ToLower();

                if (userInput == "category" || userInput == CATEGORY.ToString())
                {
                    Console.WriteLine("Enter the category name:");
                    string userCategory = Console.ReadLine();

                    string lookUpByCategory = $"https://www.themealdb.com/api/json/v1/1/filter.php?c={userCategory}";

                    MealNameSearch mealNameSearch = await MealService.GetMealNameSearchAsync(lookUpByCategory);
                    MealService.DisplayCategory(mealNameSearch);
                }

                else if (userInput == "random" || userInput == RANDOM.ToString())
                {
                    const string randomMealUrl = "https://www.themealdb.com/api/json/v1/1/random.php";
                    MealNameSearch randomMealSearch = await MealService.GetMealNameSearchAsync(randomMealUrl);
                    DisplaySearchResult(randomMealSearch);
                }

                else if (userInput == "name" || userInput == NAME.ToString())
                {
                    Console.WriteLine("Enter the name: ");
                    string name = Console.ReadLine()?.ToLower();
                    string searchName = $"https://www.themealdb.com/api/json/v1/1/search.php?s={name}";
                    MealNameSearch nameMealSearch = await MealService.GetMealNameSearchAsync(searchName);
                    DisplaySearchResult(nameMealSearch);
                }

                else
                {
                    throw new Exception("Invalid input. Please enter a valid option.");
                }

                Console.WriteLine("Do you want to search again? (yes/no)");
                string continueSearch = Console.ReadLine()?.ToLower();
                if (continueSearch != "yes" && continueSearch != "y")
                {
                    break;
                }
            }
        }
        // Pass in meal object to be displayed from DisplayMealInformation (in MealService.cs)
        public static void DisplaySearchResult(MealNameSearch mealNameSearch)
        {
            if (mealNameSearch?.meals != null && mealNameSearch.meals.Any())
            {
                MealService.DisplayMealInformation(mealNameSearch);
            }
            else
            {
                Console.WriteLine("No meals found or meals array is null.");
            }
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Search for a meal!");
            Console.WriteLine("1.........Category");
            Console.WriteLine("2.........Random");
            Console.WriteLine("3.........Name");
            Console.Write("Choice: ");
        }
    }
}
