using System.Runtime.InteropServices;

public class HelloWorldCpp : IHelloWorld
{
    [DllImport("dependencies/Cpp/HelloWorldCpp.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr GetHelloWorldCpp();

    public string GetHelloWorld()
    {
        return Marshal.PtrToStringAnsi(GetHelloWorldCpp()) ?? "Error: C++";
    }
}
