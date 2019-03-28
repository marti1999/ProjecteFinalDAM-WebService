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
    public class RewardInfoLangController : ApiController
    {
        // GET: api/rewardinfolangs
        [Route("api/rewardinfolangs")]
        public HttpResponseMessage Get()
        {
            var rewards = RewardInfoLangRepository.GetAllRewards();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rewards);
            return response;
        }

        // GET: api/rewardinfolangs/getfields/1
        [Route("api/rewardinfolangs/getfields/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var rewards = RewardInfoLangRepository.GetRewardInfoLangFromRewardId(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rewards);
            return response;
        }

        // PUT: api/rewardinfolangs/5
        [Route("api/rewardinfolangs/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] RewardInfoLang val)
        {
            var reward = RewardInfoLangRepository.UpdateRewardInfoLang(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, reward);
            return response;
        }

        // POST: api/rewardinfolangs
        [Route("api/rewardinfolangs")]
        public HttpResponseMessage Post([FromBody] RewardInfoLang val)
        {
            var rewards = RewardInfoLangRepository.InsertRewardInfoLang(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rewards);
            return response;
        }


        // DELETE: api/rewardInfoLangs/5
        [Route("api/rewardInfoLangs/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            RewardInfoLangRepository.DeleteRewardInfoLang(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}