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
    
    public partial class Donor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Donor()
        {
            this.Rewards = new HashSet<Reward>();
        }
    
        public int Id { get; set; }
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
        public string picturePath { get; set; }
        public Nullable<int> ammountGiven { get; set; }
        public string dni { get; set; }
        public int points { get; set; }
        public int Language_Id { get; set; }
    
        public virtual Language Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
