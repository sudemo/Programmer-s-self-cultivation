using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading.Tasks;
using System.Threading;
using System.Security.Policy;
using System.Net.Http;
using System.Runtime.InteropServices;

namespace invokedemo
{
    class Program
    {
        private readonly HttpClient _httpClient = new HttpClient();

        [HttpGet]
        [Out("DotNetCount")]
        public async Task<int> GetDotNetCountAsync()
        {
            // Suspends GetDotNetCountAsync() to allow the caller (the web server)
            // to accept another request, rather than blocking on this one.
            var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");

            return Regex.Matches(html, @"\.NET").Count;
        }

        /*private void mathread()
        {
            MessageBox.Show(Thread.CurrentThread.GetHashCode().ToString() + "AAA");
            var  invokeThread = new Thread(new ThreadStart(StartMethod));
            invokeThread.Start();
            string a = string.Empty;
            for (int i = 0; i < 3; i++)      //调整循环次数，看的会更清楚
            {
                Thread.Sleep(1000);
                a = a + "B";
            }
            MessageBox.Show(Thread.CurrentThread.GetHashCode().ToString() + a);
        }

        private void StartMethod()
        {
            MessageBox.Show(Thread.CurrentThread.GetHashCode().ToString() + "CCC");
            button1.BeginInvoke(new invokeDelegate(invokeMethod));
            MessageBox.Show(Thread.CurrentThread.GetHashCode().ToString() + "DDD");
        }

        private void beginInvokeMethod()
        {
            //Thread.Sleep(3000);
            MessageBox.Show(Thread.CurrentThread.GetHashCode().ToString() + "EEEEEEEEEEEE");
        }*/
        static void Main(string[] args)
    {
    }
}
}
