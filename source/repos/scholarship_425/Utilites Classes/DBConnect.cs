using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace scholarship_425
{
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public static string connectionString;

        public DBConnect()
        {
            Initialize();
        }

        // DESCRIPTION: Initializes connection values
        private void Initialize()
        {
            server = "localhost";
            database = "dbo";
            uid = "root";
            password = "hotelmgmt";
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Allow User Variables=True;";

        }

        //DESCRIPTION: Opens connection to database
        public bool OpenConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Connection Error ! " + er.Message, "Information");
            }
            return false;
        }

        //DESCRIPTION: Closes connection to database
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                connection.Dispose();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataSet ExecuteDataSet(MySqlCommand cmd)
        {
            try
            {
                this.OpenConnection();
                DataSet ds = new DataSet();
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public DataTable ExecuteDataTable(MySqlCommand cmd)
        {
            try
            {
                this.OpenConnection();
                DataTable dt = new DataTable();
                cmd.Connection = connection;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        // DESCRIPTION: Executes SELECT statements
        public MySqlDataReader ExecuteReader(MySqlCommand cmd)
        {
            this.OpenConnection();
            if (this.OpenConnection() == true)
            {
                try
                {
                    MySqlDataReader reader;
                    cmd.Connection = connection;
                    reader = cmd.ExecuteReader();
                    return reader;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return null;
            }
            return null;
        }

        //DESCRIPTION: Executes Non-Queries (INSERT, DELETE, UPDATE)
        public int NonQuery(MySqlCommand cmd)
        {
            try
            {
                int affected;
                connection = new MySqlConnection(connectionString);
                this.OpenConnection();
                cmd.Connection = connection;
                MySqlTransaction mytransaction = connection.BeginTransaction();
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                this.CloseConnection();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }

        // DESCRIPTION: Executes scalar query of type integer
        public int intScalar(MySqlCommand cmd)
        {
            int returnInt = -1;

            try
            {
                this.OpenConnection();
                cmd.Connection = connection;

                //ExecuteScalar will return one value
                returnInt = Convert.ToInt32(cmd.ExecuteScalar());
                this.CloseConnection();
                return returnInt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return returnInt;
        }


        public double doubleScalar(MySqlCommand cmd)
        {
            this.OpenConnection();
            double returnDouble = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                cmd.Connection = connection;

                //ExecuteScalar will return one value
                returnDouble = double.Parse(cmd.ExecuteScalar() + "");
                this.CloseConnection();
                return returnDouble;
            }
            else
            {
                return returnDouble;
            }
        }
        // DESCRIPTION: Executes scalar query of type string
        public string stringScalar(MySqlCommand cmd)
        {
            string returnString = null;
            this.OpenConnection();
            if (this.OpenConnection() == true)
            {
                cmd.Connection = connection;

                returnString = cmd.ExecuteScalar().ToString();
                this.CloseConnection();
                return returnString;
            }
            else
            {
                return returnString;
            }
        }
        // DESCRIPTION: Executes scalar query of type DateTime
        public DateTime dateTimeScalar(MySqlCommand cmd)
        {
            DateTime returnDateTime;
            this.OpenConnection();
            cmd.Connection = connection;
            returnDateTime = DateTime.Parse(cmd.ExecuteScalar().ToString());
            this.CloseConnection();
            return returnDateTime;
        }
    }
}
