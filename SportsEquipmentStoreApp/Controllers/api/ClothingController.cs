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
    public class ClothingController : ApiController
    {
        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: api/Clothing
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(SportStoreDB.Clothings.ToList());

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

        // GET: api/Clothing/5
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

        // POST: api/Clothing
        public IHttpActionResult Post([FromBody]Clothing value)
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

        // PUT: api/Clothing/5
        public IHttpActionResult Put(int id, [FromBody] Clothing value)
        {
            try
            {
                Clothing Clothing = SportStoreDB.Clothings.First((item) => item.Id == id);
                Clothing.TypeOfClothing = value.TypeOfClothing;
                Clothing.Gender = value.Gender;
                Clothing.Company = value.Company;
                Clothing.Price = value.Price;
                Clothing.Quantity = value.Quantity;
                Clothing.IsItShort = value.IsItShort;
                Clothing.IsItDreyfit = value.IsItDreyfit;
                Clothing.ImageLink = value.ImageLink;
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

 

        // DELETE: api/Clothing/5
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
