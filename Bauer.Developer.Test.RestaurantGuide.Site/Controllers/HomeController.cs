using Bauer.Developer.Test.RestaurantGuide.Services;
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
            var restaurants = Service.GetAllRestaurants();
            return View(restaurants.ToList());
        }
    } 
}