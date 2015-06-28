using Newtonsoft.Json;
using System;
using UniversalApp.ViewModels.Base;

namespace UniversalApp.Model
{
    public class Users : ModelBase
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "__createdAt")]
        public DateTime __createdAt { get; set; }

        private string _email;
        [JsonProperty(PropertyName = "Email")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _password;
        [JsonProperty(PropertyName = "Password")]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _title;
        [JsonProperty(PropertyName = "Title")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _firstName;
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _lastName;
        [JsonProperty(PropertyName = "LastName")]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _address;
        [JsonProperty(PropertyName = "Address")]
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _zipCode;
        [JsonProperty(PropertyName = "ZipCode")]
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _city;
        [JsonProperty(PropertyName = "City")]
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    RaisePropertyChanged();
                }
            }
        }

        [JsonProperty(PropertyName = "Country")]
        public short Country { get; set; }

        public bool AllMandatoryFieldsFilled
        {
            get
            {
                return Id != null
                    && !String.IsNullOrWhiteSpace(_email)
                    && !String.IsNullOrWhiteSpace(_password)
                    && !String.IsNullOrWhiteSpace(_title)
                    && !String.IsNullOrWhiteSpace(_firstName)
                    && !String.IsNullOrWhiteSpace(_lastName)
                    && !String.IsNullOrWhiteSpace(_address)
                    && !String.IsNullOrWhiteSpace(_zipCode)
                    && !String.IsNullOrWhiteSpace(_city);
            }
        }
    }
}
