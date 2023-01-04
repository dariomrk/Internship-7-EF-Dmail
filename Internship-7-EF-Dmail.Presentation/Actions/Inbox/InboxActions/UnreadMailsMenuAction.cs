using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using Internship_7_EF_Dmail.Presentation.Extensions;
using static Internship_7_EF_Dmail.Presentation.Messages.Messages;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions
{
    public class UnreadMailsMenuAction : BaseMenuAction
    {
        private readonly MailRepository _mailRepository;

        public UnreadMailsMenuAction(MailRepository mailRepository, IList<IAction> actions) : base(actions)
        {
            Name = "Unread mail";
            _mailRepository = mailRepository;
        }

        public override void Open()
        {
            Console.Clear();

            IList<Mail> mails = _mailRepository.GetWhereReciever(AuthAction.GetCurrentLogin()!.Id)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            if(!mails.Any())
            {
                WriteLine(WARN_NO_MAILS, Style.Warning);
                WaitForInput();
                return;
            }

            WriteMails(mails);
            AllActions.WriteActionsAndOpen(false);
        }
    }
}