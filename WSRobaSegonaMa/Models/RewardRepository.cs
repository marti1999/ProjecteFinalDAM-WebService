using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class RewardRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Reward> GetAllRewards()
        {
            List<Reward> lc = dataContext.Rewards.ToList();
            return lc;
        }

        public static bool claimRewardByDonor(int rewardId, int donorId)
        {
            Reward r = dataContext.Rewards.Where(x => x.Id == rewardId).FirstOrDefault();
            Donor d = dataContext.Donors.Where(x => x.Id == donorId).FirstOrDefault();
            try
            {
                r.Donors.Add(d);
                d.Rewards.Add(r);

                return true;
            }

            catch (Exception e)
            {
                return false;
            }



        }

        public static Reward UpdateReward(int id, Reward val)
        {
            try
            {
                Reward c0 = dataContext.Rewards.Where(x => x.Id == id).FirstOrDefault();

                val.dateCreated = c0.dateCreated;

                DeleteReward(c0.Id);
                InsertReward(val);

                dataContext.SaveChanges();
                return GetReward(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<RewardInfoLang> UpdateInfoRewardFromList(List<RewardInfoLang> infoRewards)
        {
            foreach (var info in infoRewards)
            {
                RewardInfoLang c0 = dataContext.RewardInfoLangs.Where(x => x.Id == info.Id).SingleOrDefault();
                if (!info.title.Equals(""))
                {
                    c0.title = info.title;
                    c0.description = info.description;
                }
            }

            return infoRewards;
        }

        public static Reward InsertReward(Reward val)
        {
            try
            {
                dataContext.Rewards.Add(val);
                dataContext.SaveChanges();
                return GetReward(val.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Reward GetReward(int rewardID)
        {
            Reward c = dataContext.Rewards.Where(x => x.Id == rewardID).SingleOrDefault();
            return c;
        }

        public static void DeleteReward(int id)
        {
            Reward c = dataContext.Rewards.Where(x => x.Id == id).SingleOrDefault();

            if (c != null)
            {
                List<RewardInfoLang> rewardInfoLangs = c.RewardInfoLangs.ToList();
                foreach (var info in rewardInfoLangs)
                {
                    dataContext.RewardInfoLangs.Remove(info);
                }
                dataContext.Rewards.Remove(c);
                dataContext.SaveChanges();
            }
        }
    }
}