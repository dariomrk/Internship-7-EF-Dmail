using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Domain.Enums;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using Internship_7_EF_Dmail.Data.Models;

namespace Internship_7_EF_Dmail.Presentation.Actions.Auth
{
    public class AuthAction : BaseMenuAction
    {
        private static User? _loggedInAs;

        public static void ClearLogin()
        {
            _loggedInAs = null;
        }
        public static User? GetCurrentLogin()
        {
            if(_loggedInAs == null)
                return null;
            return new User
            {
                Id = _loggedInAs.Id,
                Email = _loggedInAs.Email,
                CreatedAt = _loggedInAs.CreatedAt,
                Status = _loggedInAs.Status,
                Rights = _loggedInAs.Rights,
            };
        }

        private readonly UserRepository _userRepository;
        private readonly AuthRepository _authRepository;

        private DateTime _lastLogin;

        public AuthAction(UserRepository userRepository, AuthRepository authRepository, IList<IAction> actions) : base(actions)
        {
            Name = "Authenticate";
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        public override void Open()
        {
            Console.Clear();
            WriteLine(Name);

            if ((DateTime.UtcNow - _lastLogin) < TimeSpan.FromSeconds(30))
            {
                WriteLine($"You have been timed out. " +
                    $"Please wait {(TimeSpan.FromSeconds(30) - (DateTime.UtcNow - _lastLogin)).Seconds}s" +
                    $" for the next login attempt.", Style.Warning);
                WaitForInput();
                return;
            }

            string email = Read("Input email: ");

            if(!_userRepository.EmailExists(email))
            {
                WriteLine("Email does not exist.", Style.Error);
                WaitForInput();
                return;
            }

            string password = ReadPassword("Input password: ");
            if (_authRepository.Authenticate(email, password) == Response.ErrorInvalidPassword)
            {
                _lastLogin = DateTime.UtcNow;
                WriteLine("Password is invalid.", Style.Error);
                WaitForInput();
                return;
            }

            if(!_userRepository.IsActive(email))
            {
                WriteLine("Account is disabled.", Style.Error);
                WaitForInput();
                return;
            }

            WriteLine($"Authenticated as {email}.", Style.Success);
            WaitForInput();

            _loggedInAs = _userRepository.GetByEmail(email);

            base.Open();
        }
    }
}
