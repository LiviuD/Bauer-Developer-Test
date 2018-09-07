using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Bauer.Developer.Test.RestaurantGuide.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand("SELECT Id, Name, PhoneNumber FROM Restaurant") { Connection = connection };
            var adapter = new SqlDataAdapter(command);

            using (connection)
            {
                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                ViewBag.Restaurants = dataSet.Tables[0];
            }

            return View();
        }
    }
}