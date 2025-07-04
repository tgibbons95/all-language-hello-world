using System.Runtime.InteropServices;

public class HelloWorldAssembly : IHelloWorld
{
    [DllImport("dependencies/Assembly/HelloWorldAssembly.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetMessage();


    public string GetHelloWorld()
    {
        return Marshal.PtrToStringAnsi(GetMessage()) ?? "Error: Assembly";
    }

    public bool IsEnabled() { return true; }
}
