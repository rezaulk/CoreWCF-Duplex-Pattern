# CoreWCF-Duplex-Pattern
[CoreWCF](https://github.com/CoreWCF/CoreWCF)

Create WCF Duplex with Below version. Please have a look in repository  
 - Service built in .Net Core 3.1 & Client .Net Core 3.1
 - Service built in .Net 4.8 & Client .Net Core 3.1



 
  
 
Add NetTcpBinding between UseServiceModel  
```cs
    // Add the Echo Service
    builder.AddService<PVEventService>(serviceOptions =>
    {
        // Set the default host name:port in generated WSDL and the base path for the address 
        serviceOptions.BaseAddresses.Add(new Uri($"http://{HOST_IN_WSDL}/EchoService"));
        serviceOptions.BaseAddresses.Add(new Uri($"https://{HOST_IN_WSDL}/EchoService"));
    })

    // Add NetTcpBinding
    .AddServiceEndpoint<PVEventService, IPVEventContract>
    (new NetTcpBinding(SecurityMode.None),$"net.tcp://{HOST}:{NETTCP_PORT}/EchoService");

```

In Client create channel
```cs

    EndpointAddress address = new EndpointAddress($"net.tcp://{HOST}:{NETTCP_PORT}/EchoService");
    Binding binding = new NetTcpBinding(SecurityMode.None);
    IPVEventCallback callback = new CallBackHandler();
    InstanceContext context = new InstanceContext(callback);

    var factory = new DuplexChannelFactory<IPVEventContract>(context, binding, address);
    IPVEventContract channel = factory.CreateChannel();



```

 

