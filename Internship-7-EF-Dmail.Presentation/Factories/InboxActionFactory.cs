using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.Inbox;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class InboxActionFactory
    {
        public static InboxMenuAction Create()
        {
            var actions = new List<IAction>()
            {
                new ReturnAction(),
                MailsActionFactory.Create(Data.Enums.MailStatus.Unread),
                MailsActionFactory.Create(Data.Enums.MailStatus.Read),
            };

            actions.SetIndexes();

            return new InboxMenuAction(actions);
        }
    }
}
