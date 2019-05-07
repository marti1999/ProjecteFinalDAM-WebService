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
    public class ClothController : ApiController
    {
        //GET: api/clothes
        [Route("api/clothes")]
        public HttpResponseMessage getClothes()
        {
            var clothes = ClothRespository.GetAllClothes();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, clothes);
            return response;
        }

        //GET: api/cloth/4
        [Route("api/cloth/{id?}")]
        public HttpResponseMessage getClothById(int id)
        {
            var clothes = ClothRespository.getCloth(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, clothes);
            return response;
        }

        // PUT: api/cloth/5
        [Route("api/cloth/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Cloth val)
        {
            var cloth = ClothRespository.updateCloth(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, cloth);
            return response;
        }

        // POST: api/cloth/
        [Route("api/cloth")]
        public HttpResponseMessage Post([FromBody] Cloth val)
        {
            var cloth = ClothRespository.insertCloth(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, cloth);
            return response;
        }

        // POST: api/cloth/
        [Route("api/cloth/range")]
        public HttpResponseMessage PostRange([FromBody] List<Cloth> val)
        {
            var cloth = ClothRespository.insertClothList(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, cloth);
            return response;
        }

        // DELETE: api/cloth/5
        [Route("api/cloth/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            Cloth c = ClothRespository.deleteCloth(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, c);
            return response;
        }



    }
}