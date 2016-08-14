namespace GoogleVision.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string RemoveLastChar(this string input)
        {
            return input.Remove(input.Length - 1);
        }
    }
}
