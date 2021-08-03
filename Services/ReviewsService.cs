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
            var profiles = await _client.GetFromJsonAsync<Root>(ApiUri);

            var dataUri = $"{Program.baseAddress}sample-data/reviews.json";
            
            var reviewData = await _client.GetFromJsonAsync<ReviewDummyData[]>(dataUri);

            List<Review> reviews = new List<Review>();

            var profileReviews = reviewData?.OrderBy(r => _random.Next()).Take(4);

            int i = 0;
            
            foreach (var profile in profiles.results)
            {
                reviews.Add(new Review
                {
                    Rating = reviewData[i].rating,
                    ProductName = reviewData[i].product,
                    ReviewerLocation = $"{profile.location.state}, {profile.location.country}",
                    ReviewerName = profile.name.first,
                    ReviewerProfilePicUrl = profile.picture.medium,
                    ReviewText = reviewData[i].review
                });
                i++;
            }

            return reviews;
        }
    }
}