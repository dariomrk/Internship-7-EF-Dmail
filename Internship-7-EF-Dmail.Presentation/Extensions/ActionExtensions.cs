using Internship_7_EF_Dmail.Presentation.Interfaces;

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
            actions.ForEach((action) => Console.WriteLine(action));
        }

        public static int SelectAction(this IList<IAction> actions)
        {
            while (true)
            {
                Console.Clear();
                actions.WriteActions();
                Console.WriteLine("Select one of the provided options: ");

                if(!int.TryParse(Console.ReadLine(), out int userInput))
                {
                    // TODO
                }
            }
        }
    }
}
