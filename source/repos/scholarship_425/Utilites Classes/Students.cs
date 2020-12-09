
using MySql.Data.MySqlClient;
using scholarship_425;
using System;
using System.ComponentModel;
using System.Data.SqlTypes;

public class Student
{
    public int studentID { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phoneNum { get; set; }
    public string gender { get; set; }
    public DateTime? dbo { get; set; }
    public string status { get; set; }

    public double GPA { get; set; }
    public int credith { get; set; }

    public Student(int UserID)
    {
        // declare and parameterize mySQL Command

        MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbo.registrar_office_db WHERE studentID = @studentID");
        cmd.Parameters.Add("@UserID", MySqlDbType.Int32).Value = UserID;

        // connect to database
        DBConnect UserProfileConn = new DBConnect();

        //Create a data reader and Execute the command
        MySqlDataReader dataReader = UserProfileConn.ExecuteReader(cmd);

        //Read the data and store them in the list
        while (dataReader.Read())
        {
            studentID = Convert.ToInt32(dataReader["userID"]);
            firstName = dataReader["firstName"].ToString();
            lastName = dataReader["lastName"].ToString();
            email = dataReader["email"].ToString();
            gender = dataReader["gender"].ToString();
            status = dataReader["status"].ToString();
            GPA = Convert.ToDouble(dataReader["GPA"]);
            credith = Convert.ToInt32(dataReader["credith"]);
            if (dataReader["dbo"] == DBNull.Value) //cannot convert null to DateTime
            {
                dbo = null;
            }
            else
            {
                dbo = Convert.ToDateTime(dataReader["dbo"]);
            }
            phoneNum = Convert.ToString(dataReader["phoneNum"]);
        }

        //close Data Reader
        dataReader.Close();
    }

    // updates information on user record
    public bool updateUser(Student userinfo)
    {
        DBConnect updateUserConn = new DBConnect();
        MySqlCommand updateUserCmd = new MySqlCommand(@"UPDATE `dbo`.`registrar_office_db`(`studentID`, `firstname`, `lastname`, `phonenumber`, `emailaddress`, `gender`, `dateofbirth`, `gpa`, `status`, `creditnumbers`)
                                                        VALUES(@studentID, @firstname, @lastname, @phonenumber, @emailaddress, @gender, @dateofbirth, @gpa, @status, @creditnumbers WHERE studentID = @studentID;");
        updateUserCmd.Parameters.Add("@firstName", MySqlDbType.VarChar, 45).Value = userinfo.firstName;
        updateUserCmd.Parameters.Add("@lastName", MySqlDbType.VarChar, 45).Value = userinfo.lastName;
        updateUserCmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = userinfo.studentID;
        updateUserCmd.Parameters.Add("@email", MySqlDbType.VarChar, 45).Value = userinfo.email;
        updateUserCmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar, 45).Value = userinfo.phoneNum;
        updateUserCmd.Parameters.Add("@gpa", MySqlDbType.Double).Value = userinfo.GPA;
        updateUserCmd.Parameters.Add("@creditnumbers", MySqlDbType.Double).Value = userinfo.credith;
        updateUserCmd.Parameters.Add("@dateofbirth", MySqlDbType.DateTime).Value = userinfo.dbo;
        updateUserCmd.Parameters.Add("@gender", MySqlDbType.VarChar, 45).Value = userinfo.gender;
        updateUserCmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = userinfo.status;

        if (updateUserConn.NonQuery(updateUserCmd) > 0)
            return true;
        return false;
    }

}


