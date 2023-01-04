using Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class UnreadMailsActionFactory
    {
        public static UnreadMailsMenuAction Create()
        {
            return new UnreadMailsMenuAction(
                RepositoryFactory.Create<MailRepository>(),
                new List<IAction>()
                {

                }
                );
        }
    }
}
