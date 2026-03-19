using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemProgramming;

public class WorkerDLLPMCPP
{
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr CreatePointManagerObject(int cap);
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr DeletePointManagerObject(IntPtr obj);
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void PrintAllPoints(IntPtr obj);
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void AddPoint(IntPtr obj, int px, int py);
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void RemovePoint(IntPtr obj, int index);
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetPoint(IntPtr obj, int index, out int x, out int y);
    [DllImport("PointManager.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Count(IntPtr obj);

    public void Run()
    {
        IntPtr objPM = CreatePointManagerObject(100);
        AddPoint(objPM, 50, 25);
        AddPoint(objPM, 10, 15);
        AddPoint(objPM, 70, 37);
        Console.WriteLine("Point Added: ");
        PrintAllPoints(objPM);

        int x, y;
        GetPoint(objPM, 1, out x, out y);

        int index = 2;
        RemovePoint(objPM, index);
        Console.WriteLine($"Point on index: {index} removed");
        Console.WriteLine("Points after remove: ");
        PrintAllPoints(objPM);

        int PointCount = Count(objPM);
        Console.WriteLine($"Count: {PointCount}");

        DeletePointManagerObject(objPM);
    }
}
