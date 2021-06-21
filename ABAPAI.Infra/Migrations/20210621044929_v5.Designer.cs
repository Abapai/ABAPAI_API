﻿// <auto-generated />
using System;
using ABAPAI.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABAPAI.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210621044929_v5")]
    partial class v5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABAPAI.Domain.Entities.AddressTemplate", b =>
                {
                    b.Property<Guid>("Id_address")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(70)");

                    b.Property<Guid?>("Id_event")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Postal_code")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(3)");

                    b.HasKey("Id_address");

                    b.HasIndex("Id_event")
                        .IsUnique()
                        .HasFilter("[Id_event] IS NOT NULL");

                    b.HasIndex("Id_user")
                        .IsUnique()
                        .HasFilter("[Id_user] IS NOT NULL");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DDD")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("Date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("EmitQrCode")
                        .HasColumnType("bit");

                    b.Property<string>("EventCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Name_url")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("PublicLimit")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("QuantityConfirmed")
                        .HasColumnType("int");

                    b.Property<Guid>("Staff_ForeignKey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("URL")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("ValueEvent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Staff_ForeignKey");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Fan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("IdFirebase")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SignInProvider")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Fan");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Staff", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CPF")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("DDD")
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Free")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name_user")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateRegistration")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_eventFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_fanFK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Payment")
                        .HasColumnType("bit");

                    b.Property<string>("QrCode")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Id_eventFK");

                    b.HasIndex("Id_fanFK");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.AddressTemplate", b =>
                {
                    b.HasOne("ABAPAI.Domain.Entities.Event", "Event")
                        .WithOne("Address")
                        .HasForeignKey("ABAPAI.Domain.Entities.AddressTemplate", "Id_event");

                    b.HasOne("ABAPAI.Domain.Entities.Staff", "Staff")
                        .WithOne("Address")
                        .HasForeignKey("ABAPAI.Domain.Entities.AddressTemplate", "Id_user");

                    b.Navigation("Event");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Event", b =>
                {
                    b.HasOne("ABAPAI.Domain.Entities.Staff", "staff")
                        .WithMany("Events")
                        .HasForeignKey("Staff_ForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("staff");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("ABAPAI.Domain.Entities.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("Id_eventFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ABAPAI.Domain.Entities.Fan", "Fan")
                        .WithMany("Tickets")
                        .HasForeignKey("Id_fanFK");

                    b.Navigation("Event");

                    b.Navigation("Fan");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Event", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Fan", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Staff", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
