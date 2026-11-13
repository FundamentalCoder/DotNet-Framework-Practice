


using D.Project.HostConfigGenerics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.Configure<MonitorOptions>(context.Configuration.GetSection("Monitoring"));
        services.AddSingleton<ISensorReader, SensorReader>();
        services.AddSingleton<ITemperatureMonitor, TemperatureMonitor>();
        services.AddHostedService<MonitoringWorker>();

    })
    .Build();
var options = host.Services
    .GetRequiredService<IOptionsMonitor<MonitorOptions>>();

using var subscription = options.OnChange(newOptions =>
{
    Console.WriteLine("ÄNDERUNG ERKANNT!");
    Console.WriteLine(
        $"Neues Intervall: {newOptions.IntervalSeconds}");
});


await host.RunAsync();





