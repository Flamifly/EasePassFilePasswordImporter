using EasePassExtensibility;

namespace EasePassFilePasswordImporter
{
    public class AboutPage : IAboutPlugin
    {
        public string PluginName => "File Password Importer";

        public string PluginDescription => "Imports JSON, XML and CSV Files. The Files can be selected after starting the Import process.";

        public string PluginAuthor => "Flamy";

        public string PluginAuthorURL => "https://github.com/Flamifly";

        public Uri PluginIcon => Icon.GetIconUri();
    }
}
