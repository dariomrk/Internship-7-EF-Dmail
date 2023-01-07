using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.ProfileSettingsActions;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class ProfileSettingsMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),

                new RemoveSpamFlagAction(
                    RepositoryFactory.Create<UserRepository>(),
                    AuthAction.GetCurrentlyAuthenticatedUser()!,
                    RepositoryFactory.Create<SpamFlagRepository>()),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
