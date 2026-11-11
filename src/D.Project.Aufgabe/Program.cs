using D.Project.Aufgabe;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
{

    services.Configure<NotificationOptions>(
        context.Configuration.GetSection("Notification"));

    //services.AddSingleton<Form1>();
    services.AddSingleton<INotificationService, NotificationService>();
}).Build();

var notificationService = host.Services.GetRequiredService<INotificationService>();

var nachricht = new Nachricht<int>(42);

int ergebnis = nachricht.Content * 2;

notificationService.Send(new Nachricht<int>(ergebnis));
notificationService.Send(nachricht);
notificationService.Send(new Nachricht<string>("Test "));
notificationService.Send("Test 2");
//notificationService.Send(new Nachricht<string>("Test "));

//notificationService.Send(new Nachricht<int>(42));
