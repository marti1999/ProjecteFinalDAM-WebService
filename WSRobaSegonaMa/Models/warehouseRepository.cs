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
    }
}