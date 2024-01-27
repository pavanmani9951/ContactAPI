﻿// <auto-generated />
using System;
using ContactAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240127105903_secondmigration")]
    partial class secondmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactAPI.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Sap",
                            CreatedDate = new DateTime(2024, 1, 27, 16, 29, 2, 861, DateTimeKind.Local).AddTicks(978),
                            FirstName = "Pavan",
                            LastName = "manikanta",
                            Phone = 9951658045L
                        },
                        new
                        {
                            Id = 2,
                            City = "GNT",
                            CreatedDate = new DateTime(2024, 1, 27, 16, 29, 2, 861, DateTimeKind.Local).AddTicks(1001),
                            FirstName = "Harini",
                            LastName = "Devathi",
                            Phone = 9381272144L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
