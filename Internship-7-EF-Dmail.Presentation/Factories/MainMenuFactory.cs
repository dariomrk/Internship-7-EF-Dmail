using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public static class MainMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>()
            {
                new ExitApplicationAction(),
                AuthActionsFactory.Create(),
                new RegisterAction(RepositoryFactory.Create<UserRepository>())
            };
            actions.SetIndexes();
            return actions;
        }
    }
}
