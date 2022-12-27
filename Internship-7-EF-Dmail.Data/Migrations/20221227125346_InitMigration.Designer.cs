﻿// <auto-generated />
using System;
using Internship_7_EF_Dmail.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    [DbContext(typeof(DmailDBContext))]
    [Migration("20221227125346_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan?>("EventDuration")
                        .HasColumnType("interval");

                    b.Property<DateTime?>("EventStartAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Format")
                        .HasColumnType("integer");

                    b.Property<int>("SenderId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.Recipient", b =>
                {
                    b.Property<int>("MailId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("EventStatus")
                        .HasColumnType("integer");

                    b.HasKey("MailId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.SpamFlag", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("FlaggedUserId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "FlaggedUserId");

                    b.HasIndex("FlaggedUserId");

                    b.ToTable("SpamFlags");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rights")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.Mail", b =>
                {
                    b.HasOne("Internship_7_EF_Dmail.Data.Entities.Models.User", "Sender")
                        .WithMany("Sent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.Recipient", b =>
                {
                    b.HasOne("Internship_7_EF_Dmail.Data.Entities.Models.Mail", "Mail")
                        .WithMany("Recipients")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_EF_Dmail.Data.Entities.Models.User", "User")
                        .WithMany("Recieved")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.SpamFlag", b =>
                {
                    b.HasOne("Internship_7_EF_Dmail.Data.Entities.Models.User", "FlaggedUser")
                        .WithMany()
                        .HasForeignKey("FlaggedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_EF_Dmail.Data.Entities.Models.User", "User")
                        .WithMany("Flagged")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlaggedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.Mail", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Flagged");

                    b.Navigation("Recieved");

                    b.Navigation("Sent");
                });
#pragma warning restore 612, 618
        }
    }
}
