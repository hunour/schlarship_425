using scholarship_425.pages;
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

namespace scholarship_425
{
    public partial class Form1 : Form
    {
        private Utilities verifyCredentials = new Utilities();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var application = new Fillapplication();
            application.FormClosed += new FormClosedEventHandler(application_FormClosed);
            application.Show();
            this.Hide();
        }

        private void application_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Utilities account = new Utilities();
            // reset error status

            // if username not entered
            if (string.IsNullOrWhiteSpace(textEmployee.Text))
            {
                lblError.Text = "employeeID is required";
            }
            // if password not entered
            else if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Password is required";
            }

            else
            {
                if (verifyCredentials.employeeIDexist(textEmployee.Text))
                {
                    if (verifyCredentials.passwordMatches(Convert.ToInt32(textEmployee.Text), txtPassword.Text))
                    {
                        // re-direct to menu, hide admin buttons
                        var menuScreen = new EmployeeGUI();
                        menuScreen.FormClosed += new FormClosedEventHandler(menuScreen_FormClosed);
                        this.Hide();
                        menuScreen.Show();
                        menuScreen.employeeID = Convert.ToInt32(textEmployee.Text);
                        

                    }
                    
                    else
                    {
                        lblError.Text="Invalid password";
                    }
                }
                else
                {
                    lblError.Text = "Username does not exist";
                }
            }
            textEmployee.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }

        private void menuScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
