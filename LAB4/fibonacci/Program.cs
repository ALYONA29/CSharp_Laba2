using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace fibonacci
{
    class Program
    {
        [DllImport("LibCPP.dll", EntryPoint = "fibonacciCDECL", CallingConvention = CallingConvention.Cdecl)]
        static extern UInt32 fibonacciCDECL(UInt32 m);

        [DllImport("LibCPP.dll", EntryPoint = "_fibonacciSTD@4", CallingConvention = CallingConvention.StdCall)]
        static extern UInt32 fibonacciSTD(UInt32 m);

        [DllImport("LibCPP.dll", EntryPoint = "@fibonacciFAST@4", CallingConvention = CallingConvention.FastCall)]
        static extern UInt32 fibonacciFAST(UInt32 m);


        [DllImport("LibCPP.dll", EntryPoint = "createFibonacci", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr createFibonacci(UInt32 m);

        [DllImport("LibCPP.dll", EntryPoint = "?calc@fibonacciNumber@@QAEKXZ", CallingConvention = CallingConvention.ThisCall)]
        static extern UInt32 сalc(IntPtr instance);

        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер числа Фибоначчи, которое вы хотите найти");
            UInt32 m;
            string input = Console.ReadLine();
            while (!(UInt32.TryParse(input, out m)) || m <= 0)
            {
                Console.WriteLine("Неверный ввод, попробуйте снова : ");
                input = Console.ReadLine();
            }

            Console.WriteLine("Cdecl.   fib({0}) = {1}", m, fibonacciCDECL(m));

            Console.WriteLine("StdCall. fib({0}) = {1}", m, fibonacciSTD(m));

            IntPtr fibClass = createFibonacci(m);
            Console.WriteLine("ThisCall.   fib({0}) = {1}", m, сalc(fibClass));

            Console.ReadKey();
        }
    }
}
