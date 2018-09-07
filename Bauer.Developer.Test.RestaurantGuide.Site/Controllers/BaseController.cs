using Bauer.Developer.Test.RestaurantGuide.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Controllers
{
    /// <summary>
    /// Base controller for a service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Web.Mvc.Controller" />
    public class BaseController<T> : Controller 
        where T : IService
    {
        protected T Service;
        public BaseController()
        {
        }
        public BaseController(T service)
        {
            this.Service = service;
        }
    }
}