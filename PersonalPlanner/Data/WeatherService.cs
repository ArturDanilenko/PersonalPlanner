using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlanner
{
    public class WeatherService : IWeatherService
    {
        const string Url = "api.openweathermap.org/data/2.5/weather?q=Vancouver&appid={KEY}";
        private string authorizationKey;
        public async Task<IEnumerable<Weather>> GetAll()
        {
            HttpClient client = await GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Weather>>(result);
        }

        public async Task<Weather> Add(string name, string temperature, string weather)
        {
            Weather weather = new Weather()
            {
                Name = name,
                ID = string.Empty,
                Tempreature = temperature,
                Date = DateTime.Now.Date,
                weather = weather;
            };

            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(weather),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Weather>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task Update(Weather weather)
        {
            HttpClient client = await GetClient();
            await client.PutAsync(Url + weather.ISBN,
                new StringContent(
                    JsonConvert.SerializeObject(weather),
                    Encoding.UTF8, "application/json"));
        }

        public async Task Delete(string id)
        {
            HttpClient client = await GetClient();
            await client.DeleteAsync(Url + id);
        }
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url + "login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}