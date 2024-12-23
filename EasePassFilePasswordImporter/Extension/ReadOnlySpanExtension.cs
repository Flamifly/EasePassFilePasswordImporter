namespace EasePassFilePasswordImporter.Extension
{
    public static class ReadOnlySpanExtension
    {
        /// <summary>
        /// Gets the Seperator of a CSV File
        /// </summary>
        /// <param name="span">The Line of a CSV File</param>
        /// <returns>Returns the Seperator, which was used in the CSV Line. If no Seperator was found <see cref="char.MinValue"/> will be returned</returns>
        public static char GetSeperator(this ReadOnlySpan<char> span)
        {
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i].IsSeperator(out char seperator))
                {
                    return seperator;
                }
            }
            return char.MinValue;
        }
        
        /// <summary>
        /// Counts the occurence of <paramref name="c"/> in the <paramref name="span"/>
        /// </summary>
        /// <param name="span">The Span</param>
        /// <param name="c">The <paramref name="c"/>, which occurence should be counted</param>
        /// <returns>Returns the amount of the occurences of <paramref name="c"/> in the <paramref name="span"/></returns>
        public static int Count(this ReadOnlySpan<char> span, char c)
        {
            int count = 0;
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == c)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
