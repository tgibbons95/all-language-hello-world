using System.Runtime.InteropServices;

public class HelloWorldC : IHelloWorld
{
    [DllImport("dependencies/C/HelloWorldC.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetHelloWorldC();

    public string GetHelloWorld()
    {
        return Marshal.PtrToStringAnsi(GetHelloWorldC()) ?? "Error: C";
    }

    public bool IsEnabled() { return true; }
}
