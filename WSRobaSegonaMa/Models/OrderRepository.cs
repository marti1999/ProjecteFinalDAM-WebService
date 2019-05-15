using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public class OrderRepository
    {
        private static RobaSegonaMaEntities dataContext = new RobaSegonaMaEntities();
        public static Order insertOrder(Order o)
        {
            dataContext = new RobaSegonaMaEntities();
            try
            {
            
                dataContext.Orders.Add(o);
                dataContext.SaveChanges();

                Cloth c = dataContext.Clothes.Where(x => x.Id == o.Clothes_Id && x.active == true).FirstOrDefault();
                c.active = false;

                Requestor r = dataContext.Requestors.FirstOrDefault(x => x.Id == o.Requestor_Id);

                r.points += c.Classification.value;

                dataContext.SaveChanges();

                return o;

            }
            catch (Exception e)
            {
                return null;

            }
            dataContext = new RobaSegonaMaEntities();
        }
    }
}