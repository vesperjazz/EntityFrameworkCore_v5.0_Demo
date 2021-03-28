using EntityFrameworkCoreDemo.CodeFirst.DomainEntities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFrameworkCoreDemo.CodeFirst
{
    public class EFCoreDemoContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Gender> Genders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IVANCHIN-PC;Database=EFCoreDemo;User Id=sa; Password=blablabla;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Person Configuration
            modelBuilder.Entity<Person>()
                .ToTable(nameof(Person));
            // EntityFramework uses convention over configuration.
            //modelBuilder.Entity<Person>()
            //    .HasKey(p => p.ID);
            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(200);
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Gender)
                .WithMany(g => g.Persons)
                .HasForeignKey(p => p.GenderID);
            #endregion

            #region Gender
            modelBuilder.Entity<Gender>()
                .ToTable(nameof(Gender));
            //modelBuilder.Entity<Gender>()
            //    .HasKey(g => g.ID);
            modelBuilder.Entity<Gender>()
                .HasIndex(g => g.Code).IsUnique();
            modelBuilder.Entity<Gender>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(20);
            //modelBuilder.Entity<Gender>()
            //    .HasMany(g => g.Persons)
            //    .WithOne(p => p.Gender)
            //    .HasForeignKey(p => p.GenderID);
            modelBuilder.Entity<Gender>().HasData(
                new Gender { ID = new Guid("f093de04-28cf-4e10-82a8-b711e5b40da3"), Code = "F", Name = "Female" }, 
                new Gender { ID = new Guid("dd33c96a-8152-4266-9cbb-111af45befe9"), Code = "M", Name = "Male" }, 
                new Gender { ID = new Guid("3b8b18c5-d28a-43b3-a095-da15db73b668"), Code = "U", Name = "Unknown" });
            #endregion
        }
    }
}
