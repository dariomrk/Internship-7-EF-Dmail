using Internship_7_EF_Dmail.Data.Context;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;

namespace Internship_7_EF_Dmail.Domain.Repositories
{
    public class AuthRepository : BaseRepository
    {
        public AuthRepository(DmailDBContext context) : base(context)
        {
        }

        public Response Authenticate(string email, string password)
        {
            User? toAuth = context.Users.FirstOrDefault(u => u.Email == email);

            if (toAuth == null)
                return Response.ErrorNotFound;

            if (!Cryptography.Password.Verify(password, toAuth.Password))
                return Response.ErrorInvalidPassword;
            return Response.Succeeded;
        }
    }
}
