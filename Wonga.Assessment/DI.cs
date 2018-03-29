using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer
{
    //This static class gives us access to our dependencies anywhere in the app , if we dont constructor resolve them
    public class DI
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static void SetupServices()
        {
           
            var serviceProvider = new ServiceCollection();
            serviceProvider.AddSingleton<IProducerService, ProducerService>();
            ServiceProvider = serviceProvider.BuildServiceProvider();
        }
    }
}
