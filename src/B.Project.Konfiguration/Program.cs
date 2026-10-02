using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration.Json;

using Microsoft.Extensions.DependencyInjection;


namespace B.Project.Konfiguration
{
    internal static class Program
    {
        public static Microsoft.Extensions.Configuration.IConfiguration configuration;
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
                var hallo = configuration["test"];
                var hallo2 = configuration["Settings:test"];
                var connectionString =
                    configuration.GetConnectionString("test");

            }).Build();
         
            var configTest = configuration.GetSection("ConnectionStrings");
            var test = configTest.GetSection("test");
           
            
            var form = host.Services.GetRequiredService<Form1>();

            form.ShowDialog();



        }
    }
}
