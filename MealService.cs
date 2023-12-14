using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MealApiDemo
{
    public class MealService
    {
        public static async Task<MealNameSearch> GetMealNameSearchAsync(string apiUrl)
        {
            ApiHelper apiHelper = new ApiHelper();
            string json = await apiHelper.GetDataFromApi(apiUrl);

            if (json != null)
            {
                return JsonConvert.DeserializeObject<MealNameSearch>(json);
            }
            else
            {
                return null;
            }
        }

        public static void DisplayMealInformation(MealNameSearch mealNameSearch)
        {
            foreach (Meal meal in mealNameSearch.meals)
            {
                //properties displayed for meal searched
                Console.WriteLine($"Meal Name: {meal.strMeal}");
                Console.WriteLine($"Region: {meal.strArea}");
                Console.WriteLine($"Meal Thumbnail: {meal.strMealThumb}");
                Console.WriteLine($"YouTube Instructions: {meal.strYoutube}\n");
                Console.WriteLine($"Meal Instructions: {meal.strInstructions} \n");

                // Create two lists to hold ingredients and measures for each
                List<string> ingredients = new List<string>();
                List<string> measures = new List<string>();
                const int TOTAL_ING = 20;

                for (int i = 1; i <= TOTAL_ING; i++)
                {
                    string ingredient = (string)meal.GetType().GetProperty($"strIngredient{i}").GetValue(meal, null);
                    string measure = (string)meal.GetType().GetProperty($"strMeasure{i}").GetValue(meal, null);

                    if (!string.IsNullOrEmpty(ingredient))
                    {
                        ingredients.Add(ingredient);

                        if (!string.IsNullOrEmpty(measure))
                        {
                            measures.Add(measure);
                        }
                        else
                        {
                            measures.Add("N/A");
                        }
                    }
                }
                // Loop thru and print ingredients
                Console.WriteLine("Ingredients:");
                for (int i = 0; i < ingredients.Count; i++)
                {
                    Console.WriteLine($"{ingredients[i]} - {measures[i]}");
                }
            }
        }
        // display meal category
        public static void DisplayCategory(MealNameSearch meal)
        {
            foreach (Meal m in meal.meals)
            {
                Console.WriteLine($"Meal Name: {m.strMeal}\n");
                Console.WriteLine($"Meal Thumbnail: {m.strMealThumb}");
                Console.WriteLine($"Meal ID: {m.idMeal}");
            }
        }

        public static void DisplayDailyMessage()
        {
            List<string> list = new List<string>();
            list.Add("What are we looking at today?");
            list.Add("Is it Taco Tuesday yet...");
            list.Add("Calories shmalories");
            list.Add("Breakfast of champions");
            list.Add("Hungry? Me too...");

            Random random = new Random();
            int randIndex = random.Next(list.Count);

            Console.WriteLine("\n");
            Console.WriteLine(list[randIndex].ToString());
        }
    }
}
