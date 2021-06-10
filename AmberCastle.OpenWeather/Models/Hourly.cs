using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Models.Base;

namespace AmberCastle.OpenWeather.Models
{
    /// <summary>
    /// Почасовой прогноз погоды данных
    /// </summary>
    public class Hourly : WeatherBase
    {
        /// <summary>
        /// Вероятность осадков
        /// </summary>
        [JsonPropertyName("pop")]
        public float Pop { get; set; }
    }
}