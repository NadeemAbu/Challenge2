//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int PetID { get; set; }
        public string PetName { get; set; }
        public string Type { get; set; }
        public Nullable<int> OwnerID { get; set; }
    
        public virtual Owner Owner { get; set; }
    }
}