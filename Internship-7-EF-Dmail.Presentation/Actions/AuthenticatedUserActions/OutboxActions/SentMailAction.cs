using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.OutboxActions
{
    public class SentMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly User _authenticatedUser;

        public SentMailAction(MailRepository mailRepository, User authenticatedUser)
        {
            _mailRepository=mailRepository;
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "Sent mail";

        public void Open()
        {
            // TODO Implement
        }
    }
}
