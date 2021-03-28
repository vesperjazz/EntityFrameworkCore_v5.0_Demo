using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameworkCoreDemo.DatabaseFirst.DomainEntities
{
    public partial class EFCoreDemoContext : DbContext
    {
        public EFCoreDemoContext()
        {
        }

        public EFCoreDemoContext(DbContextOptions<EFCoreDemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IVANCHIN-XPS;Database=EFCoreDemo;User Id=sa; Password=blablabla;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .IsUnique()
                    .HasFilter("([Code] IS NOT NULL)");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.GenderId);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.GenderId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
