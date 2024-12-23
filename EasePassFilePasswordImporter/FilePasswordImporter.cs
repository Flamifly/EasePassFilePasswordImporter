using EasePassExtensibility;
using EasePassFilePasswordImporter.Helper;
using EasePassFilePasswordImporter.Import;

namespace EasePassFilePasswordImporter
{
    public class FilePasswordImporter : IPasswordImporter
    {
        /// <summary>
        /// Name of the Plugin
        /// </summary>
        public string SourceName => "File Interface";
        /// <summary>
        /// Icon of the Plugin
        /// </summary>
        public Uri SourceIcon => Icon.GetIconUri();

        /// <summary>
        /// Gets the Passwords of a File
        /// </summary>
        /// <returns>Returns the <see cref="PasswordItem"/>s of one or more Files</returns>
        public PasswordItem[] ImportPasswords()
        {
            List<PasswordItem> passwords = new List<PasswordItem>();
            string[] files = FilePickerHelper.PickFiles("All (*.csv, *.xml, *.json)|*.csv;*.xml;*.json");

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);
                switch (extension)
                {
                    case ".csv":
                        AddPasswordItems<CSV>(file, ref passwords);
                        break;
                    case ".xml":
                        AddPasswordItems<XML>(file, ref passwords);
                        break;
                    case ".json":
                        AddPasswordItems<JSON>(file, ref passwords);
                        break;
                    default:
                        break;
                }
            }
            return passwords.ToArray();
        }

        /// <summary>
        /// Adds the <see cref="PasswordItem"/>s of a File to the already imported <paramref name="items"/>
        /// </summary>
        /// <typeparam name="T">The Type of the Import-File</typeparam>
        /// <param name="path">The Path to the Import-File</param>
        /// <param name="items">The already imported Files</param>
        internal void AddPasswordItems<T>(string path, ref List<PasswordItem> items) where T : IImport
        {
            PasswordItem[] passwords = T.GetPasswordItems(path);
            if (passwords == default || passwords.Length <= 0) return;

            items.AddRange(passwords);
        }

        public bool PasswordsAvailable()
        {
            return true;
        }
    }
}