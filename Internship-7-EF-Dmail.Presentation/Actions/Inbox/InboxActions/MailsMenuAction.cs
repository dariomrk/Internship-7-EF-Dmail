using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using Internship_7_EF_Dmail.Presentation.Extensions;
using static Internship_7_EF_Dmail.Presentation.Messages.Messages;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions
{
    public class MailsMenuAction : BaseMenuAction
    {
        private readonly MailRepository _mailRepository;
        private readonly Data.Enums.MailStatus _status;

        public MailsMenuAction(
            MailRepository mailRepository,
            Data.Enums.MailStatus status,
            IList<IAction> actions) : base(actions)
        {
            Name = status == Data.Enums.MailStatus.Unread ? "Unread mails" : "Read mails";
            _mailRepository = mailRepository;
            _status = status;
        }

        public override void Open()
        {
            Console.Clear();

            IList<Mail> mails = _mailRepository.GetWhereRecieverAndStatus(
                AuthAction.GetCurrentLogin()!.Id,
                _status
                )
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            if(!mails.Any())
            {
                WriteLine(WARN_NO_MAILS, Style.Warning);
                WaitForInput();
                return;
            }

            WriteMails(mails);
            WriteLine();

            AllActions.WriteActionsAndOpen(false);
        }
    }
}