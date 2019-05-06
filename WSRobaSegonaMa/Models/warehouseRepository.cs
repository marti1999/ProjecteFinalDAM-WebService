using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            lc = lc.OrderBy(x => x.city).ToList();


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
            List<Warehouse> lw = new List<Warehouse>();
            bool first = true;
            List<Cloth> lc = null;
            lc = dc.Clothes.Where(x => x.Size_Id == c.Size_Id && x.Color_Id == c.Color_Id && x.Classification_Id == c.Classification_Id && c.Gender_Id == x.Gender_Id && x.active == true).ToList();

            foreach (Cloth cloth in lc)
            {
                if (first)
                {
                    Warehouse w = dc.Warehouses.Where(x => x.Id == cloth.Warehouse_Id).FirstOrDefault();
                    lw.Add(w);
                    first = false;
                }
                else if (!lw.Contains(cloth.Warehouse))
                {
                    Warehouse w = dc.Warehouses.Where(x => x.Id == cloth.Warehouse_Id).FirstOrDefault();
                    lw.Add(w);
                }
            }

            if (lw != null)
            {
                lw = lw.OrderBy(x => x.city).ToList();
            }



            return lw;
        }
    }
}