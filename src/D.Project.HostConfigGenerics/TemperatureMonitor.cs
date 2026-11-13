using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class TemperatureMonitor : ITemperatureMonitor
    {
        public ISensorReader temp;

        public TemperatureMonitor(ISensorReader temp)
        {
            this.temp = temp;
        }   
        public string controllTemperature(double temp)
        {
            if(temp > 10)   
            {
              return "Temperatur ist zu hoch";
            }
            return "Temperatur ist in OK";
        }

    }
}
