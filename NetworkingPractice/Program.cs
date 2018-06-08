using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading.Tasks;

namespace NetworkingPractice
{
    class Program
    {
        static bool echo = true;
        static int packetLoss = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(@"TestEnv\TestDir");
            var response = string.Empty;
            do
            {
                response = Console.ReadLine();
                ParseCMDArguments(response);
            } while (response.ToLower() != "exit");
        }

        public static void ParseCMDArguments(string arg)
        {
            var tokens = arg.Split();
            switch (tokens[0]) {
                case "ping":
                    IPAddress pAddress;
                    if (IPAddress.TryParse(tokens[1], out pAddress))
                    {
                        PingClient(pAddress);
                    }
                    else
                    {
                        PingClient(tokens[1]);
                    }
                    break;
                case "nslookup":
                    break;
                default:
                    Console.WriteLine($"{tokens[0]} not recognized as valid command");
                    break;
            }
        }

        public static void PingClient(string hostName, int requestAmount = 4, int packetSize = 32)
        {
            var pinger = new Ping();
            var options = new PingOptions(128, true);
            for (int i = 0; i < requestAmount; i++) {
                var reply = pinger.Send(hostName, 1000, new byte[packetSize], options);
                Console.WriteLine(DisplayReply(reply));
            }
        }

        public static void PingClient(IPAddress ip, int requestAmount = 4, int packetSize = 32)
        {
            var pinger = new Ping();
            var options = new PingOptions(128, true);
            for (int i = 0; i < requestAmount; i++)
            {
                var reply = pinger.Send(ip, 1000, new byte[packetSize], options);
                Console.WriteLine(DisplayReply(reply));
            }
            Console.WriteLine($"Ping statistics for {ip.ToString()}:\n\r Packets: Sent={requestAmount} Recieved={requestAmount-packetLoss} Lost{packetLoss}");
        }

        public static string DisplayReply(PingReply reply)
        {
            if (reply != null)
            {
                return $"Reply from {reply.Address}: Bytes={reply.Buffer.Count()}: Time={reply.RoundtripTime}ms: ttl={reply.Options.Ttl}: fragment={!reply.Options.DontFragment}";
            }
            else
            {
                packetLoss++;
                return $"No reply from host";
            }
        }

        public static void NetStat(string connectionType, bool activeConnections = false)
        {
            var prop = IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine("Active Connections\n");
            Console.WriteLine("Proto    Local Addr   Foreign Addr    State");
            foreach (var connection in prop.GetActiveTcpConnections())
            {
                Console.WriteLine($"TCP  {connection.LocalEndPoint}     {connection.RemoteEndPoint}     {connection.RemoteEndPoint}");
            }
        }
    }
}
