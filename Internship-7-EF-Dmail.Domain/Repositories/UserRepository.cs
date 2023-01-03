using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace Internship_7_EF_Dmail.Domain.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(DmailDBContext context) : base(context)
        {
        }

        public User? GetById(int id) => context.Users.Find(id);

        public ICollection<User> GetAll() => context.Users.ToList();

        public ICollection<User> GetFlaggedUsers(int userId) => context.SpamFlags
                .Where(sf => sf.UserId == userId)
                .Join(context.Users,
                sf => sf.FlaggedUserId,
                u => u.Id,
                (sf, u) => new { sf, u })
                .Select(a => a.u)
                .ToList();

        public Response Add(User user)
        {
            if (!Regex.IsMatch(user.Email, "^([a-z A-Z 0-9 .]{1,})+@([a-z A-Z 0-9]{3,})+.+[a-z A-z]{2,}$"))
                return Response.ErrorViolatesRequirements;

            if (GetAll().Any(u => u.Email.ToLower() == user.Email.ToLower()))
                return Response.ErrorViolatesUniqueConstraint;

            context.Users.Add(user);
            return SaveChanges();
        }

        public Response Update(User user)
        {
            throw new NotSupportedException("Use specific update method (UpdateEmail, UpdatePassword...).");
        }

        public Response UpdateEmail(int userId, string email)
        {
            User? toUpdate = GetById(userId);

            if (toUpdate == null)
                return Response.ErrorNotFound;
            if (!Regex.IsMatch(email, "^([a-z A-Z 0-9 .]{1,})+@([a-z A-Z 0-9]{3,})+.+[a-z A-z]{2,}$"))
                return Response.ErrorViolatesRequirements;

            if (GetAll().Any(u => u.Email.ToLower() == email.ToLower()))
                return Response.ErrorViolatesUniqueConstraint;

            toUpdate.Email = email;

            return SaveChanges();
        }

        public Response UpdatePassword(int userId, string password)
        {
            User? toUpdate = GetById(userId);

            if (toUpdate == null)
                return Response.ErrorNotFound;

            toUpdate.Password = Cryptography.Password.Hash(password);

            return SaveChanges();
        }

        public Response UpdateStatus(int userId, Data.Enums.UserStatus status)
        {
            User? toUpdate = GetById(userId);

            if (toUpdate == null)
                return Response.ErrorNotFound;

            toUpdate.Status = status;

            return SaveChanges();
        }

        public Response UpdateRights(int userId, Data.Enums.UserRights rights)
        {
            User? toUpdate = GetById(userId);

            if (toUpdate == null)
                return Response.ErrorNotFound;

            toUpdate.Rights = rights;

            return SaveChanges();
        }

        public Response Delete(int userId)
        {
            User? toDelete = GetById(userId);

            if (toDelete == null)
                return Response.ErrorNotFound;

            context.Users.Remove(toDelete);
            return SaveChanges();
        }
    }
}
