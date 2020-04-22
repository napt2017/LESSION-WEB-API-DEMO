using Newtonsoft.Json;

namespace LESSION_WEB_API_DEMO.Models
{
    public class SlideInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }
    }
}