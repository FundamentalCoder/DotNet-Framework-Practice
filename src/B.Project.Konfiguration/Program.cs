using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

using Microsoft.Extensions.DependencyInjection;

namespace B.Project.Konfiguration
{
    internal static class Program
    {
        public static IConfiguration configuration;
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
            {
                services.AddSingleton<Form1>();
                configuration = context.Configuration;
                string hallo = configuration.GetConnectionString("test");
                hallo = hallo?.Trim();

            }).Build();

            var configTest = configuration.GetSection("ConnectionStrings");
            var test = configTest.GetSection("test");
            
            var form = host.Services.GetRequiredService<Form1>();
            
            form.ShowDialog();
            
            

        }
    }
}
