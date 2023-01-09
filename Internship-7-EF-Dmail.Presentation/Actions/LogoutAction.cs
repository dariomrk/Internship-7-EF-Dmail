namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class LogoutAction : ExitMenuAction
    {
        private readonly Action _logoutFunc;

        public LogoutAction(Action logoutFunc)
        {
            _logoutFunc=logoutFunc;
        }

        public override string Name => "Logout";

        public override void Open()
        {
            _logoutFunc();
        }
    }
}
