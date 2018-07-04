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

namespace IPCChannelClient
{
    class Program
    {
        [SecurityPermission(SecurityAction.Demand)]
        static void Main(string[] args)
        {
            // 创建一个IPC信道。
            IpcChannel channel = new IpcChannel();

            // 注册这个信道。
            ChannelServices.RegisterChannel(channel,false);

            // 注册一个远程对象的客户端代理.
            WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(typeof(RemotingObject), "ipc://TestChannel/RemoteObject.rem");
            RemotingConfiguration.RegisterWellKnownClientType(remoteType);

            RemotingObject service = new RemotingObject();

            Console.WriteLine("The client is invoking the remote object.");
            Console.WriteLine("The remote object has been called {0} times.", service.GetCount());
            
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("called {0} times.", service.GetCount());

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("called {0} times.", service.GetCount());

            Console.ReadLine();
        }
    }
}
