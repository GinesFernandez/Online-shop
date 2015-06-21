using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalApp.Model
{
    public class Checkouts
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "__createdAt")]
        public DateTime __createdAt { get; set; }

        [JsonProperty(PropertyName = "UserId")]
        public Guid UserId { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public short Status { get; set; }
    }
}
