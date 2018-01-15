using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_post_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://hotels.t.zp.ua/reporttest/");
            // Set the Method property of the request to POST.  
            request.Method = "POST";
          
            // Create POST data and convert it to a byte array.  
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            // Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.  
            dataStream.Close();
            // Get the response.  
            WebResponse response = request.GetResponse();
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
           // textBox1.Text = ((HttpWebResponse)response).StatusDescription;
            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
           
           
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebRequest myHttpWebRequest = WebRequest.Create("http://hotels.t.zp.ua/reporttest/");
            //  HttpWebRequest myHttpWebRequest = new HttpWebRequest;
            // Set the 'Method' property of the 'Webrequest' to 'POST'.
            myHttpWebRequest.Method = "POST";
          //  Console.WriteLine("\nPlease enter the data to be posted to the (http://www.contoso.com/codesnippets/next.asp) Uri :");

            // Create a new string object to POST data to the Url.
           // string inputData = Console.ReadLine();


            string postData = "firstone=1";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);

            // Set the content type of the data being posted.
            myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";

            // Set the content length of the string being posted.
            myHttpWebRequest.ContentLength = byte1.Length;

            Stream newStream = myHttpWebRequest.GetRequestStream();

            newStream.Write(byte1, 0, byte1.Length);
          //  Console.WriteLine("The value of 'ContentLength' property after sending the data is {0}", myHttpWebRequest.ContentLength);

            // Close the Stream object.
            newStream.Close();
        }
    }
}
