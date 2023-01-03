using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class LogoutAction : IAction
    {
        public string Name { get; } = "Logout";
        public int Index { get; set; }

        public LogoutAction()
        {
        }

        public void Open()
        {
            AuthAction.ClearLogin();
            DmailApp.MainMenuActions.WriteActionsAndOpen();
        }
    }
}

