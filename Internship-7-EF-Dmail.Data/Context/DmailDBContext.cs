using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Data.Seeds;
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
                .IsRequired();

            userEntity.HasIndex(u => u.Email)
                .IsUnique();

            userEntity.Property(u => u.Password)
                .IsRequired();

            userEntity.Property(u => u.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("timezone('utc', now())");

            userEntity.Property(u => u.Status)
                .IsRequired()
                .HasDefaultValue(UserStatus.Active);

            userEntity.Property(u => u.Rights)
                .IsRequired()
                .HasDefaultValue(UserRights.Standard);

            userEntity.Property(u => u.LastFailedLogin)
                .IsRequired()
                .HasDefaultValue(DateTime.MinValue);

            #endregion

            #region Mail configuration
            var mailEntity = modelBuilder.Entity<Mail>();

            mailEntity.Property(m => m.Title)
                .IsRequired();

            mailEntity.Property(m => m.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("timezone('utc', now())");

            mailEntity.Property(m => m.HiddenFromSender)
                .IsRequired()
                .HasDefaultValue(false);

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

            recipientEntity.Property(r => r.MailStatus)
                .IsRequired()
                .HasDefaultValue(MailStatus.Unread);

            #endregion

            DMailSeeder.Seed(modelBuilder);

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
