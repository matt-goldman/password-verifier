using System;
using System.Text.Json.Serialization;

namespace password_verifier.Models
{
    public class Product
    {
        private readonly Random _random = new Random();
                
        public int id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }

        [JsonIgnore]
        public string Price => $"${price:N2}";

        public int Rating => _random.Next(1, 5);
        public int NumberOfReviews => _random.Next(1, 40);

        public string DiscountedPrice
        {
            get
            {
                var discount = (float) _random.Next(65, 95) / 100;
                var discountedPrice = price * discount;
                return $"${discountedPrice:N2}";
            }
        }
        private const int subLength = 256;

        public string TruncatedDescription => description.Length < subLength ? description : $"{description.Substring(0, subLength)}...";
    }
}