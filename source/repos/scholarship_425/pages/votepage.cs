using MySql.Data.MySqlClient;
using scholarship_425.Utilites_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scholarship_425.pages
{
    public partial class votepage : Form
    {
        public int studentID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string note { get; set; }
        public string note2 { get; set; }
        public int studentID2 { get; set; }
        public string name2 { get; set; }
        public string email2 { get; set; }
        public int employeeID;
        private string strDebugText;

        public int count { get; set; }
        public string topic { get; set; }
        public string body { get; set; }
        public votepage()
        {
            InitializeComponent();
            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT name, studentID, email from dbo.vote_participants limit 0,1;");

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                email = dataReader["email"].ToString();
                studentID = Convert.ToInt32(dataReader["studentID"]);
                name = dataReader["name"].ToString();
            }
            
                string a = name.ToString();
                label3.Text = a;
                //close Data Reader
            
            dataReader.Close();
            DBConnect payrollReportConn2 = new DBConnect();
            MySqlCommand payrollReportCmd2 = new MySqlCommand(@"SELECT name, studentID, email from dbo.vote_participants limit 1,1;");

            // connect to database
            DBConnect UserProfileConn2 = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader2 = UserProfileConn2.ExecuteReader(payrollReportCmd2);

            //Read the data and store them in the list
            while (dataReader2.Read())
            {
                email2 = dataReader2["email"].ToString();
                studentID2 = Convert.ToInt32(dataReader2["studentID"]);
                name2 = dataReader2["name"].ToString();
            }
            label4.Text = name2;
            //close Data Reader

            dataReader.Close();
            
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utilities getvote = new Utilities();
            int count,c1,c2;
            if ((count = getvote.Getvotecount()) < 3)
            {
                count = count + 1;
                if (checkBox1.Checked == true)
                {
                    Utilities update = new Utilities();
                    update.updatevote(studentID.ToString());
                    update.updateempvote(employeeID);
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    button1.Visible = false;
                    label1.Text = "THANKS FOR YOUR VOTE";
                }
                else if (checkBox2.Checked == true)
                {
                    Utilities update = new Utilities();
                    update.updatevote(studentID2.ToString());
                    update.updateempvote(employeeID);
                    checkBox1.Visible = false;
                    checkBox2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    button1.Visible = false;
                    label1.Text = "THANKS FOR YOUR VOTE";
                }
                else
                {
                    label5.Text = "Please Select a student to vote for";
                }
                if (count == 3)
                {
                    if ((c1=getvote.Getvotecountforstudents(studentID))>(c2 = getvote.Getvotecountforstudents(studentID2)))
                    {
                        getvote.addwinner(studentID, name);
                        groupBox1.Visible = true;
                    }
                    else
                    {
                        getvote.addwinner(studentID2, name2);
                        groupBox1.Visible = true;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();
            rClient.endPoint = textBox1.Text;
            debugOutput("REst Client");
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();
            debugOutput(strResponse);
            textBox2.Text = strResponse;
        }

        private void debugOutput(string v)
        {
            try {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                textBox2.Text = textBox2.Text + strDebugText + Environment.NewLine;
                textBox2.SelectionStart = textBox2.TextLength;
                textBox2.ScrollToCaret();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
