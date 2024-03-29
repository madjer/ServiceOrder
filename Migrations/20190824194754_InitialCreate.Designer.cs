﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190824194754_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("API.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int?>("ClientId");

                    b.Property<string>("Neighborhood");

                    b.Property<int>("Number");

                    b.Property<int?>("ProviderId");

                    b.Property<string>("State");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Document");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<int?>("ProviderId");

                    b.Property<int?>("ServiceOrderId");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ServiceOrderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("API.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("Prediction");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("API.Models.ServiceOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ServiceOrders");
                });

            modelBuilder.Entity("API.Models.Telephone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClientId");

                    b.Property<int>("Number");

                    b.Property<int?>("ProviderId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Telephones");
                });

            modelBuilder.Entity("API.Models.Address", b =>
                {
                    b.HasOne("API.Models.Client")
                        .WithMany("Addresses")
                        .HasForeignKey("ClientId");

                    b.HasOne("API.Models.Provider")
                        .WithMany("Addresses")
                        .HasForeignKey("ProviderId");
                });

            modelBuilder.Entity("API.Models.Product", b =>
                {
                    b.HasOne("API.Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId");

                    b.HasOne("API.Models.ServiceOrder")
                        .WithMany("UsedProducts")
                        .HasForeignKey("ServiceOrderId");
                });

            modelBuilder.Entity("API.Models.ServiceOrder", b =>
                {
                    b.HasOne("API.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("API.Models.Telephone", b =>
                {
                    b.HasOne("API.Models.Client")
                        .WithMany("Telephones")
                        .HasForeignKey("ClientId");

                    b.HasOne("API.Models.Provider")
                        .WithMany("Telephones")
                        .HasForeignKey("ProviderId");
                });
#pragma warning restore 612, 618
        }
    }
}
