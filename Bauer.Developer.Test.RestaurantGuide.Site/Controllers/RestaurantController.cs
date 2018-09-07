using Bauer.Developer.Test.RestaurantGuide.Domain;
using Bauer.Developer.Test.RestaurantGuide.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Controllers
{
    public class RestaurantController : BaseController<RestaurantService>
    {
        public RestaurantController(RestaurantService service) : base(service)
        {

        }
        public ActionResult Edit(int id)
        {
            ViewBag.Restaurant = LoadRestaurant(id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Restaurant = LoadRestaurant(id);

                ViewBag.Message = String.Format("Saved '{0}'.", restaurant.Name);

            }
            else
            {
                ViewBag.Message = String.Format("The data entered is not valid for the restaurant '{0}'.", restaurant.Name);
            }
            return View();
        }

        /// <summary>
        /// Loads the restaurant.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private Restaurant LoadRestaurant(int id)
        {
            return this.Service.GetRestaurantById(id);
        }
    }
}