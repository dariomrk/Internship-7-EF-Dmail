using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;

namespace Internship_7_EF_Dmail.Domain.Repos
{
    public class UserRepo : BaseRepo
    {
        public UserRepo(DmailDBContext context) : base(context)
        {
        }

        public User? GetById(int id) => context.Users.Find(id);

        public ICollection<User> GetAll() => context.Users.ToList();

        public Response Add(User user)
        {
            if (GetAll().Any(u => u.Email.ToLower() == user.Email.ToLower()))
                return Response.ErrorViolatesUniqueConstraint;

            context.Users.Add(user);
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

        public Response UpdateEmail(int userId, string email)
        {
            User? toUpdate = GetById(userId);

            if (toUpdate == null)
                return Response.ErrorNotFound;

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
    }
}
