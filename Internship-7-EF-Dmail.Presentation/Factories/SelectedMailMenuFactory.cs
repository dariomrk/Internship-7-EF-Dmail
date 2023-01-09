using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class SelectedMailMenuFactory
    {
        public static IList<IAction> CreateActions(Mail selected)
        {
            List<IAction> actions = new()
            {
                new ExitMenuAction(),

                new MarkAsUnreadAction(
                    RepositoryFactory.Create<MailRepository>(),
                    selected,
                    AuthAction.GetCurrentlyAuthenticatedUser()!
                    ),

                new MarkAsSpamAction(
                    RepositoryFactory.Create<SpamFlagRepository>(),
                    selected,
                    AuthAction.GetCurrentlyAuthenticatedUser()!),

                new DeleteMailAction(
                    RepositoryFactory.Create<MailRepository>(),
                    selected,
                    AuthAction.GetCurrentlyAuthenticatedUser()!),

                new ReplyToMailAction(
                    RepositoryFactory.Create<MailRepository>(),
                    selected,
                    AuthAction.GetCurrentlyAuthenticatedUser()!),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
