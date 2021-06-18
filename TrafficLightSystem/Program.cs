using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TrafficLightSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool NSGreen = false;
            bool EWGreen = false;

            TrafficLight1 t1 = new TrafficLight1();
            TrafficLight2 t2 = new TrafficLight2();

            DisplayMessage(ConsoleColor.Red, "[NS]");
            t1.State = new Red();

            DisplayMessage(ConsoleColor.Green, "[EW]");
            t2.State = new Green();
            EWGreen = true;

            while (true)
            {
                 if (EWGreen)
                {
                    WaitTime(NSGreen, EWGreen);

                    DisplayMessage(ConsoleColor.Yellow, "[EW]");
                    t2.Change();
                    Thread.Sleep(5000);

                    DisplayMessage(ConsoleColor.Red, "[EW]");
                    t2.Change();
                    Thread.Sleep(4000);
                    EWGreen = false;

                    DisplayMessage(ConsoleColor.Green, "[NS]");
                    t1.Change();
                    NSGreen = true;
                }

                if (NSGreen)
                {
                    WaitTime(NSGreen,EWGreen);

                    DisplayMessage(ConsoleColor.Yellow, "[NS]");
                    t1.Change();
                    Thread.Sleep(5000);

                    DisplayMessage(ConsoleColor.Red, "[NS]");
                    t1.Change();
                    Thread.Sleep(4000);
                    NSGreen = false;

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine("---------------------");
                    Console.WriteLine("--sequence is reset--");
                    Console.WriteLine("---------------------");

                    DisplayMessage(ConsoleColor.Green, "[EW]");
                    t2.Change();
                    EWGreen = true;
                }
            }
        }

        public static void DisplayMessage(ConsoleColor color, string lights)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(lights + " " + color + " " + DateTime.Now.ToString());
        }

        public static void WaitTime(bool NSGreen, bool EWGreen)
        {
            bool peakHours = false;
            TimeSpan peakOneStart = new TimeSpan(8, 0, 0);
            TimeSpan peakOneEnd = new TimeSpan(10, 0, 0);

            TimeSpan peakTwoStart = new TimeSpan(17, 0, 0);
            TimeSpan peakTwoEnd = new TimeSpan(19, 0, 0);

            TimeSpan now = DateTime.Now.TimeOfDay;

            peakHours = (now > peakOneStart && now < peakOneEnd) || (now > peakTwoStart && now < peakTwoEnd);

            if (!peakHours)
            {
                Thread.Sleep(20000);
            }
            else
            {
                if (NSGreen)
                    Thread.Sleep(40000);

                if (EWGreen)
                    Thread.Sleep(10000);
            }
        }
    }
}
