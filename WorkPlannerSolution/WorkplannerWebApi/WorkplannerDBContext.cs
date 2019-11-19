﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorkplannerWebApi
{
    public partial class WorkplannerDBContext : DbContext
    {
        public WorkplannerDBContext()
        {
        }

        public WorkplannerDBContext(DbContextOptions<WorkplannerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Worktime> Worktimes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("C:\\Users\\West\\Source\\Repos\\NikolajDufke\\Workplanner\\WorkPlannerSolution\\WorkPlannerDB\\bin\\Debug\\WorkPlannerDB.dacpac");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Worktime>(entity =>
            {
                entity.ToTable("Worktime");

                entity.Property(e => e.WorkTimeId)
                    .HasColumnName("WorkTimeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}