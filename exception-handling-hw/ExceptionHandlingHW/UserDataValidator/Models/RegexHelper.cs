using System.Text.RegularExpressions;

namespace UserDataValidator.Models
{
    public static class RegexHelper
    {
        /// <summary>
        /// Verifies an input agains a regular expression string.
        /// </summary>
        /// <param name="regularExpression"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsRegexMatch(string regularExpression, string input)
        {
            Regex regex = new(regularExpression);
            return regex.IsMatch(input);
        }
    }
}
