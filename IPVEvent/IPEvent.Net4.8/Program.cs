using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IPEvent.Net4._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(PVEventService),
                new Uri("net.tcp://localhost:8808"));

            host.AddServiceEndpoint(typeof(IPVEventContract), new NetTcpBinding(SecurityMode.None), "/PVEventService");

            host.Open();

            Console.WriteLine("Hit enter to close");
            Console.ReadLine();

            host.Close();
        }
    }
}
