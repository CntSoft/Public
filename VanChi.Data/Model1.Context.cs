﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VanChi.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FMSDBEntities : DbContext
    {
        public FMSDBEntities()
            : base("name=FMSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<M_Supplier> M_Supplier { get; set; }
        public virtual DbSet<M_SupplierVehicle> M_SupplierVehicle { get; set; }
        public virtual DbSet<M_Vehicle> M_Vehicle { get; set; }
        public virtual DbSet<M_VehicleBodyType> M_VehicleBodyType { get; set; }
        public virtual DbSet<M_VehicleFuelType> M_VehicleFuelType { get; set; }
        public virtual DbSet<M_VehicleMake> M_VehicleMake { get; set; }
        public virtual DbSet<M_VehicleModel> M_VehicleModel { get; set; }
        public virtual DbSet<M_VehicleType> M_VehicleType { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuRole> MenuRoles { get; set; }
        public virtual DbSet<Quote_Request> Quote_Request { get; set; }
        public virtual DbSet<Quote_RequestVehicle> Quote_RequestVehicle { get; set; }
        public virtual DbSet<Res_Request> Res_Request { get; set; }
        public virtual DbSet<Res_RequestVehicle> Res_RequestVehicle { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ServicesContract> ServicesContracts { get; set; }
        public virtual DbSet<ServicesContractDate> ServicesContractDates { get; set; }
        public virtual DbSet<ServicesContractRate> ServicesContractRates { get; set; }
        public virtual DbSet<SystemLog> SystemLogs { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }
        public virtual DbSet<M_City> M_City { get; set; }
        public virtual DbSet<M_Country> M_Country { get; set; }
        public virtual DbSet<M_Services> M_Services { get; set; }
        public virtual DbSet<M_ServicesType> M_ServicesType { get; set; }
    }
}
