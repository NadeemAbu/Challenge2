﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Challenge2Entities : DbContext
    {
        public Challenge2Entities()
            : base("name=Challenge2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Procedure> Procedures { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<OwnerView> OwnerViews { get; set; }
        public virtual DbSet<PetView> PetViews { get; set; }
        public virtual DbSet<ProcedureView> ProcedureViews { get; set; }
        public virtual DbSet<TreatmentView> TreatmentViews { get; set; }
    }
}
