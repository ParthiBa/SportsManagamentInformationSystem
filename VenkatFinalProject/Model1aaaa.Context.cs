﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VenkatFinalProject
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SportsFacilityEntities5aaaaaaa : DbContext
    {
        public SportsFacilityEntities5aaaaaaa()
            : base("name=SportsFacilityEntities5aaaaaaa")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<availabilityFriday> availabilityFridays { get; set; }
        public virtual DbSet<availabilityMonday> availabilityMondays { get; set; }
        public virtual DbSet<availabilitySaturday> availabilitySaturdays { get; set; }
        public virtual DbSet<availabilitySunday> availabilitySundays { get; set; }
        public virtual DbSet<availabilityThursday> availabilityThursdays { get; set; }
        public virtual DbSet<availabilityTuesday> availabilityTuesdays { get; set; }
        public virtual DbSet<availabilityWednesday> availabilityWednesdays { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}