using Internship_7_EF_Dmail.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Internship_7_EF_Dmail.Data.Seeds
{
    public static class DMailSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new List<User>()
                {
                    new User()
                    {
                        Id = 1,
                        Email = "administrator@dmail.hr",
                        // Password: administrator-password
                        Password = "6372EA190AC157A4AFE6BD34B6D107A5B502785396C7A9C2A2FAC9E76DC5F676_87CA606D69D409AC3422D3ED1561ABD2_10000_SHA256",
                        CreatedAt = DateTime.UtcNow,
                        Status = Enums.UserStatus.Active,
                        Rights = Enums.UserRights.Elevated,
                    },
                    new User()
                    {
                        Id = 2,
                        Email = "user@dmail.hr",
                        // Password: user-password
                        Password = "FD570FB17E4042EEA75E9F9DC05C1E7B13807BFB5C156BA5C9181C49D8DC39D8_2EAF520C6EF88385B9B1BEB7E9D9170C_10000_SHA256",
                        CreatedAt = DateTime.UtcNow,
                        Status = Enums.UserStatus.Active,
                        Rights = Enums.UserRights.Standard,
                    },
                    new User()
                    {
                        Id = 3,
                        Email = "dario@dmail.hr",
                        // Password: password
                        Password = "9AE1940F019AB31BA6BFD29F59EA05EBAEC5DBBE99DE041FB65A6354AC2A110B_0B5843ABC5E5C10F493916C0790CC01A_10000_SHA256",
                        CreatedAt = DateTime.UtcNow,
                        Status = Enums.UserStatus.Active,
                        Rights = Enums.UserRights.Standard,
                    },
                });

            modelBuilder.Entity<Mail>()
                .HasData(new List<Mail>()
                {
                    new Mail()
                    {
                        Id = 1,
                        SenderId = 1,
                        Title = "First sample mail",
                        CreatedAt = DateTime.UtcNow,
                        Format = Enums.MailFormat.Email,
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    },
                    new Mail()
                    {
                        Id = 2,
                        SenderId = 2,
                        Title = "Testing DMail",
                        CreatedAt = DateTime.UtcNow,
                        Format = Enums.MailFormat.Event,
                        EventStartAt = DateTime.UtcNow.AddMinutes(1),
                        EventDuration = TimeSpan.FromMinutes(1),
                    },
                });

            modelBuilder.Entity<Recipient>()
                .HasData(new List<Recipient>()
                {
                    new Recipient()
                    {
                        MailId = 1,
                        UserId = 2,
                    },
                    new Recipient()
                    {
                        MailId = 1,
                        UserId = 3,
                    },
                    new Recipient()
                    {
                        MailId = 2,
                        UserId = 1,
                        EventStatus = Enums.EventStatus.NoResponse,
                    },
                    new Recipient()
                    {
                        MailId = 2,
                        UserId = 3,
                        EventStatus = Enums.EventStatus.NoResponse,
                    },
                });

            modelBuilder.Entity<SpamFlag>()
                .HasData(new List<SpamFlag>()
                {
                    new SpamFlag()
                    {
                        UserId = 1,
                        FlaggedUserId = 2,
                    },
                    new SpamFlag()
                    {
                        UserId = 1,
                        FlaggedUserId = 3,
                    },
                    new SpamFlag()
                    {
                        UserId = 2,
                        FlaggedUserId = 3,
                    },
                });
        }
    }
}
