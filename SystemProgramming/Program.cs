//namespace SystemProgramming;

//using System.Collections.Concurrent;
//using System.Diagnostics;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Text.Json;
//using Threading;
//internal class Program
//{
//    //private static object _locker = new object();
//    //public static ConcurrentQueue<Order> cq = new ConcurrentQueue<Order>();
//    //private static bool IsWork = true;
//    //public const int COUNT = 20;
//    //public static void PrintLow()
//    //{
//    //    for (int i = 0;  i < COUNT; i++)
//    //    {
//    //        Console.WriteLine("Low");
//    //        Thread.Sleep(100);
//    //    }
//    //}
//    //public static void PrintHigh()
//    //{
//    //    for (int i = 0; i < COUNT; ++i)
//    //    {
//    //        Console.WriteLine("High");
//    //        Thread.Sleep(100);
//    //    }
//    //}
//    //public static void PrintNormal()
//    //{
//    //    for (int i = 0; i < COUNT; ++i)
//    //    {
//    //        Console.WriteLine("Normal");
//    //        Thread.Sleep(100);
//    //    }
//    //}
//    public class Currency()
//    {
//        public int r030 {  get; set; }
//        public string txt {  get; set; }
//        public decimal rate { get; set; }

//        public override string ToString()
//        {
//            return $"Currency {txt}, rate {rate}";
//        }
//    }

//    private static readonly string _URL = "bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";

//    static async Task<List<Currency>?> GetCurrency()
//    {
//        using (HttpClient client = new HttpClient())
//        {
//            try
//            {
//                var response = await client.GetStringAsync(_URL);
//                var obj = JsonSerializer.Deserialize<List<Currency>>(response);

//                if (obj != null)
//                {
//                    return obj;
//                }
//            }
//            catch (Exception)
//            {

//            }
//            return null;
//        }

//        return new();
//    }
//    static async Task Main(string[] args)
//    {
//        //new ProcessDemo().Run();
//        //new WorkerDllCPP().Run();
//        //new WorkerDLLPMCPP().Run();
//        var data = await GetCurrency();

//        if (data != null)
//        {
//            foreach (var item in data)
//            {
//                Console.WriteLine(item);
//            }
//        }
//        //Thread low_thread = new Thread(PrintLow);
//        //Thread high_thread = new Thread(PrintHigh);
//        //Thread normal_thread = new Thread(PrintNormal);

//        //low_thread.Priority = ThreadPriority.Lowest;
//        //high_thread.Priority = ThreadPriority.Highest;
//        //normal_thread.Priority = ThreadPriority.Normal;

//        //low_thread.Start();
//        //high_thread.Start();
//        //normal_thread.Start();

//        //low_thread.Join();
//        //high_thread.Join();
//        //normal_thread.Join();
//    }
//}
