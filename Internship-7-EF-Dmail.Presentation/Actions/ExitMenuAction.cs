using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class ExitMenuAction : IAction
    {
        public int Index { get; set; }

        public virtual string Name => "Exit";

        public void Open()
        {
        }
    }
}
