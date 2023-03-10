using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions
{
    public class DeleteMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly Mail _selected;
        private readonly User _authenticatedUser;

        public DeleteMailAction(
            MailRepository mailRepository,
            Mail selected,
            User authenticatedUser)
        {
            _mailRepository=mailRepository;
            _selected=selected;
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "Delete mail";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            if (_selected.Format == Data.Enums.MailFormat.Event)
            {
                WriteLine("Deleting this event from the inbox will remove you from the list of invited users for everyone!", Style.Warning);
            }

            if (!GetConfirmation("Are you sure you want to delete this mail?", false))
            {
                WriteLine(OTHER_CANCELLED, Style.Emphasis);
                WaitForInput();
                return;
            }

            Response response = _mailRepository.RemoveFromInbox(_selected.Id,
                _authenticatedUser.Id);

            WriteGenericResponse(response);
        }
    }
}
