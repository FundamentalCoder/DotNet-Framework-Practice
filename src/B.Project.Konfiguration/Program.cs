using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration.Json;
using B.Project.Konfiguration.Configs;
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

                    services.AddKeyedSingleton<ITier, Katze>("Katze", (sp, key) => new Katze { Rasse = "Siam", Name = "Mia", Alter = 2 });
                    services.AddKeyedSingleton<ITier, Hund>("Hund", (sp, key) => new Hund { Rasse = "Labrador", Name = "Bello", Alter = 3 });

                    services.AddSingleton<Tiere>();
                    services.AddSingleton<Form1>();
                    services.AddSingleton<RootConfig>(x => x.GetRequiredService<IConfiguration>().Get<RootConfig>());

                }).Build();


                //var configTest = configuration.GetSection("ConnectionStrings");
                //var test = configTest.GetSection("test");

                var config = host.Services.GetRequiredService<RootConfig>();


                //var tiere = new Tiere(new Hund { Rasse = "Labrador", Name = "Bello", Alter = 3 }, new Katze { Rasse = "Siam", Name = "Mia", Alter = 2 });

                var form = host.Services.GetRequiredService<Form1>();
                form.ShowDialog();
            }
        }


        public class Tiere
        {
            public ITier Hund { get; set; }
            public ITier Katze { get; set; }

            public Tiere([FromKeyedServices("Hund")] ITier hund, [FromKeyedServices("Katze")] ITier katze)
            {
                this.Hund = hund;
                this.Katze = katze;
            }
            public string Name { get; set; }
            public int Alter { get; set; }

            public string HundAnzeigen()
            {
                return Hund.Beschreibung();
            }

            public string KatzeAnzeigen()
            {
                return Katze.Beschreibung();
            }
        }

        public interface ITier
        {
            string Rasse { get; set; }
            string Name { get; set; }
            int Alter { get; set; }
            string Beschreibung();
        }
        public class Hund : ITier
        {
            public string Rasse { get; set; }
            public string Name { get; set; }
            public int Alter { get; set; }

            public string Beschreibung()
            {
                return $"Hund: {Name}, Rasse: {Rasse}, Alter: {Alter}";
            }
        }

        public class Katze : ITier
        {
            public string Rasse { get; set; }
            public string Name { get; set; }
            public int Alter { get; set; }

            public string Beschreibung()
            {
                return $"Katze: {Name}, Rasse: {Rasse}, Alter: {Alter}";
            }
        }
    }
