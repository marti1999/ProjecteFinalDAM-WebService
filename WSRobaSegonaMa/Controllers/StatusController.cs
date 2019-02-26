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
    public class StatusController : ApiController
    {
        // GET: api/status
        [Route("api/status")]
        public HttpResponseMessage Get()
        {
            var requestors = RequestorRepository.GetAllRequestors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // PUT: api/status/5
        [Route("api/status/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Requestor val)
        {
            var requestors = RequestorRepository.UpdateRequestor(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // POST: api/status
        [Route("api/status")]
        public HttpResponseMessage Post([FromBody] Requestor val)
        {
            var requestors = RequestorRepository.InsertRequestor(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }


        // DELETE: api/status/5
        [Route("api/status/{id?}")]
        public HttpResponseMessage Delete(String id)
        {
            RequestorRepository.DeleteRequestor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}