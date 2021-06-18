using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class Red : ITrafficLight1, ITrafficLight2
    {
        public void Change(TrafficLight1 light)
        {
            light.State = new Green();
        }

        public void Change(TrafficLight2 light)
        {
            light.State = new Green();
        }
    }
}
