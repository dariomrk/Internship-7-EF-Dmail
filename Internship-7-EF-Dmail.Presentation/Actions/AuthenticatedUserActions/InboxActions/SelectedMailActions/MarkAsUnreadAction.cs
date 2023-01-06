using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions
{
    public class MarkAsUnreadAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private Mail _selected;

        // TODO Add AuthenticatedUser (dependency injection)
        public MarkAsUnreadAction(MailRepository mailRepository, Mail selectedMail)
        {
            _mailRepository=mailRepository;
            _selected=selectedMail;
        }

        public int Index { get; set; }
        public string Name => "Mark as unread";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            Response response = _mailRepository.UpdateMailStatus(
                _selected.Id,
                AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                Data.Enums.MailStatus.Unread);

            WriteGenericResponse(response);
        }
    }
}
