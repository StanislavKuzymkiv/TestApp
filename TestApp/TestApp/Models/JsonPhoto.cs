using Newtonsoft.Json;
namespace TestApp.Models
{
    class JsonPhoto
    {
        [JsonProperty("photoName")]
        public string Name { get; set; }
        [JsonProperty("photoData")]
        public byte[] Data { get; set; }
        [JsonProperty("photoComment")]
        public string Comment { get; set; }
    
    }
}
