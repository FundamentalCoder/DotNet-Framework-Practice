using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class TemperatureMonitor : ITemperatureMonitor
    {
        public ISensorReader temp;
        private readonly  IOptionsMonitor<MonitorOptions> einstellungen;

        public TemperatureMonitor(ISensorReader temp, IOptionsMonitor<MonitorOptions> options)
        {
            this.temp = temp;
            einstellungen = options;
        }

        public string controllTemperature(double temp)
        {
            
            if (temp > einstellungen.CurrentValue.MaxTemperature)
            {
                return "Temperatur ist zu hoch";
            }
            else if (temp < einstellungen.CurrentValue.MinTemperature)
            {
                return "Temperatur ist zu niedrig";
            }
            else
            {
                return "Temperatur ist in OK";

            }
        }
    }
}
