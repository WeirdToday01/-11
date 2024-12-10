using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 7, 1, 9, 5, 6, 8, 10 };
            arr = arr.Where(x => x % 2 != 0).ToArray();

            int sum = arr.Sum();
            Console.WriteLine(sum);
            //foreach (int x in arr)
            //{
            //    Console.WriteLine(x);
            //}
            Console.ReadKey();
        }
    }
}
