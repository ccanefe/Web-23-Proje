﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proje.Context;

#nullable disable

namespace Proje.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231231012741_AddMesai")]
    partial class AddMesai
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proje.Models.Doktor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UzmanlikId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UzmanlikId");

                    b.ToTable("Doktor");
                });

            modelBuilder.Entity("Proje.Models.Mesai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("BaslangicZamani")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("BitisZamani")
                        .HasColumnType("time");

                    b.Property<int?>("DoktorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.ToTable("Mesai");
                });

            modelBuilder.Entity("Proje.Models.MesaiGunu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Gun")
                        .HasColumnType("int");

                    b.Property<int?>("MesaiId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MesaiId");

                    b.ToTable("MesaiGunu");
                });

            modelBuilder.Entity("Proje.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TcNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Proje.Models.Uzmanlik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("UzmanlikAdi")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("UzmanlikAdiEng")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Uzmanlik");
                });

            modelBuilder.Entity("Proje.Models.Doktor", b =>
                {
                    b.HasOne("Proje.Models.Uzmanlik", "Uzmanlik")
                        .WithMany()
                        .HasForeignKey("UzmanlikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uzmanlik");
                });

            modelBuilder.Entity("Proje.Models.Mesai", b =>
                {
                    b.HasOne("Proje.Models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("Proje.Models.MesaiGunu", b =>
                {
                    b.HasOne("Proje.Models.Mesai", "Mesai")
                        .WithMany("CalistigiGunler")
                        .HasForeignKey("MesaiId");

                    b.Navigation("Mesai");
                });

            modelBuilder.Entity("Proje.Models.Mesai", b =>
                {
                    b.Navigation("CalistigiGunler");
                });
#pragma warning restore 612, 618
        }
    }
}
