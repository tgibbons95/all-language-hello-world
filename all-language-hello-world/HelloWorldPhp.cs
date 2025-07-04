using System.Diagnostics;

public class HelloWorldPhp : IHelloWorld
{
    public string GetHelloWorld()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "php",
            Arguments = "dependencies/Php/HelloWorld.php",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (var process = Process.Start(psi))
            {
                string output = process?.StandardOutput.ReadToEnd() ?? "Error: Php";
                process?.WaitForExit();
                return output.Trim();
            }
        }
        catch
        {
            return "Error: Php";
        }
    }

    public bool IsEnabled() { return true; }
}
