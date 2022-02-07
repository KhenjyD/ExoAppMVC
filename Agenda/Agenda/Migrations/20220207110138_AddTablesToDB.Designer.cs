﻿// <auto-generated />
using System;
using Agenda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Agenda.Migrations
{
    [DbContext(typeof(AgendaDbConnect))]
    [Migration("20220207110138_AddTablesToDB")]
    partial class AddTablesToDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Agenda.Models.Appointment", b =>
                {
                    b.Property<int>("idAppointment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idAppointment"), 1L, 1);

                    b.Property<DateTime>("dateHour")
                        .HasColumnType("datetime2");

                    b.Property<int>("idBroker")
                        .HasColumnType("int");

                    b.Property<int>("idCustomer")
                        .HasColumnType("int");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idAppointment");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Agenda.Models.Broker", b =>
                {
                    b.Property<int>("idBroker")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idBroker"), 1L, 1);

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("idBroker");

                    b.ToTable("Brokers");
                });

            modelBuilder.Entity("Agenda.Models.Customer", b =>
                {
                    b.Property<int>("idCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCustomer"), 1L, 1);

                    b.Property<int>("budget")
                        .HasColumnType("int");

                    b.Property<string>("firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("idCustomer");

                    b.ToTable("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}