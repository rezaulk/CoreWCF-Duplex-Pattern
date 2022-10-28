using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using Contract;

namespace NetCoreClient
{
    public class Program
    {
        public const int HTTP_PORT = 8088;
        public const int HTTPS_PORT = 8443;
        public const int NETTCP_PORT = 8089;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Client Started.");

            EndpointAddress address = new EndpointAddress($"net.tcp://192.168.0.104:{NETTCP_PORT}/EchoService");
            Binding binding = new NetTcpBinding(SecurityMode.None);
            IPVEventCallback callback = new CallBackHandler();
            InstanceContext context = new InstanceContext(callback);

            var factory = new DuplexChannelFactory<IPVEventContract>(context, binding, address);
            IPVEventContract channel = factory.CreateChannel();

            while (true)
            {
                Console.WriteLine("Enter 1 for continue,2 For close: ");

                var name = Console.ReadLine();
                if (Convert.ToInt32(name) == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter 1 for Initialize,2 for IsAlive Check");
                    var status = Console.ReadLine();
                    try
                    {
                        if (Convert.ToInt32(status) == 1)
                        {
                            Console.WriteLine("Enter Application Name: ");
                            var appname = Console.ReadLine();
                            channel.Initialize(appname);
                            Thread.Sleep(1000);

                        }
                        else
                        {
                            Console.WriteLine("Session status: " + channel.IsAlive());
                            Thread.Sleep(1000);


                        }
                    }
                    catch
                    {
                        Console.WriteLine("Server Closed.");
                    }

                    Console.WriteLine();
                    //Thread.Sleep(1000);
                    //Console.WriteLine("Hit enter to close");
                    //Console.ReadLine();
                }
            }


        }
    }
}
