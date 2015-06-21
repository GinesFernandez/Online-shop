using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalApp.Model
{
    public class ApplicationAttributes
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "__createdAt")]
        public DateTime __createdAt { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "Value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "DataType")]
        public string DataType { get; set; }
    }
}
