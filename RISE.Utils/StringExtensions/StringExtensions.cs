namespace RISE.Utils.StringExtensions
{
    public static class StringExtensions
    {
        public static string FormatTokenToClient(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            var array = source.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '.')
                    array[i] = '|';
            }

            return new string(array);
        }

        public static string FormatGuidToClient(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            var array = source.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '-')
                    array[i] = '|';
            }

            return new string(array);
        }
    }
}