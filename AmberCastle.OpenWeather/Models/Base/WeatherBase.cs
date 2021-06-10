using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Service;

namespace AmberCastle.OpenWeather.Models.Base
{
    public abstract class WeatherBase
    {
        /// <summary>
        /// Текущее время
        /// </summary>
        [JsonPropertyName("dt")]
        [JsonConverter(typeof(JsonUnixTimeConverter))]
        public DateTimeOffset Time { get; set; }
        
        /// <summary>
        /// Температура
        /// </summary>
        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        /// <summary>
        /// Комфортная температура. Этот температурный параметр объясняет восприятие человеком погоды.
        /// </summary>
        [JsonPropertyName("feels_like")]
        public float FeelsLike { get; set; }

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
        /// Средняя видимость, метры
        /// </summary>
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

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
        /// Объем осадков за последний час
        /// </summary>
        [JsonPropertyName("rain")]
        public Dictionary<string, double> Rain { get; set; }

        /// <summary>
        /// Объем снега за последний час
        /// </summary>
        [JsonPropertyName("snow")]
        public Dictionary<string, double> Snow { get; set; }

        /// <summary>
        /// Иконки погоды
        /// </summary>
        [JsonPropertyName("weather")]
        public WeatherIcon[] WeatherIcons { get; set; }
    }
}