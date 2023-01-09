using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.AdministrationActions;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class AdministrationMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            List<IAction> actions = new()
            {
                new ExitMenuAction(),

                new DisableEnableUserAction(
                    RepositoryFactory.Create<UserRepository>(),
                    Data.Enums.UserStatus.Active,
                    AuthAction.GetCurrentlyAuthenticatedUser()!),

                new DisableEnableUserAction(
                    RepositoryFactory.Create<UserRepository>(),
                    Data.Enums.UserStatus.Disabled,
                    AuthAction.GetCurrentlyAuthenticatedUser()!),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
