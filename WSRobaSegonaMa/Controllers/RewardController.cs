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
    public class RewardController : ApiController
    {
        // GET: api/rewards
        [Route("api/rewards")]
        public HttpResponseMessage Get()
        {
            var requestors = RewardRepository.GetAllRewards();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // PUT: api/rewards/5
        [Route("api/rewards/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Reward val)
        {
            var requestors = RewardRepository.UpdateReward(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }

        // POST: api/rewards
        [Route("api/rewards")]
        public HttpResponseMessage Post([FromBody] Reward val)
        {
            var requestors = RewardRepository.InsertReward(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, requestors);
            return response;
        }


        // DELETE: api/rewards/5
        [Route("api/rewards/{id?}")]
        public HttpResponseMessage Delete(String id)
        {
            RewardRepository.DeleteReward(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}