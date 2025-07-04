public class HelloWorldCSharp : IHelloWorld
{
    public string GetHelloWorld()
    {
        return "Hello World - C#";
    }

    public bool IsEnabled() { return true; }
}
