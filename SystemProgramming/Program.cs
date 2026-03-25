namespace SystemProgramming;

using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using Threading;
internal class Program
{
    private static object _locker = new object();
    public static ConcurrentQueue<Order> cq = new ConcurrentQueue<Order>();
    private static bool IsWork = true;

    static void Main(string[] args)
    {
        new ProcessDemo().Run();
        //new WorkerDllCPP().Run();
        //new WorkerDLLPMCPP().Run();

    }
}
