using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace TimeAssist.Views
{
    public partial class WebRequestDialog : Form
    {
        public WebRequest request;
        public WebResponse response;

        System.Threading.Thread worker;

        public System.Net.WebClient webClient;

        public WebRequestDialog()
        {
            InitializeComponent();
            threadData.logMethod = Log;
            webClient = new WebClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            URL = textboxURI.Text;

            worker = new Thread(new ThreadStart(ThreadGet));
            worker.IsBackground = true;
            worker.Start();

            //webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(webClient_DownloadDataCompleted);
            //webClient.DownloadDataAsync(new Uri(URL));
        }

        void webClient_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            Clear();

            Log("WebClient Response");
            Log(System.Text.Encoding.Default.GetString(e.Result));
        }

        public void Clear()
        {
            textboxRespose.Text = "";
        }
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        // This method demonstrates a pattern for making thread-safe
        // calls on a Windows Forms control. 
        //
        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly. 
        public void Log(string msg)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textboxRespose.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Log);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.textboxRespose.Text += "\n==============================\n" + msg;
            }
        }


        public static string URL;
        public static string RESPONSE;
        public static ThreadData threadData = new ThreadData();
        public static void ThreadGet()
        {
            //WebGet(URL);
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("inUser", "93");
            d.Add("inPassword", "johnr");
            d.Add("btnSubmit", "Login");
            WebPost("http://192.168.40.116/timesheet/processlogin.asp", d);
        }

        private static void WebGet(string url)
        {
            threadData.logMethod("Starting GET Request...");
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "GET";

            threadData.logMethod("Getting Response");
            WebResponse response = request.GetResponse();
            threadData.logMethod(((HttpWebResponse)response).StatusDescription);
            threadData.logMethod("Printing Datastream");
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            threadData.logMethod(reader.ReadToEnd());
            reader.Close();
            response.Close();
        }

        private static void WebPost(string url, Dictionary<string, string> data)
        {
            threadData.logMethod("Starting POST Request...");
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";

            var requestStream = request.GetRequestStream();
            StreamWriter writer = new StreamWriter(requestStream);
            StringBuilder str = new StringBuilder();
            var enumer = data.GetEnumerator();
            for (int i = 0; enumer.MoveNext(); ++i)
            {
                if (i != 0)
                    str.Append("&");
                str.Append(enumer.Current.Key + "=" + enumer.Current.Value);
            }
            writer.Write(str.ToString());
            writer.Close();
            requestStream.Close();

            threadData.logMethod(str.ToString());

            threadData.logMethod("Getting Response");
            WebResponse response = request.GetResponse();
            threadData.logMethod(((HttpWebResponse)response).StatusDescription);
            threadData.logMethod("Printing Datastream");
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            threadData.logMethod(reader.ReadToEnd());
            reader.Close();
            response.Close();
        }

        public static void ThreadPost()
        {
            threadData.logMethod("Starting Request...");
            WebRequest request = WebRequest.Create(URL);
            //System.Net.WebClient client = new WebClient();
            request.Credentials = CredentialCache.DefaultCredentials;

            threadData.logMethod("Getting Response");
            WebResponse response = request.GetResponse();
            threadData.logMethod(((HttpWebResponse)response).StatusDescription);
            threadData.logMethod("Printing Datastream");
            for (int i = 0; i < response.Headers.Count; i++)
            {
                threadData.logMethod("HeaderIndex (" + i + "): " + response.Headers.Get(i));
            }
            
            threadData.logMethod("ResponseURI: " + response.ResponseUri.ToString());
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            threadData.logMethod(reader.ReadToEnd());
            reader.Close();
            response.Close();
        }


        public class ThreadData
        {
            public System.Action<string> logMethod;
            public System.Action<string> onThreadFinished;
        }
    }
}
