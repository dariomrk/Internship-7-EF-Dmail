using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Cryptography;
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

        public User? GetByEmail(string email) => GetAll().FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

        public bool EmailExists(string email) => GetAll().Any(u => u.Email.ToLower() == email.ToLower());

        public Response ValidateEmail(string email)
        {
            if (!Regex.IsMatch(email, "^([a-z A-Z 0-9 .]{1,})+@([a-z A-Z 0-9]{3,})+.+[a-z A-z]{2,}$"))
                return Response.ErrorInvalidFormat;
            return Response.Succeeded;
        }

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
            if (ValidateEmail(user.Email) != Response.Succeeded)
                return Response.ErrorViolatesRequirements;

            if (EmailExists(user.Email))
                return Response.ErrorViolatesUniqueConstraint;

            user.Password = Password.Hash(user.Password);

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
            if (ValidateEmail(email) != Response.Succeeded)
                return Response.ErrorViolatesRequirements;

            if (EmailExists(email))
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

        public bool IsActive(string email)
        {
            User? toCheck = GetByEmail(email);

            if (toCheck == null)
                return false;

            if (toCheck.Status == Data.Enums.UserStatus.Active)
                return true;
            return false;
        }

        public Response Authenticate(string email, string password)
        {
            User? toAuth = context.Users.FirstOrDefault(u => u.Email == email);

            if (toAuth == null)
                return Response.ErrorNotFound;

            if (toAuth.Status == Data.Enums.UserStatus.Disabled)
                return Response.ErrorAccoundDisabled;

            if((DateTime.UtcNow - toAuth.LastFailedLogin) < TimeSpan.FromSeconds(30))
                return Response.ErrorViolatesRequirements;

            if (!Password.Verify(password, toAuth.Password))
            {
                toAuth.LastFailedLogin = DateTime.UtcNow;
                context.SaveChanges();
                return Response.ErrorInvalidPassword;
            }
            return Response.Succeeded;

        }
    }
}
