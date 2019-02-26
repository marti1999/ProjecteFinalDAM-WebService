using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSRobaSegonaMa.Controllers;


namespace WSRobaSegonaMa.Models
{
    public class StatusRepository
    {

        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Status> GetAllStatus()
        {
            List<Status> lc = dataContext.Status.ToList();
            return lc;
        }

        public static Status GetStatus(int requestorID)
        {
            Status c = dataContext.Status.Where(x => x.Id == requestorID).SingleOrDefault();
            return c;
        }

        public static Status InsertStatus(Status c)
        {
            try
            {
                dataContext.Status.Add(c);
                dataContext.SaveChanges();
                return GetStatus(c.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Status UpdateStatus(int id, Status c)
        {
            try
            {
                Status c0 = dataContext.Status.Where(x => x.Id == id).SingleOrDefault();
                if (c.Id != null) c0.Id = c.Id;
                if (c.status1 != null) c0.status1 = c.status1;
                if (c.reason != null) c0.reason = c.reason;

                dataContext.SaveChanges();
                return GetStatus(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteStatus(int id)
        {
            Status c;

            c = dataContext.Status.Where(x => x.Id == id).SingleOrDefault();


            if (c != null)
            {
                dataContext.Status.Remove(c);
                dataContext.SaveChanges();
            }
        }

    }
}