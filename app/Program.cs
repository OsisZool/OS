// using System;
// using System.Threading;

// namespace OS_Problem_02
// {
//     class Thread_safe_buffer
//     {
//         static int[] TSBuffer = new int[10];
//         static int Front = 0;
//         static int Back = 0;
//         static int Count = 0;
//         private static object _Lock = new object();
//         private static Semaphore semaphore = new Semaphore(0, 1);

//         static void EnQueue(int eq)
//         {
//             TSBuffer[Back] = eq;
//             Back++;
//             Back %= 10;
//             Count += 1;
//         }

//         static int DeQueue()
//         {
//             int x = TSBuffer[Front];
//             Front++;
//             Front %= 10;
//             Count -= 1;
//             return x;
//         }

//         static void th01()
//         {
//             for (int i = 1; i <= 50; i++)
//             {
//                 lock (_Lock)
//                 {
//                     while (Count >= 10)
//                     {
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//             semaphore.Release();
//         }

//         static void th011()
//         {
//             semaphore.WaitOne();
//             for (int i = 100; i <= 150; i++)
//             {
//                 lock (_Lock)
//                 {
//                     while (Count >= 10)
//                     {
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//         }

//         static void th02(object t)
//         {
//             while (true)
//             {
//                 int j;
//                 lock (_Lock)
//                 {
//                     while (Count <= 0)
//                     {
//                         if (semaphore.WaitOne(0))
//                         {
//                             return;
//                         }
//                         Monitor.Wait(_Lock);
//                     }
//                     j = DeQueue();
//                     Console.WriteLine("j={0}, thread:{1}", j, t);
//                     Thread.Sleep(100);
//                     Monitor.Pulse(_Lock);
//                 }
//                     if (j == 150){
//                         Environment.Exit(0);
//                     }
//             }
//         }

//         static void Main(string[] args)
//         {
//             Thread t1 = new Thread(th01);
//             Thread t11 = new Thread(th011);
//             Thread t2 = new Thread(th02);
//             Thread t21 = new Thread(th02);
//             Thread t22 = new Thread(th02);

//             t1.Start();
//             t11.Start();
//             t2.Start(1);
//             t21.Start(2);
//             t22.Start(3);
//         }
//     }
// }







// using System;
// using System.ComponentModel;
// using System.Threading;

// namespace OS_Problem_02
// {
//     class Thread_safe_buffer
//     {
//         static int[] TSBuffer = new int[10];
//         static int Front = 0;
//         static int Back = 0;
//         static int Count = 0;
//         private static object _Lock = new object();
//         private static Semaphore semaphore = new Semaphore(0, 1);

//         static void EnQueue(int eq)
//         {
//             TSBuffer[Back] = eq;
//             Back++;
//             Back %= 10;
//             Count += 1;
//         }

//         static int DeQueue()
//         {
//             int x = 0;
//             x = TSBuffer[Front];
//             Front++;
//             Front %= 10;
//             Count -= 1;
//             return x;
//         }

//         static void th01()
//         {
//             int i;
//             for (i = 1; i < 51; i++)
//             {
//                 lock(_Lock)
//                 {
//                     while(Count >= 10){
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//             semaphore.Release();
//         }

//         static void th011()
//         {
//             semaphore.WaitOne();
//             int i;
//             for (i = 100; i < 151; i++)
//             {
//                 lock(_Lock)
//                 {
//                     while(Count >= 10)
//                     {
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//         }


//         static void th02(object t)
//         {
//             int i;
//             int j;

//             for (i=0; i < 60; i++)
//             {
//                 lock(_Lock)
//                 {
//                     while(Count <= 0){
//                         Monitor.Wait(_Lock);
//                     }
//                     j = DeQueue();
//                     Console.WriteLine("j={0}, thread:{1}", j, t);
//                     Thread.Sleep(100);
//                     if(Count == 0){
//                         Environment.Exit(0);
//                     }
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//         }
//         static void Main(string[] args)
//         {
//             Thread t1 = new Thread(th01);
//             Thread t11 = new Thread(th011);
//             Thread t2 = new Thread(th02);
//             Thread t21 = new Thread(th02);
//             Thread t22 = new Thread(th02);

//             t1.Start();
//             t11.Start();
//             t2.Start(1);
//             t21.Start(2);
//             t22.Start(3);
//         }
//     }
// }






// using System;
// using System.Threading;

