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
    // API controller just deals with data
    // MVC controller (red badge) also returns views (HTML/CSS/JS) 
    public class RestaurantController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();

        // C
        [HttpPost]
        public async Task<IHttpActionResult> PostRestaurant(Restaurant model)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model);
                await _context.SaveChangesAsync();

                return Ok(); // Code: 200
            }
            return BadRequest(ModelState); // Code: 400
        }

        // R
        [HttpGet]
        public async Task<IHttpActionResult> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            List<RestaurantListItem> restaurantList = restaurants.Select(rating => new RestaurantListItem()
            {
                Id = rating.Id,
                Name = rating.Name,
                Address = rating.Address,
                Rating = rating.Rating,
            }).ToList();
            return Ok(restaurantList);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);            
            if (restaurant == default)
            {
                return NotFound(); // Code: 404
            }
            RestaurantDetails restaurantDetail = new RestaurantDetails()
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Address = restaurant.Address,
                Owner = restaurant.Owner,
                Rating = restaurant.Rating,
                AverageFoodScore = restaurant.AverageFoodScore,
            };
            return Ok(restaurantDetail);
        }
        // Race condition - a situation where two async tasks happening, not sure  whil wil finish first, how the code runs depnds on whcih finishes first

        // U
        [HttpPut]
        public async Task<IHttpActionResult> UpdateRestaurant([FromUri] int id, [FromBody] Restaurant model)
        {
            /*if(ModelState.IsValid)
            {
                Restaurant restaurant = await _context.Restaurants.FindAsync(id);
                if (restaurant == null)
                {
                    return NotFound();
                }
            }
            return BadRequest(ModelState);*/
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            restaurant.Name = model.Name;
            restaurant.Address = model.Address;
            // restaurant.Rating = model.Rating;
            restaurant.Owner = model.Owner;
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok();
            }
            return NotFound();
        }

        // D
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteRestaurantById(int id)
        {
            Restaurant restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == default)
            {
                return NotFound(); // Code: 404
            }
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}