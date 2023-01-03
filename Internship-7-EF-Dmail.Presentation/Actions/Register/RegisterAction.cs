using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Actions.Register
{
    public class RegisterAction : BaseMenuAction
    {
        private readonly UserRepository _userRepository;
        public RegisterAction(IList<IAction> actions, UserRepository userRepository) : base(actions)
        {
            Name = "Register";
            _userRepository = userRepository;
        }

        public void Open()
        {
            Console.Clear();
            // TODO Implement registration
        }
    }
}
