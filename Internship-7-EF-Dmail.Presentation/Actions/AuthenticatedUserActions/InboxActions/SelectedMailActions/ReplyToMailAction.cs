using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions
{
    public class ReplyToMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly Mail _selected;

        // TODO Add AuthenticatedUser (dependency injection)
        public ReplyToMailAction(MailRepository mailRepository, Mail selected)
        {
            _mailRepository=mailRepository;
            _selected=selected;
        }

        public int Index { get; set; }
        public string Name => "Reply";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            Mail newMail = new Mail()
            {
                SenderId = AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                Format = Data.Enums.MailFormat.Email,
                Recipients = new List<Recipient>()
                {
                    new Recipient(_selected.SenderId),
                }
            };

            switch (_selected.Format)
            {
                case Data.Enums.MailFormat.Email:
                    newMail.Title = $"[Reply][{_selected.Title}]";
                    newMail.Content = Read("Input mail content: ");
                    break;

                case Data.Enums.MailFormat.Event:
                    newMail.Title = $"[Response][{_selected.Title}]";
                    newMail.Content = $"{AuthAction.GetCurrentlyAuthenticatedUser()!.Email} " +
                            $"has responded to the event titled: {_selected.Title}.";

                    int eventResponse = PromptSelectOption(
                        new List<string>()
                        {
                            "Accept",
                            "Reject",
                        }, "Your response: ");

                    _mailRepository.UpdateEventStatus(_selected.Id,
                        AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                        eventResponse == 0 ? Data.Enums.EventStatus.Accepted
                        : Data.Enums.EventStatus.Rejected);

                    break;
                default:
                    throw new Exception();
            }

            Response response = _mailRepository.Add(newMail);

            WriteGenericResponse(response);
        }
    }
}
