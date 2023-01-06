using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions
{
    public class OutboxAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly User _authenticatedUser;

        public OutboxAction(MailRepository mailRepository, User authenticatedUser)
        {
            _mailRepository=mailRepository;
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "Outbox";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            IList<Mail> sentMails = _mailRepository
                .GetWhereSender(_authenticatedUser.Id)
                .ToList();

            WriteMails(sentMails);
            if(!TrySelectMailByIndex(sentMails, out Mail? selected))
            {
                return;
            }

            OutboxMenuFactory
                .CreateActions()
                .WriteActionsAndOpen();
        }
    }
}
