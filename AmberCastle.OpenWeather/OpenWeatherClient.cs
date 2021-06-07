using System.Net.Http;

namespace AmberCastle.OpenWeather
{
    class OpenWeatherClient
    {
        #region Поля

        private readonly HttpClient _client;

        #endregion // Поля

        #region Конструктор

        public OpenWeatherClient(HttpClient Client)
        {
            _client = Client;
        }

        #endregion // Конструктор
    }
}
