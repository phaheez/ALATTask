﻿// <auto-generated />
using System;
using ALAT.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ALAT.Infrastructure.Migrations
{
    [DbContext(typeof(CustomerContext))]
    [Migration("20220710232315_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ALAT.Core.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<int?>("LgaId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LgaId");

                    b.HasIndex("StateId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ALAT.Core.Entities.Lga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Lgas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lagos Island",
                            StateId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Lagos Mainland",
                            StateId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ikorodu",
                            StateId = 1
                        },
                        new
                        {
                            Id = 4,
                            Name = "Saki",
                            StateId = 2
                        },
                        new
                        {
                            Id = 5,
                            Name = "Iseyin",
                            StateId = 2
                        },
                        new
                        {
                            Id = 6,
                            Name = "Oorelope",
                            StateId = 2
                        },
                        new
                        {
                            Id = 7,
                            Name = "Shagamu",
                            StateId = 3
                        },
                        new
                        {
                            Id = 8,
                            Name = "Abeokuta",
                            StateId = 3
                        });
                });

            modelBuilder.Entity("ALAT.Core.Entities.Otp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("Passcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("ALAT.Core.Entities.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lagos"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Oyo"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ogun"
                        });
                });

            modelBuilder.Entity("ALAT.Core.Entities.Customer", b =>
                {
                    b.HasOne("ALAT.Core.Entities.Lga", "Lga")
                        .WithMany()
                        .HasForeignKey("LgaId");

                    b.HasOne("ALAT.Core.Entities.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("ALAT.Core.Entities.Lga", b =>
                {
                    b.HasOne("ALAT.Core.Entities.State", "State")
                        .WithMany("Lgas")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ALAT.Core.Entities.Otp", b =>
                {
                    b.HasOne("ALAT.Core.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
