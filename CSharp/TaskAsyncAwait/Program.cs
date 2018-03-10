using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskAsyncAwait
{
    class Program
    {
        //示例来源于：https://www.cnblogs.com/doforfuture/p/6293926.html#undefined

        #region Thread 多线程

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(ShowMessage("主线程开始"));

        //    //IsBackground=true，将其设置为后台线程
        //    Thread t = new Thread(Run) { IsBackground = true };
        //    t.Start();
        //    Console.WriteLine(ShowMessage("主线程在做其他的事！"));

        //    //主线程结束，后台线程会自动结束，不管有没有执行完成
        //    //可以根据不同的设置查看效果
        //    //Thread.Sleep(300);
        //    Thread.Sleep(1500);

        //    Console.WriteLine(ShowMessage("主线程结束"));
        //    Console.ReadKey();
        //}
        //static void Run()
        //{
        //    Thread.Sleep(700);
        //    Console.WriteLine(ShowMessage("这是后台线程调用"));
        //}

        #endregion

        #region Task（类似于ThreadPool） 

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(ShowMessage("主线程启动"));

        //    //Task.Run启动一个线程
        //    //Task task = Task.Factory.StartNew(() => { Thread.Sleep(1500); Console.WriteLine("task启动"); });

        //    Task task = Task.Run(() => {
        //        //Thread.Sleep(1500);
        //        Console.WriteLine(ShowMessage("Task启动执行"));
        //    });

        //    //Thread.Sleep(300);

        //    //Task启动的是后台线程，要在主线程中等待后台线程执行完毕，可以调用Wait方法
        //    //可注释查看效果及设置休眠时间查看
        //    //task.Wait();

        //    Console.WriteLine(ShowMessage("主线程结束"));
        //    Console.ReadKey();
        //}

        #endregion

        #region Task(ThreadPool 与  Thead区别)

        ////可以看出来，直接用Thread会开启5个线程，用Task(用了线程池)开启了3个！
        //static void Main(string[] args)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        new Thread(Run1).Start();
        //    }
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Task.Run(() => { Run2(); });
        //    }
        //    Console.ReadKey();
        //}
        //static void Run1()
        //{
        //    Console.WriteLine(ShowMessage("Thread Id =" + Thread.CurrentThread.ManagedThreadId));
        //}
        //static void Run2()
        //{
        //    Console.WriteLine(ShowMessage("Task调用的Thread Id =" + Thread.CurrentThread.ManagedThreadId));
        //}

        #endregion

        #region Task<TResult>

        //static void Main(string[] args)
        //{
        //    Console.WriteLine(ShowMessage("主线程开始"));
        //    //返回值类型为string
        //    Task<string> task = Task<string>.Run(() => {
        //        //注释可看都会等task.result 有结后主线程才会续继操作
        //        //Thread.Sleep(2000);
        //        return ShowMessage("Task线程 ");
        //    });
        //    //会等到task执行完毕才会输出;
        //    Console.WriteLine(task.Result);
        //    Console.WriteLine(ShowMessage("主线程结束"));
        //    Console.ReadKey();
        //}

        #endregion

        #region  async/await
        static void Main(string[] args)
        {
            Console.WriteLine(ShowMessage("-------主线程启动-------"));

            var task = AsyncAwaitTest1(); //await 必须出现在async方法中，所以此方法不可用await AsyncAwaitTest1();

            Console.WriteLine(ShowMessage("-------主线程结束-------"));

            //Console.WriteLine(ShowMessage("-------主线程启动-------"));
            //Task<int> task = GetStrLengthAsync();
            //Console.WriteLine(ShowMessage("主线程继续执行"));
            //Console.WriteLine(ShowMessage("Task返回的值" + task.Result));
            //Console.WriteLine(ShowMessage("-------主线程结束-------"));

            Console.ReadKey();
        }

        static async Task AsyncAwaitTest1()
        {
            //测试1:
            //RunAsync("A", 500);
            //RunAsync("B", 0);

            //测试2：
            //await RunAsync("A", 500);
            //await RunAsync("B", 0);

            //测试3：
            //RunAsync("A", 500);
            //await RunAsync("B", 0);

            //测试4：
            //await RunAsync("A", 500);
            //RunAsync("B", 0);

            //测试5:
            //string resultA = await RunAsync("A", 500);
            //RunAsync("B", 0);
            //Console.WriteLine(ShowMessage(string.Format("由于使用了A的结果，必须等A执行完{0}", resultA)));


            //以下四个详细查看 调用 async Task<st 输入在哪个线程Id

            //测试6:
            //Thread t1 = new Thread(new ParameterizedThreadStart(RunMethad)) { IsBackground = true };
            //t1.Start("all");

            //测试7:
            //Thread t2 = new Thread(new ParameterizedThreadStart(RunMethad)) { IsBackground = true };
            //t2.Start("A");
            //RunAsync("B", 0);

            // 测试8:
            //Thread t3 = new Thread(new ParameterizedThreadStart(RunMethad)) { IsBackground = true };
            //t3.Start("B");
            //RunAsync("A", 0);

            // 测试8:
            //Thread t4 = new Thread(new ParameterizedThreadStart(RunMethad)) { IsBackground = true };
            //t4.Start("A");
            //Thread t5 = new Thread(new ParameterizedThreadStart(RunMethad)) { IsBackground = true };
            //t5.Start("B");
        }

        static Task<string> RunAsync(string typeValue, int seelpValue)
        {
            //可开启查看被哪个线程调用
            Console.WriteLine(ShowMessage(string.Format("调用 async Task<string> RunAsync({0}-{1})", typeValue, seelpValue)));

            return Task<string>.Run(() =>
            {
                Thread.Sleep(seelpValue);
                Console.WriteLine(ShowMessage(string.Format("执行 async Task<string> RunAsync({0}-{1})", typeValue, seelpValue)));
                return typeValue;
            });

        }

        static void RunMethad(object name)
        {
            if (name == "all")
            {
                RunAsync("A", 500);
                RunAsync("B", 0);
            }
            if (name == "A")
            {
                RunAsync("A", 500);
            }
            if (name == "B")
            {
                RunAsync("B", 0);
            }
        }



        static async Task<int> GetStrLengthAsync()
        {
            //注意：本方法未使用  Task<string>.Run()

            Console.WriteLine(ShowMessage("Task方法开始执行"));
            //此处返回的<string>中的字符串类型，而不是Task<string>
            string str = await GetString();
            Console.WriteLine(ShowMessage("Task方法执行结束"));
            return str.Length;
        }

        static Task<string> GetString()
        {
            //Console.WriteLine("GetString方法开始执行")
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine(ShowMessage("-------await Task 方法执行-------"));
                return ShowMessage("GetString的返回值");
            });
        }

        #endregion

        private static string ShowMessage(string msg)
        {
            return string.Format("Thread Id={0}, Message =  {1}", Thread.CurrentThread.ManagedThreadId.ToString(), msg);
        }

    }
}
