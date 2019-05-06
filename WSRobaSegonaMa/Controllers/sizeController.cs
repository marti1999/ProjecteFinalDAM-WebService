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
    public class sizeController : ApiController
    {
        // GET: api/sizes
        [Route("api/sizes")]
        public HttpResponseMessage GetSizes()
        {
            var size = SizeRepository.GetAllSizes();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, size);
            return response;
        }


        // GET: api/size/25
        [Route("api/size")]
        public HttpResponseMessage PostSize([FromBody]int id)
        {
            var size = SizeRepository.GetSize(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, size);
            return response;
        }



    }
}