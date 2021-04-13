using ABAPAI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABAPAI.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Staff>().HasKey(x=> x.Id);
            modelBuilder.Entity<Staff>().Property(x => x.Name_user).HasColumnType("varchar(70)");
            modelBuilder.Entity<Staff>().Property(x => x.Name).HasColumnType("varchar(100)");
            modelBuilder.Entity<Staff>().Property(x => x.Email).HasColumnType("varchar(100)");
            modelBuilder.Entity<Staff>().Property(x => x.Password).HasColumnType("varchar(100)");
            modelBuilder.Entity<Staff>().Property(x => x.Role).HasConversion(typeof(string));
            modelBuilder.Entity<Staff>().Property(x => x.CPF).HasColumnType("varchar()");
            modelBuilder.Entity<Staff>().Property(x => x.CNPJ).HasColumnType("varchar()");
            modelBuilder.Entity<Staff>().Property(x => x.StateRegistration).HasColumnType("varchar(9)");
            modelBuilder.Entity<Staff>().Property(x => x.Description).HasColumnType("varchar(200)");
            modelBuilder.Entity<Staff>().Property(x => x.DDD).HasColumnType("varchar(3)");
            modelBuilder.Entity<Staff>().Property(x => x.Phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<Staff>().Property(x => x.Image).HasColumnType("varchar(120)");
            // TODO = verificar parâmetro passado pelo blob (azure) para a imagem

        }
    }
}

