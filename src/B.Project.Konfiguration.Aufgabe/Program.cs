using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace B.Project.Konfiguration.Aufgabe
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
            {
                services.AddSingleton<Form1>();
                services.AddSingleton<FahrzuegeConfig>(x => x.GetRequiredService<IConfiguration>().Get<FahrzuegeConfig>());
            }).Build();

            var config = host.Services.GetRequiredService<FahrzuegeConfig>();
          
            var form = host.Services.GetRequiredService<Form1>();
            form.ShowDialog();
        }
    }
}
