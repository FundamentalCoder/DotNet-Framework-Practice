using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace B.Project.Konfiguration.SettingsUmgebungen
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            
            var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
            {
                services.AddSingleton<Form1>();
                services.AddSingleton<RootConfig>(x => x.GetRequiredService<IConfiguration>().Get<RootConfig>());
            }).Build();

          
          
            var form = host.Services.GetRequiredService<Form1>();
            var environment = host.Services.GetRequiredService<IHostEnvironment>();
            form.ShowDialog();
            MessageBox.Show(
                $"Aktuelle Umgebung: {environment.EnvironmentName}");
        }
    }
}