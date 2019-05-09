using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WSRobaSegonaMa.Controllers;

namespace WSRobaSegonaMa.Models
{
    public class DonorRepository
    {

        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities(false);

        public static List<Donor> GetAllDonors()
        {
            List<Donor> lc = dataContext.Donors.ToList();
            return lc;
        }

        public static Donor GetDonor(int donorID)
        {
            Donor c = dataContext.Donors.Where(x => x.Id == donorID).SingleOrDefault();
            return c;
        }

        public static List<Donor> SearchDonorsByDni(string donorDni)
        {
            List<Donor> lc = dataContext.Donors
                .Where(x => x.dni.Contains(donorDni)).ToList();
            return lc;
        }

        public static Donor InsertDonor(Donor c)
        {
            try
            {
                if (c.ammountGiven == null)
                {
                    c.ammountGiven = 0;
                }

                if (c.points == null)
                {
                    c.points = 0;
                }
                dataContext.Donors.Add(c);
                dataContext.SaveChanges();
                dataContext = new RobaSegonaMaEntities();
                return GetDonor(c.Id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Donor UpdateDonor(int id, Donor c)
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
                if (c.points != null) c0.points = c.points;



                dataContext.SaveChanges();
                dataContext = new RobaSegonaMaEntities();
                return GetDonor(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Donor UpdateDonorPassword(int id, Donor c)
        {
            try
            {
                Donor c0 = dataContext.Donors.Where(x => x.Id == id).SingleOrDefault();

                if (c.password != null) c0.password = c.password;


                dataContext.SaveChanges();
                return GetDonor(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public static Donor DeleteDonor(String id)
        {
            Donor c;
            if (Utils.validInt(id))
            {
                int idInt = int.Parse(id);
                c = dataContext.Donors.Where(x => x.Id == idInt || x.dni.Equals(id)).SingleOrDefault();
            }
            else
            {
                c = dataContext.Donors.Where(x => x.dni.Equals(id)).SingleOrDefault();
            }

            if (c != null)
            {
                dataContext.Donors.Remove(c);
                dataContext.SaveChanges();
                dataContext = new RobaSegonaMaEntities();
            }

            return new Donor();
        }

        public static bool UpdatePoints(Donor newDonor)
        {
            Donor d = GetDonor(newDonor.Id);

            int valorFinal = d.points + newDonor.points;
            if (valorFinal < 0)
            {
                return false;
            }

            return true;
        }

        public static bool CanLogin(Donor a)
        {
            List<Donor> lc = GetAllDonors();

            Donor donor = lc.Where(x => x.password == a.password && x.email == a.email).FirstOrDefault();
            if (donor != null)
            {
                return true;
            }
            return false;
        }

        public static string CanLoginBoth(Donor a)
        {
            List<Donor> lc = GetAllDonors();
            Donor donor = lc.Where(x => x.password == a.password && x.email == a.email && x.active == true).FirstOrDefault();

            List<Requestor> lr = RequestorRepository.GetAllRequestors();
           // Requestor requestor = lr.Where(x => x.password == a.password && x.email == a.email && x.active == true && x.Status.status1.ToLower().Equals("activated")).FirstOrDefault();
            Requestor requestor = lr.Where(x => x.password == a.password && x.email == a.email && x.active == true && x.Status_Id == 2).FirstOrDefault();

            if (donor != null || requestor != null)
            {
                if (donor != null)
                {
                    return "true-" + "Donor-" + donor.Id;
                }
                else
                {
                    return "true-" + "Requestor-" + requestor.Id;
                }

            }
            return "false";
        }

        public static string getSecurityQuestionByMail(string email)
        {
            List<Donor> lc = GetAllDonors();
            Donor donor = lc.Where(x => x.email == email).FirstOrDefault();

            List<Requestor> lr = RequestorRepository.GetAllRequestors();
            Requestor requestor = lr.Where(x => x.email == email).FirstOrDefault();

            if (donor != null || requestor != null)
            {
                if (donor != null)
                {
                    return donor.securityQuestion;
                }
                else
                {
                    return requestor.securityQuestion;
                }

            }
            return null;
        }

        public static string sendNewPassword(string email, string answer)
        {
            List<Donor> lc = GetAllDonors();
            Donor donor = lc.Where(x => x.email == email && x.securityAnswer.Equals(answer)).FirstOrDefault();

            List<Requestor> lr = RequestorRepository.GetAllRequestors();
            Requestor requestor = lr.Where(x => x.email == email && x.securityAnswer.Equals(answer)).FirstOrDefault();

            if (donor != null || requestor != null)
            {
                string word = "";

                for (int i = 0; i < 5; i++)
                {
                    word += RandomLetter();
                }



                var data = Encoding.UTF8.GetBytes(word);


                byte[] hash;

                using (SHA512 sha = new SHA512Managed())
                {
                    hash = sha.ComputeHash(data);
                }

                string hashString = Encoding.Default.GetString(hash);

                hashString = stringToHex(hashString);
                hashString = hashString.ToLower();




                if (donor != null)
                {
                    donor.password = hashString;
                    UpdateDonor(donor.Id, donor);
                    //dataContext.SaveChanges();

                    return "true-" + word;
                }
                else
                {

                    requestor.password = hashString;
                    RequestorRepository.UpdateRequestor(requestor.Id, requestor);
                    //dataContext.SaveChanges();
                    return "true-" + word;
                }

            }
            return "false-Incorrect answer";
        }

        public static string stringToHex(String text)
        {


            byte[] ba = Encoding.Default.GetBytes(text);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");


            return hexString;
        }

        public static string RandomLetter()

        {
            System.Threading.Thread.Sleep(50);



            string sLetter = " ";

            string[] letters = new string[26]  { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n",

               "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};

            Random rnd = new Random();

            int newRandom = rnd.Next(1, 26);

            sLetter = letters[newRandom];

            return sLetter;

        }



        public static Boolean isUserDuplicated(Donor a)
        {
            List<Donor> lc = GetAllDonors();
            Donor donor = lc.Where(x => x.email == a.email || x.dni.ToLower().Equals(a.dni.ToLower())).FirstOrDefault();

            List<Requestor> lr = RequestorRepository.GetAllRequestors();
            Requestor requestor = lr.Where(x => x.email == a.email || x.dni.ToLower().Equals(a.dni.ToLower())).FirstOrDefault();

            if (donor != null || requestor != null)
            {
                return true;

            }
            return false;
        }

    }
}