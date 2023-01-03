using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Data.Models;

namespace Internship_7_EF_Dmail.Presentation.Actions
{
    public class RegisterAction : IAction
    {
        private readonly UserRepository _userRepository;
        public string Name { get; } = "Register";
        public int Index { get; set; }

        public RegisterAction(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            string email = Read("Input new email: ");

            if (_userRepository.EmailExists(email))
            {
                WriteLine("Email is already taken.", Style.Error);
                WaitForInput();
                return;
            }

            if (_userRepository.ValidateEmail(email) != Response.Succeeded)
            {
                WriteLine("Email format is invalid.", Style.Error);
                WaitForInput();
                return;
            }

            string password = ReadPassword("Input a new password: ");

            if (string.IsNullOrWhiteSpace(password))
            {
                WriteLine("An empty password is a significant safety risk!", Style.Warning);
                if (!GetConfirmation("Are you sure you want to create an account with no password?"))
                {
                    WriteLine("Cancelled.", Style.Warning);
                    WaitForInput();
                }
            }

            string confimPassword = ReadPassword("Confirm the previously inputted password: ");

            if (password != confimPassword)
            {
                WriteLine("Passwords do not match! Cancelling user creation.", Style.Error);
                WaitForInput();
            }

            if (!Captcha())
            {
                WriteLine("Captcha failed.", Style.Error);
                WaitForInput();
                return;
            }

            User newUser = new User()
            {
                Email = email,
                Password = password,
            };

            Response result = _userRepository.Add(newUser);

            if (result != Response.Succeeded)
            {
                WriteLine("An unhandled exception occured. Error message: " + result + ".", Style.Error);
                WaitForInput();
                return;
            }

            WriteLine($"Added {newUser.Email.ToLower()}.", Style.Success);
            WaitForInput();
            return;
        }
    }
}
