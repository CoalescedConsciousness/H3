﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webshop.Data;

#nullable disable

namespace Webshop.Migrations
{
    [DbContext(typeof(WebshopContext))]
    [Migration("20221110111939_1111")]
    partial class _1111
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Webshop.DAL.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Webshop.DAL.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Webshop.DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Test Product 1",
                            Price = 10f
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Test Product 2",
                            Price = 20f
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Test Product 3",
                            Price = 30f
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Test Product 4",
                            Price = 40f
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Test Product 5",
                            Price = 50f
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            Name = "Test Product 6",
                            Price = 60f
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            Name = "Test Product 7",
                            Price = 70f
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            Name = "Test Product 8",
                            Price = 80f
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            Name = "Test Product 9",
                            Price = 90f
                        });
                });

            modelBuilder.Entity("Webshop.DAL.Models.Order", b =>
                {
                    b.HasOne("Webshop.DAL.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Webshop.DAL.Models.Product", b =>
                {
                    b.HasOne("Webshop.DAL.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Webshop.DAL.Models.Order", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
