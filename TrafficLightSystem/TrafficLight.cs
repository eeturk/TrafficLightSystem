using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using static TrafficLightSystem.LightOptions;

namespace TrafficLightSystem
{
    public class TrafficLight
    {
        public ITrafficLight State { get; set; }
        public string Direction { get; set; }

        public TrafficLight(ITrafficLight state, string direction)
        {
            State = state;
            Direction = direction;
        }

        public void Change()
        {
            States currentState, changedState;

            Enum.TryParse(State.GetType().Name.ToUpper(), out currentState);

            if (currentState != States.INVALID)
            {
                State.Change(this);
                Enum.TryParse(State.GetType().Name.ToUpper(), out changedState);
                DisplayState(this.Direction, changedState);
                AddDelay(this.Direction, changedState);
            }
            else
            {
                Console.WriteLine("Invalid traffic light");
                Console.WriteLine("Exiting the program.........");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
        }

        public bool Peak()
        {
            bool isPeak = false;
            var peakHoursSlots = ConfigurationManager.AppSettings["PeakHoursSlots"];
            var peakHours = peakHoursSlots?.Split(',');

            foreach (var peakHour in peakHours)
            {
                var slots = peakHour.Split('-');
                TimeSpan peakStart = new TimeSpan(Convert.ToInt32(slots[0]), 0, 0);
                TimeSpan peakEnd = new TimeSpan(Convert.ToInt32(slots[1]), 0, 0);

                TimeSpan now = DateTime.Now.TimeOfDay;

                isPeak = (now > peakStart && now < peakEnd);

                if (isPeak)
                    break;
            }
            return isPeak;
        }

        public void AddDelay(string Direction, States State)
        {
            bool IsPeak = Peak();

            bool DelayGreen = Convert.ToBoolean(ConfigurationManager.AppSettings["DelayGreen"]);
            int NonPeakHoursGreenInterval = Convert.ToInt32(ConfigurationManager.AppSettings["NonPeakHoursGreenInterval"]);
            int NSPeakHoursGreenInterval = Convert.ToInt32(ConfigurationManager.AppSettings["NSPeakHoursGreenInterval"]);
            int EWPeakHoursGreenInterval = Convert.ToInt32(ConfigurationManager.AppSettings["EWPeakHoursGreenInterval"]);

            bool DelayYellow = Convert.ToBoolean(ConfigurationManager.AppSettings["DelayYellow"]);
            int YellowToRedInterval = Convert.ToInt32(ConfigurationManager.AppSettings["YellowToRedInterval"]);

            bool DelayRed = Convert.ToBoolean(ConfigurationManager.AppSettings["DelayRed"]);
            int RedToGreenInterval = Convert.ToInt32(ConfigurationManager.AppSettings["RedToGreenInterval"]);


            switch (State)
            {
                case States.GREEN:
                    if (DelayGreen)
                    {
                        if (IsPeak)
                        {
                            if (Direction == "NS")
                                Thread.Sleep(NSPeakHoursGreenInterval);
                            if (Direction == "EW")
                                Thread.Sleep(EWPeakHoursGreenInterval);
                        }
                        else
                            Thread.Sleep(NonPeakHoursGreenInterval);
                    }
                    break;
                case States.YELLOW:
                    if(DelayYellow)
                        Thread.Sleep(YellowToRedInterval);
                    break;
                case States.RED:
                    if (DelayRed)
                        Thread.Sleep(RedToGreenInterval);
                    break;
            }
        }

        public void DisplayState(string Direction, States State)
        {
            Console.WriteLine("{0} :: {1} lights changed to {2}", DateTime.Now.ToString(), Direction, State);
        }
    }
}
