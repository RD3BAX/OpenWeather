using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Models
{
    public class LocationBase
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}