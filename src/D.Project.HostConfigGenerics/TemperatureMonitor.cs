using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class TemperatureMonitor : ITemperatureMonitor
    {
        public ISensorReader _sensorReader;
        private readonly  IOptionsMonitor<MonitorOptions> _monitorOptions;
        public TemperatureMonitor(ISensorReader temp, IOptionsMonitor<MonitorOptions> options)
        {
            _monitorOptions = options;
            _sensorReader = temp;
        }
        public string controllTemperature(double? temperatur = null)
        {
            var currentTemp = temperatur ?? _sensorReader.ReadTemperature();

            if (currentTemp > _monitorOptions.CurrentValue.MaxTemperature)
            {
                return "Temperatur ist zu hoch";
            }
            else if (currentTemp < _monitorOptions.CurrentValue.MinTemperature)
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
