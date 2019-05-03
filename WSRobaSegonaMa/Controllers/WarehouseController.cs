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

        //POST: api/warehouse
        [Route("api/warehouse")]
        public HttpResponseMessage Post([FromBody] Warehouse val)
        {

            var warehouse = warehouseRepository.addWarehouse(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, warehouse);
            return response;
        }

        //POST api/warehouse/byCloth
        [Route("api/warehouse/byCloth")]
        public HttpResponseMessage Post([FromBody] Cloth val)
        {

            var warehouse = warehouseRepository.getWarehousesByCloth(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, warehouse);
            return response;
        }



        //PUT: api/warehouse
        [Route("api/warehouse/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Warehouse val)
        {

            var warehouse = warehouseRepository.updateWarehuse(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, warehouse);
            return response;
        }



    }
}