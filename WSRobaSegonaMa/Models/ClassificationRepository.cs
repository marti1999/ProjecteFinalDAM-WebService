using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class ClassificationRepository
    {

        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Classification> GetAllClassifications()
        {
            List<Classification> lc = dataContext.Classifications.ToList();
            return lc;
        }

        public static List<Classification> GetAllClassificationCat()
            {
            List<Classification> lc = dataContext.Classifications.ToList();

            List<Name> ln = dataContext.Names.Where(x => x.itemType.ToLower().Contains("classification") && x.Language_Id == 3).ToList();

            foreach (Classification i in lc)
            {
                Name n = dataContext.Names
                    .SingleOrDefault(x => x.itemType.ToLower().Contains("classification") && x.Language_Id == 3 && x.itemId == i.Id);

                if (n != null)
                {
                    i.classificationType = n.nameInLanguage;

                }

            }

            return lc;
        }
    }
}