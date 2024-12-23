using EasePassExtensibility;

namespace EasePassFilePasswordImporter.Import
{
    /// <summary>
    /// Implements the Methods for the Import Process
    /// </summary>
    internal interface IImport
    {
        /// <summary>
        /// Gets the <see cref="PasswordItem"/>s of the given File
        /// </summary>
        /// <param name="path">The Path to the File, which should be imported</param>
        /// <returns>Returns the Passwords of the File</returns>
        public static abstract PasswordItem[] GetPasswordItems(string path);
    }
}
