using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox
{
    public class InboxMenuAction : BaseMenuAction
    {
        public InboxMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "Inbox";
        }
    }
}
