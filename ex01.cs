using System;
using System.Diagnostics;
using System.Threading;

namespace OS_Sync_Ex_01
{
    class Program
    {
        private static int sum = 0;
        static void plus()
        {
            int i;
            for (i=1;i<1000001;i++)
                sum+=i;
        }

        static void minus()
        {
            int i;
            for (i=0;i<1000000;i++)
                sum+=i;
        }

        static void Main(string[] args)
        {
            Thread P = new Thread(new ThreadStart(plus));
            Thread M = new Thread(new ThreadStart(minus));
            
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Start....");
            sw.Start();

            P.Start();
            M.Start();

            P.Join();
            M.Join();

            sw.Stop();
            Console.WriteLine("sun = {0}", sum);
            Console.WriteLine("Time used: "+ sw.ElapsedMilliseconds.ToString()+"ms");
        }

    }
}