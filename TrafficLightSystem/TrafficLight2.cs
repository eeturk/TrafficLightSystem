using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightSystem
{
    public class TrafficLight2
    {
        public ITrafficLight2 State { get; set; }

        public void Change()
        {
            State.Change(this);
        }
    }
}
