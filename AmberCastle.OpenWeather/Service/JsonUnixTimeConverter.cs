using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmberCastle.OpenWeather.Service
{
    internal class JsonUnixTimeConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dt = (long)reader.GetDouble();
            var time = DateTimeOffset.FromUnixTimeSeconds(dt);
            return time;
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUnixTimeSeconds().ToString());
        }
    }
}