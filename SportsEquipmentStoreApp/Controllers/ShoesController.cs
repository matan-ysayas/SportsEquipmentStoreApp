using SportsEquipmentStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsEquipmentStoreApp.Controllers
{
    public class ShoesController : Controller

    {
      public static  string ConnecsionString = "Data Source=laptop-e49vkatt;Initial Catalog = SchoolAdoDB; Integrated Security = True; Pooling=False";
               SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: Shoes
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AllShoes()
        {
            SportStoreDB.Shoes.ToList();
            return View(SportStoreDB.Shoes.ToList());
        }
    }
}