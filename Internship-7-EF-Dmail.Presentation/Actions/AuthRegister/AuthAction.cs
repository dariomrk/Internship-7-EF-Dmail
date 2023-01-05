using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Factories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthRegister
{
    public class AuthAction : IAction
    {
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
            
            if(string.IsNullOrWhiteSpace(email))
            {
                WriteLine(ERROR_INVALID, Style.Error);
                return;
            }

            string password = ReadPassword(PROMPT_PASSWORD);

            Response response = _userRepository.Authenticate(email, password);

            if (response == Response.ErrorViolatesRequirements)
            {
                WriteLine("You have been timed out.",Style.Warning);
                WaitForInput();
                return;
            }
            if(response == Response.ErrorInvalidPassword)
            {
                WriteLine("The password you provided is invalid.", Style.Error);
                WriteLine("You have been timed out for 30s.", Style.Warning);
                WaitForInput();
                return;
            }
            if(response != Response.Succeeded)
            {
                WriteLine(ERROR_UNHANDLED,Style.Error);
                WaitForInput();
                return;
            }

            WriteLine($"Authenticated as {email.ToLower()}.", Style.Success);
            WaitForInput();

            Console.Clear();
            AuthenticatedUserMainMenuFactory
                .CreateActions()
                .WriteActionsAndOpen();
        }
    }
}
