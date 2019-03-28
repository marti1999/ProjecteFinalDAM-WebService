using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSRobaSegonaMa.Controllers;


namespace WSRobaSegonaMa.Models
{
    public class LanguageRepository
    {

        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();

        public static List<Language> GetAllLanguages()
        {
            List<Language> lc = dataContext.Languages.ToList();
            return lc;
        }

        public static Language GetLanguage(int langId)
        {
            Language c = dataContext.Languages.Where(x => x.Id == langId).SingleOrDefault();
            return c;
        }

        public static List<Language> SearchLanguagesByCode(string langCode)
        {
            List<Language> lc = dataContext.Languages
                .Where(x => x.code.Contains(langCode)).ToList();
            return lc;
        }
        
    }
}