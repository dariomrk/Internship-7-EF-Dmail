using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class AuthActionFactory
    {
        public static AuthAction Create()
        {
            var actions = new List<IAction>()
            {
                new ReturnAction(),
                InboxActionFactory.Create(),
            };

            actions.SetIndexes();

            return new AuthAction(
                RepositoryFactory.Create<UserRepository>(),
                RepositoryFactory.Create<AuthRepository>(),
                actions
                );
        }
    }
}
