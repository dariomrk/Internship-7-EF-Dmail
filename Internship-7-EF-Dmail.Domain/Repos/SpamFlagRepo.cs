using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;

namespace Internship_7_EF_Dmail.Domain.Repos
{
    public class SpamFlagRepo : BaseRepo
    {
        public SpamFlagRepo(DmailDBContext context) : base(context)
        {
        }

        /// <summary>
        /// Returns a collection of flagged users from the given user account.
        /// </summary>
        /// <param name="userId">User account id.</param>
        /// <returns>Collection of flagged users.</returns>
        public ICollection<User> GetFlaggedUsers(int userId)
        {
            return context.SpamFlags
                .Where(sf => sf.UserId == userId)
                .Join(context.Users,
                sf => sf.FlaggedUserId,
                u => u.Id,
                (sf, u) => new {sf,u})
                .Select(a => a.u)
                .ToList();
        }
    }
}
