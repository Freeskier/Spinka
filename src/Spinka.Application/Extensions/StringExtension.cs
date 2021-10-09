namespace Spinka.Application.Extensions
{
    public static class StringExtension
    {
        public static string ToUpperCaseFirstInvariant(this string convertString)
            => (char.ToUpperInvariant(convertString[0]) + convertString.Substring(1).ToLowerInvariant());
    }
}