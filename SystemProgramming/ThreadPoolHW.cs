//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SystemProgramming.Threading;
//namespace SystemProgramming;

//public class ThreadPoolHW
//{
//    static void Main(string[] args)
//    {
//        var account = new BankAccount();
//        var rnd = new Random();

//        for (int i = 0; i < 3; i++)
//        {
//            ThreadPool.QueueUserWorkItem(_ =>
//            {
//                while (true)
//                {
//                    int op = rnd.Next(2);

//                    if (op == 0)
//                        account.Deposit(rnd.Next(1, 50));
//                    else
//                        account.Withdraw(rnd.Next(1, 50));

//                    Thread.Sleep(200);
//                }
//            });

//            Thread.Sleep(3000);
//            account.Block();

//            Thread.Sleep(3000);
//            account.Unblock();

//            Console.ReadLine();

//        }
//    }
//}
