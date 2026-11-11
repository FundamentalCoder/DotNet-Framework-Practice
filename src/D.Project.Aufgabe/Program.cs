using D.Project.Aufgabe;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");


var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
{
    //services.AddSingleton<Form1>();
    services.AddSingleton<INotificationService, NotificationService>();
}).Build();

var notificationService = host.Services.GetRequiredService<INotificationService>();

notificationService.Send(new Nachricht<string> { Content = "Test " });

notificationService.Send(new Nachricht<int> { Content = 42 });
