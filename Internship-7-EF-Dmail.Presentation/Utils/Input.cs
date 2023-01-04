using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Presentation.Extensions;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
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
            WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static string ReadPassword(string message)
        {
            Write(message);
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
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

        public static bool GetConfirmation(string message)
        {
            while(true)
            {
                WriteLine(message);
                Write("Input Y to confirm or N (no) to cancel: ");
                string input = Read().ToLower();

                if (input == "y")
                    return true;
                if (input == "n")
                    return false;

                WriteLine("Invalid input.", Style.Error);
                WaitForInput();
            }
        }

        public static bool Captcha()
        {
            Random r = new();
            string output = "";

            for (int i = 0; i < 8; i++)
            {
                switch (r.Next(0,3))
                {
                    case 0:
                        output += (char) r.Next(48, 58);
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

            if(!mails.Any())
            {
                WriteLine("There are no mails to show.", Style.Warning);
                WaitForInput();
                return false;
            }

            Write("Input the index of the mail you want to select:");

            if (!int.TryParse(Read(), out int userInput))
            {
                WriteLine("Invalid input.", Style.Error);
                WaitForInput();
                return false;
            }

            if(userInput < 0 || userInput > mails.Count())
            {
                WriteLine("Mail does not exist.", Style.Error);
                WaitForInput();
                return false;
            }

            selected = mails[userInput];
            return true;
        }
    }
}
