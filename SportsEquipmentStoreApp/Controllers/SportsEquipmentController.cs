using SportsEquipmentStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentStoreApp.Controllers
{
    public class SportsEquipmentController : Controller
    {
        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: SportsEquipment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllSportsEquipment()
        {
            return View(SportStoreDB.sportsEquipments.ToList());
        }


        public ActionResult SportsEquipmentManagerTable()
        {
            return View(SportStoreDB.sportsEquipments.ToList());
        }

        public ActionResult BasketballEquipmentOnly()
        {
            return View(SportStoreDB.sportsEquipments.Where((item)=>item.SportType== "basketball").ToList());
        }

        public ActionResult SoccerEquipmentOnly()
        {
            return View(SportStoreDB.sportsEquipments.Where((item) => item.SportType == "soccer").ToList());
        }
        public ActionResult SortedByPrice()
        {
            return View(SportStoreDB.sportsEquipments.OrderBy((item) => item.Price).ToList());
        }

    }
}