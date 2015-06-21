using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalApp.Model
{
    public class Products
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "__createdAt")]
        public DateTime __createdAt { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "SmallPicture")]
        public string SmallPicture { get; set; }

        [JsonProperty(PropertyName = "Picture")]
        public string Picture { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public double Price { get; set; }
    }
}
