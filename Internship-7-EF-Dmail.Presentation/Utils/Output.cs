using Internship_7_EF_Dmail.Data.Enums;
using Internship_7_EF_Dmail.Data.Models;
using Internship_7_EF_Dmail.Domain.Enums;
using Internship_7_EF_Dmail.Domain.Repositories;
using Internship_7_EF_Dmail.Presentation.Actions.MainMenuActions;
using Internship_7_EF_Dmail.Presentation.Extensions;

namespace Internship_7_EF_Dmail.Presentation.Utils
{
    public static class Output
    {
        public enum Style
        {
            /// <summary>
            /// No prepend, white on black.
            /// </summary>
            Standard,
            /// <summary>
            /// No prepend, white on green.
            /// </summary>
            Positive,
            /// <summary>
            /// "Success: ", white on green.
            /// </summary>
            Success,
            /// <summary>
            /// No prepend, black on yellow.
            /// </summary>
            Emphasis,
            /// <summary>
            /// "Warning: ", black on yellow.
            /// </summary>
            Warning,
            /// <summary>
            /// No prepend, white on red.
            /// </summary>
            Negative,
            /// <summary>
            /// "Error! ", white on red.
            /// </summary>
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
                Style.Positive => new StyleSettings
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.DarkGreen,
                    PrependMessage = "",
                },
                Style.Emphasis => new StyleSettings
                {
                    Foreground = ConsoleColor.Black,
                    Background = ConsoleColor.DarkYellow,
                    PrependMessage = "",
                },
                Style.Warning => new StyleSettings
                {
                    Foreground = ConsoleColor.Black,
                    Background = ConsoleColor.DarkYellow,
                    PrependMessage = "Warning: ",
                },
                Style.Negative => new StyleSettings
                {
                    Foreground = ConsoleColor.White,
                    Background = ConsoleColor.DarkRed,
                    PrependMessage = "",
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

        public static void WriteLine(string message = "", Style writeStyle = Style.Standard)
        {
            var style = GetStyleSettings(writeStyle);

            Console.ForegroundColor = style.Foreground;
            Console.BackgroundColor = style.Background;
            Console.WriteLine(style.PrependMessage + message);
            Console.ResetColor();
        }

        public static void WriteRecievedMails(IList<Mail> mails)
        {
            WriteLine("Ord. | Title                                            | Sender");
            if (!mails.Any())
                return;
            mails.ForEach((m, i) => WriteLine($"{i}    |" +
                $" {m.Title.Truncate(48).PadRight(48)} |" +
                $" {m.Sender.Email.Truncate(24).PadRight(24)}"));
        }

        public static void WriteSentMails(IList<Mail> mails, MailRepository mailRepository)
        {
            WriteLine("Ord. | Title                                            | Recipient");
            if (!mails.Any())
                return;
            mails.ForEach((m, i) => WriteLine($"{i}    |" +
                $" {m.Title.Truncate(48).PadRight(48)} | " +
                GetRecipientsEmails(mailRepository
                .GetRecipients(m.Id)
                .Select(m => m.Email)
                .ToList()).Truncate(24).PadRight(24)));
        }

        public static string GetRecipientsEmails(IList<string> recipients)
        {
            if (recipients.Count > 1)
                return "multiple recipients";
            return recipients.FirstOrDefault("no recipients");
        }

        public static void WriteInvitedUsers(Mail mail, string currentUser)
        {
            WriteLine("Invited users:");
            foreach (Recipient recipient in mail.Recipients)
            {
                if (recipient.User == null || recipient.User.Email == currentUser)
                {
                    Write(" |> ");
                    Write("my response", Style.Emphasis);
                    Write(" : ");
                }
                else
                    Write($" |> {recipient.User.Email} : ");

                if (recipient.EventStatus == EventStatus.NoResponse) WriteLine("no response");
                else if (recipient.EventStatus == EventStatus.Accepted) WriteLine("accepted", Style.Positive);
                else if (recipient.EventStatus == EventStatus.Rejected) WriteLine("rejected", Style.Negative);
            }
        }

        public static void WriteMail(Mail mail, User sender)
        {
            Console.Clear();
            if (mail.Format == MailFormat.Email)
            {
                WriteLine("--- EMAIL START ---");
                WriteLine(
                    $"Title:      {mail.Title}\n" +
                    $"Created at: {mail.CreatedAt}\n" +
                    $"Sender:     {mail.Sender.Email}\n" +
                    $"Content:\n{mail.Content}");
                WriteLine("--- EMAIL END ---");
            }
            else if (mail.Format == MailFormat.Event)
            {
                WriteLine("--- EVENT START ---");
                WriteLine(
                    $"Title:            {mail.Title}\n" +
                    $"Event start time: {mail.EventStartAt}\n" +
                    $"Event duration:   {mail.EventDuration!.Value.ToString(@"hh\:mm\:ss")}\n" +
                    $"Sender:           {mail.Sender.Email}");
                WriteInvitedUsers(mail,
                    sender.Email);
                WriteLine("--- EVENT END ---");
            }
        }

        public static void WriteGenericResponse(Response response)
        {
            switch (response)
            {
                case Response.Succeeded:
                    WriteLine(SUCCESS_DONE, Style.Positive);
                    WaitForInput();
                    break;
                case Response.NoChanges:
                    WriteLine(WARN_NO_CHANGES, Style.Warning);
                    WaitForInput();
                    break;
                default:
                    WriteLine(ERROR_UNHANDLED, Style.Error);
                    WaitForInput();
                    break;
            }
        }
    }
}
