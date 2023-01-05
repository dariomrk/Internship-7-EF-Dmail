using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions
{
    public class DeleteMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly Mail _selected;

        public DeleteMailAction(MailRepository mailRepository, Mail selected)
        {
            _mailRepository=mailRepository;
            _selected=selected;
        }

        public int Index { get; set; }
        public string Name => "Delete mail";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            if(!GetConfirmation("Are you sure you want to delete this mail?"))
            {
                WriteLine(OTHER_CANCELLED, Style.Emphasis);
                WaitForInput();
                return;
            }

            Response response = _mailRepository.RemoveFromInbox(_selected.Id,
                AuthAction.GetCurrentlyAuthenticatedUser()!.Id);

            WriteGenericResponse(response);
        }
    }
}
