using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WSRobaSegonaMa.Models
{
    public partial class Color

    {

        public bool ShouldSerializeClothes()
        {
            return serialitzable;
        }

        [JsonIgnore]
        public bool serialitzable = false;
    }
}