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
                .Where(x => x.dni.Contains(donorDni)).ToList();
            return lc;
        }

        public static Administrator InsertAdministrator(Donor c)
        {
            try
            {
                dataContext.Administrators.Add(c);
                dataContext.SaveChanges();
                return GetDonor(c.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Donor UpdateAdministrator(int id, Donor c)
        {
            try
            {
                Donor c0 = dataContext.Donors.Where(x => x.Id == id).SingleOrDefault();
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
                if (c.ammountGiven != null) c0.ammountGiven = c.ammountGiven;
                if (c.Language != null) c0.Language = c.Language;
                if (c.dni != null) c0.dni = c.dni;

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
            Donor c;
            if (Utils.validInt(id))
            {
                int idInt = int.Parse(id);
                c = dataContext.Donors.Where(x => x.Id == id || x.dni.Equals(id)).SingleOrDefault();
            }
            else
            {
                c = dataContext.Donors.Where(x => x.dni.Equals(id)).SingleOrDefault();
            }

            if (c != null)
            {
                dataContext.Donors.Remove(c);
                dataContext.SaveChanges();
            }
        }

    }
}