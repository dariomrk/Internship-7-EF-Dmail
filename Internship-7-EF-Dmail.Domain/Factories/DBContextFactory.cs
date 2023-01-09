using Internship_7_EF_Dmail.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Internship_7_EF_Dmail.Domain.Factories
{
    public static class DBContextFactory
    {
        public static DmailDBContext CreateDBContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["DmailApp"].ConnectionString)
                .Options;

            return new DmailDBContext(options);
        }
    }
}
