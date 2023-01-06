using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions
{
    public class MailFromSenderAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly UserRepository _userRepository;
        private readonly User _authenticatedUser;

        public MailFromSenderAction(
            MailRepository mailRepository,
            UserRepository userRepository,
            User authenticatedUser)
        {
            _mailRepository = mailRepository;
            _userRepository = userRepository;
            _authenticatedUser = authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "Mails from sender";

        public void Open()
        {
            WriteLine(Name);

            string query = Read("Please enter the sender address (partial / full): ");

            if(string.IsNullOrEmpty(query))
            {
                WriteLine(ERROR_INVALID,Style.Error);
                WaitForInput();
                return;
            }

            ICollection<User> senders = _userRepository.GetEmailContains(query);

            List<Mail> mailsWhereSender = new List<Mail>();

            senders.ForEach<User>((u) =>
            {
                mailsWhereSender.AddRange(_mailRepository.GetWhereSenderAndRecipient(u.Id,
                    _authenticatedUser.Id));
            });

            List<Mail> recieved = mailsWhereSender
                .Where(m => m.SenderId != _authenticatedUser.Id)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            IList<Mail> final = PromptFilterByFormat(recieved);

            if (!final.Any())
            {
                WriteLine(ERROR_NO_MAILS_WITHIN_CRITERIA, Style.Error);
                WaitForInput();
                return;
            }

            Console.Clear();
            WriteMails(final);
            
            if(!TrySelectMailByIndex(final, out Mail? selected))
            {
                return;
            }

            WriteMail(selected!);
            WriteLine("Selected mail actions are located on the next screen.");
            WaitForInput();
            SelectedMailMenuFactory.CreateActions(selected!).WriteActionsAndOpen();
        }
    }
}
