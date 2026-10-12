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

