using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Extensions.Options;

namespace D.Project.Aufgabe
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationOptions _options;

        public NotificationService(IOptions<NotificationOptions> options)
        {
            _options = options.Value;
        }

        public void Send<T>(Nachricht<T> message) {

            Console.WriteLine($"Notification sent:{_options.Prefix} {_options.ApplicationName}: {message.Content}");

        }
    }   
}
