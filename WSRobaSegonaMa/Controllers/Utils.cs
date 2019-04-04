using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using WSRobaSegonaMa.Models;

namespace WSRobaSegonaMa.Controllers
{
    public static class Utils
    {
        public static bool validInt(String number)
        {
            bool validInt = false;
            try
            {
                int numberInt = int.Parse(number);
                validInt = true;
                return validInt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return validInt;
            }
        }
        public static int getIdLang(string lang)
        {

            Language l = LanguageRepository.SearchLanguagesByCode(lang).FirstOrDefault();


            return l.Id;
        }
    }


}