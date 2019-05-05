using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class ColorRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities(false);



        public static List<Color> GetAllColors()
        {
            List<Color> lc = dataContext.Colors.ToList();
            return lc;
        }

        public static Color getColorByCode(string code)
        {
            Color c = dataContext.Colors.Where(x => x.colorCode.Equals(code)).FirstOrDefault();
            return c;
        }


        public static Color GetColor(int colorId)
        {
            Color c = dataContext.Colors.Where(x => x.Id == colorId).SingleOrDefault();
            return c;
        }
    }
}