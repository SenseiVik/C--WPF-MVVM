﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarHolding.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarHoldingEntities : DbContext
    {
        public CarHoldingEntities()
            : base("name=CarHoldingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BodyType> BodyType { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<DriveType> DriveType { get; set; }
        public virtual DbSet<ProgramConfig> ProgramConfig { get; set; }
        public virtual DbSet<TransmissionType> TransmissionType { get; set; }
    }
}
