using System.Runtime.InteropServices;

public class HelloWorldRust : IHelloWorld
{
    [DllImport("dependencies/Rust/HelloWorldRust.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr get_message();

    [DllImport("dependencies/Rust/HelloWorldRust.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void free_message();


    public string GetHelloWorld()
    {
        IntPtr ptr = get_message();
        string message = Marshal.PtrToStringAnsi(ptr) ?? "Error: Rust";
        free_message();

        return message;
    }

    public bool IsEnabled() { return true; }
}
