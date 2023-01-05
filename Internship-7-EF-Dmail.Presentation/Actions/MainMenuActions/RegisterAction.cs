using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions
{
    public class RegisterAction : IAction
    {
        private readonly UserRepository _userRepository;

        public RegisterAction(UserRepository userRepository)
        {
            _userRepository=userRepository;
        }

        public int Index { get; set; }
        public string Name => "Register";

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            string email = Read(PROMPT_EMAIL);

            if (_userRepository.EmailExists(email))
            {
                WriteLine("The email you provided is already in use.", Style.Error);
                WaitForInput();
                return;
            }

            Response emailValidationResponse = _userRepository.ValidateEmail(email);

            if (emailValidationResponse == Response.ErrorInvalidFormat)
            {
                WriteLine("The email you provided has an invalid format.", Style.Error);
                WaitForInput();
                return;
            }
            if (emailValidationResponse != Response.Succeeded)
            {
                WriteLine(ERROR_UNHANDLED, Style.Error);
                WaitForInput();
                return;
            }

            string password = ReadPassword(PROMPT_PASSWORD);

            if (string.IsNullOrEmpty(password))
            {
                WriteLine("Having no password is a immense safety risk.\n" +
                    "Are you sure you want to continue?", Style.Warning);
                if (!GetConfirmation())
                {
                    WriteLine(OTHER_CANCELLED, Style.Emphasis);
                    WaitForInput();
                    return;
                }
            }

            string confirmPassword = ReadPassword("Plase repeat the password: ");

            if (password != confirmPassword)
            {
                WriteLine("The passwords do not match.", Style.Error);
                WaitForInput();
                return;
            }

            if (!Captcha())
            {
                WriteLine("You did not pass the captcha.", Style.Error);
                WaitForInput();
                return;
            }

            Console.Clear();

            User user = new User()
            {
                Email = email,
                Password = password,
            };

            _userRepository.Add(user);

            WriteLine(SUCCESS_DONE, Style.Success);
            WaitForInput();
        }
    }
}
