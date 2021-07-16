using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace OneDrive_Enum
{

    public partial class Form1 : Form
    {
        public string domainname;
        public string extension;
        public string userslist;
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               var username = txtusername.Text.ToString();
                string URL = @"https://'" + txtdomain.Text + "'-my.sharepoint.com/personal/'" + txtusername.Text + "'_'" + txtext.Text + "'/_layouts/15/onedrive.aspx";
                URL = URL.Replace("'", "");
                var request = WebRequest.Create(URL);
                request.Method = "GET";
                using var webResponse = request.GetResponse();
                using var webStream = webResponse.GetResponseStream();
                using var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                    textBox1.Text = "USER " + txtusername.Text + " IS NOT VALID";
                }
                else
                {
                    textBox1.Text = "USER " + txtusername.Text + " IS VALID";
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    try
                    {
                        var username = row.Cells[0].Value.ToString();
                        string URL = @"https://'" + txtdomain.Text + "'-my.sharepoint.com/personal/'" + username + "'_'" + txtext.Text + "'/_layouts/15/onedrive.aspx";
                        URL = URL.Replace("'", "");
                        var request = WebRequest.Create(URL);
                        request.Method = "GET";
                        using var webResponse = request.GetResponse();
                        using var webStream = webResponse.GetResponseStream();
                        using var reader = new StreamReader(webStream);
                        var data = reader.ReadToEnd();
                    }
                    catch (Exception ex)
                    {

                        if (ex.Message.Contains("403"))
                        {
                        textBox1.Text = textBox1.Text + " User: " + row.Cells[0].Value.ToString() + " IS VALID" + System.Environment.NewLine ;
                        }
                   else
                    {
                        textBox1.Text = textBox1.Text + " User: " + row.Cells[0].Value.ToString() + " IS NOT VALID" + System.Environment.NewLine;

                    }
                }
                   
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt;";
            ofd.ShowDialog();
            ofd.OpenFile();
            userslist = ofd.FileName.ToString();
            Load_Emp_IDS(userslist);
        }


        private void Load_Emp_IDS(String filename)
        {
            // Declare a string variabel
            String sLine = "";

            //Clear All selections in DGV
            dataGridView1.ClearSelection();

            try
            {
                dataGridView1.Rows.Clear();
                // Stream Reader to read branches data from the text file      
                System.IO.StreamReader FileStream = new System.IO.StreamReader(filename);

                // Pervent users from creating a new row in the DGV
                dataGridView1.AllowUserToAddRows = false;

                // Set Sline string var reads lines in the branches text
                sLine = FileStream.ReadLine();

                // split lines by ;
                string[] s = sLine.Split(';');

                // Read text file content and add it to DGV
                sLine = FileStream.ReadLine();

                // while still reading and there's lines 
                while (sLine != null)
                {
                    // add lines as rows in DGV
                    dataGridView1.Rows.Add();


                    for (int i = 0; i <= s.Count() - 1; i++)
                    {
                        s = sLine.Split(';');
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = s[0].ToString();
                    }
                    sLine = FileStream.ReadLine();
                }

                // Close the file Steam ( Stop Reading )
                FileStream.Close();

            }
            catch (Exception err)
            {
                // show message if there's an error
                System.Windows.Forms.MessageBox.Show(err.Message);
            }
        }

        private string ReplaceQuotes(string sentence)

        {

            return sentence.Replace("\"", "").Replace("'", "");

        }


    }
}
        

       
