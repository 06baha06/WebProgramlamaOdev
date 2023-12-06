﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProgramlamaOdev.Models;

#nullable disable

namespace WebProgramlamaOdev.Migrations
{
    [DbContext(typeof(BolumlerContext))]
    partial class BolumlerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("WebProgramlamaOdev.Models.Bolum", b =>
                {
                    b.Navigation("Doktorlar");
                });

            modelBuilder.Entity("WebProgramlamaOdev.Models.Doktor", b =>
                {
                    b.Navigation("Saatler");
                });
#pragma warning restore 612, 618
        }
    }
}
