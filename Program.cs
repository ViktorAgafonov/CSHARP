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
            decimal result4 = 0;

            decimal limit = 50000; // 25000 an 9.31 sec 40% \\ 50000 an 43sec
            decimal limit1 = limit - Math.Ceiling(limit/4);
            decimal limit2 = limit - Math.Ceiling((limit - limit1)/4);
            decimal limit3 = limit - Math.Ceiling((limit - limit2) / 4);

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
                result3 = Task(limit2, limit3);
            });

        var thread4 = new Thread(
            () =>
            {
                result4 = Task(limit3, limit);
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();


            time.Stop(); 
            Console.WriteLine(time.Elapsed);
            
            Console.WriteLine($"Result: {result1 + result2 + result3 + result4}");
            Console.WriteLine($"Limit1 = {limit1}; Limit2 = {limit2}; Limit3 = {limit3}; Limit = {limit}");

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