using Internship_7_EF_Dmail.Presentation.Interfaces;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;
using static Internship_7_EF_Dmail.Presentation.Utils.Input;
using Internship_7_EF_Dmail.Presentation.Actions;
using Internship_7_EF_Dmail.Presentation.Utils;

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

        public static void WriteActionsAndOpen(this IList<IAction> actions, bool clear = true)
        {
            bool isExitSelected = false;

            do
            {
                if (clear)
                    Console.Clear();

                actions.WriteActions();
                Write(Messages.OTHER_SELECT_OPTION);

                if (!int.TryParse(Console.ReadLine(), out int userInput))
                {
                    WriteLine(Messages.ERROR_PARSE, Style.Error);
                    WaitForInput();
                    continue;
                }

                var selectedAction = actions.FirstOrDefault(a => a.Index == userInput);

                if (selectedAction == null)
                {
                    WriteLine(Messages.ERROR_OPTION_OUT_OF_RANGE, Style.Error);
                    WaitForInput();
                    continue;
                }

                selectedAction.Open();

                isExitSelected = selectedAction is ExitMenuAction;
            }
            while (!isExitSelected);
        }
    }
}
