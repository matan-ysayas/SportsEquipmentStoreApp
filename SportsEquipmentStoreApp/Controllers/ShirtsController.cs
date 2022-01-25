using SportsEquipmentStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentStoreApp.Controllers
{
    public class ShirtsController : Controller
    {
        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: Shirts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllShirts()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt").ToList());
        }
        public ActionResult ShirtsManagerTable()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt").ToList());
        }
        public ActionResult ShortSleeves()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt"&&item.IsItShort==true ).ToList());
        }
        public ActionResult LongSleeves()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt" && item.IsItShort == false).ToList());
        }

        public ActionResult DreyfitOnly()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt" && item.IsItDreyfit == true).ToList());
        }
        public ActionResult SortedByPrice()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt").OrderBy((item)=>item.Price).ToList());
        }

    }
}