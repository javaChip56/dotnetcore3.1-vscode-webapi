using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ClientApi.Models;

namespace ClientApi.Context
{
    public partial class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=localhost,1466;Database=ClientDB;User Id=sa;Password=D0ckerSQL123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Clientname)
                    .HasColumnName("clientname")
                    .HasMaxLength(100);

                entity.Property(e => e.Clientno)
                    .HasColumnName("clientno")
                    .HasMaxLength(20);

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(20);

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("date");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(20);

                entity.Property(e => e.Updateddate)
                    .HasColumnName("updateddate")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
