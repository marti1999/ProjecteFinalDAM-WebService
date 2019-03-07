﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using WSRobaSegonaMa.Controllers;

namespace WSRobaSegonaMa.Models
{
    public class ClothRespository
    {

        private static RobaSegonaMaEntities dc = new RobaSegonaMaEntities();

        public static List<Cloth> GetAllClothes()
        {
            List<Cloth> lc = dc.Clothes.ToList();
            return lc;
        }

        public static Cloth getCloth(int id)
        {
            Cloth c = dc.Clothes.Where(x => x.Id == id).FirstOrDefault();
            return c;
        }

        public static Cloth insertCloth(Cloth c)
        {
            try
            {
                Cloth c2 = ClothRespository.getCloth(4);
                c2.Id = 7;
               // dc.Clothes.Add(c);
                dc.Clothes.Add(c2);
                dc.SaveChanges();
                return c;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Cloth updateCloth(int id, Cloth c)
        {
            try
            {
                Cloth c2 = dc.Clothes.Where(x => x.Id == id).SingleOrDefault();

                
                if (c.active != null) c2.active = c.active;
                if (c.ClothesRequest != null) c2.ClothesRequest = c.ClothesRequest;
                if (c.Color != null) c2.Color = c.Color;
                if (c.Gender != null) c2.Gender = c.Gender;
                if (c.Size != null) c2.Size = c.Size;
                if (c.Classification != null) c2.Classification = c.Classification;
                if (c.Warehouse != null) c2.Warehouse = c.Warehouse;
                if (c.dateCreated != null) c2.dateCreated = c.dateCreated;
                
                dc.SaveChanges();
                return c2;

            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public static void deleteCloth(int id)
        {
            Cloth c;

            c = dc.Clothes.Where(x => x.Id == id).FirstOrDefault();
            if (c != null) { }
            {
                dc.Clothes.Remove(c);
                dc.SaveChanges();
            }
        }

    }
}