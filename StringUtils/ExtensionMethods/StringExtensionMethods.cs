using System.Linq;

namespace StringUtils.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string ReplaceSpecialCharacters(this string input)
        {
            return input.Replace('ı', 'i')
                .Replace('ç', 'c')
                .Replace('ö', 'o')
                .Replace('ş', 's')
                .Replace('ü', 'u')
                .Replace('ğ', 'g')
                .Replace('İ', 'I')
                .Replace('Ç', 'C')
                .Replace('Ö', 'O')
                .Replace('Ş', 'S')
                .Replace('Ü', 'U')
                .Replace('Ğ', 'G');
        }
        public static string RemovePath(this string input)
        {
            if (input.Contains("\\"))
            {
                var modifiedInput = input.SkipWhile(s => s != '\\').Skip(1);
                string output = string.Empty;
                var enumerable = modifiedInput as char[] ?? modifiedInput.ToArray();
                for (int i = 0; i < enumerable.Count(); i++)
                {
                    output += enumerable[i];
                }
                return RemovePath(output);
            }
            return input;
        }
    }
}
