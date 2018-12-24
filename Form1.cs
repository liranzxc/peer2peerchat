using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiranNachmanPeer2PeerChat
{
    public partial class Form1 : Form
    {
        private Dictionary<string,string> userlist = new Dictionary<string,string>();
        private int _port = 28000;

        private string _multicastGroupAddress = "239.1.1.1";

        private UdpClient _sender;
        private UdpClient _receiver;

        private Thread _receiveThread;

        private void UpdateMessages(IPEndPoint sender, string message)
        {

            chatbox.Text += $"{userlist[sender.ToString()]} | {message}\r\n";
        }

        public Form1()
        {
            InitializeComponent();

            _receiver = new UdpClient();
            _receiver.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));
            _receiver.Client.Bind(new IPEndPoint(IPAddress.Any, _port));

            _receiveThread = new Thread(() =>
            {
                while (true)
                {
                    IPEndPoint sentBy = new IPEndPoint(IPAddress.Any, _port);
                    var dataGram = _receiver.Receive(ref sentBy);
                    string dataencode = Encoding.UTF8.GetString(dataGram);

                    if (dataencode.StartsWith("@"))
                    { // someone enter the chat 

                        if(!userlist.ContainsKey(sentBy.ToString()))
                        {
                            userlist.Add(sentBy.ToString(), dataencode.Substring(1));
                            updateListUser();
                        }

                    }
                    else
                    { 
                        
                        
                        
                        
                        
                        // normal message
                        chatbox.BeginInvoke(
                       new Action<IPEndPoint, string>(UpdateMessages),
                       sentBy,
                      dataencode);
                    }

                   
                }
            });
            _receiveThread.IsBackground = true;
            _receiveThread.Start();


            _sender = new UdpClient();
            _sender.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));


            Thread t = new Thread(SendOpeningMessage);
            t.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = Encoding.UTF8.GetBytes(messagebox.Text);
            _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port));
        }


        private void SendOpeningMessage()
        {
            string alias = "liran";
            var data = Encoding.UTF8.GetBytes("@"+alias);
            _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port));

        }
        private static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            return ipAddress;
        }

        private void updateListUser()
        {
            mylist.Items.Clear();

            userlist.Values.ToList().ForEach(item => {

                mylist.Items.Add(item);
            });

        }

    }
}
