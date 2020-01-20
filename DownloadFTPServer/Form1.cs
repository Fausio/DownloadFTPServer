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

namespace DownloadFTPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Get_Data_From_My_FTP_Server();
        }

        private string Get_Data_From_My_FTP_Server()
        {

            //result date from file 
            string result = string.Empty;



            // do ftp web request
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.fhi360covida.org//" + "e-MAC.rar");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // set up credentials
            request.Credentials = new NetworkCredential("Administrator", "VPServer2019");

            // initialize ftp response

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            //open readers
            Stream ResponseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(ResponseStream);


            // data from file 
            result = reader.ReadToEnd();

            return result;
        }
    }
}
