using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using IPCChannelBase;

namespace IPCChannelServer
{
    class Program
    {
        [SecurityPermission(SecurityAction.Demand)]
        static void Main(string[] args)
        {
            // 创建一个IPC信道
            IpcChannel serverChannel = new IpcChannel("TestChannel");

            // 注册这个IPC信道.
            ChannelServices.RegisterChannel(serverChannel, false);

            // 打印这个信道的名称.
            Console.WriteLine("The name of the channel is {0}.", serverChannel.ChannelName);

            // 打印这个信道的优先级.
            Console.WriteLine("The priority of the channel is {0}.", serverChannel.ChannelPriority);

            // 打印这个信道的URI数组.
            ChannelDataStore channelData = (ChannelDataStore)serverChannel.ChannelData;
            foreach (string uri in channelData.ChannelUris)
            {
                Console.WriteLine("The channel URI is {0}.", uri);
            }

            // 向信道暴露一个远程对象.
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingObject), "RemoteObject.rem", WellKnownObjectMode.Singleton);

            Console.WriteLine("Press ENTER to exit the server.");
            Console.ReadLine();
        }
    }
}
