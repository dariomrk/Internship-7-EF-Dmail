using Internship_7_EF_Dmail.Presentation.Actions.Register;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class RegisterFactory
    {
        public static RegisterAction Create()
        {
            return new RegisterAction(RepositoryFactory.Create<UserRepository>());
        }
    }
}
