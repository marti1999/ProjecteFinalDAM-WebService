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
    public class GenderController : ApiController
    {
        // GET: api/genders
        [Route("api/genders")]
        public HttpResponseMessage GetGenders()
        {
            
            var size = GenderRepository.GetAllGenders();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, size);
            return response;
        }

        [Route("api/genders/{name:alpha}")]
        public HttpResponseMessage GetGenderByName(string name)
        {

            var size = GenderRepository.getGenderByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, size);
            return response;
        }



    }
}