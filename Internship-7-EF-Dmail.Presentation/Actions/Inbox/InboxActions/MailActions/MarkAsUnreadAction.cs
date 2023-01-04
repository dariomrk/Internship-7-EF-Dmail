using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using Internship_7_EF_Dmail.Presentation.Utils;

namespace Internship_7_EF_Dmail.Presentation.Actions.Inbox.InboxActions.MailActions
{
    public class MarkAsUnreadAction : IAction
    {
        public readonly MailRepository _mailRepository;

        public MarkAsUnreadAction(MailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        public int Index { get; set; }
        public string Name => "Mark as unread";


        public void Open()
        {
            Response response = _mailRepository.UpdateMailStatus(
                SelectMailAction.GetSelectedMail()!.Id,
                AuthAction.GetCurrentLogin()!.Id,
                Data.Enums.MailStatus.Unread);

            if(!GetConfirmation("Mark mail as unread?"))
            {
                WriteLine(Messages.OTHER_CANCELLED);
                WaitForInput();
                return;
            }

            Console.Clear();
            switch (response)
            {
                case Response.Succeeded:
                    WriteLine("Done.",Style.Accepted);
                    break;
                default:
                    WriteLine(Messages.ERROR_UNHANDLED + " Code: " + response, Style.Error);
                    break;
            }


            WaitForInput();
            Console.Clear();
        }
    }
}
