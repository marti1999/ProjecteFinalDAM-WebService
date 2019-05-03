using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class warehouseRepository
    {
        private static RobaSegonaMaEntities dc = new RobaSegonaMaEntities(false);

        public static List<Warehouse> GetAllWarehouses()
        {
            List<Warehouse> lc = dc.Warehouses.ToList();
            return lc;
        }

        public static Warehouse addWarehouse(Warehouse w)
        {
            dc.Warehouses.Add(w);
            dc.SaveChanges();
            return w;
        }

        public static Warehouse updateWarehuse(int id, Warehouse w)

        {

            Warehouse w1 = dc.Warehouses.Where(x => x.Id == id).FirstOrDefault();
            w1.street = w.street;
            w1.city = w.city;
            w1.number = w.number;
            w1.postalCode = w.postalCode;
            w1.name = w.name;


           
            dc.SaveChanges();
            return w1;
        }

        public static List<Warehouse> getWarehousesByCloth(Cloth c)
        {
            List<Warehouse> lw = null;

            List<Cloth> lc = null;
            lc = dc.Clothes.Where(x => x.Size_Id == c.Size_Id && x.Color_Id == c.Color_Id && x.Classification_Id == c.Classification_Id && c.Gender_Id == x.Gender_Id).ToList();

            foreach (Cloth cloth in lc)
            {
                if (!lw.Contains(cloth.Warehouse))
                {
                    lw.Add(cloth.Warehouse);
                }
            }




            return lw;
        }
    }
}