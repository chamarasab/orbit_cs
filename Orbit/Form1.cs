﻿using Guna.UI2.WinForms;
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

namespace Orbit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
                try
                {
                    String name = guna2TextBox1.Text;
                    int contact = Int32.Parse(guna2TextBox2.Text);
                    MessageDialog.Show(name + " " + contact + "\n\nData Inserting...");
                    insertData(name, contact);
                }
                catch (Exception ex)
                {
                    //throw;
                    MessageDialog.Show(ex.Message);
                }   
        }

        private void insertData(string name, int contact)
        {
            String postdata = "name=" + name + "&phone=" + contact;
            Byte[] data = Encoding.UTF8.GetBytes(postdata);
            String url = "https://orbitcompany.000webhostapp.com/insert.php";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();

            StreamReader sr = new StreamReader(stream);
            String responsefromServer = sr.ReadToEnd();
            
            sr.Close();
            response.Close();
            stream.Close();

            MessageDialog.Show(responsefromServer);
            clearTextBoxes();
        }

        private void clearTextBoxes()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
        }
    }
}
