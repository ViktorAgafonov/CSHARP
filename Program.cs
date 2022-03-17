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

            decimal limit = 2000000;

            int temp1 = 0;
            int temp2 = 0;
            int result = 0;

            decimal limit1 = Math.Ceiling(limit/2);
            decimal limit2 = limit - limit1;

            Task task1 = new Task(() =>
            {
                while (temp1 < limit1)
                {
                    temp1++;
                    for (int i = 2; i <= temp1; i++)
                    {
                        if (temp1 % i == 0 && i < temp1)
                        {
                            break;
                        }
                        else if (temp1 % i == 0 && i == temp1)
                        {
                            result += temp1;
                        }
                    }
                }
            });

            Task task2 = new Task(() =>
            {
                while (temp2 < limit2)
                {
                    temp2++;
                    for (int i = 2; i <= temp2; i++)
                    {
                        if (temp2 % i == 0 && i < temp2)
                        {
                            break;
                        }
                        else if (temp2 % i == 0 && i == temp2)
                        {
                            result += temp2;
                        }
                    }
                }
            });

            task1.Start();
            task2.Start();

            task1.Wait();
            task2.Wait();

            time.Stop(); 
            Console.WriteLine(time.Elapsed); 
            Console.WriteLine($"Result: {result}");
            Console.ReadKey();
        }
    }
}