using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class InboxMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),

                new ReadUnreadMailAction(
                    RepositoryFactory.Create<MailRepository>(),
                    RepositoryFactory.Create<SpamFlagRepository>(),
                    MailStatus.Read),

                new ReadUnreadMailAction(
                    RepositoryFactory.Create<MailRepository>(),
                    RepositoryFactory.Create<SpamFlagRepository>(),
                    MailStatus.Unread),

                new MailFromSenderAction(
                    RepositoryFactory.Create<MailRepository>(),
                    RepositoryFactory.Create<UserRepository>()),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
