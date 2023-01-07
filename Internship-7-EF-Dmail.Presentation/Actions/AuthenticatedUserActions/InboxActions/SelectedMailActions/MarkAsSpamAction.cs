using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions
{
    public class MarkAsSpamAction : IAction
    {
        private readonly SpamFlagRepository _spamFlagRepository;
        private readonly Mail _selected;
        private readonly User _authenticatedUser;

        public MarkAsSpamAction(
            SpamFlagRepository spamFlagRepository,
            Mail mail,
            User authenticatedUser)
        {
            _spamFlagRepository=spamFlagRepository;
            _selected=mail;
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name => "Mark sender as spam";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            Response response = _spamFlagRepository.MarkAsSpam(
                _authenticatedUser.Id,
                _selected.SenderId);

            WriteGenericResponse(response);
        }
    }
}
