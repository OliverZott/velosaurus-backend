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
    [DbContext(typeof(TourDbContext))]
    [Migration("20240222104251_DescriptionAdded")]
    partial class DescriptionAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                        .HasColumnType("text");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TourType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
