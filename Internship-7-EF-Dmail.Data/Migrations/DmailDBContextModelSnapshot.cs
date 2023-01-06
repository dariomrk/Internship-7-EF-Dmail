﻿// <auto-generated />
using System;
using Internship_7_EF_Dmail.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Internship_7_EF_Dmail.Data.Migrations
{
    [DbContext(typeof(DmailDBContext))]
    partial class DmailDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.Mail", b =>
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

                    b.Property<bool>("HiddenFromSender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

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
                            CreatedAt = new DateTime(2023, 1, 6, 22, 57, 54, 356, DateTimeKind.Utc).AddTicks(1105),
                            Format = 0,
                            HiddenFromSender = false,
                            SenderId = 1,
                            Title = "First sample mail"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1110),
                            EventDuration = new TimeSpan(0, 0, 1, 0, 0),
                            EventStartAt = new DateTime(2023, 1, 6, 22, 58, 55, 356, DateTimeKind.Utc).AddTicks(1110),
                            Format = 1,
                            HiddenFromSender = false,
                            SenderId = 2,
                            Title = "Testing DMail"
                        });
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.Recipient", b =>
                {
                    b.Property<int>("MailId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("EventStatus")
                        .HasColumnType("integer");

                    b.Property<int>("MailStatus")
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
                            UserId = 2,
                            MailStatus = 0
                        },
                        new
                        {
                            MailId = 1,
                            UserId = 3,
                            MailStatus = 0
                        },
                        new
                        {
                            MailId = 2,
                            UserId = 1,
                            EventStatus = 0,
                            MailStatus = 0
                        },
                        new
                        {
                            MailId = 2,
                            UserId = 3,
                            EventStatus = 0,
                            MailStatus = 0
                        });
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.SpamFlag", b =>
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

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.User", b =>
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

                    b.Property<DateTime>("LastFailedLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1076),
                            Email = "administrator@dmail.hr",
                            LastFailedLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "5845B848BD99AA5475E670D8518D63D142575340C29CEFDF56F5EFEA28068310_CC18CC50FB84BF2EB9C806C10C469716_100000_SHA256",
                            Rights = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1080),
                            Email = "user@dmail.hr",
                            LastFailedLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "CB228A47EACC6C7ABF8F8DA723679F8AB1E26295221090C89E0AFC3282F45519_1903295D3BE77E41AC3ABBE41A35459B_100000_SHA256",
                            Rights = 0,
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 1, 6, 22, 57, 55, 356, DateTimeKind.Utc).AddTicks(1081),
                            Email = "dario@dmail.hr",
                            LastFailedLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Password = "8ECF23A945F94B746FBEC39022F694BC6DAE3D43C551F968F7407D140F79B8FE_9C3A3884E70F8CD724B094A75CEEAF20_100000_SHA256",
                            Rights = 0,
                            Status = 1
                        });
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.Mail", b =>
                {
                    b.HasOne("Internship_7_EF_Dmail.Data.Models.User", "Sender")
                        .WithMany("Sent")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.Recipient", b =>
                {
                    b.HasOne("Internship_7_EF_Dmail.Data.Models.Mail", "Mail")
                        .WithMany("Recipients")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_EF_Dmail.Data.Models.User", "User")
                        .WithMany("Recieved")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.SpamFlag", b =>
                {
                    b.HasOne("Internship_7_EF_Dmail.Data.Models.User", "FlaggedUser")
                        .WithMany()
                        .HasForeignKey("FlaggedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Internship_7_EF_Dmail.Data.Models.User", "User")
                        .WithMany("Flagged")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FlaggedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.Mail", b =>
                {
                    b.Navigation("Recipients");
                });

            modelBuilder.Entity("Internship_7_EF_Dmail.Data.Models.User", b =>
                {
                    b.Navigation("Flagged");

                    b.Navigation("Recieved");

                    b.Navigation("Sent");
                });
#pragma warning restore 612, 618
        }
    }
}
