using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSRobaSegonaMa.Controllers;


namespace WSRobaSegonaMa.Models
{
    public class RequestorRepository
    {

        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Requestor> GetAllRequestors()
        {

            try
            {
                List<Requestor> lc = dataContext.Requestors.ToList();
                return lc;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }

        public static Requestor GetRequestor(int requestorID)
        {
            dataContext = new RobaSegonaMaEntities(false);
            Requestor c = dataContext.Requestors.Where(x => x.Id == requestorID).SingleOrDefault();
            c.MaxClaim = dataContext.MaxClaims.Where(x => x.Id == c.MaxClaims_Id).FirstOrDefault();
            
            return c;
        }

        public static List<Requestor> SearchRequestorsByDni(string requestorDni)
        {
            List<Requestor> lc = dataContext.Requestors
                .Where(x => x.dni.Contains(requestorDni)).ToList();
            return lc;
        }

        public static Requestor InsertRequestor(Requestor c)
        {
            try
            {
                dataContext.Requestors.Add(c);
                dataContext.SaveChanges();
                return GetRequestor(c.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Requestor UpdateRequestor(int id, Requestor c)
        {
            try
            {
                Requestor c0 = dataContext.Requestors.Where(x => x.Id == id).SingleOrDefault();
                if (c.name != null) c0.name = c.name;
                if (c.lastName != null) c0.lastName = c.lastName;
                if (c.birthDate != null) c0.birthDate = c.birthDate;
                if (c.gender != null) c0.gender = c.gender;
                if (c.password != null) c0.password = c.password;
                if (c.email != null) c0.email = c.email;
                if (c.securityAnswer != null) c0.securityAnswer = c.securityAnswer;
                if (c.securityQuestion != null) c0.securityQuestion = c.securityQuestion;
                if (c.dateCreated != null) c0.dateCreated = c.dateCreated;
                if (c.active != null) c0.active = c.active;
                if (c.picturePath != null) c0.picturePath = c.picturePath;
                if (c.Language_Id != null) c0.Language_Id = c.Language_Id;
                if (c.dni != null) c0.dni = c.dni;
                if (c.Status_Id != null) c0.Status_Id= c.Status_Id;

                dataContext.SaveChanges();
                return GetRequestor(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Requestor UpdateRequestorPassword(int id, Requestor c)
        {
            try
            {
                Requestor c0 = dataContext.Requestors.Where(x => x.Id == id).SingleOrDefault();
                
                if (c.password != null) c0.password = c.password;
    

                dataContext.SaveChanges();
                return GetRequestor(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteRequestor(String id)
        {
            Requestor c;
            if (Utils.validInt(id))
            {
                int idInt = int.Parse(id);
                c = dataContext.Requestors.Where(x => x.Id == idInt || x.dni.Equals(id)).SingleOrDefault();
            }
            else
            {
                c = dataContext.Requestors.Where(x => x.dni.Equals(id)).SingleOrDefault();
            }

            if (c != null)
            {
                dataContext.Requestors.Remove(c);
                dataContext.SaveChanges();
            }
        }

        public static bool CanLogin(Requestor a)
        {
            List<Requestor> lc = GetAllRequestors();

            Requestor requestor = lc.Where(x => x.password == a.password && x.email == a.email).FirstOrDefault();
            if (requestor != null)
            {
                return true;
            }
            return false;
        }

    }
}