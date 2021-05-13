
using ABAPAI.Domain.Entities;
using ABAPAI.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace ABAPAI.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<AddressTemplate> addressTemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Staff>().HasKey(x => x.Id);
            modelBuilder.Entity<Staff>().Property(x => x.Name_user).HasColumnType("varchar(70)").IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Name).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Password).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Role).HasConversion(x => x.ToString(), x => (Roles)Enum.Parse(typeof(Roles), x)).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.CPF).HasColumnType("varchar(255)");
            modelBuilder.Entity<Staff>().Property(x => x.CNPJ).HasColumnType("varchar(255)");
            modelBuilder.Entity<Staff>().Property(x => x.StateRegistration).HasColumnType("varchar(20)");
            modelBuilder.Entity<Staff>().Property(x => x.Description).HasColumnType("varchar(200)");
            modelBuilder.Entity<Staff>().Property(x => x.DDD).HasColumnType("varchar(3)");
            modelBuilder.Entity<Staff>().Property(x => x.Phone).HasColumnType("varchar(10)");
            modelBuilder.Entity<Staff>().Property(x => x.Image).HasColumnType("varchar(120)");

            modelBuilder.Entity<AddressTemplate>().ToTable("Address");
            modelBuilder.Entity<AddressTemplate>().HasKey(x => x.Id_address);
            modelBuilder.Entity<AddressTemplate>().Property(x => x.State).HasColumnType("varchar(3)");
            modelBuilder.Entity<AddressTemplate>().Property(x => x.Address).HasColumnType("varchar(150)");
            modelBuilder.Entity<AddressTemplate>().Property(x => x.City).HasColumnType("varchar(70)");
            modelBuilder.Entity<AddressTemplate>().Property(x => x.Postal_code).HasColumnType("varchar(50)");
            //modelBuilder.Entity<AddressTemplate>().Property(x => x.Id_user).HasColumnType("varchar(50)");         
            modelBuilder.Entity<Staff>().HasOne(x => x.Address).WithOne(y => y.Staff).HasForeignKey<AddressTemplate>(y => y.Id_user);

            // TODO = verificar parâmetro passado pelo blob (azure) para a imagem

        }
    }
}

