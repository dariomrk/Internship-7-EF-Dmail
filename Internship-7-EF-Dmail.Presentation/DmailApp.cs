using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation
{
    public class DmailApp
    {
        public static IList<IAction> MainMenuActions = MainMenuFactory.CreateActions();

        public static void Main()
        {
            MainMenuActions.WriteActionsAndOpen();
        }
    }
}