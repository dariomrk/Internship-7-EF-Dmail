using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class AuthenticatedUserMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new LogoutAction(),
                new InboxMenuActions(),
                new OutboxMenuActions(),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
