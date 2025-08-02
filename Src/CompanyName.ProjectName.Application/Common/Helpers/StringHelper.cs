namespace CompanyName.ProjectName.Application.Common.Helpers
{
    public static class StringHelper
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value) || maxLength < 1)
            {
                return value;
            }

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string ToLowerCase(string value)
        {
            return value?.ToLowerInvariant();
        }

        public static string ToUpperCase(string value)
        {
            return value?.ToUpperInvariant();
        }
    }
}
