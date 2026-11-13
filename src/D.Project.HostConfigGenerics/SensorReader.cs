using System;
using System.Collections.Generic;
using System.Text;

namespace D.Project.HostConfigGenerics
{
    public class SensorReader : ISensorReader
    {
        public int ReadTemperature()
        {
            // Simulate reading temperature from a sensor
            Random random = new Random();
            return random.Next(-10, 40); // Return a random temperature between -10 and 40 degrees Celsius
        }
    }
}
