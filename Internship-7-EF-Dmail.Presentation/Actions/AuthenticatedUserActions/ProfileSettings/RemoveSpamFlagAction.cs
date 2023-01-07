using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.ProfileSettings
{
    public class RemoveSpamFlagAction : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly User _authenticatedUser;
        private readonly SpamFlagRepository _spamFlagRepository;

        public RemoveSpamFlagAction(
            UserRepository userRepository,
            User authenticatedUser,
            SpamFlagRepository spamFlagRepository)
        {
            _userRepository=userRepository;
            _authenticatedUser=authenticatedUser;
            _spamFlagRepository=spamFlagRepository;
        }

        public int Index { get; set; }
        public string Name => "Remove spam flag";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            IList<User> flaggedUsers = _userRepository
                .GetFlaggedUsers(_authenticatedUser.Id)
                .ToList();

            if(!flaggedUsers.Any())
            {
                WriteLine("You have not flagged anyone as spam.",Style.Warning);
                WaitForInput();
                return;
            }

            WriteLine("Ord. | User");
            for (int i = 0; i<flaggedUsers.Count; i++)
            {
                User user = flaggedUsers[i];
                WriteLine($"{i.ToString().PadRight(4)} | {user.Email}");
            }

            if (!TrySelectUserByIndex(flaggedUsers, out User selected))
            {
                return;
            }    

            Response response = _spamFlagRepository.RemoveAsSpam(
                _authenticatedUser.Id,
                selected!.Id);

            WriteGenericResponse(response);
        }
    }
}
