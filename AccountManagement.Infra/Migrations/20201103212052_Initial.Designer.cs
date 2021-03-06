﻿// <auto-generated />
using System;
using AccountManagement.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountManagement.Infra.Migrations
{
    [DbContext(typeof(AccountManagementContext))]
    [Migration("20201103212052_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountManagement.Infra.Configuration.DbAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AcquisitionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("AcquisitionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("AmountGained")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ArchiveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConsommationEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ConsommationStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
