using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class OrderRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();
        public static Order insertOrder (Order o)
        {

            try
            {
                dataContext.Orders.Add(o);
                dataContext.SaveChanges();

                Cloth c = dataContext.Clothes.Where(x => x.Id == o.Cloth.Id).FirstOrDefault();
                c.active = false;

             //   Requestor r = dataContext.Requestors.Where(x => x.Id = o.Requestor.Id).FirstOrDefault();
                

                return o;

            }
            catch (Exception e)
            {
                return null;

            }
        }
    }
}