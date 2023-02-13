namespace GLRToggle
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string firstTimeCheck = Properties.Settings1.Default.firstTimeCheck;
            //Run 1st time prompt
            if (String.IsNullOrEmpty(firstTimeCheck))
            {
                string firstTimeMessage = "Please select your root Steam folder. By default this should be C:\\Program Files (x86)\\Steam.";
                MessageBox.Show(firstTimeMessage);
                FolderBrowserDialog steampath = new FolderBrowserDialog();
                steampath.Description = "Select your root Steam folder.";
                steampath.ShowDialog();
                string userPath = steampath.SelectedPath;
                string removeCheck = "yes";
                Properties.Settings1.Default.userpath = userPath;
                Properties.Settings1.Default.firstTimeCheck = removeCheck;
                Properties.Settings1.Default.Save();
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new Form1());
            }

        }
    }
}