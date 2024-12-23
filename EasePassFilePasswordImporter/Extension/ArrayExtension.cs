namespace EasePassFilePasswordImporter.Extension
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Checks if the <paramref name="value"/> exist in the <paramref name="strings"/>
        /// </summary>
        /// <param name="strings">An Array of Strings</param>
        /// <param name="value">The Value, which should exist in <paramref name="strings"/></param>
        /// <returns>Returns <see langword="true"/> if the <paramref name="value"/> exist in the <paramref name="strings"/></returns>
        public static bool Contains(this string[] strings, ReadOnlySpan<char> value)
        {
            foreach (ReadOnlySpan<char> span in strings)
            {
                if (span.Equals(value, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }
    }
}