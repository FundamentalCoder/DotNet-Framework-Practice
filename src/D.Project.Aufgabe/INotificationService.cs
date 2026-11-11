using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.Aufgabe
{
    public interface INotificationService
    {
      public void Send<T>(Nachricht<T> message);
    }
}
