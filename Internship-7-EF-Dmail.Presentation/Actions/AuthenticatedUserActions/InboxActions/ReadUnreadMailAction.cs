using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions
{
    public class ReadUnreadMailAction : IAction
    {
        private readonly MailRepository _mailRepository;
        private readonly SpamFlagRepository _spamFlagRepository;
        private MailStatus _mailStatus;

        public ReadUnreadMailAction(
            MailRepository mailRepository,
            SpamFlagRepository spamFlagRepository,
            MailStatus mailStatus)
        {
            Name = mailStatus switch
            {
                MailStatus.Read => "Read mails",
                MailStatus.Unread => "Unread mails",
                _ => throw new NotSupportedException(),
            };
            _mailRepository=mailRepository;
            _spamFlagRepository=spamFlagRepository;
            _mailStatus=mailStatus;
        }
        public string Name { get; }
        public int Index { get; set; }

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            IList<Mail> query = _mailRepository
                .GetWhereRecieverAndStatus(
                AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                _mailStatus)
                .ToList();

            IList<SpamFlag> mySpamFlags = _spamFlagRepository
                .GetSpamFlagsForUser(AuthAction.GetCurrentlyAuthenticatedUser()!.Id)
                .ToList();

            IList<Mail> mails = query
                .Where(m => !mySpamFlags
                .Select(sf => sf.FlaggedUserId)
                .Contains(m.SenderId))
                .ToList();

            if (!mails.Any())
            {
                WriteLine(WARN_NO_MAILS, Style.Warning);
                WaitForInput();
                return;
            }


            Console.Clear();

            IList<Mail> final = PromptFilterByFormat(mails)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            WriteMails(final);

            if (!TrySelectMailByIndex(final, out Mail? selected))
            {
                return;
            }

            WriteMail(selected!);
            if(_mailStatus == MailStatus.Unread)
            {
                _mailRepository.UpdateMailStatus(selected!.Id,
                    AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                    MailStatus.Read);
            }
            WriteLine("Selected mail actions are located on the next screen.", Style.Emphasis);
            WaitForInput();
            SelectedMailMenuFactory.CreateActions(selected!).WriteActionsAndOpen();
        }
    }
}