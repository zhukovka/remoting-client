using RemotingOne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace RemotingOneClient1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press return after the server is started");
            Console.ReadLine();

            ChannelServices.RegisterChannel(new TcpClientChannel(), true);
            Hello obj = (Hello)Activator.GetObject(
                                         typeof(Hello), "tcp://localhost:8086/Hi");
            if (obj == null)
            {
                Console.WriteLine("could not locate server");
                return;
            }
            Console.WriteLine(obj.Greeting("Helen Zhukova"));
            MySerialized ser = obj.GetMySerialized();
            if (!RemotingServices.IsTransparentProxy(ser))
            {
                Console.WriteLine("ser is not a transparent proxy");
            }
            ser.Foo();
        }
    }
}
