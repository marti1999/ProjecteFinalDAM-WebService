//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSRobaSegonaMa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RewardInfoLang
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int Language_Id { get; set; }
        public int Rewards_Id { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Reward Reward { get; set; }
    }
}
