﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Udem.WebApi.Data;

namespace Udem.WebApi.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Udem.WebApi.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Teknoloji"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Giyim"
                        });
                });

            modelBuilder.Entity("Udem.WebApi.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 11, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(708),
                            Name = "Telefon",
                            Price = 10000m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 9, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(2260),
                            Name = "Bilgisayar",
                            Price = 20000m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 10, 10, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(2271),
                            Name = "Buzdolabı",
                            Price = 25000m,
                            Stock = 20
                        });
                });

            modelBuilder.Entity("Udem.WebApi.Data.Product", b =>
                {
                    b.HasOne("Udem.WebApi.Data.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Udem.WebApi.Data.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
