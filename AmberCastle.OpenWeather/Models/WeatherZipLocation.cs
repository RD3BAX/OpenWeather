using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Models
{
    public class WeatherZipLocation : LocationBase
    {
        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }
}