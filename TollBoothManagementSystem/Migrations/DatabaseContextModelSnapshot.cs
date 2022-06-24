﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TollBoothManagementSystem.Core.Persistence;

#nullable disable

namespace TollBoothManagementSystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.General.Model.Currency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.General.Model.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PostalCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.FaultReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfReport")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ReporterId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TollBoothId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReporterId");

                    b.HasIndex("TollBoothId");

                    b.ToTable("FaultReports");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollBooth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsETC")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTollGateFunctional")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsTrafficLightFunctional")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TollStationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TollStationId");

                    b.ToTable("TollBooths");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BossId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BossId");

                    b.HasIndex("LocationId");

                    b.HasIndex("SectionId");

                    b.ToTable("TollStations");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.ElectronicTollCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("Credit")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("LastEnteredStationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicencePlateNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LastEnteredStationId");

                    b.ToTable("ElectronicTollCollections");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EnterTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RoadTollPriceId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TollBoothId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoadTollPriceId");

                    b.HasIndex("TollBoothId");

                    b.ToTable("Payments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Payment");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.PriceList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ActivationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadToll", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("TollStationId")
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("TollStationId");

                    b.ToTable("RoadTolls");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadTollPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<Guid>("PriceListId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoadTollId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PriceListId");

                    b.HasIndex("RoadTollId");

                    b.ToTable("RoadTollPrices");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("OriginId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.SectionInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("Distance")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TollStationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.HasIndex("TollStationId");

                    b.ToTable("SectionInfos");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ReferentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TollBoothId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReferentId");

                    b.HasIndex("TollBoothId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.ETCPayment", b =>
                {
                    b.HasBaseType("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Payment");

                    b.Property<Guid>("ElectronicTollCollectionId")
                        .HasColumnType("TEXT");

                    b.HasIndex("ElectronicTollCollectionId");

                    b.HasDiscriminator().HasValue("ETCPayment");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadTollPayment", b =>
                {
                    b.HasBaseType("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Payment");

                    b.Property<string>("LicencePlateNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("RoadTollPayment");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Administrator", b =>
                {
                    b.HasBaseType("TollBoothManagementSystem.Core.Features.UserManagement.Model.User");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Employee", b =>
                {
                    b.HasBaseType("TollBoothManagementSystem.Core.Features.UserManagement.Model.User");

                    b.Property<Guid?>("TollStationId")
                        .HasColumnType("TEXT");

                    b.HasIndex("TollStationId");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Manager", b =>
                {
                    b.HasBaseType("TollBoothManagementSystem.Core.Features.UserManagement.Model.Employee");

                    b.HasDiscriminator().HasValue("Manager");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Referent", b =>
                {
                    b.HasBaseType("TollBoothManagementSystem.Core.Features.UserManagement.Model.Employee");

                    b.HasDiscriminator().HasValue("Referent");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.FaultReport", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.UserManagement.Model.Referent", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollBooth", "TollBooth")
                        .WithMany()
                        .HasForeignKey("TollBoothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reporter");

                    b.Navigation("TollBooth");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollBooth", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "TollStation")
                        .WithMany("TollBooths")
                        .HasForeignKey("TollStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TollStation");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.UserManagement.Model.Referent", "Boss")
                        .WithMany()
                        .HasForeignKey("BossId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.General.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Section", null)
                        .WithMany("TollStations")
                        .HasForeignKey("SectionId");

                    b.Navigation("Boss");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.ElectronicTollCollection", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "LastEnteredStation")
                        .WithMany()
                        .HasForeignKey("LastEnteredStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LastEnteredStation");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Payment", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadTollPrice", "RoadTollPrice")
                        .WithMany()
                        .HasForeignKey("RoadTollPriceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollBooth", "TollBooth")
                        .WithMany()
                        .HasForeignKey("TollBoothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoadTollPrice");

                    b.Navigation("TollBooth");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.PriceList", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadToll", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.General.Model.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "TollStation")
                        .WithMany()
                        .HasForeignKey("TollStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("TollStation");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadTollPrice", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.PriceList", "PriceList")
                        .WithMany()
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.RoadToll", "RoadToll")
                        .WithMany()
                        .HasForeignKey("RoadTollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PriceList");

                    b.Navigation("RoadToll");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Section", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destination");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.SectionInfo", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Section", "Section")
                        .WithMany()
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "TollStation")
                        .WithMany()
                        .HasForeignKey("TollStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("TollStation");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Shift", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.UserManagement.Model.Referent", "Referent")
                        .WithMany()
                        .HasForeignKey("ReferentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollBooth", "TollBooth")
                        .WithMany()
                        .HasForeignKey("TollBoothId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Referent");

                    b.Navigation("TollBooth");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.ETCPayment", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.ElectronicTollCollection", "ElectronicTollCollection")
                        .WithMany()
                        .HasForeignKey("ElectronicTollCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectronicTollCollection");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.UserManagement.Model.Employee", b =>
                {
                    b.HasOne("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", "TollStation")
                        .WithMany("Employees")
                        .HasForeignKey("TollStationId");

                    b.Navigation("TollStation");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.Infrastructure.Model.TollStation", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("TollBooths");
                });

            modelBuilder.Entity("TollBoothManagementSystem.Core.Features.TransactionManagement.Model.Section", b =>
                {
                    b.Navigation("TollStations");
                });
#pragma warning restore 612, 618
        }
    }
}
