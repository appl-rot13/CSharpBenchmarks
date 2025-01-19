
using System.Diagnostics;

public class ProcessExists
{
    public static bool GetProcessesAny(string processName)
    {
        return Process.GetProcesses().Any(
            process => processName.Equals(process.ProcessName, StringComparison.OrdinalIgnoreCase));
    }

    public static bool GetProcessesForEach(string processName)
    {
        foreach (var process in Process.GetProcesses())
        {
            if (processName.Equals(process.ProcessName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    public static bool GetProcessesByNameAny(string processName)
    {
        return Process.GetProcessesByName(processName).Any();
    }

    public static bool GetProcessesByNameLength(string processName)
    {
        return Process.GetProcessesByName(processName).Length > 0;
    }
}
