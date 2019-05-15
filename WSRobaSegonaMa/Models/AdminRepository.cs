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

        public static Administrator GetAdministrator(int adminId)
        {
            Administrator c = dataContext.Administrators.Where(x => x.Id == adminId).SingleOrDefault();
            return c;
        }

        public static List<Administrator> SearchAdministratorsByCode(string adminCode)
        {
            List<Administrator> lc = dataContext.Administrators
                .Where(x => x.workerCode.Contains(adminCode)).ToList();
            return lc;
        }

        public static Administrator SearchAdministratorsByEmail(string adminEmail)
        {
            Administrator admin = dataContext.Administrators
                .Where(x => x.email.Equals(adminEmail)).FirstOrDefault();
            return admin;
        }

        public static Administrator InsertAdministrator(Administrator c)
        {
            try
            {
                c.Language = null;
                dataContext.Administrators.Add(c);
              
                dataContext.SaveChanges();
                return GetAdministrator(c.Id);
            }
            catch (Exception e)
            {
               Console.WriteLine(e.ToString());
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
                if (c.workerCode != null) c0.workerCode = c.workerCode;
                if (c.Language_Id != null) c0.Language_Id = c.Language_Id;
                if (c.Warehouse_Id != null) c0.Warehouse_Id = c.Warehouse_Id;

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
                c = dataContext.Administrators.Where(x => x.Id == idInt || x.workerCode.Equals(id)).SingleOrDefault();
            }
            else
            {
                c = dataContext.Administrators.Where(x => x.workerCode.Equals(id)).SingleOrDefault();
            }

            if (c != null)
            {
                dataContext.Administrators.Remove(c);
                dataContext.SaveChanges();
            }
        }


        public static bool CanLogin(Administrator a)
        {
            List<Administrator> lc = GetAllAdministrators();
            //Administrator a2 = lc.FirstOrDefault();
            //Console.WriteLine(a2.password);

            Administrator admin = lc.Where(x => x.password == a.password && x.email == a.email).FirstOrDefault();
            if (admin != null)
            {
                return true;
            }
            return false;
        }

        public static void SetAdminLang(int id, string lang)
        {
            try
            {
                Administrator a = GetAllAdministrators().Where(x => x.Id.Equals(id)).FirstOrDefault();
                a.Language_Id = Utils.getIdLang(lang);
                dataContext.SaveChanges();
            }
            catch ( Exception ex)
            {
            }
            
        }


    }
}