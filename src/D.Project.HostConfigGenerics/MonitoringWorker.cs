using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class MonitoringWorker : BackgroundService
    {
        private readonly ISensorReader _sensorReader;
        private readonly ITemperatureMonitor _temperaturMonitor;
        private readonly IOptionsMonitor<MonitorOptions> _monitorOptions;

        public MonitoringWorker(ISensorReader sensorReader, ITemperatureMonitor temperatureMonitor, IOptionsMonitor<MonitorOptions> options)
        {
            _sensorReader = sensorReader;
            _temperaturMonitor = temperatureMonitor;
            _monitorOptions = options;
            _monitorOptions.OnChange(options =>
            {
                Console.WriteLine($"Neue Intervalleinstellung: {options.IntervalSeconds}");
            });
        }
        protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
        {
            Console.WriteLine("BackgroundService gestartet");
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_monitorOptions.CurrentValue.Enabled)
                {
                    var temperatur = _sensorReader.ReadTemperature();
                    Console.WriteLine($"Aktuelle Temperatur: {temperatur}" + "C°" + " : " + $"{_temperaturMonitor.controllTemperature(temperatur)}");
                    Console.WriteLine($"Aktuelles Intervall: {_monitorOptions.CurrentValue.IntervalSeconds}");
                }
                else 
                {
                    Console.WriteLine("Monitoring ist deaktiviert.");
                }   
                
                await Task.Delay(_monitorOptions.CurrentValue.IntervalSeconds * 1000, stoppingToken);
                _monitorOptions.OnChange(options =>
                {
                    Console.WriteLine($"Neue Intervalleinstellung: {options.IntervalSeconds}");
                });

            }
            


        }

    }
}
