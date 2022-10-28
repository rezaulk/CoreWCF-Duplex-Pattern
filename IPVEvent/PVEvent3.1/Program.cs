using IPEvent.Net4._8;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Threading;
using System.Xml.Linq;

namespace PVEvent3._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            EndpointAddress address = new EndpointAddress("net.tcp://192.168.0.104:8808/PVEventService");
            Binding binding = new NetTcpBinding(SecurityMode.None);
            IPVEventCallback callback = new CallBackHandler();
            InstanceContext context = new InstanceContext(callback);

            var factory = new DuplexChannelFactory<IPVEventContract>(context, binding, address);


            //factory.Credentials.ServiceCertificate.SslCertificateAuthentication =
            //        new X509ServiceCertificateAuthentication()
            //        {
            //            CertificateValidationMode = X509CertificateValidationMode.None,
            //            RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
            //        };


            while (true)
            {
                Console.WriteLine("Enter 1 for close,2 For continue: ");

                var name = Console.ReadLine();
                if(Convert.ToInt32(name) == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter 1 for Initialize,2 for IsAlive Check");

                    var status = Console.ReadLine();
                    IPVEventContract channel = factory.CreateChannel();

                    try
                    {
                        if (Convert.ToInt32(status) == 1)
                        {
                            Console.WriteLine("Enter Application Name: ");
                            var appname = Console.ReadLine();
                            channel.Initialize(appname);

                        }
                        else
                        {

                            Console.WriteLine("Session status: " + channel.IsAlive());

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Server Closed.");

                    }




                    Console.WriteLine();

                    Thread.Sleep(1000);
                    //Console.WriteLine("Hit enter to close");
                    //Console.ReadLine();
                }
            }

          
        }
    }
}

