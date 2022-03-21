using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            int limit = 50000;
            int result = 0;
            int count = 0;
            int[] arr = new int[limit+1];

            for (int a = 0; a < arr.Length; a++)
            { 
                arr[a] = count;
                count++;
            }

            foreach (int i in arr)
            {
                if (i != 0 && i > 1){
                    result += i;
                    for (int n = i; n < arr.Length; n+=i)
                    {
                        arr[n] = 0;
                    }
                }
            }

            time.Stop(); 
            Console.WriteLine(time.Elapsed); 
            Console.WriteLine($"Result: {result}");
            Console.ReadKey();
        }
    }
}