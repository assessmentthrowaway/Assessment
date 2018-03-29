using PeterKottas.DotNetCore.WindowsService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer
{
    class TheConsumerService : IMicroService
    {
        private IMicroServiceController controller;

        public TheConsumerService(IMicroServiceController controller)
        {
            this.controller = controller;
        }
        public void Start()
        {
            DI.ServiceProvider.GetService<IConsumerService>().ConsumeMessage();
            //Lets Loop Here in order to send messages to the other service
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                //Resolve service and FIRE
                
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
