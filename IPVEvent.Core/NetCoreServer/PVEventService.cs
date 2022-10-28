using System;
using Contract;
using CoreWCF;

namespace NetCoreServer
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]

    public class PVEventService : IPVEventContract
    {
        private static PVEvent pVEvent = null;

        //IPVEventCallback callback =null;
        //public string Echo(string text)
        //{
            
        // //   callback = OperationContext.Current.GetCallbackChannel<IPVEventCallback>();

        //    pVEvent = new PVEvent();

        //    Callback.RaiseEvent(pVEvent);
        //    Callback.RaiseEvent(pVEvent);
        //    Callback.RaiseEvent(pVEvent);
        //    Callback.RaiseEvent(pVEvent);


        //    System.Console.WriteLine($"Received {text} from client!");
        //    return text;
        //}

        //public string ComplexEcho(EchoMessage text)
        //{
        //    System.Console.WriteLine($"Received {text.Text} from client!");
        //    return text.Text;
        //}

        //public string FailEcho(string text)
        //    => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

        //[AuthorizeRole("CoreWCFGroupAdmin")]
        //public string EchoForPermission(string echo)
        //{
        //    return echo;
        //}


        public void Initialize(string clientApplicationName)
        {

            if (pVEvent == null)
            {
                pVEvent = new PVEvent();
            }
            pVEvent.Name = clientApplicationName;
            pVEvent.EventDate = DateTime.Now.ToString("yyyy-MM-dd");
            pVEvent.EventTime = DateTime.Now.ToString("HH-mm-ss");
            pVEvent.MonitorPointId = "11-012-115-885";

            //callback = OperationContext.Current.GetCallbackChannel<IPVEventCallback>();

            Callback.RaiseEvent(pVEvent);

 

            Console.WriteLine("Initialize from Client");
            Console.WriteLine("Client Name: " + clientApplicationName);
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

            if (pVEvent != null)
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
