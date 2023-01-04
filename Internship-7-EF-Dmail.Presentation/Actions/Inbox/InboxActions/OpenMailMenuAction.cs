using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions
{
    public class OpenMailMenuAction : BaseMenuAction
    {
        public OpenMailMenuAction(IList<IAction> actions) : base(actions)
        {
            Name = "Mail menu";
        }

        public override void Open()
        {

        }
    }
}