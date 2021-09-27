using System;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World! (Server)");

            await Run();
        }

        static async Task Run()
        {
            //Httpリスナーを立ち上げ、クライアントからの接続を待つ
            HttpListener s = new HttpListener();
            s.Prefixes.Add("http://localhost:8000/ws/");
            s.Start();
            var hc = await s.GetContextAsync();

            //クライアントからのリクエストがWebSocketでない場合は処理を中断
            if (!hc.Request.IsWebSocketRequest)
            {
                //クライアント側にエラー(400)を返却し接続を閉じる
                hc.Response.StatusCode = 400;
                hc.Response.Close();
                return;
            }

            //WebSocketでレスポンスを返却
            var wsc = await hc.AcceptWebSocketAsync(null);
            var ws = wsc.WebSocket;

            Console.WriteLine("Enter exit -> finish");
            while (true)
            {
                var str = Console.ReadLine();
                if (str == "exit")
                {
                    break;
                }

                //文字列をByte型に変換
                var time = DateTime.Now.ToLongTimeString();
                var buffer = Encoding.UTF8.GetBytes(time + " " + str);
                var segment = new ArraySegment<byte>(buffer);

                //クライアント側に文字列を送信
                await ws.SendAsync(segment, WebSocketMessageType.Text,
                  true, CancellationToken.None);
                await Listen(ws);
            }

            //接続を閉じる
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure,
              "Done", CancellationToken.None);
        }

        static async Task Listen(WebSocket ws)
        {
            var buffer = new byte[1024];
            var segment = new ArraySegment<byte>(buffer);

            var result = await ws.ReceiveAsync(segment, CancellationToken.None);
            //メッセージの最後まで取得
            int count = result.Count;
            while (!result.EndOfMessage)
            {
                if (count >= buffer.Length)
                {
                    Console.WriteLine(count + " / " + buffer.Length);
                    await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData,
                      "That's too long", CancellationToken.None);
                }
                segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                result = await ws.ReceiveAsync(segment, CancellationToken.None);

                count += result.Count;
            }
            //メッセージを取得
            count = Math.Min(count, buffer.Length);
            var message = Encoding.UTF8.GetString(buffer, 0, count);
            Console.WriteLine(">> " + message);
        }
    }
}
