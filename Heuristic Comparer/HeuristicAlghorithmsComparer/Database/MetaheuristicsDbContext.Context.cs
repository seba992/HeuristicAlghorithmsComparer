﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HeuristicAlghorithmsComparer.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EntityDataModelContainer : DbContext
    {
        public EntityDataModelContainer()
            : base("name=EntityDataModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Alghoritm> Alghoritms { get; set; }
        public virtual DbSet<InputParameter> InputParameters { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<ResultDetail> ResultDetails { get; set; }
        public virtual DbSet<ExitFlag> ExitFlags { get; set; }
        public virtual DbSet<TestFunction> TestFunctions { get; set; }
    }
}
