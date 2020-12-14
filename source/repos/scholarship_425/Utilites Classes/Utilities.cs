using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace scholarship_425.Utilites_Classes
{
    class Utilities
    {
        public int count;
        public int countvote;
        public int countvotestudent;
        public bool studentIDexist(string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where studentID = @studentID");
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;

            // connect to database
            DBConnect studentIDExistsConn = new DBConnect();

            // if records exist
            if (studentIDExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool employeeIDexist(string employeeID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.employee where employeeID = @employeeID");
            cmd.Parameters.Add("@employeeID", MySqlDbType.VarChar, 45).Value = employeeID;

            // connect to database
            DBConnect studentIDExistsConn = new DBConnect();

            // if records exist
            if (studentIDExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool employeevoted(int employeeID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT count(*) from dbo.employee where employeeID = @employeeID and vote = 0");
            cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = employeeID;

            // connect to database
            DBConnect studentIDExistsConn = new DBConnect();

            // if records exist
            if (studentIDExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool firstnameexist(string Fname, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where firstname = @firstname AND studentID = @studentID");
            cmd.Parameters.Add("@firstname", MySqlDbType.VarChar, 45).Value = Fname;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect fnameExistsConn = new DBConnect();

            // if records exist
            if (fnameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool lastnameexist(string Lname, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where lastname = @lastname AND studentID = @studentID");
            cmd.Parameters.Add("@lastname", MySqlDbType.VarChar, 45).Value = Lname;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect lnameExistsConn = new DBConnect();

            // if records exist
            if (lnameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool emailexist(string email, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where emailaddress = @emailaddress AND studentID = @studentID");
            cmd.Parameters.Add("@emailaddress", MySqlDbType.VarChar, 45).Value = email;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect emailExistsConn = new DBConnect();

            // if records exist
            if (emailExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool phonenumberexist(string phone, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where phonenumber = @phonenumber AND studentID = @studentID");
            cmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar, 45).Value = phone;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool genderexist(string gender, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where gender = @gender AND studentID = @studentID");
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar, 45).Value = gender;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool dboexist(DateTime dbo, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where dateofbirth = @dateofbirth AND studentID = @studentID");
            cmd.Parameters.Add("@dateofbirth", MySqlDbType.Date).Value = dbo.Date;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool statusexist(string status, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where status = @status AND studentID = @studentID");
            cmd.Parameters.Add("@status", MySqlDbType.VarChar, 45).Value = status;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool GPAexist(string GPA, string studentID)
        {
            double gpa = Convert.ToDouble(GPA);
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where gpa = @gpa AND studentID = @studentID");
            cmd.Parameters.Add("@gpa", MySqlDbType.Double).Value = GPA;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool credithexist(string credith, string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where creditnumbers = @creditnumbers AND studentID = @studentID");
            cmd.Parameters.Add("@creditnumbers", MySqlDbType.VarChar, 45).Value = credith;
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;
            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool studentIDexistApp(string studentID)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.applicant_data_store where studentID = @studentID");
            cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = studentID;

            // connect to database
            DBConnect studentIDExistsConn = new DBConnect();

            // if records exist
            if (studentIDExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public int getUserIDFromUsername(int username)
        {
            int userID = -1;
            DBConnect getUserIDFromUsernameConn = new DBConnect();

            // build query
            MySqlCommand cmd = new MySqlCommand("SELECT employeeID from dbo.employee where employeeID = @employeeID");
            cmd.Parameters.Add("@employeeID", MySqlDbType.VarChar, 45).Value = username;

            // assign value to variable
            userID = getUserIDFromUsernameConn.intScalar(cmd);
            return userID;
        }
        public int Getgpacount(int username)
        {
            
            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT count(firstname) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')) ");

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["count(firstname)"]);

            }

            //close Data Reader

            dataReader.Close();
            return count;
        }

        public int Getsemgpacount(int username)
        {

            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT count(*) from registrar_office_db where  semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))");

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["count(*)"]);

            }

            //close Data Reader

            dataReader.Close();
            return count;
        }
        public int Getstatuscount(int username)
        {

            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT count(*) from registrar_office_db where status='Junior' AND semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))");

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["count(*)"]);

            }

            //close Data Reader

            dataReader.Close();
            return count;
        }
        public int Getgendercount(int username)
        {

            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT count(*) FROM dbo.registrar_office_db
                                                               where status='Junior' AND gender='Female' AND semgpa = (SELECT MAX(semgpa) from registrar_office_db where gpa= (select max(gpa) from registrar_office_db  where studentID IN(SELECT studentID from applicant_data_store where stat ='elegible')))");

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                count = Convert.ToInt32(dataReader["count(*)"]);

            }

            //close Data Reader

            dataReader.Close();
            return count;
        }

        public bool passwordMatches(int username, string password)
        {

            int userID = getUserIDFromUsername(username);
            if (userID != -1)
            {
                employee userInfo = new employee(userID);
                if (userInfo.password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void writeFile(string student)
        {
            StreamWriter file = new StreamWriter("C://Users//husse//Downloads//resultfile.json");
            file.Write(student);
            file.Close();

        }
        public void writeFile2(string student)
        {
            StreamWriter file = new StreamWriter("C://Users//husse//Downloads//resultfile2.json");
            file.Write(student);
            file.Close();

        }
        public void writexmlFile()
        {
            dynamic jsonfile = JsonConvert.DeserializeObject(File.ReadAllText("C://Users//husse//Downloads//resultfile.json"));
            XDocument xDoc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Student",
                    new XAttribute("Note", jsonfile["note"]),
                    new XAttribute("StudentID", jsonfile["studentIDw"]),
                    new XAttribute("name", jsonfile["namew"]),
                    new XAttribute("email", jsonfile["emailw"])));
            xDoc.Save("C://Users//husse//Downloads//xmlfile.xml");
            
        }
        public void writexmlFile2()
        {
            dynamic jsonfile2 = JsonConvert.DeserializeObject(File.ReadAllText("C://Users//husse//Downloads//resultfile2.json"));
            XDocument xDoc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement("RootNAME",
                new XElement("Student",
                    new XAttribute("Note", jsonfile2["note"]),
                    new XAttribute("StudentID", jsonfile2["studentIDw"]),
                    new XAttribute("name", jsonfile2["namew"]),
                    new XAttribute("email", jsonfile2["emailw"])),
                new XElement("Student",
                    new XAttribute("Note", jsonfile2["note2"]),
                    new XAttribute("StudentID", jsonfile2["studentIDw2"]),
                    new XAttribute("name", jsonfile2["namew2"]),
                    new XAttribute("email", jsonfile2["emailw2"]))));
            xDoc.Save("C://Users//husse//Downloads//xmlfile2.xml");

        }
        public void sendemail(string sentTO, string name, string topic, string body)
        {

            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "hnoureddine@ptiqcs.com",
                    Password = "password"
                }
            };
            MailAddress Fromemail = new MailAddress("hnoureddine@ptiqcs.com", "Scholarship admin");
            MailAddress ToEmail = new MailAddress("husseinnour24@gmail.com", name);
            MailMessage Message = new MailMessage()
            {
                From = Fromemail,
                Subject = topic,
                Body = body,
            };
            Message.To.Add(ToEmail);
            try {
                Client.Send(Message);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public bool updatevote(string studentID)
        {
            DBConnect updateUserConn = new DBConnect();
            MySqlCommand updateUserCmd = new MySqlCommand(@"UPDATE vote_participants SET vote = vote + 1 WHERE studentID=@studentID");

            updateUserCmd.Parameters.Add("@studentID", MySqlDbType.Int32).Value = studentID;

            if (updateUserConn.NonQuery(updateUserCmd) > 0)
            {
                MessageBox.Show("good");
                return true;
            }
            else
            {
                MessageBox.Show("error");
                return false;
            }
        }
        public bool updateempvote(int employeeID)
        {
            DBConnect updateUserConn = new DBConnect();
            MySqlCommand updateUserCmd = new MySqlCommand(@"UPDATE employee SET vote = vote + 1 WHERE employeeID=@employeeID");

            updateUserCmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = employeeID;

            if (updateUserConn.NonQuery(updateUserCmd) > 0)
            {
                
                return true;
            }
            else
            {
                MessageBox.Show("error");
                return false;
            }
        }
        public int Getvotecount()
        {

            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT count(vote) FROM employee
                                                               where vote = 1");

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                countvote = Convert.ToInt32(dataReader["count(vote)"]);

            }

            //close Data Reader

            dataReader.Close();
            return countvote;
        }
        public int Getvotecountforstudents(int studentID)
        {

            DBConnect payrollReportConn = new DBConnect();
            MySqlCommand payrollReportCmd = new MySqlCommand(@"SELECT vote FROM vote_participants
                                                               where studentID=@studentID");
            payrollReportCmd.Parameters.Add("@studentID", MySqlDbType.Int32).Value = studentID;
            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(payrollReportCmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                countvotestudent = Convert.ToInt32(dataReader["vote"]);

            }

            //close Data Reader

            dataReader.Close();
            return countvotestudent;
        }
        //INSERT INTO `dbo`.`awarded_data_store` (`studentID`, `Name`) VALUES('1', 'd');
        public void addwinner(int studentID, string name)
        {
            MySqlCommand cmd = new MySqlCommand(@"INSERT INTO `dbo`.`awarded_data_store` (`studentID`, `Name`) VALUES (@studentID, @Name);");
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar, 45).Value = name;
            cmd.Parameters.Add("@studentID", MySqlDbType.Int32).Value = studentID;

           
            // connect to database
            DBConnect userCreationConn = new DBConnect();

            // execute statement
            if (userCreationConn.NonQuery(cmd) > 0)
            {
               
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
