using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Models
{
    public class WeatherOneCall
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

        /// <summary>
        /// Текущие метеорологические данные
        /// </summary>
        [JsonPropertyName("current")]
        public Current Current { get; set; }

        /// <summary>
        /// Минутный прогноз погоды
        /// </summary>
        [JsonPropertyName("minutely")]
        public Minutely[] Minutelys { get; set; }

        /// <summary>
        ///  Почасовой прогноз погоды
        /// </summary>
        [JsonPropertyName("hourly")]
        public Hourly[] Hourlys { get; set; }

        /// <summary>
        /// Прогноз по дням
        /// </summary>
        [JsonPropertyName("daily")]
        public Daily[] Dailys { get; set; }

        /// <summary>
        /// Национальные данные о погоде от основных национальных систем предупреждения о погоде
        /// </summary>
        [JsonPropertyName("alerts")]
        public Alert[] Alerts { get; set; }
    }
}
