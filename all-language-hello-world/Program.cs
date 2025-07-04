using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // Set up DI container
        var serviceCollection = new ServiceCollection()
            .AddSingleton<IHelloWorld, HelloWorldAssembly>()
            .AddSingleton<IHelloWorld, HelloWorldCpp>()
            .AddSingleton<IHelloWorld, HelloWorldCSharp>()
            .AddSingleton<IHelloWorld, HelloWorldPython>()
            .AddSingleton<IHelloWorld, HelloWorldRust>();

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
