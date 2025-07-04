using System.Runtime.InteropServices;

public class HelloWorldGo : IHelloWorld
{
    [DllImport("dependencies/Go/HelloWorldGo.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetHelloWorldGo();

    public string GetHelloWorld()
    {
        return Marshal.PtrToStringAnsi(GetHelloWorldGo()) ?? "Error: Go";
    }

    public bool IsEnabled() { return true; }
}
