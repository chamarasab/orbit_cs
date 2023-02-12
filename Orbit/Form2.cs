using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orbit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            retrieveData();
        }

        private void retrieveData()
        {
            guna2DataGridView1.Rows.Clear();
            WebClient webClient = new WebClient();
            String url = "https://orbitcompany.000webhostapp.com/retrieve_json.php";
            String jsonstring = webClient.DownloadString(url);
            JObject jsonobject = JObject.Parse(jsonstring);
            JArray jsonarray = JArray.Parse(jsonobject.SelectToken("users").ToString());
            foreach (var item in jsonarray)
            {
                guna2DataGridView1.Rows.Add(
                    item.SelectToken("id"), 
                    item.SelectToken("name"), 
                    item.SelectToken("phone")
                    );
            }
        }
    }
}
