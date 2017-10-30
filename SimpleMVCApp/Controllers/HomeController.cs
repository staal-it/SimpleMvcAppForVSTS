using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using SimpleMVCApp.Data;

namespace SimpleMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var environment = ConfigurationManager.AppSettings["Environment"];
            var version = ConfigurationManager.AppSettings["ApplicationVersion"];

            AddFruitsIfDatabaseIsEmpty();

            List<Fruit> fruits;
            using (var context = new FruitContext())
            {
                fruits = context.Fruits.ToList();
            }

            ViewBag.Environment = environment;
            ViewBag.Version = version;

            return View(fruits);
        }

        private void AddFruitsIfDatabaseIsEmpty()
        {
            using (var context = new FruitContext())
            {
                if (!context.Fruits.Any())
                {
                    var fruits = new List<Fruit>
                    {
                        new Fruit { Name = "Apple"},
                        new Fruit { Name = "Banana"},
                        new Fruit { Name = "Orange"}
                    };
                    fruits.ForEach(s => context.Fruits.Add(s));
                    context.SaveChanges();
                }
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}