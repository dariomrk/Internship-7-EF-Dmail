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

            Response response = _mailRepository.RemoveFromOutbox(_selected.Id);

            WriteGenericResponse(response);
        }
    }
}
