using Bauer.Developer.Test.RestaurantGuide.DataAccess.Common;
using Bauer.Developer.Test.RestaurantGuide.Domain;
using Bauer.Developer.Test.RestaurantGuide.Services.Validation;
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
        public Restaurant SaveRestaurant(Restaurant restaurant)
        {
            List<ValidationResult> results = null;
            var isValid = restaurant.TryValidateObject(out results);
            if (!isValid)
            {
                throw new ValidationException("The restaurant entity is not valid!", null, results);
            }
            else
            {
                restaurant.PhoneNumber = TransformPhoneNumber(restaurant.PhoneNumber);
                this.UnitOfWork.Repository<Restaurant>().Update(restaurant);
                this.UnitOfWork.SaveChanges();
                return restaurant;
            }
        }

        /// <summary>
        /// Transforms the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public static string TransformPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber?.Replace("(", String.Empty)?.Replace(")", String.Empty)?.Replace(" ", "");

            if (phoneNumber == null)
                return null;
            if (phoneNumber.IndexOf("0") == 0)
            {
                phoneNumber = phoneNumber.Substring(1, phoneNumber.Length - 1);
            }
            if (phoneNumber.IndexOf("+61") == 0)
            {
                phoneNumber = phoneNumber.Substring(3, phoneNumber.Length - 3);
            }
            if (phoneNumber.IndexOf("61") == 0)
            {
                phoneNumber = phoneNumber.Substring(2, phoneNumber.Length - 2);
            }
            if (phoneNumber.Length < 9)
            {
                phoneNumber = phoneNumber.Substring(0, phoneNumber.Length);
            }
            else
            {
                phoneNumber = phoneNumber.Substring(0, 9);
            }
            return phoneNumber;
        }
    }
}
