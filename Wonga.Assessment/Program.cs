using PeterKottas.DotNetCore.WindowsService;
using System;

namespace Consumer
{
    class Program
    {
      
        static void Main(string[] args)
        {
            DI.SetupServices();
            ServiceRunner<TheProducerService>.Run(config =>
            {
                var name = config.GetDefaultName();
                
                config.Service(serviceConfig =>
                {
                    serviceConfig.ServiceFactory((extraArguments, controller) =>
                    {
                        return new TheProducerService(controller);
                    });

                    serviceConfig.OnStart((service, extraParams) =>
                    {
                        Console.WriteLine("Service {0} started", name);
                        service.Start();
                    });

                    serviceConfig.OnStop(service =>
                    {
                        Console.WriteLine("Service {0} stopped", name);
                        service.Stop();
                    });

                    serviceConfig.OnError(e =>
                    {
                        Console.WriteLine("Service {0} errored with exception : {1}", name, e.Message);
                    });
                });
            });
            Console.WriteLine("Hello World!");
        }
    }
}
