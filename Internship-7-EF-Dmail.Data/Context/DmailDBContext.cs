﻿using Internship_7_EF_Dmail.Data.Entities.Models;
using Internship_7_EF_Dmail.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Internship_7_EF_Dmail.Data.Context
{
    public class DmailDBContext : DbContext
    {
        public DmailDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Mail> Mails => Set<Mail>();
        public DbSet<Recipient> Recipients => Set<Recipient>();
        public DbSet<SpamFlag> SpamFlags => Set<SpamFlag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User configuration
            var userEntity = modelBuilder.Entity<User>();

            userEntity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(64);

            userEntity.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(64);

            userEntity.Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("timezone('utc', now())");

            userEntity.Property(u => u.Status)
                .IsRequired()
                .HasDefaultValue(UserStatus.Active);

            userEntity.Property(u => u.Rights)
                .IsRequired()
                .HasDefaultValue(UserRights.Standard);

            #endregion

            #region Mail configuration
            var mailEntity = modelBuilder.Entity<Mail>();

            mailEntity.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(64);

            mailEntity.Property(m => m.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("timezone('utc', now())");

            mailEntity.Property(m => m.Format)
                .IsRequired();

            #endregion

            #region SpamFlag configuration
            var spamFlagEntity = modelBuilder.Entity<SpamFlag>();

            spamFlagEntity.HasKey(sf => new { sf.UserId, sf.FlaggedUserId });

            spamFlagEntity.HasOne(sf => sf.User)
                .WithMany(u => u.Flagged)
                .HasForeignKey(sf => sf.UserId);

            #endregion

            #region Recipient configuration
            var recipientEntity = modelBuilder.Entity<Recipient>();
            
            recipientEntity.HasKey(r => new { r.MailId, r.UserId });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
    public class DmailDBContextFactory : IDesignTimeDbContextFactory<DmailDBContext>
    {
        public DmailDBContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddXmlFile("App.config")
                .Build();

            config.Providers
                .First()
                .TryGet("connectionStrings:add:DmailApp:connectionString", out var connectionString);

            var options = new DbContextOptionsBuilder<DmailDBContext>()
                .UseNpgsql(connectionString)
                .Options;
            
            return new DmailDBContext(options);
        }
    }
}
