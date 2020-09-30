﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Monafasati.Data;

namespace Monafasati.Data.Migrations
{
    [DbContext(typeof(MonafasatiDbContext))]
    [Migration("20200912114746_editSadad")]
    partial class editSadad
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Monafasati.Core.Entity.Engineer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Monafasati.Core.Entity.Monafsa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Advertiser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PdfFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<double>("Sadad")
                        .HasColumnType("float");

                    b.Property<int>("StatuId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineerId");

                    b.HasIndex("StatuId");

                    b.ToTable("Monafsas");
                });

            modelBuilder.Entity("Monafasati.Core.Entity.Statu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Monafasati.Core.Entity.Monafsa", b =>
                {
                    b.HasOne("Monafasati.Core.Entity.Engineer", "Engineer")
                        .WithMany()
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Monafasati.Core.Entity.Statu", "Statu")
                        .WithMany()
                        .HasForeignKey("StatuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
