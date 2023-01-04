using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using Internship_7_EF_Dmail.Presentation.Actions;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions.MailActions
{
    public class SelectMailAction : BaseMenuAction
    {
        private readonly MailRepository _mailRepository;
        private readonly Data.Enums.MailStatus _status;
        public SelectMailAction(MailRepository mailRepository,
            Data.Enums.MailStatus status,
            IList<IAction> actions) : base(actions)
        {
            Name = "Select mail";
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

            if (!mails.Any())
                return;

            Mail? selected;

            while (true)
            {
                Console.Clear();
                WriteMails(mails);
                if (!TrySelectMailByIndex(mails, out selected))
                    continue;
                break;
            }

            _mailRepository.UpdateMailStatus(
                selected!.Id,
                AuthAction.GetCurrentLogin()!.Id,
                Data.Enums.MailStatus.Read).ToString();
            WriteMail(selected);
        }
    }
}
