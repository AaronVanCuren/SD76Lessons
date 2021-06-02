using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _13_RestaurantRater.Models
{
    public class Restaurant
    {
        // Database model - serializanble (POCO)
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string Owner { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating
        {
            get
            {
                double TotalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    TotalAverageRating += rating.AverageScore;
                }
                // ? = IF and return A:B where : = OR
                return (Ratings.Count > 0) ? TotalAverageRating / Ratings.Count : 0;
            }
        }

        public double AverageFoodScore
        {
            get
            {
                // Select LINQ Method - convert a list to another type of list
                IEnumerable<double> scores = Ratings.Select(rating => rating.FoodScore);
                double totalFoodScore = scores.Sum();
                return Ratings.Count > 0 ? totalFoodScore / Ratings.Count : 0;
            }
        }
    }
}