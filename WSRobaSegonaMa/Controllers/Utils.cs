using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}