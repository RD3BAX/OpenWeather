using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Models.Base
{
    public abstract class LocalInfoBase
    {
        /// <summary>
        ///  Географические координаты местоположения (широта)
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Географические координаты местоположения (долгота)
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Название тайм-зоны для запрашиваемого местоположения
        /// </summary>
        [JsonPropertyName("timezone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Сдвиг в секундах от UTC
        /// </summary>
        [JsonPropertyName("timezone_offset")]
        public int TimeZoneOffset { get; set; }
    }
}