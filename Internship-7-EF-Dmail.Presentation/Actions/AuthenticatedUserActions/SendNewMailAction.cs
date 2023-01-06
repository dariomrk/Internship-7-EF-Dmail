using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions
{
    public class SendNewMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly UserRepository _userRepository;
        private readonly User _authenticatedUser;

        public SendNewMailAction(
            MailRepository mailRepository,
            UserRepository userRepository,
            User authenticatedUser)
        {
            _mailRepository=mailRepository;
            _userRepository=userRepository;
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "New mail";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            Mail newMail = new Mail()
            {
                SenderId = _authenticatedUser.Id,
                Format = Data.Enums.MailFormat.Email,
            };

            IList<string>? userInput = ReadRecipients();

            if(userInput == null)
            {
                WriteLine(ERROR_INVALID, Style.Error);
                WaitForInput();
                return;
            }

            if (userInput.Contains(_authenticatedUser.Email))
            {
                WriteLine("You cannot send a mail to yourself!", Style.Warning);
                userInput.Remove(_authenticatedUser.Email);
            }

            List<User> recipientsUsers = new List<User>();

            userInput.ForEach((ui) => {
                User toAdd = _userRepository.GetByEmail(ui);

                if(toAdd != null && !recipientsUsers.Contains(toAdd))
                    recipientsUsers.Add(toAdd);
            });

            if (!userInput.Any())
            {
                WriteLine("None of the listed emails were valid.", Style.Error);
                WaitForInput();
                return;
            }

            newMail.Title = ReadWithFallback(PROMPT_MAIL_TITLE, "No title");
            newMail.Content = ReadWithFallback(PROMPT_MAIL_CONTENT, "No content.");
            newMail.Recipients = new List<Recipient>();

            recipientsUsers.ForEach((u) =>
            {
                newMail.Recipients.Add(new Recipient(u.Id));
            });

            Response response = _mailRepository.Add(newMail);

            WriteGenericResponse(response);
        }
    }
}
