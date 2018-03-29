using PeterKottas.DotNetCore.WindowsService.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer
{
    class TheProducerService : IMicroService
    {
        private IMicroServiceController controller;

        public TheProducerService(IMicroServiceController controller)
        {
            this.controller = controller;
        }
        public void Start()
        {
            //Lets Loop Here in order to send messages to the other service
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                //Resolve service and FIRE
                 DI.ServiceProvider.GetService<IProducerService>().SendMessage(input);
            }
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
