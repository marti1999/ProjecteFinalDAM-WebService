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
    
    public partial class Gender
    {
        public int Id { get; set; }
        public string gender1 { get; set; }
        public bool active { get; set; }
        public int Clothes_Id { get; set; }
    
        public virtual Cloth Cloth { get; set; }
    }
}
