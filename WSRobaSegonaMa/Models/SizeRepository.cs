using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class SizeRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Size> GetAllSizes()
        {
            List<Size> lc = dataContext.Sizes.ToList();
            return lc;
        }

        
    }
}