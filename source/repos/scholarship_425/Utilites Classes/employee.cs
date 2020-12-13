using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholarship_425.Utilites_Classes
{
    class employee
    {
        public string employeeID { get; set; }
        public string password { get; set; }
        public int vote { get; set; }
        

        public employee(int UserID)
        {
            // declare and parameterize mySQL Command

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM dbo.employee WHERE employeeID = @employeeID");
            cmd.Parameters.Add("@employeeID", MySqlDbType.Int32).Value = UserID;

            // connect to database
            DBConnect UserProfileConn = new DBConnect();

            //Create a data reader and Execute the command
            MySqlDataReader dataReader = UserProfileConn.ExecuteReader(cmd);

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                employeeID = dataReader["employeeID"].ToString();
                password = dataReader["password"].ToString();
                vote = Convert.ToInt32(dataReader["vote"]);
            }

            //close Data Reader
            dataReader.Close();
        }


    }
}
