using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSample;

internal static partial class Program
{
    /// <summary>
    /// starts logging to a file in the Logs directory
    /// </summary>
    static void StartLogging()
    {
        var dir = Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));
        string logPath = Path.Combine(dir.FullName, DateTime.Now.ToString("yyyy_MM_dd-_hh_mm_ss") + ".txt");
        TextWriterTraceListener traceListener = new TextWriterTraceListener(File.Create(logPath));
        Trace.Listeners.Add(traceListener);
        Trace.AutoFlush = true;
    }
}
