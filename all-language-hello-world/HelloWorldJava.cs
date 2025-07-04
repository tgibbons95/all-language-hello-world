public class HelloWorldJava : IHelloWorld
{
    public string GetHelloWorld()
    {
        try
        {
            var rtmCtx = Javonet.Netcore.Sdk.Javonet.InMemory().Jvm();
            rtmCtx.LoadLibrary("dependencies/Java/HelloWorld.jar");
            var javaType = rtmCtx.GetType("HelloWorldClass").Execute();
            var result = javaType.InvokeStaticMethod("HelloWorld").Execute();
            return result.GetValue() as string ?? "Error: Java";
        }
        catch (Exception)
        {
            return "Error: Java";
        }
    }

    public bool IsEnabled() { return true; }
}
