using Bauer.Developer.Test.RestaurantGuide.Services;
using Bauer.Developer.Test.RestaurantGuide.Site.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Controllers
{
    public class HomeController : BaseController<RestaurantService>
    {
        public HomeController(RestaurantService restaurantService) : base(restaurantService)
        {

        }

        public ActionResult Index()
        {
            var restaurants = Service
                .GetAllRestaurants();
            if (restaurants == null)
                return View(new List<RestaurantModel>());

            return View(restaurants.ToList().Select(x=>new RestaurantModel(x)).ToList());
        }
    } 
}