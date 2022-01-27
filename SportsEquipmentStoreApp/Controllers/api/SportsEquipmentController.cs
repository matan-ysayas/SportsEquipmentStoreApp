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
    public class SportsEquipmentController : ApiController
    {

        public static string ConnecsionString = "Data Source=.;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        SportStoreDBDataContext SportStoreDB = new SportStoreDBDataContext(ConnecsionString);
        // GET: api/SportsEquipment
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(SportStoreDB.sportsEquipments.ToList());

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

        // GET: api/SportsEquipment/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(SportStoreDB.sportsEquipments.First((item) => item.Id == id));

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

        // POST: api/SportsEquipment
        public IHttpActionResult Post([FromBody] sportsEquipment value)
        {
            try
            {
                SportStoreDB.sportsEquipments.InsertOnSubmit(value);
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

        // PUT: api/SportsEquipment/5
        public IHttpActionResult Put(int id, [FromBody] sportsEquipment value)
        {
            try
            {
                sportsEquipment se = SportStoreDB.sportsEquipments.First((item) => item.Id == id);
                se.SportType = value.SportType;
                se.ProductName = value.ProductName;
                se.Company = value.Company;
                se.Price = value.Price;
                se.Quantity = value.Quantity;
                se.SportsClubId = value.SportsClubId;
                se.ImageLink = value.ImageLink;
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


        // DELETE: api/SportsEquipment/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                SportStoreDB.sportsEquipments.DeleteOnSubmit(SportStoreDB.sportsEquipments.First((item) => item.Id == id));

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
