using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;

namespace Internship_7_EF_Dmail.Presentation.Extensions
{
    public static class ActionExtensions
    {
        #region Error message constants
        private const string PARSE_ERROR_MSG = "Cannot parse input. Please input an integer.";
        private const string OUT_OF_RANGE_ERROR_MSG = "Option does not exist. Please input a valid option.";
        #endregion

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
                    WriteLine(PARSE_ERROR_MSG, Style.Error);
                    WaitForInput();
                    continue;
                }

                var selectedAction = actions.FirstOrDefault(a => a.Index == userInput);

                if (selectedAction == null)
                {
                    WriteLine(OUT_OF_RANGE_ERROR_MSG, Style.Error);
                    WaitForInput();
                    continue;
                }

                if (selectedAction is Actions.ExitMenuAction)
                    return;

                selectedAction.Open();
            }
        }
    }
}
