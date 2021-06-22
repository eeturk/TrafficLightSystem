using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class Green : ITrafficLight
    {
        public void Change(TrafficLight light)
        {
            light.State = new Yellow();
        }

    }
}
