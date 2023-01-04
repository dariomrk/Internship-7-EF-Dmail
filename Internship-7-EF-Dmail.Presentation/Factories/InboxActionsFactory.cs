﻿using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.Inbox;
using Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class InboxActionsFactory
    {
        public static InboxMenuAction Create()
        {
            return new InboxMenuAction(new List<IAction>()
            {
                new ReturnAction(),
                new UnreadMailsAction(),
                new ReadMailsAction(),
                new MailsFromSenderAction(),
            });
        }
    }
}
