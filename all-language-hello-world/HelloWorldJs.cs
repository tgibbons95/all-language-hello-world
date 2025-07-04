public class HelloWorldJs : IHelloWorld
{
    public string GetHelloWorld()
    {
        try
        {
            var rtmCtx = Javonet.Netcore.Sdk.Javonet.InMemory().Nodejs();
            rtmCtx.LoadLibrary("dependencies/Js/HelloWorld.js");
            var jsModule = rtmCtx.GetType("HelloWorld").Execute();
            var result = jsModule.InvokeStaticMethod("getMessage").Execute();
            return result.GetValue() as string ?? "Error: Js";
        }
        catch (Exception)
        {
            return "Error: Js";
        }
    }

    public bool IsEnabled() { return true; }
}
