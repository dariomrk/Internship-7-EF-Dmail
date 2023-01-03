using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class ReturnAction : IAction
    {
        public int Index { get; set; }
        public string Name { get; } = "Return";

        public void Open()
        {
        }
    }
}
