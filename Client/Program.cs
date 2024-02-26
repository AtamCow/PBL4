namespace Client
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

            using (var connectForm = new ConnectForm())
            {
                var result = connectForm.ShowDialog();

                if (result == DialogResult.OK && connectForm.IsConnected)
                {
                    Application.Run(new MainForm());
                }
                else
                {
                    
                }
            }
        }
    }
}