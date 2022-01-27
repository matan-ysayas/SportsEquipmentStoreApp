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
    public class ShoesController : ApiController
    {

        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: api/Shoes
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(SportStoreDB.Shoes.ToList());

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

        // GET: api/Shoes/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(SportStoreDB.Shoes.First((item) => item.Id == id));

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

        // POST: api/Shoes
        public IHttpActionResult Post([FromBody] Shoe value)
        {
            try
            {
                SportStoreDB.Shoes.InsertOnSubmit(value);
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

        // PUT: api/Shoes/5
        public IHttpActionResult Put(int id, [FromBody] Shoe value)
        {
            try
            {
               Shoe shoe= SportStoreDB.Shoes.First((item) => item.Id == id);
                shoe.ShoeType= value.ShoeType;
                shoe.Company = value.Company;
                shoe.Model = value.Model;
                shoe.Price= value.Price;
                shoe.Quantity = value.Quantity;
                shoe.IsOnSale = value.IsOnSale;
                shoe.ImageLink = value.ImageLink;
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

        // DELETE: api/Shoes/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                SportStoreDB.Shoes.DeleteOnSubmit(SportStoreDB.Shoes.First((item) => item.Id == id));

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
