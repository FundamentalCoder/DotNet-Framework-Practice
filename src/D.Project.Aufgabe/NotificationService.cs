using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.Aufgabe
{
    public class NotificationService : INotificationService
    {

        public void Send(Nachricht<T> message) {

            Console.WriteLine($"Notification sent: {message.Content}");

        }
    }
}
