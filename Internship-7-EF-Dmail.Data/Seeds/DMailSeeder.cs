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
                        Password = "5845B848BD99AA5475E670D8518D63D142575340C29CEFDF56F5EFEA28068310_CC18CC50FB84BF2EB9C806C10C469716_100000_SHA256",
                        CreatedAt = DateTime.UtcNow,
                        Status = Enums.UserStatus.Active,
                        Rights = Enums.UserRights.Elevated,
                    },
                    new User()
                    {
                        Id = 2,
                        Email = "user@dmail.hr",
                        // Password: user-password
                        Password = "CB228A47EACC6C7ABF8F8DA723679F8AB1E26295221090C89E0AFC3282F45519_1903295D3BE77E41AC3ABBE41A35459B_100000_SHA256",
                        CreatedAt = DateTime.UtcNow,
                        Status = Enums.UserStatus.Active,
                        Rights = Enums.UserRights.Standard,
                    },
                    new User()
                    {
                        Id = 3,
                        Email = "dario@dmail.hr",
                        // Password: password
                        Password = "8ECF23A945F94B746FBEC39022F694BC6DAE3D43C551F968F7407D140F79B8FE_9C3A3884E70F8CD724B094A75CEEAF20_100000_SHA256",
                        CreatedAt = DateTime.UtcNow,
                        Status = Enums.UserStatus.Active,
                        Rights = Enums.UserRights.Standard,
                    }
                });

            modelBuilder.Entity<Mail>()
                .HasData(new List<Mail>()
                {
                    new Mail()
                    {
                        Id = 1,
                        SenderId = 1,
                        Title = "First sample mail",
                        CreatedAt = DateTime.UtcNow.AddHours(-1),
                        Format = Enums.MailFormat.Email,
                        Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
                    },
                    new Mail()
                    {
                        Id = 2,
                        SenderId = 2,
                        Title = "Testing DMail Events",
                        CreatedAt = DateTime.UtcNow.AddMinutes(-10),
                        Format = Enums.MailFormat.Event,
                        EventStartAt = DateTime.UtcNow.AddMinutes(1),
                        EventDuration = TimeSpan.FromMinutes(1),
                    },
                    new Mail()
                    {
                        Id = 3,
                        SenderId = 1,
                        Title = "Hello there",
                        CreatedAt = DateTime.UtcNow.AddSeconds(-1),
                        Format = Enums.MailFormat.Email,
                        Content = "Hello world from the admin.",
                    },
                    new Mail()
                    {
                        Id = 4,
                        SenderId = 1,
                        Title = "Hello there again",
                        CreatedAt = DateTime.UtcNow,
                        Format = Enums.MailFormat.Email,
                        Content = "This one should arrive a bit later.",
                    }
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
                    new Recipient()
                    {
                        MailId = 3,
                        UserId = 3,
                    },
                    new Recipient()
                    {
                        MailId = 4,
                        UserId = 3,
                    }
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
