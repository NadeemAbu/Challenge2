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
    
    public partial class TreatmentView
    {
        public int TreatmentID { get; set; }
        public string PetName { get; set; }
        public Nullable<int> OwnerID { get; set; }
        public Nullable<int> ProcedureID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Notes { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}
