
using IPEvent.Net4._8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVEvent3._1
{
    public class CallBackHandler : IPVEventCallback
    {
        public void RaiseEvent(PVEvent eventDetails)
        {
            Console.WriteLine("CallBack start from server: ");
            Console.WriteLine("Application Name: " + eventDetails.Name);
            Console.WriteLine("Event Date: "+ eventDetails.EventDate);
            Console.WriteLine("Event Time: "+ eventDetails.EventTime);
            Console.WriteLine("Event Monitor Point: "+ eventDetails.MonitorPointId);

            Console.WriteLine("CallBack end from server ");
            Console.WriteLine("");

        }
    }
}
