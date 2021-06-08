using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Models
{
    public class WeatherLocation : LocationBase
    {
        [JsonPropertyName("local_names")]
        public Dictionary<string, string> LocalNames { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}