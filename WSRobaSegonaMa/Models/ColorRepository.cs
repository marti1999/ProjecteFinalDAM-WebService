using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class ColorRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Color> GetAllColors()
        {
            List<Color> lc = dataContext.Colors.ToList();
            return lc;
        }
    }
}