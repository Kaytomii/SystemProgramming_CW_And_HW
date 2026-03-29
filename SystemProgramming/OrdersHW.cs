using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;

public class OrdersHW
{
    static void Main(string[] args)
    {
        int totalOrders = 10;
        CountdownEvent countdown = new CountdownEvent(totalOrders);

        for (int i = 1; i <= totalOrders; i++)
        {
            ThreadPool.QueueUserWorkItem(ProcessOrder, i);
        }

        void ProcessOrder(object state)
        {
            int orderId = (int)state;

            Thread.Sleep(new Random().Next(500, 1500));

            Console.WriteLine(
                $"Order {orderId} is finish on thread {Thread.CurrentThread.ManagedThreadId}");

            countdown.Signal();
        }

    }
}
