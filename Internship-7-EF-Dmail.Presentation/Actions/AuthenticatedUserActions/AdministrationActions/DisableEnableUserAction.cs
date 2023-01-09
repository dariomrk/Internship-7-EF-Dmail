using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.AdministrationActions
{
    public class DisableEnableUserAction : IAction
    {
        private readonly UserRepository _userRepository;
        private readonly UserStatus _userStatus;
        private readonly User _authenticatedUser;

        public DisableEnableUserAction(
            UserRepository userRepository,
            UserStatus userStatus,
            User authenticatedUser)
        {
            _userRepository=userRepository;
            _userStatus=userStatus;
            Name= userStatus == UserStatus.Active ? "Activate user" : "Disable user";
            _authenticatedUser=authenticatedUser;
        }

        public int Index { get; set; }
        public string Name { get; init; }

        public void Open()
        {
            Console.Clear();
            WriteLine(Name);

            IList<User> users = _userRepository.GetAll()
                .Where(u => u.Status != _userStatus && u.Email != _authenticatedUser.Email)
                .ToList();

            if (!users.Any())
            {
                WriteLine(ERROR_NO_MAILS_WITHIN_CRITERIA, Style.Error);
                WaitForInput();
                return;
            }

            for (int i = 0; i<users.Count; i++)
            {
                User user = users[i];
                WriteLine($"{i,-4} | {user.Email}");
            }

            if (!TrySelectUserByIndex(users, out User selected))
            {
                return;
            }

            if (!GetConfirmation($"Are you sure you want to change the user status to " +
                $"{(_userStatus == UserStatus.Active ? "active" : "disabled")}?"))
            {
                WriteLine(OTHER_CANCELLED, Style.Emphasis);
                WaitForInput();
                return;
            }

            Response response = _userRepository.UpdateStatus(selected!.Id, _userStatus);

            WriteGenericResponse(response);
        }
    }
}
