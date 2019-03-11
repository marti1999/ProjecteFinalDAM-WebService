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
    
    public partial class Requestor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Requestor()
        {
            this.ClothesRequests = new HashSet<ClothesRequest>();
            this.Orders = new HashSet<Order>();
        }
    
        public string dni { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public System.DateTime birthDate { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string securityAnswer { get; set; }
        public string securityQuestion { get; set; }
        public System.DateTime dateCreated { get; set; }
        public bool active { get; set; }
        public double householdIncome { get; set; }
        public int householdMembers { get; set; }
        public string picturePath { get; set; }
        public int Id { get; set; }
        public int Language_Id { get; set; }
        public int MaxClaims_Id { get; set; }
        public int Status_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClothesRequest> ClothesRequests { get; set; }
        public virtual Language Language { get; set; }
        public virtual MaxClaim MaxClaim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        public virtual Status Status { get; set; }
    }
}
