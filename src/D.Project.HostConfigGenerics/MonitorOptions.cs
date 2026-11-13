using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class MonitorOptions
    {
        public string SensorName { get; set; }
        public int IntervalSeconds { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public bool Enabled { get; set; }
    }
}
