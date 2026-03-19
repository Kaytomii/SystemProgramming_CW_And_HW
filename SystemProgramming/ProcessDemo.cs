using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;
internal class ProcessDemo
{
    public void Run()
    {
        ConsoleKeyInfo key;
        do
        {
            Console.WriteLine("Process Demo");
            Console.WriteLine("1 - ShowAllProcessesFilter");
            Console.WriteLine("2 - ShowAllProcesses");
            Console.WriteLine("3 - GetProcessbyPID");
            Console.WriteLine("4 - CreateProcess");
            Console.WriteLine("5 - KillProcess");
            Console.WriteLine("6 - CallTestProgram");
            Console.WriteLine("0 - Exit");
            key = Console.ReadKey();

            switch (key.KeyChar)
            {
                case '1':
                    ShowAllProcessesFilter();
                    break;

                case '2':
                    ShowAllProcesses();
                    break;

                case '3':
                    GetProcessByPid();
                    break;

                case '4':
                    CreateProcess();
                    break;

                case '5':
                    KillProcess();
                    break;

                case '6':
                    CallTestProgram();
                    break;

                default: Console.WriteLine("unknown operation");
                    break;
            }

        }
        while (key.KeyChar != '0');

        ShowAllProcesses();
    }

    private void GetProcessByPid()
    {
        try
        {
            Console.WriteLine("\nEnter PID: ");
            int pid = Convert.ToInt32(Console.ReadLine());
            var process = Process.GetProcessById(pid);

            Console.WriteLine($"{process.ProcessName}");
        }
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.Message);
        }
        
    }
    private void ShowAllProcessesFilter()
    {
        Process[] processes = Process.GetProcesses();
        Dictionary<String, int> procs = new Dictionary<String, int>();

        foreach (var process in processes)
        {
            if (procs.ContainsKey(process.ProcessName))
            {
                procs[process.ProcessName]++;
            }
            else
            {
                procs[process.ProcessName] = 1;
            }
        }

        foreach (var count in procs)
        {
            Console.WriteLine($"{count.Key} - {count.Value} ");
        }
    }
    private void ShowAllProcesses()
    {
        Process[] processes = Process.GetProcesses();
        
        foreach (var process in processes)
        {
            Console.WriteLine($"Process name: {process.ProcessName}, PID: {process.Id}");
        }    
    }

   private Process? process;
    private void CreateProcess()
    {

        Console.WriteLine("\nEnter program name: ");
        string process_program = Console.ReadLine();

        if (process != null && !process.HasExited)
        {
            Console.WriteLine("Process not Exited");
            return;
        }

        try
        {
            process = Process.Start(process_program);
            Console.WriteLine($"Running PID: {process.Id}");
        }
        catch (Exception)
        {
            Console.WriteLine($"Error to start");
        }
    }
    private void KillProcess()
    {
        try
        {
            Console.WriteLine("\nEnter PID for kill process: ");
            int pid = Convert.ToInt32(Console.ReadLine());
            var process = Process.GetProcessById(pid);

            process.Kill();
            Console.WriteLine($"Process {pid} is kill");
        }
        catch (Exception)
        {
            Console.WriteLine("Procces with PID not found");
        }
        
    }
    private void CallTestProgram()
    {
        string exePath = @"C:\Users\ioant\source\repos\SystemProgramming\TestProgram\bin\Debug\net9.0\TestProgram.exe";
        Console.WriteLine("\n Enter any arg: ");
        string arg = Console.ReadLine()??"hi";
        ProcessStartInfo processInfo = new ProcessStartInfo()
        {
            FileName = exePath,
            Arguments = arg,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        using ( var process = new Process() )
        {
            process.StartInfo = processInfo;
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error  = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrEmpty(error))
            {
               Console.WriteLine($"Result: {output}");
            }
            else
            {
                Console.WriteLine(error);
            }
           
        }
    }
}
