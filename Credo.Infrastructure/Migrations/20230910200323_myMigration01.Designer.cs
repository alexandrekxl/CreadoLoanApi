﻿// <auto-generated />
using System;
using Credo.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Credo.Infrastructure.Migrations
{
    [DbContext(typeof(CredoDbContext))]
    [Migration("20230910200323_myMigration01")]
    partial class myMigration01
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Credo.Domain.Loans.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("LoanType")
                        .HasColumnType("int");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Loan", (string)null);
                });

            modelBuilder.Entity("Credo.Domain.LoansAggregate.Entities.LoanStatuses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanStatuses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "გადაგზავნილი"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "დამუშავების პროცესში"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "დამტკიცებული"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "უარყოფილი"
                        });
                });

            modelBuilder.Entity("Credo.Domain.LoansAggregate.Entities.LoanTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LoanTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LoanTypes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LoanTypeName = "სწრაფი სესხი"
                        },
                        new
                        {
                            Id = 2,
                            LoanTypeName = "ავტო სესხი"
                        },
                        new
                        {
                            Id = 3,
                            LoanTypeName = "განვადება"
                        });
                });

            modelBuilder.Entity("Credo.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Credo.Domain.Users.User", b =>
                {
                    b.OwnsMany("Credo.Domain.Loans.ValueObjects.LoanId", "LoanIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserLoanId");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserLoanIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("LoanIds");
                });
#pragma warning restore 612, 618
        }
    }
}
