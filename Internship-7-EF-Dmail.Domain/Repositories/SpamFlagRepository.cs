using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories.Interfaces;

namespace Internship_7_EF_Dmail.Domain.Repositories
{
    public class SpamFlagRepository : BaseRepository, IRepository<SpamFlag>
    {
        public SpamFlagRepository(DmailDBContext context) : base(context)
        {
        }
        public ICollection<SpamFlag> GetAll() => context.SpamFlags.ToList();

        public SpamFlag? GetById(int id)
        {
            throw new NotSupportedException();
        }

        public Response Add(SpamFlag entity)
        {
            throw new NotSupportedException();
        }

        public Response Delete(int id)
        {
            throw new NotSupportedException();
        }

        public Response Update(SpamFlag entity)
        {
            throw new NotSupportedException();
        }

        public bool SpamFlagExists(int userId, int userToFlag)
        {
            return GetAll().Any(sf => sf.UserId == userId && sf.FlaggedUserId == userToFlag);
        }

        public Response MarkAsSpam(int userId, int userToFlag)
        {

            if(SpamFlagExists(userId,userToFlag))
            {
                return Response.NoChanges;
            }

            context.SpamFlags.Add(new SpamFlag()
            {
                UserId = userId,
                FlaggedUserId = userToFlag,
            });

            return base.SaveChanges();
        }

        public Response RemoveAsSpam(int userId, int userToFlag)
        {
            context.SpamFlags.Remove(new SpamFlag()
            {
                UserId = userId,
                FlaggedUserId = userToFlag,
            });

            return base.SaveChanges();
        }

    }
}
