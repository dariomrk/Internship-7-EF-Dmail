using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.OutboxActions
{
    public class HideMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly Mail _selected;

        public HideMailAction(MailRepository mailRepository,
            Mail selected)
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

            if (_selected.Format == Data.Enums.MailFormat.Event)
            {
                WriteLine("Deleting this event from the outbox will not remove the event invitations you sent!", Style.Warning);
                WriteLine("This operation will cancel the event!", Style.Warning);

            }
            if (!GetConfirmation("Are you sure you want to delete this mail?", false))
            {
                WriteLine(OTHER_CANCELLED, Style.Emphasis);
                WaitForInput();
                return;
            }

            Response response = _mailRepository.RemoveFromOutbox(_selected.Id);

            WriteGenericResponse(response);
        }
    }
}
