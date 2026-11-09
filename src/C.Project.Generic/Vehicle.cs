using System;
using System.Collections.Generic;
using System.Text;

namespace C.Project.Generic
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string Make { get;  set; }
        public string? Model { get; set; }
    }
}
