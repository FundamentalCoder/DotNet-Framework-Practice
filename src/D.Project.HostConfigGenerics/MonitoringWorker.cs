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
        private readonly ISensorReader temp;
        private readonly ITemperatureMonitor tempMonitor;
        private readonly  IOptionsMonitor<MonitorOptions> einstelungen;

        public MonitoringWorker(ISensorReader sensorReader, ITemperatureMonitor temperatureMonitor, IOptionsMonitor<MonitorOptions> options)
        {
            temp = sensorReader;
            tempMonitor = temperatureMonitor;
            einstelungen = options;
        }
        protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
        {
            Console.WriteLine("BackgroundService gestartet");
            while (!stoppingToken.IsCancellationRequested)
            {
             
                var tmp = temp.ReadTemperature();
                Console.WriteLine($"Aktuelle Temperatur: {tmp}" +"C°"+  " : " + $"{tempMonitor.controllTemperature(tmp)}");
                Console.WriteLine($"Aktuelles Intervall: {einstelungen.CurrentValue.IntervalSeconds}");
                await Task.Delay(einstelungen.CurrentValue.IntervalSeconds * 1000, stoppingToken);
               

            }
            


        }

    }
}
