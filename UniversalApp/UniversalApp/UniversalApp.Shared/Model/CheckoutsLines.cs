using Newtonsoft.Json;
using System;
using UniversalApp.ViewModels.Base;

namespace UniversalApp.Model
{
    public class CheckoutsLines : ModelBase
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

        private int _quantity;
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("TotalPrice");
                }
            }
        }

        public double TotalPrice
        {
            get { return _quantity * Product.Price; }
        }
    }
}
