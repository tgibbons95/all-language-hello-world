using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // Set up DI container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IHelloWorld, HelloWorldCSharp>()
            .AddSingleton<IHelloWorld, HelloWorldCpp>()
            .BuildServiceProvider();

        // Get an enumerable of all IHelloWorld interface implementations
        var helloWorldImpls = serviceProvider.GetServices<IHelloWorld>();
        foreach (var helloWorldImpl in helloWorldImpls)
        {
            Console.WriteLine($"{helloWorldImpl.GetHelloWorld()}");
        }
    }
}
