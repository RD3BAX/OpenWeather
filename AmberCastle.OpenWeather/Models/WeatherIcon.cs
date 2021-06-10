using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Models
{
    /// <summary>
    /// Иконки погоды
    /// </summary>
    public class WeatherIcon
    {
        /// <summary>
        /// Идентификатор погоды
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Группа параметров погоды (Дождь, Снег, Экстремальные и т.д.)
        /// </summary>
        [JsonPropertyName("main")]
        public string Main { get; set; }

        /// <summary>
        /// Погодные условия внутри группы
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор значка
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}