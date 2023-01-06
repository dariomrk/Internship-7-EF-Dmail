using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Factories;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Actions.AuthenticatedUserActions.OutboxActions;
using Internship_7_EF_Dmail.Presentation.Extensions;
using Internship_7_EF_Dmail.Presentation.Interfaces;

namespace Internship_7_EF_Dmail.Presentation.Factories
{
    public class OutboxMenuFactory
    {
        public static IList<IAction> CreateActions(Mail selected)
        {
            var actions = new List<IAction>()
            {
                new ExitMenuAction(),

                new HideMailAction(
                    RepositoryFactory.Create<MailRepository>(),
                    selected),
            };

            actions.SetIndexes();

            return actions;
        }
    }
}
