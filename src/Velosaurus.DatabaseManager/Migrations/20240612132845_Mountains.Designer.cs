﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Velosaurus.DatabaseManager;

#nullable disable

namespace Velosaurus.DatabaseManager.Migrations
{
    [DbContext(typeof(VelosaurusDbContext))]
    [Migration("20240612132845_Mountains")]
    partial class Mountains
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Velosaurus.DatabaseManager.Models.Mountain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Region")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Mountains");
                });

            modelBuilder.Entity("Velosaurus.DatabaseManager.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AltitudeGain")
                        .HasColumnType("real");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<int>("MountainId")
                        .HasColumnType("integer");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("TourType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MountainId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Velosaurus.DatabaseManager.Models.Tour", b =>
                {
                    b.HasOne("Velosaurus.DatabaseManager.Models.Mountain", "Mountain")
                        .WithMany("Tours")
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mountain");
                });

            modelBuilder.Entity("Velosaurus.DatabaseManager.Models.Mountain", b =>
                {
                    b.Navigation("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
