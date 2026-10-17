using B.Project.Konfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B.Project.Konfiguration.Configs
{


    public class RootConfig
    {
        public string test { get; set; }
        public Settings Settings { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public List<Vehicle> Vehicle { get; set; }

    }
   

    public class Settings
    {
        public string test { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
        public string test { get; set; }
    }
}
public class Vehicle
{
    public string Name { get; set; }
    public bool status { get; set; }
    public int jahr { get; set; }
    public List<string> features { get; set; }
    public Auto1 auto1 { get; set; }
}

public class Auto1 {
    public string name { get; set; }
}
