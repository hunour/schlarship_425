
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
    public partial class Fillapplication : Form
    {
        private Utilities verifyinfo = new Utilities();
        public Fillapplication()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {


            // check that fields are entered and valid

            // if first name not entered
            if (string.IsNullOrWhiteSpace(textFirstName.Text))
            {
                lblFN.Text = "First Name is required";
            }
            // if last name not entered
            else if (string.IsNullOrWhiteSpace(textLastName.Text))
            {
                lblLN.Text = "Last Name is required";
            }
            //if Student ID is not entered
            else if (string.IsNullOrWhiteSpace(textStudentID.Text))
            {
                lblSID.Text = "Student ID is required";
            }
            //if Phone Number is not entered
            else if (!(textPhoneNumber.MaskCompleted))
            {
                lblPN.Text = "Phone Number is required";
            }
            // if email not entered
            else if (string.IsNullOrWhiteSpace(textEmail.Text))
            {
                lblEA.Text = "Email address is required";
            }
            // if email format is invalid
            else if (!(isValidEmail(textEmail.Text)))
            {
                lblEA.Text = "Invalid email format";
            }
            // if gender was  not selected
            else if (string.IsNullOrWhiteSpace(textGender.SelectedItem.ToString()))
            {
                lblG.Text= "Select Gender is required";
            }
            // if status is not selected
            else if (string.IsNullOrWhiteSpace(textStatus.SelectedItem.ToString()))
            {
                lblS.Text="Select Status is required";
            }
            // if GPA is not entered
            else if (string.IsNullOrWhiteSpace(textGPA.Text))
            {
                lblGPA.Text="Password cannot exceed 45 characters";
            }
            

            else
            {
                ////Fields are entered and valid. Proceed with mySQL


                //    // Everything is good. Create user account

                //    MySqlCommand cmd = new MySqlCommand(@"INSERT INTO `dbo`.`registrar_office_db`(`studentID`, `firstname`, `lastname`, `phonenumber`, `emailaddress`, `gender`, `dateofbirth`, `gpa`, `status`, `creditnumbers`)
                //                                        VALUES(@studentID, @firstname, @lastname, @phonenumber, @emailaddress, @gender, @dateofbirth, @gpa, @status, @creditnumbers)");

                //    // assign parameter values
                //    cmd.Parameters.Add("@firstName", MySqlDbType.VarChar, 45).Value = textFirstName.Text;
                //    cmd.Parameters.Add("@lastName", MySqlDbType.VarChar, 45).Value = textLastName.Text;
                //    cmd.Parameters.Add("@studentID", MySqlDbType.VarChar, 45).Value = textStudentID.Text;
                //    cmd.Parameters.Add("@email", MySqlDbType.VarChar, 45).Value = textEmail.Text;
                //    cmd.Parameters.Add("@phonenumber", MySqlDbType.VarChar, 45).Value = textPhoneNumber.Text;
                //    cmd.Parameters.Add("@gpa", MySqlDbType.Double).Value = textGPA.Text;
                //    cmd.Parameters.Add("@creditnumbers", MySqlDbType.Double).Value = textCreditHour.Text;
                //    cmd.Parameters.Add("@dateofbirth", MySqlDbType.DateTime).Value = dateBirth.Value;
                //    cmd.Parameters.Add("@gender", MySqlDbType.VarChar, 45).Value = textGender.SelectedValue;
                //    cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = textStatus.SelectedValue;


                //// connect to database
                //    DBConnect userCreationConn = new DBConnect();

                //    // execute statement
                //    if (userCreationConn.NonQuery(cmd) > 0)
                //    {

                //    }
                //    else
                //    {
                //        lblerror.Text="Error creating account";
                //    }


                if (verifyinfo.studentIDexist(textStudentID.Text))
                {
                    if (verifyinfo.firstnameexist(textFirstName.Text))
                    {
                        if (verifyinfo.lastnameexist(textLastName.Text))
                        {
                            if (verifyinfo.emailexist(textEmail.Text))
                            {
                                if (verifyinfo.phonenumberexist(textPhoneNumber.Text))
                                {
                                    if (verifyinfo.genderexist(textGender.Text))
                                    {
                                        if (verifyinfo.dboexist(dateBirth.Value.Date))
                                        {
                                            if (verifyinfo.statusexist(textStatus.Text))
                                            {
                                                if (verifyinfo.GPAexist(textGPA.Text))
                                                {
                                                    if (verifyinfo.credithexist(textCreditHour.Text))
                                                    {
                                                        
                                                        var application = new Finalpage();
                                                        application.FormClosed += new FormClosedEventHandler(application_finished);
                                                        application.Show();
                                                        this.Hide();
                                                    }
                                                    else { lblerror.Text = "credit hours doesnt match"; }
                                                }
                                                else { lblerror.Text = "GPA doesnt match"; }
                                            }
                                            else { lblerror.Text = "Status doesnt match"; }
                                        }
                                        else { lblerror.Text = "Date of birth doesnt match"; }

                                    }
                                    else { lblerror.Text = "Gender doesnt match"; }

                                }
                                else { lblerror.Text = "Phone number doesnt match"; }

                            }
                            else { lblerror.Text = "email doesnt match"; }

                        }
                        else { lblerror.Text = "last name doesnt match"; }
                    }
                    else { lblerror.Text = "First name doesnt match"; }
                }
                else { lblerror.Text = "Student ID doesnt match"; }       
                

            }
        }

        private void application_finished(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private bool isValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
