using _13_RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _13_RestaurantRater.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // C
        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Code: 400
            }
            _context.Ratings.Add(model);
            if( await _context.SaveChangesAsync() == 1)
            {
                return Ok(); // Code: 200
            }
            return InternalServerError(); // Code:500
        }

        // R
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRatings()
        {
            List<RatingListItem> ratings = await _context.Ratings
                .Select(rating => new RatingListItem()
                {
                Id = rating.Id,
                AverageScore = rating.AverageScore,
                RestaurantName = rating.Restaurant.Name,
            }).ToListAsync();
            return Ok(ratings);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllRatingsForRestaurant(int id)
        {
            // LINQ
            List<RatingListItem> ratings = await _context.Ratings
                .Where(rating => rating.RestaurantId == id)
                .Select(rating => new RatingListItem()
                {
                Id = rating.Id,
                AverageScore = rating.AverageScore,
                RestaurantName = rating.Restaurant.Name,
            }).ToListAsync();
            return Ok(ratings);
        }
    }
}
