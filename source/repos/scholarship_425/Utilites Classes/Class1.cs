using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholarship_425.Utilites_Classes
{
    class Utilities
    {
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
        public bool firstnameexist(string Fname)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where firstname = @firstname");
            cmd.Parameters.Add("@firstname", MySqlDbType.VarChar, 45).Value = Fname;

            // connect to database
            DBConnect fnameExistsConn = new DBConnect();

            // if records exist
            if (fnameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool lastnameexist(string Lname)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where lastname = @lastname");
            cmd.Parameters.Add("@lastname", MySqlDbType.VarChar, 45).Value = Lname;

            // connect to database
            DBConnect lnameExistsConn = new DBConnect();

            // if records exist
            if (lnameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool emailexist(string email)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where emailaddress = @emailaddress");
            cmd.Parameters.Add("@emailaddress", MySqlDbType.VarChar, 45).Value = email;

            // connect to database
            DBConnect emailExistsConn = new DBConnect();

            // if records exist
            if (emailExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool phonenumberexist(string phone)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where phonenumber = @phonenumber");
            cmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar, 45).Value = phone;

            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool genderexist(string gender)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where gender = @gender");
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar, 45).Value = gender;

            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool dboexist(DateTime dbo)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where dateofbirth = @dateofbirth");
            cmd.Parameters.Add("@dateofbirth", MySqlDbType.Date).Value = dbo.Date;

            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool statusexist(string status)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where status = @status");
            cmd.Parameters.Add("@status", MySqlDbType.VarChar, 45).Value = status;

            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool GPAexist(string GPA)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where gpa = @gpa");
            cmd.Parameters.Add("@gpa", MySqlDbType.VarChar, 45).Value = GPA;

            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
        public bool credithexist(string credith)
        {
            // declare and parameterize mySQL Command
            MySqlCommand cmd = new MySqlCommand("SELECT Count(*) from dbo.registrar_office_db where creditnumbers = @creditnumbers");
            cmd.Parameters.Add("@creditnumbers", MySqlDbType.VarChar, 45).Value = credith;

            // connect to database
            DBConnect usernameExistsConn = new DBConnect();

            // if records exist
            if (usernameExistsConn.intScalar(cmd) > 0)
                return true;
            else
                return false;
        }
    }
}
