using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions
{
    public class AuthAction : IAction
    {
        private static User? _currentlyAuthenticatedUser = null;
        public static void Logout() => _currentlyAuthenticatedUser = null;
        public static User? GetCurrentlyAuthenticatedUser()
        {
            if (_currentlyAuthenticatedUser == null)
                return null;
            return new User
            {
                Id = _currentlyAuthenticatedUser.Id,
                Email = _currentlyAuthenticatedUser.Email,
                Rights = _currentlyAuthenticatedUser.Rights,
            };
        }
        private static void SetAuthenticatedUser(User user)
        {
            _currentlyAuthenticatedUser = user;
        }

        private readonly UserRepository _userRepository;

        public AuthAction(UserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public int Index { get; set; }
        public string Name => "Authenticate";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            string email = Read(PROMPT_EMAIL);

            if (string.IsNullOrWhiteSpace(email))
            {
                WriteLine(ERROR_INVALID, Style.Error);
                return;
            }

            string password = ReadPassword(PROMPT_PASSWORD);

            Response response = _userRepository.Authenticate(email, password);

            switch (response)
            {
                case Response.ErrorAccoundDisabled:
                    WriteLine("The account is disabled.", Style.Error);
                    WaitForInput();
                    return;
                case Response.ErrorViolatesRequirements:
                    WriteLine("You have been timed out.", Style.Warning);
                    WaitForInput();
                    return;
                case Response.ErrorInvalidPassword:
                    WriteLine("The password you provided is invalid.", Style.Error);
                    WriteLine("You have been timed out for 30s.", Style.Warning);
                    WaitForInput();
                    return;
                case Response.ErrorNotFound:
                    WriteLine("The account does not exist.", Style.Error);
                    WaitForInput();
                    return;
                default:
                    if (response != Response.Succeeded)
                    {
                        WriteLine(ERROR_UNHANDLED, Style.Error);
                        WaitForInput();
                        return;
                    }
                    break;
            }

            WriteLine($"Authenticated as {email.ToLower()}.", Style.Success);
            AuthAction.SetAuthenticatedUser(_userRepository.GetByEmail(email)!);
            WaitForInput();

            Console.Clear();
            AuthenticatedUserMenuFactory
                .CreateActions()
                .WriteActionsAndOpen();
        }
    }
}
