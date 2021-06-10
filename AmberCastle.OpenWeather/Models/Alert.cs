using System;
using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Service;

namespace AmberCastle.OpenWeather.Models
{
    /// <summary>
    /// Национальные данные о погоде от основных национальных систем предупреждения о погоде
    /// </summary>
    public class Alert
    {
        /// <summary>
        ///  Название источника оповещения
        /// </summary>
        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        /// Имя события
        /// </summary>
        [JsonPropertyName("event")]
        public string Event { get; set; }

        /// <summary>
        /// Дата и время начала
        /// </summary>
        [JsonPropertyName("start")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset Start { get; set; }

        /// <summary>
        /// Дата и время окончания
        /// </summary>
        [JsonPropertyName("end")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset End { get; set; }

        /// <summary>
        /// Описание оповещения
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}