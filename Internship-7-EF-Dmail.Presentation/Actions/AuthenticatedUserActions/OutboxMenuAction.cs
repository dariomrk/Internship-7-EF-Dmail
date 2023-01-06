using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions
{
    public class OutboxMenuAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly User _authenticatedUser;

        public OutboxMenuAction(MailRepository mailRepository, User authenticatedUser)
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
                .GetWhereSenderAndNotHidden(_authenticatedUser.Id)
                .OrderBy(m => m.CreatedAt) // TODO Fix, not getting sorted.
                .ToList();

            if (!sentMails.Any())
            {
                WriteLine(OTHER_NO_MAILS);
                WaitForInput();
                return;
            }

            WriteSentMails(sentMails, _mailRepository);

            if(!TrySelectMailByIndex(sentMails, out Mail? selected))
            {
                return;
            }

            WriteMail(selected!, _authenticatedUser);
            WriteLine("Selected mail actions are located on the next screen.");
            WaitForInput();

            OutboxMenuFactory
                .CreateActions(selected!)
                .WriteActionsAndOpen();
        }
    }
}
