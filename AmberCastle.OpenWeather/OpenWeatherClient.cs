using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AmberCastle.OpenWeather
{
    public class OpenWeatherClient
    {
        #region Поля

        private readonly HttpClient _client;
        private readonly IConfiguration _config;
        private readonly string _ApiKey;

        #endregion // Поля

        #region Свойства

        #endregion // Свойства

        #region Методы

        #region Geo 1.0

        public async Task<WeatherLocation[]> GetDirectGeocoding(string Name, int Limit = 0)
        {
            return await _client.GetFromJsonAsync<WeatherLocation[]>(
                $"/geo/1.0/direct?q={Name}" +
                (Limit == 0 ? "" : $"&limit={Limit}") +
                $"&appid={_ApiKey}");
        } 
        
        public async Task<WeatherLocation[]> GetReverseGeocoding(double Lat, double Lon,int Limit = 0)
        {
            return await _client.GetFromJsonAsync<WeatherLocation[]>(
                $"/geo/1.0/reverse?lat={Lat}&lon={Lon}" +
                (Limit == 0 ? "" : $"&limit={Limit}") +
                $"&appid={_ApiKey}");
        }

        public async Task<WeatherZipLocation> GetCoordinatesByZip(string ZipCode)
        {
            return await _client.GetFromJsonAsync<WeatherZipLocation>(
                $"/geo/1.0/zip?zip={ZipCode}" +
                $"&appid={_ApiKey}");
        }

        #endregion // Geo 1.0

        #endregion // Методы

        #region Конструктор

        public OpenWeatherClient(HttpClient Client, IConfiguration config)
        {
            _client = Client;
            _config = config;
            _ApiKey = config["OpenWeather:ApiKey"];
        }

        #endregion // Конструктор
    }


    public class WeatherLocation
    {
        public string name { get; set; }
        public Dictionary<string, string> local_names { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }


    public class WeatherZipLocation
    {
        public string zip { get; set; }
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string country { get; set; }
    }

    
}
