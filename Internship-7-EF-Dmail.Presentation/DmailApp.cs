using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;

namespace Internship_7_EF_Dmail.Presentation
{
    public class DmailApp
    {
        public static void Main()
        {
            MainMenuFactory
                .CreateActions()
                .WriteActionsAndOpen();
        }
    }
}