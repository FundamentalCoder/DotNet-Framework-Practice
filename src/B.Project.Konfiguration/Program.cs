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


            //var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
            //{

            //    services.AddKeyedSingleton<ITier, Katze>("Katze", (sp, key) => new Katze { Rasse = "Siam", Name = "Mia", Alter = 2 });
            //    services.AddKeyedSingleton<ITier, Hund>("Hund", (sp, key) => new Hund { Rasse = "Labrador", Name = "Bello", Alter = 3 });

            //    services.AddSingleton<Tiere>();
            //    services.AddSingleton<Form1>();
            //    services.AddSingleton<RootConfig>(x => x.GetRequiredService<IConfiguration>().Get<RootConfig>());

            //}).Build();

            var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) => { 
                
                services.AddKeyedSingleton<IFahrzeug, Auto>("Auto",(sp, key) => new Auto { Marke = "BMW", Modell = "X5", Baujahr = 2020, Reifen = 4 });
                services.AddKeyedSingleton<IFahrzeug, Motorrad>("Motorrad",(sp, key) => new Motorrad { Marke = "Yamaha", Modell = "R1", Baujahr = 2021, Reifen = 2 });
                services.AddKeyedSingleton<IFahrzeug, Lastwagen>("Lastwagen",(sp, key) => new Lastwagen { Marke = "Volvo", Modell = "FH16", Baujahr = 2019, Reifen = 6 });

                services.AddSingleton<Fahrzeug>();
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


    public class Fahrzeug 
    {
        public IFahrzeug Auto { get; set; }
        public IFahrzeug Motorrad { get; set; }
        public IFahrzeug Lastwagen { get; set; }
        
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
        public int Reifen { get; set; }
        public Fahrzeug(
            [FromKeyedServices("Auto")] IFahrzeug auto, 
            [FromKeyedServices("Motorrad")] IFahrzeug motorrad, 
            [FromKeyedServices("Lastwagen")] IFahrzeug lastwagen)

        {
            Auto = auto;
            Motorrad = motorrad;
            Lastwagen = lastwagen;
        }

        public string AutoAnzeigen()
        {
            return Auto.Beschreibung();
        }

        public string MotorradAnzeigen()
        {
            return Motorrad.Beschreibung();
        }
        public string LastwagenAnzeigen()
        {
            return Lastwagen.Beschreibung();
        }

    }

    public interface IFahrzeug
    {
        string Marke { get; set; }
        string Modell { get; set; }
        int Baujahr { get; set; }
        int Reifen { get; set; }

        string Beschreibung();
       

    }

    public class Auto : IFahrzeug
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
        public int Reifen { get; set; }

        public string Beschreibung()
        {
            return $"Auto: {Marke} {Modell}, Baujahr: {Baujahr}, Reifen: {Reifen}";
        }

    }
    public class Motorrad : IFahrzeug
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
        public int Reifen { get; set; }
        public string Beschreibung()
        {
            return $"Motorrad: {Marke} {Modell}, Baujahr: {Baujahr}, Reifen: {Reifen}";
        }

    }
    public class Lastwagen : IFahrzeug
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
        public int Reifen { get; set; }
        public string Beschreibung()
        {
            return $"Lastwagen: {Marke} {Modell}, Baujahr: {Baujahr}, Reifen: {Reifen}";
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
