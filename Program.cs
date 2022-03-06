using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = false;     // 1 bit
            byte b = (byte)'A'; // 8 bit
            sbyte s = 0;        // 8 bit
            char c = 'A';       // 16 bit
            short s1 = 0;       // 16 bit
            ushort s2 = 0;      // 16 bit
            int i = 0;          // 32 bit
            long l = 0;         // 64 bit
            decimal d = 0;      // 128 bit
            string key;

            key = (string)Console.ReadKey();
            Console.WriteLine($"Char: {key}, Byte: {b}");
        }
    }
}