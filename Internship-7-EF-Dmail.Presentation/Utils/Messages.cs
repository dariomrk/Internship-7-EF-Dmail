namespace Internship_7_EF_Dmail.Presentation.Utils
{
    /// <summary>
    /// Set of standard message constants.
    /// </summary>
    public static class Messages
    {
        public const string ERROR_PARSE = "Cannot parse input.";
        public const string ERROR_INVALID = "Invalid input.";
        public const string ERROR_OPTION_OUT_OF_RANGE = "Option does not exist";
        public const string ERROR_MAIL_DOES_NOT_EXIST = "Mail does not exist.";
        public const string ERROR_UNHANDLED = "An unhandled exception occured.";
        public const string ERROR_NO_MAILS_WITHIN_CRITERIA = "No mails found within the given search criteria.";

        public const string WARN_NO_CHANGES = "No changes have been applied.";

        public const string SUCCESS_DONE = "Done.";

        public const string OTHER_CANCELLED = "Cancelled.";
        public const string OTHER_NO_MAILS = "There are no mails to show.";

        public const string PROMPT_PRESS_ANY_KEY = "Press any key to continue...";
        public const string PROMPT_CONFIRMATION_Y_N = "Input Y (yes) to confirm or N (no) to cancel: ";
        public const string PROMPT_SELECT_OPTION = "Select one of the provided options: ";
        public const string PROMPT_EMAIL = "Please enter an email: ";
        public const string PROMPT_PASSWORD = "Please enter the password: ";
    }
}
