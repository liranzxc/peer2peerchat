using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private Dictionary<IPEndPoint, string> userlist = new Dictionary<IPEndPoint, string>();
        private int _port = 28000;

        private string _multicastGroupAddress = "239.1.1.1";

        private UdpClient _sender;
        private UdpClient _receiver;

        private Thread _receiveThread;

        private void UpdateMessages(IPEndPoint sender, string message)
        {

            chatbox.Text += $"{userlist[sender]} | {message}\r\n";
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

                    if(dataencode.StartsWith("File"))
                    {
                        string[] paths = dataencode.Split('@');
                        string extention = paths[1];

                        int lengthtoSkip = Encoding.UTF8.GetByteCount("File@" + extention + "@");
                        byte[] bytesToUse = dataGram.Skip(lengthtoSkip).ToArray();

                        //File@extention@bytes

                        CreateAndOpenFile(extention, bytesToUse);
                    }
                    else
                    { 
                    if (dataencode.StartsWith("@"))
                    { // someone new enter the chat 

                        if(!userlist.ContainsKey(sentBy))
                        {
                            userlist.Add(sentBy, dataencode.Substring(1));
                            updateListUser();

                            //now need to send back a message we get his message 

                            // back message hello back
                            Thread back = new Thread(SendOpeningMessage);
                            back.Start();

                        }

                    }
                    else
                    { 
                        if(dataencode.StartsWith("%"))
                        {
                            // someone exit 
                            userlist.Remove(sentBy);
                            updateListUser();

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
                    }
                }
            });
            _receiveThread.IsBackground = true;
            _receiveThread.Start();


            _sender = new UdpClient();
            _sender.JoinMulticastGroup(IPAddress.Parse(_multicastGroupAddress));


            Thread t = new Thread(SendOpeningMessage);
            t.Start();

            mylist.SelectionMode = SelectionMode.One;



        }

        private void CreateAndOpenFile(string extention, byte[] dataimage)
        {
           // read file
            string fileName = "newFile"+new Random().Next(100000).ToString()+extention;

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + fileName;

                if (extention.Equals(".txt"))
                {
                    string dataencode = Encoding.UTF8.GetString(dataimage);

                    System.IO.File.WriteAllText(path, dataencode);

                }
                else
                {
                    System.IO.File.WriteAllBytes(path, dataimage);
                }

                System.Diagnostics.Process.Start(path);


            }
            catch (Exception s)
            {

                Console.WriteLine(s.Message);
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mylist.SelectedItems.Count > 0)
            {
                var data = Encoding.UTF8.GetBytes("Private***: " +messagebox.Text);
                var adress = userlist.Keys.ToList()[mylist.SelectedIndex].Address;
                _sender.Send(data, data.Length, new IPEndPoint(adress, _port));
            }
            else
            {
                var data = Encoding.UTF8.GetBytes(messagebox.Text);
                _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port));

            }
        }

        protected override void OnClosed(EventArgs e)
        {
            Thread left = new Thread(LeftMessage);
            left.Start();

            _receiver.DropMulticastGroup(IPAddress.Parse(_multicastGroupAddress)); // leave virtual group
            _sender.DropMulticastGroup(IPAddress.Parse(_multicastGroupAddress));

            base.OnClosed(e);
        }

     

        public void LeftMessage()
        {
            string alias = "exit";
            var data = Encoding.UTF8.GetBytes("%" + alias);
            _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port));
            _sender.Send(data, data.Length, new IPEndPoint(IPAddress.Broadcast, _port)); // control
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

        private void clearSelect_Click(object sender, EventArgs e)
        {
            mylist.ClearSelected();
        }

        private void messagebox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }

        }

        private void sendfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               byte [] buffer = File.ReadAllBytes(openFileDialog1.FileName);

               string extention = Path.GetExtension(openFileDialog1.FileName);

                string title = "File@" + extention + "@";
                

                byte [] titlebuffer = Encoding.UTF8.GetBytes(title);

                byte[] final = new byte[titlebuffer.Length + buffer.Length];

                titlebuffer.CopyTo(final, 0);
                buffer.CopyTo(final, titlebuffer.Length);




                if (mylist.SelectedItems.Count > 0)
                {
                    var adress = userlist.Keys.ToList()[mylist.SelectedIndex].Address;
                    _sender.Send(final, final.Length, new IPEndPoint(adress, _port));
                }
                else
                {
                    _sender.Send(final, final.Length, new IPEndPoint(IPAddress.Broadcast, _port));

                }



            }
        }
    }
}
