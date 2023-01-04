using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Presentation.Extensions;

namespace Internship_7_EF_Dmail.Presentation.Utils
{
    public static class Output
    {
        public enum Style
        {
            Standard,
            Success,
            Warning,
            Error,
        }

        public struct StyleSettings
        {
            public ConsoleColor Foreground { get; init; }
            public ConsoleColor Background { get; init; }
            public string PrependMessage { get; init; }
        }

        public static StyleSettings GetStyleSettings(Style style)
        {
            return style switch
            {
                Style.Standard => new StyleSettings
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.Black,
                    PrependMessage = "",
                },
                Style.Success => new StyleSettings
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.DarkGreen,
                    PrependMessage = "Success: ",
                },
                Style.Warning => new StyleSettings
                {
                    Foreground = ConsoleColor.Black,
                    Background = ConsoleColor.DarkYellow,
                    PrependMessage = "Warning: ",
                },
                Style.Error => new StyleSettings
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.DarkRed,
                    PrependMessage = "Error! ",
                },
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public static void Write(string message, Style writeStyle = Style.Standard)
        {
            var style = GetStyleSettings(writeStyle);

            Console.ForegroundColor = style.Foreground;
            Console.BackgroundColor = style.Background;
            Console.Write(style.PrependMessage + message);
            Console.ResetColor();
        }

        public static void WriteLine(string message, Style writeStyle = Style.Standard)
        {
            var style = GetStyleSettings(writeStyle);

            Console.ForegroundColor = style.Foreground;
            Console.BackgroundColor = style.Background;
            Console.WriteLine(style.PrependMessage + message);
            Console.ResetColor();
        }

        public static void WriteMailsAscending(IList<Mail> mails)
        {
            IList<Mail> ordered = mails.OrderBy(m => m.CreatedAt).ToList();
            WriteLine("Ord. |" +
                " Title                    |" +
                " Sender                ");
            ordered.ForEach((m, i) => WriteLine($"{i}.   |" +
                $" {m.Title.Truncate(24).PadRight(24)} |" +
                $" {m.Sender.Email.Truncate(24).PadRight(24)}"));
        }
    }
}
