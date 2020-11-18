
using Microsoft.Extensions.DependencyInjection;
using System;
using Injector;


namespace Injector
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<ICustomer,Customer>();
            services.AddSingleton<ConsoleApplication>();

            _serviceProvider = services.BuildServiceProvider(true);

        }

        private static void DisposeServices()
        {
           if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            } 
        }
    }
}
