using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions
{
    public class MailFromSenderAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly UserRepository _userRepository;

        public MailFromSenderAction(MailRepository mailRepository, UserRepository userRepository)
        {
            _mailRepository = mailRepository;
            _userRepository = userRepository;
        }

        public int Index { get; set; }
        public string Name => "Mails from sender";

        public void Open()
        {
            string searchPattern = Read("Please enter a mail or a part of an mail to search: ");
        }
    }
}
