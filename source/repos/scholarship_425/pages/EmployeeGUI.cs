using MySql.Data.MySqlClient;
using Newtonsoft.Json;
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
    public partial class EmployeeGUI : Form
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
        public int count { get; set; }
        public string topic { get; set; }
        public string body { get; set; }
        public string body2 { get; set; }
        public EmployeeGUI()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnpro_Click(object sender, EventArgs e)
        {
            Utilities winner = new Utilities();
            if (!(winner.Getgpacount(this.employeeID) == 1))
            {
                if (!(winner.Getsemgpacount(this.employeeID) == 1))
                {
                    if (!(winner.Getstatuscount(this.employeeID) == 1))
                    {
                        if (!(winner.Getgendercount(this.employeeID) == 1))
                        {
                            DBConnect payrollReportConn = new DBConnect();
                            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT studentID, firstname, lastname, emailaddress FROM dbo.registrar_office_db
                                                               where status='Junior' AND  semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))order by dateofbirth desc 
                                                                limit 0,1");

                            // connect to database
                            DBConnect UserProfileConn = new DBConnect();

                            //Create a data reader and Execute the command
                            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

                            //Read the data and store them in the list
                            while (dataReader.Read())
                            {
                                email = dataReader["emailaddress"].ToString();
                                studentID = Convert.ToInt32(dataReader["studentID"]);
                                name = dataReader["firstname"].ToString() + " " + dataReader["lastname"].ToString();

                            }

                            //close Data Reader

                            dataReader.Close();
                            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO dbo.vote_participants (name, studentID, email) VALUES  (@name, @studentID, @email);");
                            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 45).Value = name;
                            cmd.Parameters.Add("@email", MySqlDbType.VarChar, 45).Value = email;
                            cmd.Parameters.Add("@studentID", MySqlDbType.Int32).Value =studentID;
                            
                            // connect to database
                            DBConnect userCreationConn = new DBConnect();

                            // execute statement
                            if (userCreationConn.NonQuery(cmd) > 0)
                            {
                               
                            }
                            else
                            {
                                lblerror.Text = "Error creating account";
                            }
                            winner studentwin = new winner
                            {
                                note = " Get elected for interviewe",
                                namew = name,
                                studentIDw = studentID,
                                emailw = email
                            };
                            DBConnect secondConn = new DBConnect();
                            MySqlCommand secondCmd = new MySqlCommand(@"
                                                                                    SELECT studentID, firstname, lastname, emailaddress FROM dbo.registrar_office_db
                                                               where status='Junior' AND  semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))order by dateofbirth desc 
                                                                limit 1,1");

                            // connect to database
                            DBConnect secondConn2 = new DBConnect();

                            //Create a data reader and Execute the command
                            MySqlDataReader dataReader2 = secondConn.ExecuteReader(secondCmd);

                            //Read the data and store them in the list
                            while (dataReader2.Read())
                            {
                                note2 = " Get elected for interviewe";
                                email2 = dataReader2["emailaddress"].ToString();
                                studentID2 = Convert.ToInt32(dataReader2["studentID"]);
                                name2 = dataReader2["firstname"].ToString() + " " + dataReader2["lastname"].ToString();

                            }

                            dataReader.Close();
                            MySqlCommand cmd2 = new MySqlCommand(@"INSERT INTO dbo.vote_participants (name, studentID, email) VALUES (@name, @studentID, @email);");
                            cmd2.Parameters.Add("@name", MySqlDbType.VarChar, 45).Value =name2;
                            cmd2.Parameters.Add("@email", MySqlDbType.VarChar, 45).Value = email2;
                            cmd2.Parameters.Add("@studentID", MySqlDbType.Int32).Value = studentID2;
                            
                            DBConnect userCreationConn2 = new DBConnect();

                            // execute statement
                            if (userCreationConn2.NonQuery(cmd2) > 0)
                            {

                            }
                            else
                            {
                                lblerror.Text = "Error creating account";
                            }

                            studentwin.note2 = " Get elected for interviewe";
                                studentwin.namew2 = name2;
                                studentwin.studentIDw2 = studentID2;
                                studentwin.emailw2 = email2;
                            
                            string JsonOutput = JsonConvert.SerializeObject(studentwin);
                            Utilities create = new Utilities();
                            create.writeFile2(JsonOutput);
                            create.writexmlFile2();
                            DataSet xmlfile = new DataSet();
                            xmlfile.ReadXml("C://Users//husse//Downloads//xmlfile2.xml");
                            topic = "Scholarship Interviewe";
                            body = name+ " you was selected for scholarship interviewe in January 02, 2021" +"\n"+
                                "Thank You";
                            body2 = name2 + " you was selected for scholarship interviewe in January 02, 2021" + "\n" +
                                "Thank You";
                            datagrilview.DataSource = xmlfile.Tables[0];
                            create.sendemail(email, name, topic, body);
                            create.sendemail(email2, name2, topic, body2);
                        }
                        else
                        {
                            DBConnect payrollReportConn = new DBConnect();
                            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT studentID, firstname, lastname, emailaddress FROM dbo.registrar_office_db
                                                               where status='Junior' AND gender='Female' AND semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))");

                            // connect to database
                            DBConnect UserProfileConn = new DBConnect();

                            //Create a data reader and Execute the command
                            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

                            //Read the data and store them in the list
                            while (dataReader.Read())
                            {
                                email = dataReader["emailaddress"].ToString();
                                studentID = Convert.ToInt32(dataReader["studentID"]);
                                name = dataReader["firstname"].ToString() + " " + dataReader["lastname"].ToString();

                            }

                            //close Data Reader

                            dataReader.Close();
                            winner studentwin = new winner
                            {
                                note = "The winner is: \n",
                                namew = name,
                                studentIDw = studentID,
                                emailw = email
                            };
                            string JsonOutput = JsonConvert.SerializeObject(studentwin);
                            Utilities create = new Utilities();
                            create.writeFile(JsonOutput);
                            create.writexmlFile();
                            DataSet xmlfile = new DataSet();
                            xmlfile.ReadXml("C://Users//husse//Downloads//xmlfile2.xml");
                            topic = "Scholarship Result";
                            body = name + " You are the winner for 2020-2021 scholarship" + "\n" +
                                "Thank You";
                            datagrilview.DataSource = xmlfile.Tables[0];
                            create.sendemail(email, name, topic, body);
                        }
                    }
                    else
                    {
                        DBConnect payrollReportConn = new DBConnect();
                        MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT studentID, firstname, lastname, emailaddress FROM dbo.registrar_office_db
                                                               where status='Junior' AND semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))");

                        // connect to database
                        DBConnect UserProfileConn = new DBConnect();

                        //Create a data reader and Execute the command
                        MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

                        //Read the data and store them in the list
                        while (dataReader.Read())
                        {
                            email = dataReader["emailaddress"].ToString();
                            studentID = Convert.ToInt32(dataReader["studentID"]);
                            name = dataReader["firstname"].ToString() + " " + dataReader["lastname"].ToString();

                        }

                        //close Data Reader

                        dataReader.Close();
                        winner studentwin = new winner
                        {
                            note = "The winner is: \n",
                            namew = name,
                            studentIDw = studentID,
                            emailw = email
                        };
                        string JsonOutput = JsonConvert.SerializeObject(studentwin);
                        Utilities create = new Utilities();
                        create.writeFile(JsonOutput);
                        create.writexmlFile();
                        DataSet xmlfile = new DataSet();
                        xmlfile.ReadXml("C://Users//husse//Downloads//xmlfile2.xml");
                        topic = "Scholarship Result";
                        body = name + " You are the winner for 2020-2021 scholarship" + "\n" +
                            "Thank You";
                        datagrilview.DataSource = xmlfile.Tables[0];
                        create.sendemail(email, name, topic, body);
                    }

                }
                else
                {
                    DBConnect payrollReportConn = new DBConnect();
                    MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT studentID, firstname, lastname, emailaddress FROM dbo.registrar_office_db
                                                                               where  semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))");

                    // connect to database
                    DBConnect UserProfileConn = new DBConnect();

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        email = dataReader["emailaddress"].ToString();
                        studentID = Convert.ToInt32(dataReader["studentID"]);
                        name = dataReader["firstname"].ToString() + " " + dataReader["lastname"].ToString();

                    }

                    //close Data Reader

                    dataReader.Close();
                    winner studentwin = new winner
                    {
                        note = "The winner is: \n",
                        namew = name,
                        studentIDw = studentID,
                        emailw = email
                    };
                    string JsonOutput = JsonConvert.SerializeObject(studentwin);
                    Utilities create = new Utilities();
                    create.writeFile(JsonOutput);
                    create.writexmlFile();
                    DataSet xmlfile = new DataSet();
                    xmlfile.ReadXml("C://Users//husse//Downloads//xmlfile2.xml");
                    topic = "Scholarship Result";
                    body = name + " You are the winner for 2020-2021 scholarship" + "\n" +
                        "Thank You";
                    datagrilview.DataSource = xmlfile.Tables[0];
                    create.sendemail(email, name, topic, body);
                }
            }
            else
            {

                DBConnect payrollReportConn = new DBConnect();
                MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT studentID, firstname, lastname, emailaddress FROM dbo.registrar_office_db
                                                               where gpa= (select max(gpa) from registrar_office_db where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible'))");

                // connect to database
                DBConnect UserProfileConn = new DBConnect();

                //Create a data reader and Execute the command
                MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    email = dataReader["emailaddress"].ToString();
                    studentID = Convert.ToInt32(dataReader["studentID"]);
                    name = dataReader["firstname"].ToString() + " " + dataReader["lastname"].ToString();
                }

                //close Data Reader

                dataReader.Close();
                winner studentwin = new winner
                {
                    note = "The winner is: \n",
                    namew = name,
                    studentIDw = studentID,
                    emailw = email
                };
                string JsonOutput = JsonConvert.SerializeObject(studentwin);
                Utilities create = new Utilities();
                create.writeFile(JsonOutput);
                create.writexmlFile();
                DataSet xmlfile = new DataSet();
                xmlfile.ReadXml("C://Users//husse//Downloads//xmlfile2.xml");
                topic = "Scholarship Result";
                body = name + " You are the winner for 2020-2021 scholarship" + "\n" +
                    "Thank You";
                datagrilview.DataSource = xmlfile.Tables[0];
                create.sendemail(email, name, topic, body);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            Utilities votevalid = new Utilities();
            if (votevalid.employeevoted(this.employeeID))
            {
                if (!(name == null))
                {
                    string a = name.ToString();
                    var menuScreen = new votepage();
                    menuScreen.FormClosed += new FormClosedEventHandler(menuScreen_FormClosed);
                    menuScreen.employeeID = employeeID;
                    this.Hide();
                    menuScreen.Show();
                }
                else
                {
                    label1.Text = "The voting is not available";
                }

            }
            else
            {
                label1.Text = "You already voted";
            }
        }

        private void menuScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
