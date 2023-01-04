using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions.MailActions
{
    public class SelectMailMenuAction : BaseMenuAction
    {
        private readonly MailRepository _mailRepository;
        public SelectMailMenuAction(MailRepository mailRepository, IList<IAction> actions) : base(actions)
        {
            Name = "Select mail";
            _mailRepository = mailRepository;
        }
        public override void Open()
        {
            Console.Clear();

            IList<Mail> mails = _mailRepository.GetWhereReciever(AuthAction.GetCurrentLogin()!.Id)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            Mail? selected;
            while (mails.Any())
            {
                Console.Clear();
                WriteMails(mails);
                if (!TrySelectMailByIndex(mails, out selected))
                    continue;
                break;
            }
        }
    }
}
