using Bauer.Developer.Test.RestaurantGuide.Domain;
using Bauer.Developer.Test.RestaurantGuide.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using Bauer.Developer.Test.RestaurantGuide.Site.Models;
using System.ComponentModel.DataAnnotations;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Controllers
{
    public class RestaurantController : BaseController<RestaurantService>
    {
        public RestaurantController(RestaurantService service) : base(service)
        {

        }
        public ActionResult Edit(int id)
        {
            var restaurant = LoadRestaurant(id);
            if (restaurant == null && id != 0)
            {
                ViewBag.Message = "The restaurant does not exists!";
                return View();
            }
            var model = new RestaurantModel(restaurant);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, RestaurantModel model)
        {
            ViewBag.Message = String.Format("The data entered is not valid for this restaurant '{0}'.", model?.Name);
            if (ModelState.IsValid)
            {
                var restaurant = Service.GetRestaurantById(model.Id.Value);
                restaurant = model.ToRestaurant(restaurant);
                restaurant.Id = id;
                try
                {
                    this.Service.SaveRestaurant(restaurant);
                    ViewBag.Message = String.Format("Saved '{0}'.", restaurant.Name);
                }
                catch (Exception)
                {
                    //Log
                }
            }
            return View(model);
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