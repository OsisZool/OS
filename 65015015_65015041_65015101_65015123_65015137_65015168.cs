using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Problem01
{
    class Program
    {
        static byte[] Data_Global = new byte[1000000000];
        static long Sum_Global = 0;

        static int ReadData()
        {
            int returnData = 0;
            FileStream fs = new FileStream("Problem01.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                Data_Global = (byte[])bf.Deserialize(fs);
            }
            catch (SerializationException se)
            {
                Console.WriteLine("Read Failed:" + se.Message);
                returnData = 1;
            }
            finally
            {
                fs.Close();
            }

            return returnData;
        }
        static void sum()
        {
            int G_index = 0;
            Process currentProcess = Process.GetCurrentProcess();
            int threadCount = currentProcess.Threads.Count;
            for (int i = 0; i < (1000000000/threadCount); i++)
            {
                if (Data_Global[G_index] % 2 == 0)
                {
                    Sum_Global -= Data_Global[G_index];
                }
                else if (Data_Global[G_index] % 3 == 0)
                {
                    Sum_Global += (Data_Global[G_index] * 2);
                }
                else if (Data_Global[G_index] % 5 == 0)
                {
                    Sum_Global += (Data_Global[G_index] / 2);
                }
                else if (Data_Global[G_index] % 7 == 0)
                {
                    Sum_Global += (Data_Global[G_index] / 3);
                }
                Data_Global[G_index] = 0;
                G_index += 1;
            }
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            int totalThread = Environment.ProcessorCount;
            Thread[] th = new Thread[totalThread];
            for(int i = 0; i < totalThread; i++){
                th[i] = new Thread(sum);
            }
            /* Read data from file */
            Console.Write("Data read...");
            int y = ReadData();
            if (y == 0)
            {
                Console.WriteLine("Complete.");
            }
            else
            {
                Console.WriteLine("Read Failed!");
            }

            /* Start */
            Console.Write("\n\nWorking...");
            sw.Start();
            foreach(Thread thread in th){
                thread.Start();
            }
            foreach(Thread thread in th){
                thread.Join();
            }
            sw.Stop();
            Console.WriteLine("Done.");

            /* Result */
            //For 6 Core
            Console.WriteLine("Summation result: {0}", Sum_Global);
            Console.WriteLine("Time used: " + sw.ElapsedMilliseconds.ToString() + "ms");
        }
    }
}
