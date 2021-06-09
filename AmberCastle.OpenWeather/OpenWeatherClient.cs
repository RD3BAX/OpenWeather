using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using AmberCastle.OpenWeather.Models;
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

        public async Task<WeatherLocation[]> GetDirectGeocoding(string Name, int Limit = 0, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherLocation[]>(
                    $"/geo/1.0/direct?q={Name}" +
                    (Limit == 0 ? "" : $"&limit={Limit}") +
                    $"&appid={_ApiKey}", 
                    cancellationToken: Cancel)
                .ConfigureAwait(false);
        } 
        
        public async Task<WeatherLocation[]> GetReverseGeocoding(double Latitude, double Longitude, int Limit = 0, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherLocation[]>(
                    $"/geo/1.0/reverse?lat={Latitude}&lon={Longitude}" +
                    (Limit == 0 ? "" : $"&limit={Limit}") +
                    $"&appid={_ApiKey}", 
                    cancellationToken: Cancel)
                .ConfigureAwait(false);
        }

        public async Task<WeatherZipLocation> GetCoordinatesByZip(string ZipCode, CancellationToken Cancel = default)
        {
            return await _client
                .GetFromJsonAsync<WeatherZipLocation>(
                    $"/geo/1.0/zip?zip={ZipCode}" +
                    $"&appid={_ApiKey}", 
                    cancellationToken: Cancel)
                .ConfigureAwait(false);
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
}
