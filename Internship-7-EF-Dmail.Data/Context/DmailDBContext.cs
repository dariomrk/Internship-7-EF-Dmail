using Microsoft.EntityFrameworkCore;

namespace Internship_7_EF_Dmail.Data.Context
{
    public class DmailDBContext : DbContext
    {
        public DmailDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
