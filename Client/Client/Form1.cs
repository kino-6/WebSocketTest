using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.WebSockets;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class ClinetMainForm : Form
    {
        private enum SERVERx_E : byte
        {
            SERVER1,
            SERVER2,
            N_SERVER
        }
        private static WebSocket[] g_ws = new WebSocket[(byte)SERVERx_E.N_SERVER];

        public ClinetMainForm()
        {
            InitializeComponent();
        }

        private static async Task<WebSocket> ListenStart(string addr, byte idx)
        {
            HttpListener s = new HttpListener();
            s.Prefixes.Add(addr);
            s.Start();
            var hc = await s.GetContextAsync();
            var wsc = await hc.AcceptWebSocketAsync(null);
            var ws = wsc.WebSocket;

            var str = "Connected!";
            var time = DateTime.Now.ToLongTimeString();
            var buffer = Encoding.UTF8.GetBytes(time + " " + str);
            var segment = new ArraySegment<byte>(buffer);

            await ws.SendAsync(segment, WebSocketMessageType.Text,
              true, CancellationToken.None);

            g_ws[idx] = ws;
            return ws;
        }

        private static async Task<byte[]> SndMsg(WebSocket ws, string str)
        {
            //var time = DateTime.Now.ToLongTimeString();
            var buffer = Encoding.UTF8.GetBytes(str + " ");
            var segment = new ArraySegment<byte>(buffer);

            if (ws != null)
            {
                await ws.SendAsync(segment, WebSocketMessageType.Text,
                  true, CancellationToken.None);
            }
            return buffer;
        }

        private static async Task<string> RcvMsg(WebSocket ws)
        {
            var buffer = new byte[4096];
            var segment = new ArraySegment<byte>(buffer);

            var result = await ws.ReceiveAsync(segment, CancellationToken.None);
            int count = result.Count;

            while (!result.EndOfMessage)
            {
                if (count >= buffer.Length)
                {
                    await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData,
                      "That's too long", CancellationToken.None);
                }
                segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                result = await ws.ReceiveAsync(segment, CancellationToken.None);

                count += result.Count;
            }

            count = Math.Min(count, buffer.Length);
            var message = Encoding.UTF8.GetString(buffer, 0, count);

            var tcs = new TaskCompletionSource<string>();
            tcs.TrySetResult(message);

            return await tcs.Task;
        }

        private void AddLog(RichTextBox Log, String str, Color color)
        {
            if (Log.InvokeRequired)
            {
                Log.Invoke((MethodInvoker)delegate {
                    AddLog(Log, str, color);
                });
            }
            else
            {
                Log.ForeColor = color;
                Log.AppendText(System.DateTime.Now.ToString() + " " + str + System.Environment.NewLine);
            }
        }

        private void ConnectButtonServer1_Click(object sender, EventArgs e)
        {
            var ws = ListenStart(TextBoxServer1.Text, (byte)SERVERx_E.SERVER1);
            if(ws != null)
            {
                ConnectButtonServer1.Text = "Connected!";
                AddLog(LogMsgBox1, "Success! Waiting for Response...", Color.Black);
            }
            else
            {
                AddLog(LogMsgBox1, "Fail Connect!", Color.Red);
            }
        }

        private void SendMsg1_Click(object sender, EventArgs e)
        {
            if (g_ws[(byte)SERVERx_E.SERVER1] != null)
            {
                string str = SendMsgBox1.Text;
                var mes = SndMsg(g_ws[(byte)SERVERx_E.SERVER1], str);
                var rcv_mes = RcvMsg(g_ws[(byte)SERVERx_E.SERVER1]);
                SendMsgBox1.Text = "";

                foreach (var rmes in rcv_mes.Result)
                    LogMsgBox1.AppendText(rmes.ToString());

                LogMsgBox1.AppendText("\n".ToString());
                LogMsgBox1.ScrollToCaret();
            }
            else
            {
                AddLog(LogMsgBox1, "Need Connect!", Color.Red);
            }

        }

        private void ConnectButtonServer2_Click(object sender, EventArgs e)
        {
            var ws = ListenStart(TextBoxServer2.Text, (byte)SERVERx_E.SERVER2);
            if (ws != null)
            {
                ConnectButtonServer2.Text = "Connected!";
                AddLog(LogMsgBox2, "Success! Waiting for Response...", Color.Black);
            }
            else
            {
                AddLog(LogMsgBox2, "Fail Connect!", Color.Red);
            }

        }

        private void SendMsg2_Click(object sender, EventArgs e)
        {
            if (g_ws[(byte)SERVERx_E.SERVER1] != null)
            {
                string str = SendMsgBox2.Text;
                var mes = SndMsg(g_ws[(byte)SERVERx_E.SERVER2], str);
                var rcv_mes = RcvMsg(g_ws[(byte)SERVERx_E.SERVER2]);
                SendMsgBox2.Text = "";

                foreach (var rmes in rcv_mes.Result)
                    LogMsgBox2.AppendText(rmes.ToString());

                LogMsgBox2.AppendText("\n".ToString());
                LogMsgBox2.ScrollToCaret();
            }
            else
            {
                AddLog(LogMsgBox2, "Need Connect!", Color.Red);
            }
        }
    }
}
