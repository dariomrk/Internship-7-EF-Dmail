using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class MailsActionFactory
    {
        public static MailsMenuAction Create(Data.Enums.MailStatus status)
        {
            var actions = new List<IAction>()
            {
                new ReturnAction(),
                SelectMailActionFactory.Create(status),
            };

            actions.SetIndexes();

            return new MailsMenuAction(
                RepositoryFactory.Create<MailRepository>(),
                status,
                actions
                );
        }
    }
}
