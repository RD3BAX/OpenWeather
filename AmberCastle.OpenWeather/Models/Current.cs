using System;
using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Service;

namespace AmberCastle.OpenWeather.Models
{
    /// <summary>
    /// Текущие метеорологические данные
    /// </summary>
    public class Current : WeatherBase
    {
        /// <summary>
        /// Время восхода солнца
        /// </summary>
        [JsonPropertyName("sunrise")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset Sunrise { get; set; }

        /// <summary>
        /// Время заката
        /// </summary>
        [JsonPropertyName("sunset")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset Sunset { get; set; }
    }
}