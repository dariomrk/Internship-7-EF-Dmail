using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions.MailActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class SelectMailActionFactory
    {
        public static SelectMailAction Create(Data.Enums.MailStatus status)
        {
            return new SelectMailAction(
                RepositoryFactory.Create<MailRepository>(),
                status,
                new List<IAction>()
                {

                }
                );
        }
    }
}
