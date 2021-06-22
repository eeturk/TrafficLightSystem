using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public interface ITrafficLight
    {
        void Change(TrafficLight light);
    }
}
