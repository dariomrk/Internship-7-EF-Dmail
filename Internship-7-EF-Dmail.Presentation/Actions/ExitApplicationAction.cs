using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class ExitApplicationAction : IAction
    {
        public int Index { get; set; }
        public string Name { get; } = "Exit the application";

        public void Open()
        {
            Environment.Exit(0);
        }
    }
}
