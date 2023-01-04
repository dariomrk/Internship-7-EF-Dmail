namespace Internship_7_EF_Dmail.Presentation.Extensions
{
    public static class StringExtensions
    {
        public static string Truncate(this string value, int length)
        {
            return value[..Math.Min(length, value.Length)];
        }
    }
}
