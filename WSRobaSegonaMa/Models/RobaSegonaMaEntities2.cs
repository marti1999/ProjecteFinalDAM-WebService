using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSRobaSegonaMa.Models
{
    public partial class RobaSegonaMaEntities

    {
        public RobaSegonaMaEntities(bool enabled)
            : base("name=RobaSegonaMaEntities")
        {
            if (!enabled)
            {
                this.Configuration.LazyLoadingEnabled = false;
                this.Configuration.ProxyCreationEnabled = false;
            }

        }
    }
}