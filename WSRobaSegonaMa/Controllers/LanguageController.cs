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
    public class LanguageController : ApiController
    {
        // GET: api/languages
        [Route("api/languages")]
        public HttpResponseMessage Get()
        {
            var langFinal = LanguageRepository.GetAllLanguages();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, langFinal);
            return response;
        }

        //GET: api/language/getcode/es
        [Route("api/language/getcode/{lang}")]
        public HttpResponseMessage GetLanguageByName(string lang)
        {
            var langFinal = LanguageRepository.SearchLanguagesByCode(lang);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, langFinal);
            return response;
        }

        // GET: api/language/5
        [Route("api/language/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var langFinal = RequestorRepository.GetRequestor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, langFinal);
            return response;
        }

    }
}