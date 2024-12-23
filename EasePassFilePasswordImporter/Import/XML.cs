using EasePassExtensibility;
using System.Xml.Serialization;

namespace EasePassFilePasswordImporter.Import
{
    internal class XML : IImport
    {
        public static PasswordItem[] GetPasswordItems(string path)
        {
            try
            {
                string content = File.ReadAllText(path);
                XmlSerializer serializer = new XmlSerializer(typeof(PasswordItem[]));
                using (StringReader stringReader = new StringReader(content))
                {
                    return (PasswordItem[])serializer.Deserialize(stringReader);
                }
            }
            catch { }
            return default;
        }
    }
}
