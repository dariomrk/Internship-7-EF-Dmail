using Internship_7_EF_Dmail.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Internship_7_EF_Dmail.Domain.Factories
{
    public static class DBContextFactory
    {
        public static DmailDBContext GetDmailDBContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Dmail"].ConnectionString)
                .Options;

            return new DmailDBContext(options);
        }
    }
}
