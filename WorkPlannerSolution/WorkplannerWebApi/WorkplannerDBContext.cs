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

        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeInformation>  EmployeeInformations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WorkPlannerDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Access>(entity =>
            {
                entity.HasKey(e => e.AccessLevel)
                    .HasName("PK__Access__6697619B4A2D88F6");

                entity.ToTable("Access");

                entity.Property(e => e.AccessLevel).ValueGeneratedNever();

                entity.Property(e => e.AccessDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EinformationId).HasColumnName("EInformationID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Einformation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EinformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmployeeInformation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Users");
            });

            modelBuilder.Entity<EmployeeInformation>(entity =>
            {
                entity.HasKey(e => e.EinformationId)
                    .HasName("PK__tmp_ms_x__1FD944B674616FCA");

                entity.ToTable("EmployeeInformation");

                entity.Property(e => e.EinformationId).HasColumnName("EInformationID");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.AccessLevelNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccessLevel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Access");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}