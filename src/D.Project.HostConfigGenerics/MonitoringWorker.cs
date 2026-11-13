using Microsoft.Extensions.Hosting;
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
        public MonitoringWorker(ISensorReader sensorReader, ITemperatureMonitor temperatureMonitor)
        {
            temp = sensorReader;
            tempMonitor = temperatureMonitor;
        }
        protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("BackgroundService gestartet");
                var tmp = temp.ReadTemperature();
                Console.WriteLine($"Aktuelle Temperatur: {tmp}" +"C°"+  " : " + $"{tempMonitor.controllTemperature(tmp)}");

                await Task.Delay(5000, stoppingToken);
                Console.WriteLine("BackgroundService beendet");

            }


        }

    }
}
