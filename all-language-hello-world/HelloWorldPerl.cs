using System.Diagnostics;

public class HelloWorldPerl : IHelloWorld
{
    public string GetHelloWorld()
    {
        var psi = new ProcessStartInfo
        {
            FileName = "perl", // or full path to perl.exe
            Arguments = "dependencies/Perl/HelloWorld.perl",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        try
        {
            using (var process = Process.Start(psi))
            {
                string output = process?.StandardOutput.ReadToEnd() ?? "Error: Perl";
                process?.WaitForExit();
                return output.Trim();
            }
        }
        catch
        {
            return "Error: Perl";
        }
    }

    public bool IsEnabled() { return true; }
}
