namespace EasePassFilePasswordImporter.Helper
{
    internal static class FilePickerHelper
    {
        /// <summary>
        /// Picks the Files
        /// </summary>
        /// <param name="filter">The Filter, which should be used in the Dialog</param>
        /// <returns>Returns the File paths</returns>
        public static string[] PickFiles(string filter)
        {
            OpenFileDialog openPicker = new OpenFileDialog();
            openPicker.Multiselect = true;
            openPicker.DefaultExt = "";
            openPicker.Filter = filter;
            DialogResult result = openPicker.ShowDialog();

            if (result == DialogResult.OK)
            {
                return openPicker.FileNames;
            }
            return default;
        }
    }
}
