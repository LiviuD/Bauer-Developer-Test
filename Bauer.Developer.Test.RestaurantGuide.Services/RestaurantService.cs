using Bauer.Developer.Test.RestaurantGuide.DataAccess.Common;
using Bauer.Developer.Test.RestaurantGuide.Domain;
using System;
using System.Collections.Generic;
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
    }
}
