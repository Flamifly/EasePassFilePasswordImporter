namespace EasePassFilePasswordImporter.Extension
{
    public static class CharExtension
    {
        private static char[] _seperator = new char[] { '\t', ',', ';', ':'  };
        /// <summary>
        /// Checks if the given <paramref name="c"/> is a valid Seperator of a CSV File
        /// </summary>
        /// <param name="c">The Character, which should be checked</param>
        /// <param name="seperator">The Seperator</param>
        /// <returns>Returns <see langword="true"/> if the <paramref name="c"/> is a valid CSV Seperator</returns>
        public static bool IsSeperator(this char c, out char seperator)
        {
            int index = Array.IndexOf(_seperator, c);
            if (index != -1)
            {
                seperator = _seperator[index];
                return true;
            }
            else
            {
                seperator = char.MinValue;
                return false;
            }
        }
    }
}
