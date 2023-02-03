﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MiniDukan.Models;

namespace MiniDukan.Migrations
{
    [DbContext(typeof(MiniDukkanContext))]
    [Migration("20221010130355_ekleurunler")]
    partial class ekleurunler
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MiniDukan.Models.Urun", b =>
                {
                    b.Property<long>("UrunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Açıklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kategori")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrunAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("fiyat")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("UrunID");

                    b.ToTable("Urunler");
                });
#pragma warning restore 612, 618
        }
    }
}
