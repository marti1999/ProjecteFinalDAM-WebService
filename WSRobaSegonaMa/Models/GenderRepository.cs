﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class GenderRepository
    {
        private static RobaSegonaMaEntities dc = new RobaSegonaMaEntities();

        public static List<Gender> GetAllGenders()
        {
            List<Gender> lc = dc.Genders.ToList();
            return lc;
        }

        public static Gender getGenderByName(string name)
        {
            name = name.ToLower();

            Gender c = dc.Genders.Where(x => x.gender1.ToLower().Equals(name)).FirstOrDefault();
            return c;
        }
    }
}