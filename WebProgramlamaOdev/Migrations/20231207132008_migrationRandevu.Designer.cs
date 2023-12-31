﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProgramlamaOdev.Models;

#nullable disable

namespace WebProgramlamaOdev.Migrations
{
    [DbContext(typeof(BolumlerContext))]
    [Migration("20231207132008_migrationRandevu")]
    partial class migrationRandevu
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebProgramlamaOdev.Models.Bolum", b =>
                {
                    b.Property<int>("BolumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BolumID"), 1L, 1);

                    b.Property<string>("BolumAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BolumID");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.CalismaSaati", b =>
                {
                    b.Property<int>("SaatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaatID"), 1L, 1);

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<string>("Saatler")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SaatID");

                    b.HasIndex("DoktorID");

                    b.ToTable("Saatler");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorID"), 1L, 1);

                    b.Property<int>("BolumID")
                        .HasColumnType("int");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DoktorSoyadi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DoktorID");

                    b.HasIndex("BolumID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Hasta", b =>
                {
                    b.Property<int>("HastaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HastaID"), 1L, 1);

                    b.Property<string>("HastaAdSoyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HastaPass")
                        .HasColumnType("int");

                    b.Property<int>("HastaTC")
                        .HasColumnType("int");

                    b.HasKey("HastaID");

                    b.ToTable("Hastalar");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"), 1L, 1);

                    b.Property<int>("BolumID")
                        .HasColumnType("int");

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<int>("HastaID")
                        .HasColumnType("int");

                    b.Property<int>("SaatID")
                        .HasColumnType("int");

                    b.HasKey("RandevuID");

                    b.HasIndex("BolumID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("HastaID");

                    b.HasIndex("SaatID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.CalismaSaati", b =>
                {
                    b.HasOne("WebProgramlamaOdev.Models.Doktor", "Doktor")
                        .WithMany("Saatler")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Doktor", b =>
                {
                    b.HasOne("WebProgramlamaOdev.Models.Bolum", "Bolum")
                        .WithMany("Doktorlar")
                        .HasForeignKey("BolumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Randevu", b =>
                {
                    b.HasOne("WebProgramlamaOdev.Models.Bolum", "Bolum")
                        .WithMany("Randevular")
                        .HasForeignKey("BolumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProgramlamaOdev.Models.Doktor", "Doktor")
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProgramlamaOdev.Models.Hasta", "Hasta")
                        .WithMany("Randevular")
                        .HasForeignKey("HastaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebProgramlamaOdev.Models.CalismaSaati", "Saat")
                        .WithMany("Randevular")
                        .HasForeignKey("SaatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bolum");

                    b.Navigation("Doktor");

                    b.Navigation("Hasta");

                    b.Navigation("Saat");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Bolum", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.CalismaSaati", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Doktor", b =>
                {
                    b.Navigation("Randevular");

                    b.Navigation("Saatler");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Hasta", b =>
                {
                    b.Navigation("Randevular");
                });
#pragma warning restore 612, 618
        }
    }
}
