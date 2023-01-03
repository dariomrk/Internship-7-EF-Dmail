using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static IList<Interfaces.IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
                AuthFactory.Create(),
            };
            actions.SetIndexes();
            return actions;
        }
    }
}
