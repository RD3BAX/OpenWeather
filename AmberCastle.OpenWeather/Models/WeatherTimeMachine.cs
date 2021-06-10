using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Models.Base;

namespace AmberCastle.OpenWeather.Models
{
    
    public class WeatherTimeMachine : LocalInfoBase
    {
        /// <summary>
        /// Текущие метеорологические данные
        /// </summary>
        [JsonPropertyName("current")]
        public Current Current { get; set; }

        /// <summary>
        ///  Почасовой прогноз погоды
        /// </summary>
        [JsonPropertyName("hourly")]
        public Hourly[] Hourlys { get; set; }
    }
}
