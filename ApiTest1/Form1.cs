using Newtonsoft.Json.Linq;
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


namespace ApiTest1
{
    public partial class UK : Form
    {
        private Label Label1;
        public UK()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string apiurl = String.Format("https://api.currencyapi.com/v3/latest?apikey=cur_live_ifEH63Icmu2lv7FeR7lSKGMiyRfjwEdZPO4baFYr&currencies=LKR&base_currency=GBP");
            WebRequest requestObj = WebRequest.Create(apiurl);
            requestObj.Method = "Get";
            HttpWebResponse responseObj = null;

            try
            {
                responseObj = (HttpWebResponse)requestObj.GetResponse();
                string stringresult = null;
                using (Stream stream = responseObj.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    stringresult = sr.ReadToEnd();
                    sr.Close();
                }

                JObject jsonObject = JObject.Parse(stringresult);
                JObject dataObject = (JObject)jsonObject["data"];
                JObject lkrObject = (JObject)dataObject["LKR"];
                string value = lkrObject["value"].ToString();

                this.Label2.Text = $"LKR: {value}";
            }

            catch 
            {
                this.Label2.Text = "error";
            }
            finally
            {
                responseObj?.Close();
            }
        }



        public void TimeApi()
        {
            string timeapi = String.Format("http://worldtimeapi.org/api/timezone/Europe/London");
            WebRequest requestObj2 = WebRequest.Create(timeapi);
            requestObj2.Method = "Get";
            HttpWebResponse responseObj2 = null;


            try
            {
                responseObj2 = (HttpWebResponse)requestObj2.GetResponse();
                string stringresult2 = null;
                using (Stream stream = responseObj2.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    stringresult2 = sr.ReadToEnd();
                    sr.Close();
                }

                JObject jsonObject2 = JObject.Parse(stringresult2);
                string value = jsonObject2["datetime"].ToString();
                label3.Text = $"Time:{value}";

                
            }
            catch
            {
                this.label3.Text = "error";
            }
            finally
            {
                responseObj2?.Close();
            }

        }


        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}

