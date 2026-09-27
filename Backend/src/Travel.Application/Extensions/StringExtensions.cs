namespace Travel.Application.Extensions
{
    internal static class StringExtensions
    {
        public static string Capitalize(this String str)
        {
            string first = str.First().ToString().ToUpper();
            string other = str.Remove(0, 1).ToLower();

            return $"{first}{other}";
        }
    }
}
