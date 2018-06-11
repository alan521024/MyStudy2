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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int startFun(int code, string msg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int errorFun(int code, string msg);


        [DllImport(@"E:\Source\MyStudy\Tools\Speech\output\speech.dll", EntryPoint = "startupTask", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        extern static int startupTask(string loginParams, string sessionBeginParams, startFun startCallback, errorFun errorCallback);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var loginParams = "appid = 5b0dfbb4, work_dir = .";
            var sessionBeginParams = "sub = iat, domain = iat, language = zh_cn, accent = mandarin, sample_rate = 16000, result_type = plain, result_encoding = gb2312";

            var startCall = new startFun(Start);
            var errorCall = new errorFun(Error);

            var result = startupTask(loginParams, sessionBeginParams, startCall, errorCall);
        }

        public static int Start(int code, string msg)
        {
            return 1;
        }


        public static int Error(int code, string msg)
        {
            MessageBox.Show(msg);
            return 1;
        }

    }
}
