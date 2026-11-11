using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.Aufgabe
{
    public class NotificationOptions
    {
        public string ApplicationName { get; set; }
        public string Prefix { get; set; }
        public int MaxMessageLength { get; set; }
        public bool Enabled { get; set; }   
    }
}
