using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class Green : ITrafficLight1, ITrafficLight2
    {
        public void Change(TrafficLight1 light)
        {
            light.State = new Yellow();
        }

        public void Change(TrafficLight2 light)
        {
            light.State = new Yellow();
        }

    }
}
