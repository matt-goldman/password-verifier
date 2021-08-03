using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using password_verifier.Models;
using password_verifier.Models.JsonHelpers;

namespace password_verifier.Services
{
    public class ReviewsService
    {
        private readonly HttpClient _client;

        private readonly Random _random = new Random();

        private const string ApiUri = "https://randomuser.me/api/?results=4";

        public ReviewsService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Review>> GetReviews()
        {
            var profiles = await _client.GetFromJsonAsync<Result[]>(ApiUri);
            
            var reviewData = await _client.GetFromJsonAsync<ReviewDummyData[]>("sample-data/reviews.json");

            List<Review> reviews = new List<Review>();

            var profileReviews = reviewData?.OrderBy(r => _random.Next()).Take(4);

            int i = 0;
            
            foreach (var profile in profiles)
            {
                reviews.Add(new Review()
                {
                    
                });
                i++;
            }

            return reviews;
        }
    }
}