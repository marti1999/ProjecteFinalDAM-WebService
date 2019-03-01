using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WSRobaSegonaMa.Models;

namespace WSRobaSegonaMa.Controllers
{
    public class WarehouseController : ApiController
    {
        // GET: api/warehouses
        [Route("api/warehouses")]
        public HttpResponseMessage GetWarehouses()
        {

            var warehouse = warehouseRepository.GetAllWarehouses();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, warehouse);
            return response;
        }
         


    }
}