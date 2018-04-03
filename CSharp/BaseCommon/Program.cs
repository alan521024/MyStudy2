using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseCommon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ShowMessage("-------运算开始-------"));

            decimal value1 = 5.0M, value2 = 4.0M, value3 = 11.0M, value4 = 15.0M;

            Console.WriteLine(ShowMessage(string.Format("除法：商 {0}/{1}={3}   余 {0}%{1}={2}", value2, value1, value2 % value1, value2 / value1)));
            Console.WriteLine(ShowMessage(string.Format("除法：商 {0}/{1}={3}   余 {0}%{1}={2}", value3, value1, value3 % value1, value3 / value1)));
            Console.WriteLine(ShowMessage(string.Format("除法：商 {0}/{1}={3}   余 {0}%{1}={2}", value4, value1, value4 % value1, value4 / value1)));

            Console.WriteLine(ShowMessage(string.Format("自加：{0}++ {2} ", value1, value1++,value1)));

            Console.WriteLine(ShowMessage("-------运算结束-------"));
            Console.ReadKey();
        }

        private static string ShowMessage(string msg)
        {
            return string.Format("Thread Id={0}, Message =  {1}", Thread.CurrentThread.ManagedThreadId.ToString(), msg);
        }
    }
}
