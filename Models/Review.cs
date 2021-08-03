using System;

namespace password_verifier.Models
{
    public class Review
    {
        private readonly Random _random = new Random();
        
        public string ReviewerName { get; set; }
        public string ReviewerLocation { get; set; }
        public string ReviewerProfilePicUrl { get; set; }
        public string ReviewText { get; set; }
        public string ProductName { get; set; }
        public int Rating { get; set; }

        public DateTime PurchaseDate
        {
            get
            {
                var daysAgo = _random.Next(20, 120);
                return DateTime.Now.AddDays(-daysAgo);
            }
        }
    }
}