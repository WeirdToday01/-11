using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 7, 1, 9, 5, 3, 6, 3 };
            //int count = 0;
            //foreach (int x in array)
            //{
            //    if (x == 3)
            //    {
            //        count++;
            //    }
            //}
            int count = array.Count(x => x == 3);
            Console.WriteLine(count);
            Console.Read();
        }
    }
}
