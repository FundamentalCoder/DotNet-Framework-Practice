


using D.Project.HostConfigGenerics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
       services.AddSingleton<ISensorReader, SensorReader>();
        services.AddSingleton<ITemperatureMonitor, TemperatureMonitor>();
        
    })
    .Build();

var test = host.Services.GetRequiredService<ISensorReader>();
Console.WriteLine(test.ReadTemperature());
