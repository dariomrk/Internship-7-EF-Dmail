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
        public static string ReadPassword(string message)
        {
            Write(message);
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            Console.WriteLine();
            return password;
        }
    }
}
