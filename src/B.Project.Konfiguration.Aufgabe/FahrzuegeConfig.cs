using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B.Project.Konfiguration.Aufgabe
{
    public class FahrzuegeConfig
    {
        public Fahrzeug Fahrzeug { get; set; }
    }

    public class Fahrzeug
    {
        public Auto Auto { get; set; }
        public Lastwagen Lastwagen { get; set; }

    }

    public class Auto
    {
        public Pkw Pkw { get; set; }
        public Limousine Limousine { get; set; }
    }
    public class Pkw
    {

        public string name { get; set; }
        public int ps { get; set; }
        public int doors { get; set; }
    }
    public class Limousine
    {
        public string name { get; set; }
        public int ps { get; set; }
        public int doors { get; set; }



    }
    public class Lastwagen
    { 
        public LKW LKW{ get; set; }
        public KleineLastwagen KleineLastwagen { get; set; }
    }

    public class LKW
    {
        public string name { get; set; }
        public int ps { get; set; }
        public int doors { get; set; }
        public Anhänger Anhänger { get; set; }
    }
    public class Anhänger 
    {
        public string name { get; set; }
        public int size { get; set; }
    }
    public class KleineLastwagen
    {
        public string name { get; set; }
        public int ps { get; set; }
        public int doors { get; set; }
    }
}
