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
    
    public partial class Administrator
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public System.DateTime dateCreated { get; set; }
        public bool isSuper { get; set; }
        public bool active { get; set; }
        public string workerCode { get; set; }
        public int Language_Id { get; set; }
        public int Warehouse_Id { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
