using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class AuthenticatedUserMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            List<IAction> actions = new()
            {
                new LogoutAction(AuthAction.Logout),

                new InboxMenuActions(),

                new OutboxMenuAction(
                    RepositoryFactory.Create<MailRepository>(),
                    AuthAction.GetCurrentlyAuthenticatedUser()!),

                new SendNewMailAction(
                    RepositoryFactory.Create<MailRepository>(),
                    RepositoryFactory.Create<UserRepository>(),
                    AuthAction.GetCurrentlyAuthenticatedUser()!),

                new SendNewEventAction(
                    RepositoryFactory.Create<MailRepository>(),
                    RepositoryFactory.Create<UserRepository>(),
                    AuthAction.GetCurrentlyAuthenticatedUser()!),

                new ProfileSettingsMenuAction(),

                new AdministrationMenuActions(
                    AuthAction.GetCurrentlyAuthenticatedUser()!),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
