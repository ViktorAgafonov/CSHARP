using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            decimal result1 = 0;
            decimal result2 = 0;
            decimal result3 = 0;

            decimal limit = 60000; // 60000 - 48sec
            decimal limit1 = limit - Math.Ceiling(limit/3);
            decimal limit2 = limit - Math.Ceiling((limit - limit1)/3);

            decimal Task(decimal limitStart, decimal limitEnd)
            {
                decimal temp = limitStart;
                decimal result = 0;

                while (temp < limitEnd)
                {
                    temp++;

                    for (decimal i = 2; i <= temp; i++)
                    {
                        if (temp % i == 0 && i < temp)
                        {
                            break;
                        }
                        else if (temp % i == 0 && i == temp)
                        {
                            result += temp;
                        }
                    }
                }
                return result;
            }

        var thread1 = new Thread(
            () =>
            {
                result1 = Task(1, limit1);
            });

        var thread2 = new Thread(
            () =>
            {
                result2 = Task(limit1, limit2);
            });

        var thread3 = new Thread(
            () =>
            {
                result3 = Task(limit2, limit);
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();


            time.Stop(); 
            Console.WriteLine(time.Elapsed);
            
            Console.WriteLine($"Result: {result1 + result2 + result3}");
            Console.WriteLine($"Limit1 = {limit1}; Limit2 = {limit2}; Limit = {limit}");

            Console.ReadKey();
        }
    }
}
//  object value = null; // Used to store the return value
//  var thread = new Thread(
//   () =>
//   {
//      value = "Hello World"; // Publish the return value
//    });
//   thread.Start();
//  thread.Join();
//  Console.WriteLine(value); // Use the return value here