using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions
{
    public class ReadUnreadMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private MailStatus _mailStatus;

        public ReadUnreadMailAction(MailRepository mailRepository, MailStatus mailStatus)
        {
            Name = mailStatus switch
            {
                MailStatus.Read => "Read mails",
                MailStatus.Unread => "Unread mails",
                _ => throw new NotSupportedException(),
            };
            _mailRepository=mailRepository;
            _mailStatus=mailStatus;
        }
        public string Name { get; }
        public int Index { get; set; }

        public void Open()
        {
            Console.Clear();
            
            IList<Mail> mails = _mailRepository
                .GetWhereRecieverAndStatus(
                AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                _mailStatus)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            if(!mails.Any())
            {
                WriteLine(WARN_NO_MAILS, Style.Warning);
                WaitForInput();
                return;
            }

            WriteMails(mails);
            WaitForInput();
        }
    }
}