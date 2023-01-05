using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class SelectedMailMenuFactory
    {
        public static IList<IAction> CreateActions(Mail selected)
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
