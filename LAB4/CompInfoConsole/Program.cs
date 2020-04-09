using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices; 
using System.Management;   

namespace CompInfoConsole
{
    class Program
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        static extern bool GetPhysicallyInstalledSystemMemory(ref ulong memoryLength);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        static extern bool GetComputerNameEx(COMPUTER_NAME_FORMAT NameType,  StringBuilder lpBuffer, ref uint lpnSize);

        enum COMPUTER_NAME_FORMAT
        {
            ComputerNameNetBIOS,
            ComputerNameDnsHostname,
            ComputerNameDnsDomain,
            ComputerNameDnsFullyQualified,
            ComputerNamePhysicalNetBIOS,
            ComputerNamePhysicalDnsHostname,
            ComputerNamePhysicalDnsDomain,
            ComputerNamePhysicalDnsFullyQualified
        }

        static void Main(string[] args)
        {
            
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject wmi_CPU in searcher.Get())
            {
                Console.WriteLine("Процессор: {0}", wmi_CPU["Name"]);
            }

            ulong memoryLength = 0;
            bool rc = true;

            rc = GetPhysicallyInstalledSystemMemory(ref memoryLength);
            Console.WriteLine("Установленная память: {0} Гб", memoryLength / 1024 / 1024.0);
            
            StringBuilder name = new StringBuilder(260);
            uint size = 260;
            rc = GetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNameDnsFullyQualified, name, ref size);
            Console.WriteLine("Компьютер: {0}", name);

            Console.ReadKey();
        }
    }
}
