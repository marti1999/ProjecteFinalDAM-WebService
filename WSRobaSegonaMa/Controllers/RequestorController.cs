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
    public class RequestorController : ApiController
    {
        // GET: api/requestors
        [Route("api/requestors")]
        public HttpResponseMessage Get()
        {
            var requestors = RequestorRepository.GetAllRequestors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }
        // GET: api/requestorsTot
        [Route("api/requestorsTot")]
        public HttpResponseMessage GetTot()
        {
            var requestors = RequestorRepository.GetAllRequestors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }
        //GET: api/requestor/65432343T
        [Route("api/requestor/{dni:alpha}")]
        public HttpResponseMessage GetRequestorByName(string dni)
        {
            var requestors = RequestorRepository.SearchRequestorsByDni(dni);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // GET: api/requestor/5
        [Route("api/requestor/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var requestors = RequestorRepository.GetRequestor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // PUT: api/requestor/5
        [Route("api/requestor/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Requestor val)
        {
            var requestors = RequestorRepository.UpdateRequestor(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // PUT: api/requestor/5
        [Route("api/requestorPassword/{id?}")]
        public HttpResponseMessage PutPassword(int id, [FromBody] Requestor val)
        {
            var requestors = RequestorRepository.UpdateRequestorPassword(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // POST: api/requestor
        [Route("api/requestor")]
        public HttpResponseMessage Post([FromBody] Requestor val)
        {
            var requestors = RequestorRepository.InsertRequestor(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }


        // DELETE: api/requestor/5
        [Route("api/requestor/{id?}")]
        public HttpResponseMessage Delete(String id)
        {
            RequestorRepository.DeleteRequestor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        // POST: api/requestor/login
        [Route("api/requestor/login")]
        public HttpResponseMessage Login([FromBody] Requestor val)
        {
            var canLogin = RequestorRepository.CanLogin(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, canLogin);
            return response;
        }
    }
}