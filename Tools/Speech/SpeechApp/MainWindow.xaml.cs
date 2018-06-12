using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeechApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int  defaultCode = -1;

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int startFun();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int stopFun(int code);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int resultFun(string result, char isEnd);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int errorFun(int code, string msg);


        [DllImport(@"E:\Source\MyStudy\Tools\Speech\output\speech.dll", EntryPoint = "startupTask", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        extern static int startupTask(string loginParams, string sessionBeginParams,
            startFun startCallback,
            stopFun stopCallback,
            resultFun resultCallback,
            errorFun errorCallback);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var loginParams = "appid = 5b0dfbb4, work_dir = .";
            var sessionBeginParams = "sub = iat, domain = iat, language = zh_cn, accent = mandarin, sample_rate = 16000, result_type = plain, result_encoding = gb2312";

            var startCall = new startFun(Start);
            var stopCall = new stopFun(Stop);
            var resultCall = new resultFun(Result);
            var errorCall = new errorFun(Error);

            var result = startupTask(loginParams, sessionBeginParams, startCall, stopCall, resultCall, errorCall);
        }

        public static int Start()
        {
            return defaultCode;
        }

        public static int Stop(int reason)
        {
            return defaultCode;
        }

        public static int Result(string result, char isLast)
        {
            return defaultCode;
        }

        public static int Error(int code, string msg)
        {
            //MessageBox.Show(msg);
            return defaultCode;
        }
    }
}
