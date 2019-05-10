using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSRobaSegonaMa.Controllers;

namespace WSRobaSegonaMa.Models
{
    public class AnnouncementRespository
    {

        private static RobaSegonaMaEntities dc = new RobaSegonaMaEntities();

        

        public static List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> lc = dc.Announcements.ToList();
            return lc;
        }

        public static List<Announcement> getAllAnnouncementsByUserType(string userType)
        {
            List<Announcement> lc = dc.Announcements.Where(x => ((x.recipient.ToLower().Contains(userType.ToLower()) || (x.recipient.ToLower().Contains("everyone"))) && x.language.Contains("ngl"))).ToList();
            return lc;
        }

        public static int getNewAnnouncementNumberByUserType(string userType)
        {
            List<Announcement> lc = dc.Announcements.Where(x => ((x.recipient.ToLower().Contains(userType.ToLower()) || (x.recipient.ToLower().Contains("everyone"))) && x.language.Contains("ngl"))).ToList();

            return lc.Count();

        }

        public static Announcement getAnnouncement(int id)
        {
            Announcement c = dc.Announcements.Where(x => x.Id == id).FirstOrDefault();
            return c;
        }

        public static Announcement insertAnnouncement(Announcement c)
        {
            try
            {
                dc.Announcements.Add(c);
                dc.SaveChanges();
                return c;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Announcement updateAnnouncement(int id, Announcement c)
        {
            try
            {
                Announcement c2 = dc.Announcements.Where(x => x.Id == id).SingleOrDefault();

                
                if (c.title != null) c2.title = c.title;
                if (c.message != null) c2.message = c.message;
                if (c.dateCreated != null) c2.dateCreated = c.dateCreated;
                if (c.recipient != null) c2.recipient = c.recipient;
                
                dc.SaveChanges();
                return c2;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static void deleteAnnouncement(int id)
        {
            Announcement c;

            c = dc.Announcements.Where(x => x.Id == id).FirstOrDefault();
            if (c != null) { }
            {
                dc.Announcements.Remove(c);
                dc.SaveChanges();
            }
        }

    }
}