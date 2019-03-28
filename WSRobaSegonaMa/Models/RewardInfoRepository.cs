using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class RewardInfoLangRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();



        public static List<RewardInfoLang> GetAllRewards()
        {
            List<RewardInfoLang> lc = dataContext.RewardInfoLangs.ToList();
            return lc;
        }

        public static RewardInfoLang UpdateRewardInfoLang(int id, RewardInfoLang val)
        {
            try
            {
                RewardInfoLang c0 = dataContext.RewardInfoLangs.Where(x => x.Id == id).SingleOrDefault();
                if (val.Id != null) c0.Id = val.Id;
                if (val.title != null) c0.title = val.title;
                if (val.description != null) c0.description = val.description;

                dataContext.SaveChanges();
                return GetRewardInfoLang(id);
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

        public static RewardInfoLang InsertRewardInfoLang(RewardInfoLang val)
        {
            try
            {
                dataContext.RewardInfoLangs.Add(val);
                dataContext.SaveChanges();
                return GetRewardInfoLang(val.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static RewardInfoLang GetRewardInfoLang(int rewardInfoID)
        {
            RewardInfoLang c = dataContext.RewardInfoLangs.Where(x => x.Id == rewardInfoID).SingleOrDefault();
            return c;
        }
        public static List<RewardInfoLang> GetRewardInfoLangFromRewardId(int rewardID)
        {
            List<RewardInfoLang> c = dataContext.RewardInfoLangs.Where(x => x.Rewards_Id == rewardID).ToList();
            return c;
        }

        public static void DeleteRewardInfoLang(int id)
        {
            RewardInfoLang c = dataContext.RewardInfoLangs.Where(x => x.Id == id).SingleOrDefault();

            if (c != null)
            {
                dataContext.RewardInfoLangs.Remove(c);
                dataContext.SaveChanges();
            }
        }
    }
}