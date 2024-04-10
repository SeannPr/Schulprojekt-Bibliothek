﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Schulprojekt_Bibliothek.DCF;

#nullable disable

namespace Schulprojekt_Bibliothek.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20240410165708_NewStuffNewFixes")]
    partial class NewStuffNewFixes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Schulprojekt_Bibliothek.Ausleihungen", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AbgabeDatum")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("AusleihDatum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Buch")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Userld")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Userld");

                    b.ToTable("Ausleihungen");
                });

            modelBuilder.Entity("Schulprojekt_Bibliothek.Buch", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Bücher")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Seiten")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Buche");
                });

            modelBuilder.Entity("Schulprojekt_Bibliothek.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Pin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Stadt")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Tel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Userld")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Schulprojekt_Bibliothek.Ausleihungen", b =>
                {
                    b.HasOne("Schulprojekt_Bibliothek.User", "User")
                        .WithMany("Ausleihungen")
                        .HasForeignKey("Userld")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Schulprojekt_Bibliothek.User", b =>
                {
                    b.Navigation("Ausleihungen");
                });
#pragma warning restore 612, 618
        }
    }
}
