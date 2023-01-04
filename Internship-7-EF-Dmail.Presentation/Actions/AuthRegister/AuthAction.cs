using Internship_7_EF_Dmail.Domain.Repositories;
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
        public string Name => "Auth";


        public void Open()
        {
            // TODO Implement
        }
    }
}
