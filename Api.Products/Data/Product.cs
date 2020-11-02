using System.Collections.Generic;
using Newtonsoft.Json;

namespace Products
{
    public class Product
    {
        [JsonProperty("id")]    
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}