﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoCode.FlowerShop.Infrastructure.Persistence;

#nullable disable

namespace NoCode.FlowerShop.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(FlowerShopDbContext))]
    [Migration("20230526132545_AddFlowerTables")]
    partial class AddFlowerTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("NoCode.FlowerShop.Domain.Administrator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Administrators", (string)null);
                });

            modelBuilder.Entity("NoCode.FlowerShop.Domain.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("NoCode.FlowerShop.Domain.Flower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Flowers", (string)null);
                });

            modelBuilder.Entity("NoCode.FlowerShop.Domain.FlowerArrangement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FlowerArrangementCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("StorageQuantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("FlowerArrangementCategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FlowersArrangements", (string)null);
                });

            modelBuilder.Entity("NoCode.FlowerShop.Domain.FlowerArrangementCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FlowersArrangementCategories", (string)null);
                });

            modelBuilder.Entity("NoCode.FlowerShop.Domain.FlowerArrangement", b =>
                {
                    b.HasOne("NoCode.FlowerShop.Domain.FlowerArrangementCategory", "FlowerArrangementCategory")
                        .WithMany()
                        .HasForeignKey("FlowerArrangementCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("NoCode.FlowerShop.Domain.Flowers", "Flowers", b1 =>
                        {
                            b1.Property<Guid>("FlowerArrangementId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("FlowerId")
                                .HasColumnType("TEXT");

                            b1.Property<int>("Quantity")
                                .HasColumnType("INTEGER");

                            b1.HasKey("FlowerArrangementId", "FlowerId");

                            b1.HasIndex("FlowerId");

                            b1.ToTable("FlowersArrangementsFlowers", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("FlowerArrangementId");

                            b1.HasOne("NoCode.FlowerShop.Domain.Flower", "Flower")
                                .WithMany()
                                .HasForeignKey("FlowerId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Flower");
                        });

                    b.Navigation("FlowerArrangementCategory");

                    b.Navigation("Flowers");
                });
#pragma warning restore 612, 618
        }
    }
}
