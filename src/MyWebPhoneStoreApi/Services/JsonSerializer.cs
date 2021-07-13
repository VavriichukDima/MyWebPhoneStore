using System;
using System.Text.Json.Serialization;
using PhoneApi.Services.Abstractions;
using Newtonsoft.Json;

namespace PhoneApi.Services
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T data)
        {
           return JsonConvert.SerializeObject(data);
        }

        public T? Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}