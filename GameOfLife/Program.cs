namespace GameOfLife
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if NET6_0_OR_GREATER
            ApplicationConfiguration.Initialize();
#elif NET5_0_OR_GREATER
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#endif
            Application.Run(new MainForm());
        }
    }
}