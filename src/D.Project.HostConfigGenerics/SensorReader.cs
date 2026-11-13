using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class SensorReader : ISensorReader
    {
       
        public double ReadTemperature()
        {
            Random random = new Random();
            return random.Next(-10, 40); 
        }
    }
}
