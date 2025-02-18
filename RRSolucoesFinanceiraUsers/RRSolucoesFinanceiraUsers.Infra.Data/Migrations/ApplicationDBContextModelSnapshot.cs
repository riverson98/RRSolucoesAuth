﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RRSolucoesFinanceiraUsers.Infra.Data.Context;

#nullable disable

namespace RRSolucoesFinanceiraUsers.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DateUpload")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("Number")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ProofOfResidencePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.DocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateUpload")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumberOfDocument")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("NumberOfDocument")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Document");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.PhoneEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<int>("TypeOfContact")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("IsRegistrationComplete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("PhotoPath")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Sex")
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntityRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("RequiredAddress")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("RequiredDocument")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("RequiredPhone")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Roles")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("User_role");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.AddressEntity", b =>
                {
                    b.HasOne("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntity", "User")
                        .WithOne("Address")
                        .HasForeignKey("RRSolucoesFinanceiraUsers.Domain.Entities.AddressEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.DocumentEntity", b =>
                {
                    b.HasOne("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntity", "User")
                        .WithOne("Document")
                        .HasForeignKey("RRSolucoesFinanceiraUsers.Domain.Entities.DocumentEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.PhoneEntity", b =>
                {
                    b.HasOne("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntity", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntityRoles", b =>
                {
                    b.HasOne("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntity", "User")
                        .WithOne("Role")
                        .HasForeignKey("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntityRoles", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RRSolucoesFinanceiraUsers.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Document");

                    b.Navigation("Phones");

                    b.Navigation("Role")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
