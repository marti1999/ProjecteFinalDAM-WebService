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
            var rewards = RewardRepository.GetAllRewards();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rewards);
            return response;
        }

        // PUT: api/reward/update/5
        [Route("api/reward/update/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Reward val)
        {
            var reward = RewardRepository.UpdateReward(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, reward);
            return response;
        }

        //PUT: api/reward/claim
        [Route("api/reward/claim/{rewardId?}")]
        public HttpResponseMessage PutClaimReward(int rewardId, [FromBody] int donorId)
        {
            var reward = RewardRepository.claimRewardByDonor(rewardId, donorId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, reward);
            return response;
        }

        //PUT: api/reward/availableDonor/6
        [Route("api/reward/availableDonor/{donorId?}")]
        public HttpResponseMessage PutGetRewardDonor(int donorId)
        {
            var reward = RewardRepository.getAvailableRewardsDonor(donorId);
            //     reward.Add(new Reward());
            foreach (Reward item in reward)
            {
                item.Donors = null;
            }
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, reward);
            return response;
        }





        // POST: api/rewards
        [Route("api/rewards")]
        public HttpResponseMessage Post([FromBody] Reward val)
        {
            var rewards = RewardRepository.InsertReward(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, rewards);
            return response;
        }


        // DELETE: api/reward/5
        [Route("api/reward/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            RewardRepository.DeleteReward(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

    }
}