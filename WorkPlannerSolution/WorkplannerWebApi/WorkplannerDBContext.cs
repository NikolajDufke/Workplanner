namespace WorkPlannerWebApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkPlannerDBContext : DbContext
    {
        public WorkPlannerDBContext()
            : base("name=WorkPlannerDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeInformation> EmployeeInformations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Worktime> Worktimes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access>()
                .Property(e => e.AccessDescription)
                .IsFixedLength();

            modelBuilder.Entity<Access>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Access)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Worktimes)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeeInformation>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInformation>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInformation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInformation>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInformation>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeInformation>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.EmployeeInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
