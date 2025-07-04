﻿using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // Prerequisites for Javonet
        var apiKey = Environment.GetEnvironmentVariable("JavonetApiKey");
        if (apiKey != null)
        {
            Javonet.Netcore.Sdk.Javonet.Activate(apiKey);
        } else
        {
            Console.WriteLine("Warning: No JavonetApiKey env variable. Skipping javonet required languages.");
        }

        // Set up DI container
        var serviceCollection = new ServiceCollection()
            .AddSingleton<IHelloWorld, HelloWorldAssembly>()
            .AddSingleton<IHelloWorld, HelloWorldC>()
            .AddSingleton<IHelloWorld, HelloWorldCpp>()
            .AddSingleton<IHelloWorld, HelloWorldCSharp>()
            .AddSingleton<IHelloWorld, HelloWorldGo>()
            .AddSingleton<IHelloWorld, HelloWorldPerl>()
            .AddSingleton<IHelloWorld, HelloWorldPhp>()
            .AddSingleton<IHelloWorld, HelloWorldPython>()
            .AddSingleton<IHelloWorld, HelloWorldR>()
            .AddSingleton<IHelloWorld, HelloWorldRust>()
            .AddSingleton<IHelloWorld, HelloWorldSql>();

        if (apiKey != null)
        {
            serviceCollection = serviceCollection.AddSingleton<IHelloWorld, HelloWorldJava>();
            serviceCollection = serviceCollection.AddSingleton<IHelloWorld, HelloWorldJs>();
        }

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Get an enumerable of all IHelloWorld interface implementations
        var helloWorldImpls = serviceProvider.GetServices<IHelloWorld>();
        foreach (var helloWorldImpl in helloWorldImpls)
        {
            if (helloWorldImpl.IsEnabled())
            {
                Console.WriteLine($"{helloWorldImpl.GetHelloWorld()}");
            }
        }
    }
}
