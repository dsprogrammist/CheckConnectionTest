using System;

using System.Text;
using System.Windows.Forms;

using System.Net.NetworkInformation;

using System.Threading;

namespace TracertForm
{
    public partial class PingForm : Form
    {
        public PingForm()
        {
            InitializeComponent();
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startPing_Click(object sender, EventArgs e)
        {

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            string strHostName = destination.Text;

            if (String.IsNullOrEmpty(strHostName))
            {
                strHostName = "localhost";
            }
            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(strHostName, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                //Console.WriteLine("Address: {0}", reply.Address.ToString());
                //Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                //Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                //Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                //Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);

                ListViewItem item = pingList.Items.Add(reply.Address.ToString());
                item.SubItems.Add((item.Index + 1).ToString());
                ListViewItem.ListViewSubItem hostNameItem = item.SubItems.Add(strHostName);
                item.SubItems.Add(reply.Status == IPStatus.Success ? reply.RoundtripTime.ToString() : "*");

            }
        }

     
    }
}
    

