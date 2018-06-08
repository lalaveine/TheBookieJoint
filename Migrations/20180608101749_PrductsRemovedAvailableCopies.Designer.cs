﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TheBookieJoint.Models;

namespace TheBookieJoint.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180608101749_PrductsRemovedAvailableCopies")]
    partial class PrductsRemovedAvailableCopies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TheBookieJoint.Models.CartLine", b =>
                {
                    b.Property<int>("CartLineID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderID");

                    b.Property<int?>("ProductID");

                    b.Property<int>("Quantity");

                    b.HasKey("CartLineID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartLine");
                });

            modelBuilder.Entity("TheBookieJoint.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("GiftWrap");

                    b.Property<string>("Line1")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Line2")
                        .HasMaxLength(100);

                    b.Property<string>("Line3")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(100);

                    b.Property<bool>("Shipped");

                    b.HasKey("OrderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TheBookieJoint.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1500);

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("NumberOfCopies");

                    b.Property<string>("OriginalLanguage")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<decimal>("Price");

                    b.Property<string>("PublicationYear")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Translators")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TheBookieJoint.Models.CartLine", b =>
                {
                    b.HasOne("TheBookieJoint.Models.Order")
                        .WithMany("Lines")
                        .HasForeignKey("OrderID");

                    b.HasOne("TheBookieJoint.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");
                });
#pragma warning restore 612, 618
        }
    }
}
