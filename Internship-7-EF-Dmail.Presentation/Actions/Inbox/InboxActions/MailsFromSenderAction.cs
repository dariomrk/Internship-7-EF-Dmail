using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions
{
    public class MailsFromSenderAction : IAction
    {
        public int Index { get; set; }
        public string Name => "Unread Mail";
        public void Open()
        {
            // TODO Implement
        }
    }
}