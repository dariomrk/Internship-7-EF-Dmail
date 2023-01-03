using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox
{
    public class InboxReadMailAction : IAction
    {
        public int Index { get; set; }
        public string Name => "Read Mail";
        public void Open()
        {
            // TODO Implement
        }
    }
}
