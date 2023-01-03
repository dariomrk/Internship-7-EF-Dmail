using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class BaseMenuAction : IMenuAction
    {
        public int Index { get; set; }
        public string Name { get; } = "BaseMenuAction";
        public IList<IAction> AllActions { get; }

        public BaseMenuAction(IList<IAction> actions)
        {
            actions.SetIndexes();
            AllActions = actions;
        }

        public void Open()
        {
            AllActions.WriteActionsAndOpen();
        }
    }
}
