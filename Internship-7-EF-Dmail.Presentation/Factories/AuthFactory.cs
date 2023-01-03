using Internship_7_EF_Dmail.Presentation.Actions.Auth;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using Internship_7_EF_Dmail.Presentation.Actions.Register;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class AuthFactory
    {
        public static AuthAction Create()
        {
            // TODO
            return new AuthAction(
                RepositoryFactory.Create<UserRepository>(),
                RepositoryFactory.Create<AuthRepository>(),
                new List<IAction>()
                {
                    new LogoutAction(),
                }
                );
        }
    }
}
