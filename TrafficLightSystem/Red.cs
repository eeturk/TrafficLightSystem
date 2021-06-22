using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class Red : ITrafficLight
    {
        public void Change(TrafficLight light)
        {
            light.State = new Green();
        }

    }
}
