using SportsEquipmentStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SportsEquipmentStoreApp.Controllers.api
{
    public class PantsController : ApiController
    {
        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: api/Pants
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(SportStoreDB.Clothings.Where((item) => item.TypeOfClothing == "shirt").ToList());

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Pants/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(SportStoreDB.Clothings.First((item) => item.Id == id));

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // POST: api/Pants
        public IHttpActionResult Post([FromBody] Clothing value)
        {
            try
            {
                SportStoreDB.Clothings.InsertOnSubmit(value);
                SportStoreDB.SubmitChanges();
                return Ok("item was add");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Pants/5
        public IHttpActionResult Put(int id, [FromBody] Clothing value)
        {
            try
            {
                Clothing clothing = SportStoreDB.Clothings.First((item) => item.Id == id);
                clothing.TypeOfClothing = value.TypeOfClothing;
                clothing.Gender = value.Gender;
                clothing.Company = value.Company;
                clothing.Model = value.Model;
                clothing.Quantity = value.Quantity;
                clothing.IsItShort = value.IsItShort;
                clothing.IsItDreyfit = value.IsItDreyfit;
                clothing.ImageLink = value.ImageLink;
                SportStoreDB.SubmitChanges();
                return Ok("item was update");

            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        public IHttpActionResult Delete(int id)
        {
            try
            {
                SportStoreDB.Clothings.DeleteOnSubmit(SportStoreDB.Clothings.First((item) => item.Id == id));

                SportStoreDB.SubmitChanges();
                return Ok("Item deleted");
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
