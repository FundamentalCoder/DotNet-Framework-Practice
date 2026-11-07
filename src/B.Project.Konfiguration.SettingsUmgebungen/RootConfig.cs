using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B.Project.Konfiguration.SettingsUmgebungen;
public class RootConfig
{
    public Application Application { get; set; } 
    public Database Database { get; set; } 
    
}

public class Application
{
    public string Name { get; set; }
    public string Version { get; set; } 
}

public class Database
{
    public string Server { get; set; } 
    public string Name { get; set; } 
    public string User { get; set; } 

    public int CommandTimeout { get; set; }

    public string Password { get; set; }

    public bool Encrypt { get; set; }
    public bool TrustServerCertificate { get; set; }
}

