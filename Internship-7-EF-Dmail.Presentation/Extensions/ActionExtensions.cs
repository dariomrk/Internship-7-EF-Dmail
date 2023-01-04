using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;

namespace Internship_7_EF_Dmail.Presentation.Extensions
{
    public static class ActionExtensions
    {
        public static void SetIndexes(this IList<IAction> actions)
        {
            actions.ForEach((action,index) => action.Index = index);
        }

        public static void WriteActions(this IList<IAction> actions)
        {
            actions.ForEach((action) => WriteLine($"{action.Index} - {action.Name}"));
        }

        public static void WriteActionsAndOpen(this IList<IAction> actions)
        {
            while (true)
            {
                Console.Clear();
                actions.WriteActions();
                Write("Select one of the provided options: ");

                if (!int.TryParse(Console.ReadLine(), out int userInput))
                {
                    WriteLine("Cannot parse input. Please input an integer.", Style.Error);
                    WaitForInput();
                    continue;
                }

                var selectedAction = actions.FirstOrDefault(a => a.Index == userInput);

                if (selectedAction == null)
                {
                    WriteLine("Option does not exist. Please input a valid option.", Style.Error);
                    WaitForInput();
                    continue;
                }

                if (selectedAction is ReturnAction)
                    return;

                selectedAction.Open();
            }
        }
    }
}
