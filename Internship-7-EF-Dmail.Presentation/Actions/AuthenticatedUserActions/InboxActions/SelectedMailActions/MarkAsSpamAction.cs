using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.InboxActions.SelectedMailActions
{
    public class MarkAsSpamAction : IAction
    {
        private readonly SpamFlagRepository _spamFlagRepository;
        private readonly Mail _selected;

        // TODO Add AuthenticatedUser (dependency injection)
        public MarkAsSpamAction(SpamFlagRepository spamFlagRepository, Mail mail)
        {
            _spamFlagRepository=spamFlagRepository;
            _selected=mail;
        }

        public int Index { get; set; }
        public string Name => "Mark sender as spam";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            Response response = _spamFlagRepository.MarkAsSpam(
                AuthAction.GetCurrentlyAuthenticatedUser()!.Id,
                _selected.SenderId);

            WriteGenericResponse(response);
        }
    }
}
