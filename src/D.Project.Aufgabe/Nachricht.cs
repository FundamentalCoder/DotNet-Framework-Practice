using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.Aufgabe
{
    public class Nachricht<T>
    {
        public Guid Id { get; set; }
        public T Content { get;}
        public DateTime CreatedAt { get; set; }


        public Nachricht(T content)
        {
            Id = Guid.NewGuid();
            Content = content;
            CreatedAt = DateTime.UtcNow;
        }

    }

}

