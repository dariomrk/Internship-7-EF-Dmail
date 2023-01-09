using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions
{
    public class SendNewEventAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly UserRepository _userRepository;
        private readonly User _authenticatedUser;

        public SendNewEventAction(
            MailRepository mailRepository,
            UserRepository userRepository,
            User authenticatedUser)
        {
            _mailRepository=mailRepository;
            _userRepository=userRepository;
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "New event";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            Mail newMail = new()
            {
                SenderId = _authenticatedUser.Id,
                Format = Data.Enums.MailFormat.Event,
            };

            IList<string>? userInput = ReadRecipients();

            if (userInput == null)
            {
                WriteLine(ERROR_INVALID, Style.Error);
                WaitForInput();
                return;
            }

            if (userInput.Contains(_authenticatedUser.Email))
            {
                WriteLine(WARN_CANNOT_MAIL_SELF, Style.Warning);
                userInput.Remove(_authenticatedUser.Email);
            }

            List<User> recipientsUsers = new();

            userInput.ForEach((ui) =>
            {
                User toAdd = _userRepository.GetByEmail(ui);

                if (toAdd != null && !recipientsUsers.Contains(toAdd))
                {
                    recipientsUsers.Add(toAdd);
                }
            });

            if (!recipientsUsers.Any())
            {
                WriteLine("None of the listed emails were valid.", Style.Error);
                WaitForInput();
                return;
            }

            newMail.Title = ReadWithFallback(PROMPT_MAIL_TITLE, "No title");
            newMail.EventStartAt = ReadDateTime(PROMPT_DATETIME);

            if (newMail.EventStartAt == null)
            {
                return;
            }

            if (newMail.EventStartAt - DateTime.UtcNow <= TimeSpan.Zero)
            {
                WriteLine("Cannot set event start in the past.", Style.Error);
                WaitForInput();
                return;
            }

            newMail.EventDuration = ReadTimeSpan(PROMPT_TIMESPAN);

            if (newMail.EventDuration == null)
            {
                return;
            }

            newMail.Recipients = new List<Recipient>();

            recipientsUsers.ForEach((u) =>
            {
                newMail.Recipients.Add(new Recipient(u.Id)
                {
                    EventStatus = Data.Enums.EventStatus.NoResponse,
                });
            });

            Response response = _mailRepository.Add(newMail);

            WriteGenericResponse(response);
        }
    }
}
