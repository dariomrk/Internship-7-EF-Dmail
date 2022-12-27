//using Internship_7_EF_Dmail.Data.Entities.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Internship_7_EF_Dmail.Data.Seeds
//{
//    public static class DMailSeeder
//    {
//        public static void Seed(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>()
//                .HasData(new List<User>()
//                {
//                    new User()
//                    {
//                        Id = 1,
//                        Email = "administrator@dmail.hr",
//                        Password = "password",
//                        CreatedAt = DateTime.UtcNow,
//                        Status = Enums.UserStatus.Active,
//                        Rights = Enums.UserRights.Elevated,
//                    },
//                    new User()
//                    {
//                        Id = 2,
//                        Email = "korisnik@dmail.hr",
//                        Password = "password",
//                        CreatedAt= DateTime.UtcNow,
//                        Status= Enums.UserStatus.Active,
//                        Rights = Enums.UserRights.Standard,
//                    }
//                }
//                );
//        }
//    }
//}
