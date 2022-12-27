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
    [Migration("20221227165551_Feature-Added-Mail-Status")]
    partial class FeatureAddedMailStatus
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                            CreatedAt = new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1778),
                            Format = 0,
                            SenderId = 1,
                            Title = "First sample mail"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1780),
                            EventDuration = new TimeSpan(0, 0, 1, 0, 0),
                            EventStartAt = new DateTime(2022, 12, 27, 16, 56, 50, 850, DateTimeKind.Utc).AddTicks(1781),
                            Format = 1,
                            SenderId = 2,
                            Title = "Testing DMail"
                        });
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.Recipient", b =>
                {
                    b.Property<int>("MailId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("EventStatus")
                        .HasColumnType("integer");

                    b.Property<int?>("MailStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.HasKey("MailId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Recipients");

                    b.HasData(
                        new
                        {
                            MailId = 1,
                            UserId = 2
                        },
                        new
                        {
                            MailId = 1,
                            UserId = 3
                        },
                        new
                        {
                            MailId = 2,
                            UserId = 1
                        },
                        new
                        {
                            MailId = 2,
                            UserId = 3
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FlaggedUserId = 2
                        },
                        new
                        {
                            UserId = 1,
                            FlaggedUserId = 3
                        },
                        new
                        {
                            UserId = 2,
                            FlaggedUserId = 3
                        });
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("timezone('utc', now())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Rights")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1749),
                            Email = "administrator@dmail.hr",
                            Password = "6372EA190AC157A4AFE6BD34B6D107A5B502785396C7A9C2A2FAC9E76DC5F676_87CA606D69D409AC3422D3ED1561ABD2_10000_SHA256",
                            Rights = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1752),
                            Email = "user@dmail.hr",
                            Password = "FD570FB17E4042EEA75E9F9DC05C1E7B13807BFB5C156BA5C9181C49D8DC39D8_2EAF520C6EF88385B9B1BEB7E9D9170C_10000_SHA256",
                            Rights = 0,
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2022, 12, 27, 16, 55, 50, 850, DateTimeKind.Utc).AddTicks(1753),
                            Email = "dario@dmail.hr",
                            Password = "9AE1940F019AB31BA6BFD29F59EA05EBAEC5DBBE99DE041FB65A6354AC2A110B_0B5843ABC5E5C10F493916C0790CC01A_10000_SHA256",
                            Rights = 0,
                            Status = 1
                        });
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
