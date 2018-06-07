using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Record
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport(@"../../../lib/recordlib.dll", EntryPoint = "start", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        extern static int start(int a, int b);


        public MainWindow()
        {
            InitializeComponent();
        }
        private void UpdateTextRight()
        {
            while (true)
            {
                var cc = start(1, 2);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Thread thread = new Thread(UpdateTextRight);
            //thread.Start();
            Task task = Task.Factory.StartNew((object mystate) =>
            {
                Process process = Process.Start(@"E:\Source\MyStudy\Library\Record\cmd\recordcmd.exe", mystate.ToString());
                process.WaitForExit();
            }, CancellationToken.None);

        }
    }

}
