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
    public const int COUNT = 20;
    public static void PrintLow()
    {
        for (int i = 0;  i < COUNT; i++)
        {
            Console.WriteLine("Low");
            Thread.Sleep(100);
        }
    }
    public static void PrintHigh()
    {
        for (int i = 0; i < COUNT; ++i)
        {
            Console.WriteLine("High");
            Thread.Sleep(100);
        }
    }
    public static void PrintNormal()
    {
        for (int i = 0; i < COUNT; ++i)
        {
            Console.WriteLine("Normal");
            Thread.Sleep(100);
        }
    }
    
    static void Main(string[] args)
    {
        //new ProcessDemo().Run();
        //new WorkerDllCPP().Run();
        //new WorkerDLLPMCPP().Run();

        Thread low_thread = new Thread(PrintLow);
        Thread high_thread = new Thread(PrintHigh);
        Thread normal_thread = new Thread(PrintNormal);
        
        low_thread.Priority = ThreadPriority.Lowest;
        high_thread.Priority = ThreadPriority.Highest;
        normal_thread.Priority = ThreadPriority.Normal;

        low_thread.Start();
        high_thread.Start();
        normal_thread.Start();

        low_thread.Join();
        high_thread.Join();
        normal_thread.Join();
    }
}
