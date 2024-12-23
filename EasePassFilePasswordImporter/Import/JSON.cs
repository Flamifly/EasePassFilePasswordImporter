using EasePassExtensibility;

namespace EasePassFilePasswordImporter.Import
{
    internal class JSON : IImport
    {
        public static PasswordItem[] GetPasswordItems(string path)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<PasswordItem[]>(File.ReadAllText(path));
            }
            catch { }
            return default;
        }
    }
}
