using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalApp.Model
{
    public class CheckoutsLines
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "__createdAt")]
        public DateTime __createdAt { get; set; }

        [JsonProperty(PropertyName = "CheckoutId")]
        public Guid CheckoutId { get; set; }

        [JsonProperty(PropertyName = "ProductId")]
        public Guid ProductId { get; set; }


        public Products Product { get; set; }
    }
}
