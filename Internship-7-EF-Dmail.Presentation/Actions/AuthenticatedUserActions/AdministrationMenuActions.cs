using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions
{
    public class AdministrationMenuActions : IAction
    {
        private readonly User _authenticatedUser;

        public AdministrationMenuActions(User authenticatedUser)
        {
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "Administration";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            if(_authenticatedUser.Rights != Data.Enums.UserRights.Elevated)
            {
                WriteLine("This menu is not available for your profile.", Style.Error);
                WaitForInput();
                return;
            }

            AdministrationMenuFactory
                .CreateActions()
                .WriteActionsAndOpen();
        }
    }
}
