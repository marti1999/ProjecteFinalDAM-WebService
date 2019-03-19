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
    public class OrderController : ApiController
    {
        // PUT: api/order
        [Route("api/order")]
        public HttpResponseMessage Put([FromBody] Order val)
        {
            var orders = OrderRepository.insertOrder(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, orders);
            return response;
        }
    }
}