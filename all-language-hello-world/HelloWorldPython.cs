using System.Diagnostics;

public class HelloWorldPython : IHelloWorld
{
    public string GetHelloWorld()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "python", // or full path to python.exe
            Arguments = "dependencies/Python/HelloWorldPython.py",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (var process = Process.Start(psi))
            {
                string output = process?.StandardOutput.ReadToEnd() ?? "Error: Python";
                process?.WaitForExit();
                return output.Trim();
            }
        }
        catch
        {
            return "Error: Python";
        }
    }

    public bool IsEnabled() { return true; }
}
