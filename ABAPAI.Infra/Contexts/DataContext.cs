
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

        public DbSet<Event> Event { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region STAFF
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
            #endregion

            #region ADDRESS
            modelBuilder.Entity<AddressTemplate>().ToTable("Address");
            modelBuilder.Entity<AddressTemplate>().HasKey(x => x.Id_address);
            modelBuilder.Entity<AddressTemplate>().Property(x => x.State).HasColumnType("varchar(3)");
            modelBuilder.Entity<AddressTemplate>().Property(x => x.Address).HasColumnType("varchar(150)");
            modelBuilder.Entity<AddressTemplate>().Property(x => x.City).HasColumnType("varchar(70)");
            modelBuilder.Entity<AddressTemplate>().Property(x => x.Postal_code).HasColumnType("varchar(50)");
            //modelBuilder.Entity<AddressTemplate>().Property(x => x.Id_user).HasColumnType("varchar(50)");         
            modelBuilder.Entity<Staff>().HasOne(x => x.Address).WithOne(y => y.Staff).HasForeignKey<AddressTemplate>(y => y.Id_user);
            modelBuilder.Entity<Event>().HasOne(x => x.Address).WithOne(y => y.Event).HasForeignKey<AddressTemplate>(y => y.Id_event);
            #endregion

            #region EVENT
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Event>().HasKey(x => x.Id);
            modelBuilder.Entity<Event>().Property(x => x.Title).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.Description).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.Image).HasColumnType("varchar(120)").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.DateTimeStart).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.DateTimeEnd).HasColumnType("Date").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.EventCategory).HasConversion(x => x.ToString(), x => (EventCategory)Enum.Parse(typeof(EventCategory), x)).IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.ValueEvent).HasConversion(x => x.ToString(), x => (ValueEvent)Enum.Parse(typeof(ValueEvent), x)).IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.DDD).HasColumnType("varchar(3)").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.Phone).HasColumnType("varchar(10)").IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.Name_url).HasColumnType("varchar(60)");
            modelBuilder.Entity<Event>().Property(x => x.URL).HasColumnType("varchar(300)");
            modelBuilder.Entity<Event>().HasOne(x => x.staff).WithMany(b => b.Events).HasForeignKey(x => x.Staff_ForeignKey);
            #endregion

            #region FAN
            modelBuilder.Entity<Fan>().ToTable("Fan");
            modelBuilder.Entity<Fan>().HasKey(x => x.Id);
            modelBuilder.Entity<Fan>().Property(x => x.Name).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Fan>().Property(x => x.Email).HasColumnType("varchar(300)").IsRequired();
            modelBuilder.Entity<Fan>().Property(x => x.Image).HasColumnType("varchar(500)").IsRequired();
            modelBuilder.Entity<Fan>().Property(x => x.IdFirebase).HasColumnType("varchar(300)").IsRequired();
            modelBuilder.Entity<Fan>().Property(x => x.SignInProvider).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Fan>().Property(x => x.CPF).HasColumnType("varchar(15)");
            #endregion

            #region TICKET
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<Ticket>().HasKey(x => x.Id);
            modelBuilder.Entity<Ticket>().HasOne(a => a.Event).WithMany(b => b.Tickets).HasForeignKey(c => c.Id_eventFK);
            modelBuilder.Entity<Ticket>().HasOne(a => a.Fan).WithMany(b => b.Tickets).HasForeignKey(c => c.Id_fanFK);
            modelBuilder.Entity<Ticket>().Property(x => x.QrCode).HasColumnType("varchar(500)");
            #endregion



        }
    }
}

