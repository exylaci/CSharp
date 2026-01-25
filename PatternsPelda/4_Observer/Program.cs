using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Observer_Event
{
    internal class Program
    {
        public class TemperatureSensor
        {
            public event Action<int> TemperatureChanged;
            private int _temperature;

            public void setTemperature(int temperature)
            {
                _temperature = temperature;
                Action<int> handler = TemperatureChanged;
                if (handler != null) { handler(_temperature); }
            }
        }
        static void Main(string[] args)
        {
            TemperatureSensor sensor = new TemperatureSensor();
            sensor.TemperatureChanged += t => Console.WriteLine("Új hőmérséklet: " + t);

            sensor.setTemperature(1);
            sensor.setTemperature(10);
        }
    }
}
