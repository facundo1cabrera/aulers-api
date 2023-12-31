﻿// <auto-generated />
using System;
using AulersWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AulersWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230626185126_InitialMigration-UserDb-ItemDb-UserItemDb")]
    partial class InitialMigrationUserDbItemDbUserItemDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AulersWebAPI.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Measurements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceInPesos")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserSellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserSellerId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("AulersWebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailVerificatioCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AulersWebAPI.Models.UserItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("UsersItems");
                });

            modelBuilder.Entity("AulersWebAPI.Models.Item", b =>
                {
                    b.HasOne("AulersWebAPI.Models.User", "UserSeller")
                        .WithMany()
                        .HasForeignKey("UserSellerId");

                    b.Navigation("UserSeller");
                });

            modelBuilder.Entity("AulersWebAPI.Models.UserItem", b =>
                {
                    b.HasOne("AulersWebAPI.Models.Item", "Item")
                        .WithMany("UserItemPreselected")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AulersWebAPI.Models.User", "User")
                        .WithMany("UserItemPreselected")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AulersWebAPI.Models.Item", b =>
                {
                    b.Navigation("UserItemPreselected");
                });

            modelBuilder.Entity("AulersWebAPI.Models.User", b =>
                {
                    b.Navigation("UserItemPreselected");
                });
#pragma warning restore 612, 618
        }
    }
}
