using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.Aufgabe
{
    public static class NotificationServiceExtension
    {
        public static void Send<T>(this INotificationService notificationService, T content)
        {
            var message = new Nachricht<T>(content);
            notificationService.Send(message);
        }
    }
}
