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
            get { return _quantity * ProductPrice; }
        }

        private double _productPrice;
        public double ProductPrice
        {
            get { return _productPrice; }
            set
            {
                if (_productPrice != value)
                {
                    _productPrice = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _productSmallPicture;
        public string ProductSmallPicture
        {
            get { return _productSmallPicture; }
            set
            {
                if (_productSmallPicture != value)
                {
                    _productSmallPicture = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
