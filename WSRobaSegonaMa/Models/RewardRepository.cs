using System;
using System.Collections.Generic;
using System.Linq;
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

        public static Reward UpdateReward(int id, Reward val)
        {
            try
            {
                Reward c0 = dataContext.Rewards.Where(x => x.Id == id).SingleOrDefault();
                if (val.Id != null) c0.Id = val.Id;
                if (val.active != null) c0.active = val.active;
                if (val.neededPoints != null) c0.neededPoints = val.neededPoints;
                if (val.RewardInfoLangs.Any()) val.RewardInfoLangs = UpdateInfoRewardFromList(val.RewardInfoLangs.ToList());

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
                dataContext.Rewards.Remove(c);
                dataContext.SaveChanges();
            }
        }
    }
}