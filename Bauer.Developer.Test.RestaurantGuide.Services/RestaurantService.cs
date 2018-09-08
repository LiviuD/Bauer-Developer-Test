using Bauer.Developer.Test.RestaurantGuide.DataAccess.Common;
using Bauer.Developer.Test.RestaurantGuide.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bauer.Developer.Test.RestaurantGuide.Services
{
    public class RestaurantService : BaseService
    {
        public RestaurantService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Gets the restaurant by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The restaurant entity</returns>
        public Restaurant GetRestaurantById(int id)
        {
            return UnitOfWork.Repository<Restaurant>().Find(x => x.Id == id);
        }

        /// <summary>
        /// Gets all restaurants.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return UnitOfWork.Repository<Restaurant>().All();
        }

        /// <summary>
        /// Saves the restaurant.
        /// </summary>
        /// <param name="restaurant">The restaurant.</param>
        /// <exception cref="ValidationException">The restaurant entity is not valid!</exception>
        public void SaveRestaurant(Restaurant restaurant)
        {
            var context = new ValidationContext(restaurant);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(restaurant, context, results);
            if (!isValid)
            {
                throw new ValidationException("The restaurant entity is not valid!", null, results);
            }
            else
            {
                //TO DO use a procedure to update in db
            }
        }
    }
}
