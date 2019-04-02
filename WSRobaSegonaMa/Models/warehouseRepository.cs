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
    }
}