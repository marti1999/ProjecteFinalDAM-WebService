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
    public class NameController : ApiController
    {
        // GET: api/classifications
        [Route("api/classifications")]
        public HttpResponseMessage GetClassifications()
        {
            var classifications = ClassificationRepository.GetAllClassifications();
            HttpResponseMessage response =  Request.CreateResponse(HttpStatusCode.OK, classifications);
            return response;
        }

        // GET: api/classificationsCat
        [Route("api/classificationsCat")]
        public HttpResponseMessage GetClassificationsCat()
        {
            var classifications = ClassificationRepository.GetAllClassifications();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, classifications);
            return response;
        }

    }
}