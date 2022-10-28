using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPEvent.Net4._8
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PVEventService : IPVEventContract
    {
        private static PVEvent pVEvent = null;
        public void Initialize(string clientApplicationName)
        {
           
            if(pVEvent == null)
            {
                pVEvent = new PVEvent();
            }
            pVEvent.Name = clientApplicationName;
            pVEvent.EventDate = DateTime.Now.ToString("yyyy-MM-dd");
            pVEvent.EventTime = DateTime.Now.ToString("HH-mm-ss");
            pVEvent.MonitorPointId = "11-012-115-885";

            Callback.RaiseEvent(pVEvent);
            Console.WriteLine("Initialize from Client");
            Console.WriteLine("Client Name: "+ clientApplicationName);
            Console.WriteLine("Event Date: " + pVEvent.EventDate);
            Console.WriteLine("Event Time: " + pVEvent.EventTime);
            Console.WriteLine("Event Monitor Point: " + pVEvent.MonitorPointId);
            Console.WriteLine("");


        }

        public bool IsAlive()
        {
            pVEvent.EventDate = DateTime.Now.ToString("yyyy-MM-dd");
            pVEvent.EventTime = DateTime.Now.ToString("HH-mm-ss");


            Console.WriteLine("IsAlive check from Client");
            Console.WriteLine("Client Name: " + pVEvent.Name);
            Console.WriteLine("Event Date: " + pVEvent.EventDate);
            Console.WriteLine("Event Time: " + pVEvent.EventTime);
            Console.WriteLine("Event Monitor Point: " + pVEvent.MonitorPointId);
            Console.WriteLine("");



            Callback.RaiseEvent(pVEvent);

            if(pVEvent != null)
            {
                return true;

            }
            else 
            {
                return false;
            }
        }

        IPVEventCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IPVEventCallback>();
            }
        }
    }
}
