using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using Internship_7_EF_Dmail.Presentation.Actions;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class AuthActionFactory
    {
        public static AuthAction Create()
        {
            return new AuthAction(
                RepositoryFactory.Create<UserRepository>(),
                RepositoryFactory.Create<AuthRepository>(),
                new List<IAction>()
                {
                    new LogoutAction(),
                    InboxActionFactory.Create(),
                }
                );
        }
    }
}
