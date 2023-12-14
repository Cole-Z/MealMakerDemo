using System;
using System.Net.Http;
using System.Threading.Tasks;
using MealApiDemo;

namespace MealApiDemo
{
    public class ApiHelper
    {
        private readonly HttpClient httpClient;

        public ApiHelper()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetDataFromApi(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }
        }
    }
}

