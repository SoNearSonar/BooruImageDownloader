namespace BooruImageDownloader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appName = "Booru Image Downloader";
            _ = new Mutex(true, appName, out bool appNotLoaded);

            if (!appNotLoaded)
            {
                MessageBox.Show("You cannot have more than one instance of this program running", $"{appName} is already running", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new BooruImageDownloader());
        }
    }
}