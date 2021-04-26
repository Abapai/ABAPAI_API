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
    [Migration("20210424192953_v2")]
    partial class v2
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

                    b.Property<string>("Country")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Id_user")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Postal_code")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id_address");

                    b.HasIndex("Id_user")
                        .IsUnique();

                    b.ToTable("Address");
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

            modelBuilder.Entity("ABAPAI.Domain.Entities.AddressTemplate", b =>
                {
                    b.HasOne("ABAPAI.Domain.Entities.Staff", "Staff")
                        .WithOne("Address")
                        .HasForeignKey("ABAPAI.Domain.Entities.AddressTemplate", "Id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ABAPAI.Domain.Entities.Staff", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
