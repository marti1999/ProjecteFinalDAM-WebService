using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSRobaSegonaMa.Controllers;


namespace WSRobaSegonaMa.Models
{
    public class AdminRepository
    {

        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Administrator> GetAllAdministrators()
        {
            List<Administrator> lc = dataContext.Administrators.ToList();
            return lc;
        }

        public static Administrator GetAdministrator(int donorID)
        {
            Administrator c = dataContext.Administrators.Where(x => x.Id == donorID).SingleOrDefault();
            return c;
        }

        public static List<Administrator> SearchAdministratorsByDni(string donorDni)
        {
            List<Administrator> lc = dataContext.Administrators
                .Where(x => x.codiEmpleat.Contains(donorDni)).ToList();
            return lc;
        }

        public static Administrator InsertAdministrator(Administrator c)
        {
            try
            {
                dataContext.Administrators.Add(c);
                dataContext.SaveChanges();
                return GetAdministrator(c.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Administrator UpdateAdministrator(int id, Administrator c)
        {
            try
            {
                Administrator c0 = dataContext.Administrators.Where(x => x.Id == id).SingleOrDefault();
                if (c.email != null) c0.email = c.email;
                if (c.name != null) c0.name = c.name;
                if (c.lastName != null) c0.lastName = c.lastName;
                if (c.password != null) c0.password = c.password;
                if (c.dateCreated != null) c0.dateCreated = c.dateCreated;
                if (c.isSuper != null) c0.isSuper = c.isSuper;
                if (c.active != null) c0.active = c.active;
                if (c.codiEmpleat != null) c0.codiEmpleat = c.codiEmpleat;
                if (c.Language != null) c0.Language = c.Language;
                if (c.Warehouse != null) c0.Warehouse = c.Warehouse;

                dataContext.SaveChanges();
                return GetAdministrator(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteAdministrator(String id)
        {
            Administrator c;
            if (Utils.validInt(id))
            {
                int idInt = int.Parse(id);
                c = dataContext.Administrators.Where(x => x.Id == idInt || x.codiEmpleat.Equals(id)).SingleOrDefault();
            }
            else
            {
                c = dataContext.Administrators.Where(x => x.codiEmpleat.Equals(id)).SingleOrDefault();
            }

            if (c != null)
            {
                dataContext.Administrators.Remove(c);
                dataContext.SaveChanges();
            }
        }

    }
}