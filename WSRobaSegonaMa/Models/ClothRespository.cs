using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSRobaSegonaMa.Controllers;

namespace WSRobaSegonaMa.Models
{
    public class ClothRespository
    {

        private static RobaSegonaMaEntities dc = new RobaSegonaMaEntities();

        public static List<Cloth> GetAllCLothes()
        {
            List<Cloth> lc = dc.Clothes.ToList();
            return lc;
        }

        public static Cloth getCLoth(int id)
        {
            Cloth c = dc.Clothes.Where(x => x.Id == id).FirstOrDefault();
            return c;
        }

        public static Cloth insertCloth(Cloth c)
        {
            try
            {
                dc.Clothes.Add(c);
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
#pragma warning disable CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                if (c.active != null)
#pragma warning restore CS0472 // The result of the expression is always the same since a value of this type is never equal to 'null'
                {
                    c2.active = c.active;
                }

                if (c.ClothesRequest_Id != null) c2.ClothesRequest_Id = c.ClothesRequest_Id;
                if (c.Color_Id != null) c2.Color_Id = c.Color_Id;
                if (c.Gender_Id != null) c2.Gender_Id = c.Gender_Id;
                if (c.Size_Id != null) c2.Size_Id = c.Size_Id;
                if (c.Type_Id != null) c2.Type_Id = c.Type_Id;
                if (c.Warehouse_Id != null) c2.Type_Id = c.Type_Id;
                if (c.dateCreated != null) c2.dateCreated = c.dateCreated;
                
                //TODO falten alguns atributs, potser

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