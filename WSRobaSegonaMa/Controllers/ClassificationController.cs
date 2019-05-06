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
    public class ClassificationController : ApiController
    {
        // GET: api/classifications
        [Route("api/classifications")]
        public HttpResponseMessage GetClassifications()
        {
            var classifications = ClassificationRepository.GetAllClassifications();
            HttpResponseMessage response =  Request.CreateResponse(HttpStatusCode.OK, classifications);
            return response;
        }


        [Route("api/classification/{id}")]
        public HttpResponseMessage GetClassificationById(int id)
        {
            var classifications = ClassificationRepository.GetClassification(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, classifications);
            return response;
        }


        [Route("api/classification")]
        public HttpResponseMessage PostClassificationById2([FromBody]int id)
        {
            var classifications = ClassificationRepository.GetClassification(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, classifications);
            return response;
        }


        // GET: api/classifications/en
        [Route("api/classifications/{lang}")]
        public HttpResponseMessage GetClassificationsCat(string lang)
        {
            var classifications = ClassificationRepository.GetAllClassificationsLang(lang);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, classifications);
            return response;
        }


        

    }
}