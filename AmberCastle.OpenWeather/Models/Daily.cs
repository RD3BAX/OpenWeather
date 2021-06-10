using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Service;

namespace AmberCastle.OpenWeather.Models
{
    /// <summary>
    /// Ежедневные прогнозные данные погоды
    /// </summary>
    public class Daily
    {
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset Time { get; set; }

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

        /// <summary>
        /// Восход луны
        /// </summary>
        [JsonPropertyName("moonrise")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset MoonRise { get; set; }

        /// <summary>
        /// Заход луны
        /// </summary>
        [JsonPropertyName("moonset")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset MoonSet { get; set; }

        /// <summary>
        /// Фазы луны
        /// </summary>
        [JsonPropertyName("moon_phase")]
        public float MoonPhase { get; set; }

        /// <summary>
        /// Температура в течении дня
        /// </summary>
        [JsonPropertyName("temp")]
        public Dictionary<string, double> TempDaily { get; set; }

        /// <summary>
        /// Температура комфорта.
        /// Это объясняет человеческое восприятие погоды.
        /// </summary>
        [JsonPropertyName("feels_like")]
        public Dictionary<string, double> FeelsLikeDaily { get; set; }

        /// <summary>
        /// Атмосферное давление на уровне моря, hPa
        /// </summary>
        [JsonPropertyName("pressure")]
        public int Pressure { get; set; }

        /// <summary>
        /// Влажность, %
        /// </summary>
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        /// <summary>
        /// Точка росы. Температура воздуха (в зависимости от давления и влажности), ниже которой начинают конденсироваться капли воды и может образовываться роса.
        /// </summary>
        [JsonPropertyName("dew_point")]
        public float DewPoint { get; set; }

        /// <summary>
        /// Скорость ветра
        /// </summary>
        [JsonPropertyName("wind_speed")]
        public float WindSpeed { get; set; }

        /// <summary>
        /// Порыв ветра.
        /// </summary>
        [JsonPropertyName("wind_gust")]
        public float WindGust { get; set; }

        /// <summary>
        /// Направление ветра, градусы (метеорологические)
        /// </summary>
        [JsonPropertyName("wind_deg")]
        public int WindDeg { get; set; }

        /// <summary>
        /// Облачность, %
        /// </summary>
        [JsonPropertyName("clouds")]
        public int Clouds { get; set; }

        /// <summary>
        /// Текущий УФ-индекс
        /// </summary>
        [JsonPropertyName("uvi")]
        public float Uvi { get; set; }

        /// <summary>
        /// Вероятность осадков
        /// </summary>
        [JsonPropertyName("pop")]
        public float Pop { get; set; }

        /// <summary>
        /// Объем осадков
        /// </summary>
        [JsonPropertyName("rain")]
        public double Rain { get; set; }

        /// <summary>
        /// Объем снега
        /// </summary>
        [JsonPropertyName("snow")]
        public double Snow { get; set; }

        /// <summary>
        /// Иконки погоды
        /// </summary>
        [JsonPropertyName("weather")]
        public WeatherIcon[] WeatherIcons { get; set; }
    }
}