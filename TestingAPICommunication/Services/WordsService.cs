using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestingAPICommunication.Models;

namespace TestingAPICommunication.Services
{
    public class WordsService : IWordsService
    {
        public async Task<Definition> GetDefinitionAsync(string word)
        {
            Definition result = new Definition();    
            HttpClient client = new HttpClient();

            string uriString = $"https://wordsapiv1.p.rapidapi.com/words/{word}/definitions";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(uriString),
                Headers = {
                    { "x-rapidapi-key", "704ca8d251mshe6218a98dd2f799p114d43jsn0dae0dca77d3" },
                    { "x-rapidapi-host", "wordsapiv1.p.rapidapi.com" },
                },
            };
            
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonPayload = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    result = await Task.Run(() =>
                           JsonConvert.DeserializeObject<Definition>(jsonPayload)
                        ).ConfigureAwait(false);
                }

                return result;
            }
        }
    }
}
