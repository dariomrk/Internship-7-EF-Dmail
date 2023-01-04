using Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using Internship_7_EF_Dmail.Presentation.Actions;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class MailsActionFactory
    {
        public static MailsMenuAction Create(Data.Enums.MailStatus status)
        {
            return new MailsMenuAction(
                RepositoryFactory.Create<MailRepository>(),
                status,
                new List<IAction>()
                {
                    new ReturnAction(),
                    SelectMailActionFactory.Create(Data.Enums.MailStatus.Unread),
                }
                );
        }
    }
}
