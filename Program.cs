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

            decimal limit = 60000; // 60000 - 56sec
            decimal limitBorder = limit - Math.Ceiling(limit/3);

            decimal temp1 = 0;
            decimal temp2 = limitBorder;

            decimal result = 0;

            Task task1 = new Task(() =>
            {
                while (temp1 < limitBorder)
                {
                    temp1++;
                    for (decimal i = 2; i <= temp1; i++)
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
                while (temp2 < limit)
                {
                    temp2++;
                    for (decimal i = 2; i <= temp2; i++)
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