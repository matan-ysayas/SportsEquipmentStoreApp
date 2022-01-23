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
        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False"; 
               SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: Shoes
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult AllShoes()
        {
            
            return View(SportStoreDB.Shoes.ToList());
        }
    }
}