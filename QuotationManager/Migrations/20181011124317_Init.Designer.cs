﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuotationManager.Models;

namespace QuotationManager.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20181011124317_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuotationManager.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SignificanceLevel");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new { Id = 1, Name = "Красноярск", SignificanceLevel = 10 },
                        new { Id = 2, Name = "Новосибирск", SignificanceLevel = 8 },
                        new { Id = 3, Name = "Москва", SignificanceLevel = 5 },
                        new { Id = 4, Name = "Санкт-Петербург", SignificanceLevel = 6 },
                        new { Id = 5, Name = "Челябинск", SignificanceLevel = 1 }
                    );
                });

            modelBuilder.Entity("QuotationManager.Models.Contribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseSum");

                    b.Property<int>("CityId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Contributions");

                    b.HasData(
                        new { Id = 1, BaseSum = 10, CityId = 1, Name = "Плохая экология" },
                        new { Id = 2, BaseSum = 10, CityId = 1, Name = "Плохие дороги" },
                        new { Id = 3, BaseSum = 3, CityId = 1, Name = "Нет метро" },
                        new { Id = 4, BaseSum = 5, CityId = 2, Name = "Столица Сибири" },
                        new { Id = 5, BaseSum = 8, CityId = 4, Name = "Красивый город" },
                        new { Id = 6, BaseSum = 10, CityId = 3, Name = "Столица России" },
                        new { Id = 7, BaseSum = 10, CityId = 3, Name = "Вечные пробки" },
                        new { Id = 8, BaseSum = 7, CityId = 5, Name = "Плохая экология" }
                    );
                });

            modelBuilder.Entity("QuotationManager.Models.Purpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Purposes");

                    b.HasData(
                        new { Id = 1, Name = "Ипотека" },
                        new { Id = 2, Name = "Потребительский кредит" },
                        new { Id = 3, Name = "Автокредит" }
                    );
                });

            modelBuilder.Entity("QuotationManager.Models.Quota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("Comment")
                        .HasMaxLength(1024);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("EditDate");

                    b.Property<double>("InterestRate");

                    b.Property<int>("PurposeId");

                    b.Property<int>("RefinancingAmount");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PurposeId");

                    b.ToTable("Quotas");
                });

            modelBuilder.Entity("QuotationManager.Models.QuotaContribution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuotaId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("QuotaId");

                    b.ToTable("QuotaContributions");
                });

            modelBuilder.Entity("QuotationManager.Models.Contribution", b =>
                {
                    b.HasOne("QuotationManager.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuotationManager.Models.Quota", b =>
                {
                    b.HasOne("QuotationManager.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuotationManager.Models.Purpose", "Purpose")
                        .WithMany()
                        .HasForeignKey("PurposeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuotationManager.Models.QuotaContribution", b =>
                {
                    b.HasOne("QuotationManager.Models.Quota")
                        .WithMany("QuotaContributions")
                        .HasForeignKey("QuotaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
