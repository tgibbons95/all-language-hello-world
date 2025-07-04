using System.Diagnostics;

public class HelloWorldR : IHelloWorld
{
    public string GetHelloWorld()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "Rscript",
            Arguments = "dependencies/R/HelloWorld.r",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (var process = Process.Start(psi))
            {
                string output = process?.StandardOutput.ReadToEnd() ?? "Error: R";
                process?.WaitForExit();
                return output.Trim();
            }
        }
        catch
        {
            return "Error: R";
        }
    }

    public bool IsEnabled() { return true; }
}
