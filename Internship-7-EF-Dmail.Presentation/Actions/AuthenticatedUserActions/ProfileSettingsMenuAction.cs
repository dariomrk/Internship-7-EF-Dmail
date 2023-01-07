using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions
{
    public class ProfileSettingsMenuAction : IAction
    {
        public int Index { get; set; }
        public string Name => "Profile settings";

        public void Open()
        {
            ProfileSettingsMenuFactory
                .CreateActions()
                .WriteActionsAndOpen();
        }
    }
}
