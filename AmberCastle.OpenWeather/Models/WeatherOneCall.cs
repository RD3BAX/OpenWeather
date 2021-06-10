using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Models.Base;

namespace AmberCastle.OpenWeather.Models
{
    public class WeatherOneCall : LocalInfoBase
    {
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
