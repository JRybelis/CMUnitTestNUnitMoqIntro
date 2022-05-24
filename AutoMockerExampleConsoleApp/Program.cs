using System;
using AutoMockerExampleCore.Interfaces;
using AutoMockerExampleCore.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AutoMockerExampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddLogging(builder => builder.AddConsole())
                .AddSingleton<IFooService, FooService>().AddSingleton<IBarService, BarService>()
                .AddSingleton<ISomeOtherService, SomeOtherService>().BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogInformation("Starting application");

            var bar = serviceProvider.GetService<IBarService>();
            bar.DoBarThing();
            bar.DoOtherThing("Ilguma.");

            logger.LogDebug("All done!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}