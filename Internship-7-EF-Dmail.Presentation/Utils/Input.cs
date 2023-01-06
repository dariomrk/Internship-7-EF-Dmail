using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Presentation.Extensions;
using static Internship_7_EF_Dmail.Presentation.Utils.Output;

namespace Internship_7_EF_Dmail.Presentation.Utils
{
    public static class Input
    {
        public static string Read()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public static string Read(string message)
        {
            Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        public static void WaitForInput()
        {
            WriteLine(PROMPT_PRESS_ANY_KEY);
            Console.ReadKey();
        }

        public static string ReadPassword(string message)
        {
            Write(message);
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
                {
                    password = password.Truncate(password.Length-1);
                    continue;
                }
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            Console.WriteLine();
            return password;
        }

        public static bool GetConfirmation(string message = "", bool clear = true)
        {
            while (true)
            {
                if (clear)
                    Console.Clear();
                if (!string.IsNullOrEmpty(message))
                    WriteLine(message);
                Write(PROMPT_CONFIRMATION_Y_N);
                string input = Read().ToLower();

                if (input == "y" || input == "yes")
                    return true;
                if (input == "n" || input == "no")
                    return false;

                WriteLine(ERROR_INVALID, Style.Error);
                WaitForInput();
            }
        }

        public static bool Captcha()
        {
            Random r = new();
            string output = "";

            for (int i = 0; i < 8; i++)
            {
                switch (r.Next(0, 3))
                {
                    case 0:
                        output += (char)r.Next(48, 58);
                        break;
                    case 1:
                        output += (char)r.Next(65, 91);
                        break;
                    case 2:
                        output += (char)r.Next(97, 123);
                        break;
                }
            }

            WriteLine($"Captcha: {output}");
            string input = Read("Re-type the captcha: ");

            if (output == input)
                return true;
            return false;
        }

        public static bool TrySelectMailByIndex(IList<Mail> mails, out Mail? selected)
        {
            selected = null;

            if (!mails.Any())
            {
                WriteLine(OTHER_NO_MAILS, Style.Warning);
                WaitForInput();
                return false;
            }

            Write("Input the index of the mail you want to select: ");

            if (!int.TryParse(Read(), out int userInput))
            {
                WriteLine(ERROR_INVALID, Style.Error);
                WaitForInput();
                return false;
            }

            if (userInput < 0 || userInput > mails.Count())
            {
                WriteLine(ERROR_MAIL_DOES_NOT_EXIST, Style.Error);
                WaitForInput();
                return false;
            }

            selected = mails[userInput];
            return true;
        }

        public static IList<Mail> PromptFilterByFormat(ICollection<Mail> input)
        {
            Console.Clear();
            if (!GetConfirmation("Do you want to filter mail by format as well?"))
            {
                Console.Clear();
                return input.ToList();
            }

            List<string> options = new List<string>()
            {
                "Retrieve emails",
                "Retrieve events",
            };

            Console.Clear();
            return PromptSelectOption(options) == 0 ?
                input.Where(m => m.Format == Data.Enums.MailFormat.Email).ToList()
                :
                input.Where(m => m.Format == Data.Enums.MailFormat.Event).ToList();
        }

        public static int PromptSelectOption(IList<string> options, string message = "")
        {
            while (true)
            {
                if(!string.IsNullOrEmpty(message))
                    WriteLine(message);
                options.ForEach((option, i) => WriteLine($"{i} - {option}"));
                Write(PROMPT_SELECT_OPTION);

                if (!int.TryParse(Read(), out int userSelection))
                {
                    WriteLine(ERROR_INVALID, Style.Error);
                    WaitForInput();
                    continue;
                }

                if (userSelection < 0 || userSelection >= options.Count)
                {
                    WriteLine(ERROR_OPTION_OUT_OF_RANGE, Style.Error);
                    WaitForInput();
                    continue;
                }
                return userSelection;
            }
        }
    }
}
