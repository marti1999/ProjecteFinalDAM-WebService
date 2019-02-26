using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WSRobaSegonaMa.Models
{
    public partial class Language
    {

        public bool ShouldSerializeAdministrators()
        {
            return serialitzable;
        }
        public bool ShouldSerializeDonors()
        {
            return serialitzable;
        }
        public bool ShouldSerializeNames()
        {
            return serialitzable;
        }
        public bool ShouldSerializeRequestors()
        {
            return serialitzable;
        }
        public bool ShouldSerializeRewardInfoLangs()
        {
            return serialitzable;
        }

        [JsonIgnore]
        public bool serialitzable = false;
    }
}