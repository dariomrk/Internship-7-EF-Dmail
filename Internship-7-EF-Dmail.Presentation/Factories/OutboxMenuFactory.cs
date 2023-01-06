using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.OutboxActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class OutboxMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
                new SentMailAction(),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
