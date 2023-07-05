namespace Azel_Raportare_Balkani
{
    internal static class Program
    {
        const int SW_SHOW = 5;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.



            const string appName = "Azel_Raportare_Balkani";
            bool createdNew;

           var mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                var currentProcess = System.Diagnostics.Process.GetCurrentProcess();

                // search for another process with the same name
                var anotherProcess = System.Diagnostics.Process.GetProcesses().FirstOrDefault(p => p.ProcessName == currentProcess.ProcessName);

                if (anotherProcess != null)
                {
                    ShowWindow(anotherProcess.MainWindowHandle, SW_SHOW);
                }
                MessageBox.Show("Aplicatia este deja deschisa! Oprire instanta noua.");
                return;
            }

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            try
            {
                System.Windows.Forms.Application.Run(new Aplicatie_Raportare_Balkani());
            }
            catch (Exception ex)
            {

            }
        }
    }
}