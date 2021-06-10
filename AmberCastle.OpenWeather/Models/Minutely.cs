using System;
using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Service;

namespace AmberCastle.OpenWeather.Models
{
    /// <summary>
    /// Минутный прогноз погоды
    /// </summary>
    public class Minutely
    {
        /// <summary>
        /// Время прогнозируемых данных
        /// </summary>
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// Объем осадков, мм
        /// </summary>
        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }
    }
}