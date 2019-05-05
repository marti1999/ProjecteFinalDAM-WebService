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
    public class ColorController : ApiController
    {
        // GET: api/colors
        [Route("api/colors")]
        public HttpResponseMessage Get()
        {
            var colors = ColorRepository.GetAllColors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, colors);
            return response;
        }
        // GET: api/color/25
        [Route("api/color/{id}")]
        public HttpResponseMessage GetColor(int id)
        {
            var size = ColorRepository.GetColor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, size);
            return response;
        }
    }
}