using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TruthOrDrink.Abstractions;
using TruthOrDrink.MVVM.Models;

namespace TruthOrDrink.Logic
{
    public class MemeService : IMemeService
    {
        private readonly HttpClient _httpClient;

       public MemeService()
        {
            _httpClient = new HttpClient();
        }
        
        public async Task<Meme> GetRandomMemeAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://api.imgflip.com/get_memes");
                Console.WriteLine("API Response: " + response); // Debug statement

                var memeResponse = JsonSerializer.Deserialize<MemeResponse>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine("Deserialized Response: " + memeResponse); // Debug statement

                if (memeResponse?.Success == true && memeResponse.Data?.Memes != null && memeResponse.Data.Memes.Count > 0)
                {
                    var random = new Random();
                    int index = random.Next(memeResponse.Data.Memes.Count);
                    var meme = memeResponse.Data.Memes[index];
                    Console.WriteLine("Selected Meme: " + meme.Name + " - " + meme.Url); // Debug statement
                    return meme;
                }

                throw new Exception("No memes found in the response.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // Debug statement
                throw new Exception("Error fetching meme.", ex);
            }
        }
    }
}