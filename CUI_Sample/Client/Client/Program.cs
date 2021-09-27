using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public class TcpException : Exception
    {
        public TcpException(string msg) : base(msg) {
            Console.WriteLine(msg);
        }
    }

    class Program
    {
        private static ulong call_cnt = 0;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string end_point = GetEndPoint(args);
            Console.WriteLine("Waiting for Request...");

            while (true)
            {
                try
                {
                    await GetWebTest(end_point, 10000);
                }
                catch (Exception e) { }
            }
        }

        static string GetEndPoint(string[] args)
        {
            string result = "ws://localhost:8000/ws/";
            if (args.Length == 0)
            {
            }
            else
            {
                result = args[0];
            }
            Console.WriteLine("End point = " + result);
            return result;
        }

        static async Task GetWebTest(string end_point, int connectTimeout)
        {
            ClientWebSocket ws = new ClientWebSocket();
            var uri = new Uri(end_point);

            var cancelTask = Task.Delay(connectTimeout);
            var connectTask = ws.ConnectAsync(uri, CancellationToken.None);
            await await Task.WhenAny(connectTask, cancelTask);
            if (cancelTask.IsCompleted)
            {
                throw new TcpException("Time out");
            }

            var buffer = new byte[1024];
            var segment = new ArraySegment<byte>(buffer);

            while (true)
            {
                // get response
                var result = await ws.ReceiveAsync(segment, CancellationToken.None);

                // get message
                int count = result.Count;
                while (!result.EndOfMessage)
                {
                    if (count >= buffer.Length)
                    {
                        await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData,
                          "That's too long", CancellationToken.None);
                        return;
                    }
                    segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                    result = await ws.ReceiveAsync(segment, CancellationToken.None);

                    count += result.Count;
                }

                // get message string
                if(count > 0)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, count);
                    Console.WriteLine("> " + message);

                    var time = DateTime.Now.ToLongTimeString();
                    var str = "Received message[" + call_cnt + "] = " + message;

                    // string -> byte[]
                    var rcv_buffer = Encoding.UTF8.GetBytes(time + " " + str);
                    var rcv_segment = new ArraySegment<byte>(rcv_buffer);

                    // send response message
                    await ws.SendAsync(rcv_segment, WebSocketMessageType.Text,
                      true, CancellationToken.None);
                    call_cnt++;
                }
            }
        }

    }
}
