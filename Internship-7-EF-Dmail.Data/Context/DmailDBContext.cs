using Internship_7_EF_Dmail.Data.Entities.Models;
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
            modelBuilder.Entity<SpamFlag>()
                .HasKey(sf => new { sf.UserId, sf.FlaggedUserId });

            modelBuilder.Entity<SpamFlag>()
                .HasOne(sf => sf.User)
                .WithMany(u => u.Flagged)
                .HasForeignKey(sf => sf.UserId);

            modelBuilder.Entity<Recipient>()
                .HasKey(r => new { r.MailId, r.UserId });

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
