namespace WorkplannerWebApi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WorkplannerDBContext : DbContext
    {
        public WorkplannerDBContext()
            : base("name=WorkplannerDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Access> Accesses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
