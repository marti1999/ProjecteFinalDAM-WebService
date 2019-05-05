using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class SizeRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities(false);

        public static List<Size> GetAllSizes()
        {
            List<Size> lc = dataContext.Sizes.ToList();
            return lc;
        }


        public static Size GetSize(int sizeId)
        {
            Size c = dataContext.Sizes.Where(x => x.Id == sizeId).SingleOrDefault();
            return c;
        }


    }
}