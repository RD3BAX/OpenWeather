using System.Text.Json.Serialization;
using AmberCastle.OpenWeather.Models.Base;

namespace AmberCastle.OpenWeather.Models
{
    public class WeatherZipLocation : LocationBase
    {
        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }
}