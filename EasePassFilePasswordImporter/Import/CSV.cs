using EasePassFilePasswordImporter.Extension;
using EasePassExtensibility;
using System.Runtime.InteropServices;

namespace EasePassFilePasswordImporter.Import
{
    internal class CSV : IImport
    {
        private static string[] _importTerms = new string[] { "UserName", "Password", "Website", "DisplayName", "Notes", "EMail", "TOTPSecret", "TOTPInterval", "TOTPAlgorithm", "TOTPDigits" };
        private static string[] _defaultImportTerms = new string[] { "DisplayName", "UserName", "EMail", "Password", "Website", "Notes" };

        /// <summary>
        /// Gets the Password of the given <paramref name="path"/>
        /// </summary>
        /// <param name="path">The Path to a CSV File</param>
        /// <returns>Returns the Passwords in the CSV File</returns>
        public static PasswordItem[] GetPasswordItems(string path)
        {
            List<PasswordItem> items = new List<PasswordItem>();
            bool isHeader = false;
            int seperatorCount = 0;
            char seperator = char.MinValue;
            Span<string> terms = Span<string>.Empty;
            Span<Range> ranges = Span<Range>.Empty;

            int count = 0;
            foreach (ReadOnlySpan<char> line in File.ReadLines(path))
            {
                // DisplayName; Username; E-Mail; Password; Website; Note;
                if (count == 0)
                {
                    seperator = line.GetSeperator();
                    if (seperator == char.MinValue)
                        break;

                    seperatorCount = line.Count(seperator);
                    if (line[^1] == seperator)
                    {
                        seperatorCount--;
                    }

                    ranges = new Range[seperatorCount + 1];

                    line.Split(ranges, seperator);
                    terms = getImportTerms(line, ranges, out isHeader);
                }
                count++;

                if (!isHeader)
                {
                    if (line.Length == 0)
                        continue;

                    int tempCount = line.Count(seperator);
                    if (line[^1] == seperator)
                    {
                        tempCount--;
                    }

                    if (tempCount != seperatorCount)
                        continue;

                    PasswordItem item = setPasswordItem(line, ranges, seperator, terms);
                    if (item == default)
                        continue;

                    items.Add(item);
                }
                else
                {
                    isHeader = false;
                }
            }
            return items.ToArray();
        }

        /// <summary>
        /// Sets the Properties of the <see cref="PasswordItem"/> by the <paramref name="line"/>
        /// </summary>
        /// <param name="line">The Line, which includes the Infos to set the Properties</param>
        /// <param name="ranges">The Range of each Term, which should be set</param>
        /// <param name="seperator">The Seperator of the Terms</param>
        /// <param name="terms">The Terms, which should be used</param>
        /// <returns>Returns the new created <see cref="PasswordItem"/> by the Terms of the <paramref name="line"/></returns>
        private static PasswordItem setPasswordItem(ReadOnlySpan<char> line, Span<Range> ranges, char seperator, Span<string> terms)
        {
            PasswordItem item = new PasswordItem();
            line.Split(ranges, seperator);
            for (int i = 0; i < ranges.Length; i++)
            {
                if (terms[i] == _importTerms[0])
                {
                    item.UserName = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[1])
                {
                    item.Password = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[2])
                {
                    item.Website = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[3])
                {
                    item.DisplayName = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[4])
                {
                    item.Notes = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[5])
                {
                    item.EMail = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[6])
                {
                    item.TOTPSecret = line[ranges[i]].ToString();
                }
                else if (terms[i] == _importTerms[7])
                {
                    int.TryParse(line[ranges[i]], out int result);
                    item.TOTPInterval = result;
                }
                else if (terms[i] == _importTerms[8])
                {
                    PasswordItem.Algorithm result = PasswordItem.Algorithm.SHA1;
                    try
                    {
                        result = (PasswordItem.Algorithm)Enum.Parse(typeof(PasswordItem.Algorithm), line[ranges[i]]);
                    }
                    catch { }
                    item.TOTPAlgorithm = result;
                }
                else if (terms[i] == _importTerms[9])
                {
                    int.TryParse(line[ranges[i]], out int result);
                    item.TOTPDigits = result;
                }
            }
            return item;
        }

        /// <summary>
        /// Gets the Terms, which should be imported
        /// </summary>
        /// <param name="line">The Headline</param>
        /// <param name="ranges">The Ranges to the next Term</param>
        /// <param name="isHeader">Specifies if the Line is a Headline or a Record</param>
        /// <returns>Returns every Terms, which should be imported. If the <paramref name="line"/> is not a Headline the default terms will be used.</returns>
        private static Span<string> getImportTerms(ReadOnlySpan<char> line, Span<Range> ranges, out bool isHeader)
        {
            List<string> terms = new List<string>();
            isHeader = true;
            foreach (Range range in ranges)
            {
                ReadOnlySpan<char> term = line[range].Trim();
                if (_importTerms.Contains(term))
                {
                    terms.Add(term.ToString());
                }
                else if (term == "")
                {
                    continue;
                }
                else
                {
                    isHeader = false;
                    return _defaultImportTerms.AsSpan();
                }
            }
            return CollectionsMarshal.AsSpan(terms);
        }
    }
}
