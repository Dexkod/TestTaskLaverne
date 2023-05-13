using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestTaskWinForm.Entity;
using static System.Net.WebRequestMethods;

namespace TestTaskWinForm
{
    public static class RequestApi
    {
        /// <summary>
        /// Ключ подключение к API
        /// </summary>
        private const string _KEY = "6c7902a236e887ea370e6dde33a1909a";
        
        /// <summary>
        /// Получения геопозиции с API в случаи неудачи null
        /// </summary>
        /// <param name="city">Название города</param>
        public static async Task<City> GetCityGeocodingApiOrNull
            (string city)
        {
            string connectionString =
                $"http://api.openweathermap.org/geo/1.0/direct" +
                $"?q={city}&appid={_KEY}";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Получаем JSON ответ
                    using var responseJson = await httpClient
                        .GetAsync(connectionString);

                    // Приводим JSON ответ в вид класса City
                    var response = await responseJson.Content
                        .ReadFromJsonAsync<City[]>();

                    return response[0];
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Получаем погоду, в случае неудачи null
        /// </summary>
        /// <param name="city">Город с геопозицией</param>
        public static async Task<WeatherAll> GetWeatherInCityOrNull
            (City city)
        {
            string connectionString =
                $"https://api.openweathermap.org/data/2.5/weather?lat=" +
                $"{city.Lat}&lon={city.Lon}&appid={_KEY}";

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Получаем JSON ответ
                    using var responseJson = await httpClient
                        .GetAsync(connectionString);

                    // Преобразуем в класс WeatherAll
                    return await responseJson.Content
                        .ReadFromJsonAsync<WeatherAll>();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
