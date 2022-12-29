using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class BaseMenuAction : IMenuAction
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public IList<IAction> AllActions { get; set; }

        public BaseMenuAction(IList<IAction> actions)
        {
            Name = "BaseMenuAction";
            Index = 0;
            actions.SetIndexes();
            AllActions = actions;
        }
        public virtual void Action()
        {
            // TODO
        }
    }
}
