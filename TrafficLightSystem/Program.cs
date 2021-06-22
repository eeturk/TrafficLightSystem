using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;

namespace TrafficLightSystem
{
    class Program
    {
        public static void Main(string[] args)
        {            
            var NSLights = new TrafficLight(new Red(), "NS" );
            var EWLights = new TrafficLight(new Red(), "EW");
            var NSLightsActive = true;

            while (true)
            {
                if (NSLightsActive)
                {
                    NSLights.Change();
                    if (NSLights.State.GetType() == typeof(Red))
                    {
                        NSLightsActive = false;
                        EWLights.Change();
                    }
                }
                else
                {
                    EWLights.Change();
                    if (EWLights.State.GetType() == typeof(Red))
                    {
                        NSLightsActive = true;
                        NSLights.Change();
                    }
                }
            }
        }

    }
}
