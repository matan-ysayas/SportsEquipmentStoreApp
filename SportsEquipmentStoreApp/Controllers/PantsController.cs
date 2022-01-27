using SportsEquipmentStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentStoreApp.Controllers
{
    public class PantsController : Controller
    {
        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: Pants
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllPants()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "pants").ToList());
        }
        public ActionResult PantsManagerTable()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "pants").ToList());
        }
        public ActionResult ShortPants()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "pants" && item.IsItShort == true).ToList());
        }
        public ActionResult LongPants()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "pants" && item.IsItShort == false).ToList());
        }
        public ActionResult DreyfitOnly()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "pants" && item.IsItDreyfit == true).ToList());
        }
        public ActionResult SortedByPrice()
        {
            return View(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "pants").OrderBy((item) => item.Price).ToList());
        }
    }
}