// namespace OS_Problem_02
// {
//     class Thread_safe_buffer
//     {
//         static int[] TSBuffer = new int[10];
//         static int Front = 0;
//         static int Back = 0;
//         static int Count = 0;
//         private static object _Lock = new object();
//         private static Semaphore semaphore = new Semaphore(0, 1);

//         static void EnQueue(int eq)
//         {
//             TSBuffer[Back] = eq;
//             Back++;
//             Back %= 10;
//             Count += 1;
//         }

//         static int DeQueue()
//         {
//             int x = TSBuffer[Front];
//             Front++;
//             Front %= 10;
//             Count -= 1;
//             return x;
//         }

//         static void th01()
//         {
//             for (int i = 1; i <= 50; i++)
//             {
//                 lock (_Lock)
//                 {
//                     while (Count >= 10)
//                     {
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//             semaphore.Release();
//         }

//         static void th011()
//         {
//             semaphore.WaitOne();
//             for (int i = 100; i <= 150; i++)
//             {
//                 lock (_Lock)
//                 {
//                     while (Count >= 10)
//                     {
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//         }

//         static void th02(object t)
//         {
//             while (true)
//             {
//                 int j;
//                 lock (_Lock)
//                 {
//                     while (Count <= 0)
//                     {
//                         if (semaphore.WaitOne(0))
//                         {
//                             return;
//                         }
//                         Monitor.Wait(_Lock);
//                     }
//                     j = DeQueue();
//                     Console.WriteLine("j={0}, thread:{1}", j, t);
//                     Thread.Sleep(100);
//                     Monitor.Pulse(_Lock);
//                 }
//                     if (j == 150){
//                         Environment.Exit(0);
//                     }
//             }
//         }

//         static void Main(string[] args)
//         {
//             Thread t1 = new Thread(th01);
//             Thread t11 = new Thread(th011);
//             Thread t2 = new Thread(th02);
//             Thread t21 = new Thread(th02);
//             Thread t22 = new Thread(th02);

//             t1.Start();
//             t11.Start();
//             t2.Start(1);
//             t21.Start(2);
//             t22.Start(3);
//         }
//     }
// }






// using System;
// using System.ComponentModel;
// using System.Threading;

// namespace OS_Problem_02
// {
//     class Thread_safe_buffer
//     {
//         static int[] TSBuffer = new int[10];
//         static int Front = 0;
//         static int Back = 0;
//         static int Count = 0;
//         private static object _Lock = new object();
//         private static Semaphore semaphore = new Semaphore(0, 1);

//         static void EnQueue(int eq)
//         {
//             TSBuffer[Back] = eq;
//             Back++;
//             Back %= 10;
//             Count += 1;
//         }

//         static int DeQueue()
//         {
//             int x = 0;
//             x = TSBuffer[Front];
//             Front++;
//             Front %= 10;
//             Count -= 1;
//             return x;
//         }

//         static void th01()
//         {
//             int i;
//             for (i = 1; i < 51; i++)
//             {
//                 lock(_Lock)
//                 {
//                     while(Count >= 10){
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//             semaphore.Release();
//         }

//         static void th011()
//         {
//             semaphore.WaitOne();
//             int i;
//             for (i = 100; i < 151; i++)
//             {
//                 lock(_Lock)
//                 {
//                     while(Count >= 10)
//                     {
//                         Monitor.Wait(_Lock);
//                     }
//                     EnQueue(i);
//                     Thread.Sleep(5);
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//         }


//         static void th02(object t)
//         {
//             int i;
//             int j;

//             for (i=0; i < 60; i++)
//             {
//                 lock(_Lock)
//                 {
//                     while(Count <= 0){
//                         Monitor.Wait(_Lock);
//                     }
//                     j = DeQueue();
//                     Console.WriteLine("j={0}, thread:{1}", j, t);
//                     Thread.Sleep(100);
//                     if(Count == 0){
//                         Environment.Exit(0);
//                     }
//                     Monitor.Pulse(_Lock);
//                 }
//             }
//         }
//         static void Main(string[] args)
//         {
//             Thread t1 = new Thread(th01);
//             Thread t11 = new Thread(th011);
//             Thread t2 = new Thread(th02);
//             Thread t21 = new Thread(th02);
//             Thread t22 = new Thread(th02);

//             t1.Start();
//             t11.Start();
//             t2.Start(1);
//             t21.Start(2);
//             t22.Start(3);
//         }
//     }
// }


