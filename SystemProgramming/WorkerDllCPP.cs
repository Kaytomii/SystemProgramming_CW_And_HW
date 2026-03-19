using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace SystemProgramming;

public class WorkerDllCPP
{
    [DllImport("Calculator.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr CreateCalculatorObject(int cap);

    [DllImport("Calculator.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void DeleteCalculatorObject(IntPtr obj);

    [DllImport("Calculator.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Add(IntPtr obj, int num_1, int num_2);

    public void Run()
    {
        IntPtr objCalc = CreateCalculatorObject(100);
        Console.WriteLine(Add(objCalc, 4, 6));
        DeleteCalculatorObject(objCalc);
    }
}
