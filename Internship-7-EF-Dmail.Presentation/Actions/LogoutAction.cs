using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class LogoutAction : ExitMenuAction
    {
        public override string Name => "Logout";

        public override void Open()
        {
            AuthAction.Logout();
        }
    }
}
