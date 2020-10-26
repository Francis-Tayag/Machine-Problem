using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Group2_MachineProblem
{
    class RegisterForm : Form
    {
        private Label lblFName, lblLName, lblUName, lblPin;
        private TextBox txtFName, txtLName, txtUName, txtPin;
        private Button btnSubmit, btnBack;

        public RegisterForm()
        {
            LoadControls();
        }

        private void LoadControls()
        {
            // lblFNName
            lblFName = new Label();
            lblFName.Name = "lblFname";
            lblFName.Text = "First Name:";
            lblFName.Size = new Size(70, 25);
            lblFName.Location = new Point(10, 17);
            this.Controls.Add(lblFName);

            // lblLName
            lblLName = new Label();
            lblLName.Name = "lblLName";
            lblLName.Text = "Last Name:";
            lblLName.Size = new Size(70, 25);
            lblLName.Location = new Point(10, 47);
            this.Controls.Add(lblLName);

            // lblUName
            lblUName = new Label();
            lblUName.Name = "lblUName";
            lblUName.Text = "Username:";
            lblUName.Size = new Size(70, 25);
            lblUName.Location = new Point(10, 77);
            this.Controls.Add(lblUName);

            // lblPin
            lblPin = new Label();
            lblPin.Name = "lblPin";
            lblPin.Text = "PIN:";
            lblPin.Size = new Size(70, 25);
            lblPin.Location = new Point(10, 105);
            this.Controls.Add(lblPin);

            // txtFName
            txtFName = new TextBox();
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(100, 50);
            txtFName.Location = new Point(110, 15);
            txtFName.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtFName);

            // txtLName
            txtLName = new TextBox();
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(100, 50);
            txtLName.Location = new Point(110, 45);
            txtLName.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtLName);

            // txtUName
            txtUName = new TextBox();
            txtUName.Name = "txtUName";
            txtUName.Size = new Size(100, 50);
            txtUName.Location = new Point(110, 75);
            txtUName.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtUName);

            // txtPin
            txtPin = new TextBox();
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(100, 50);
            txtPin.Location = new Point(110, 105);
            txtPin.MaxLength = 4;
            txtPin.PasswordChar = '*';
            txtPin.KeyPress += new KeyPressEventHandler(txtPin_KeyPress);
            this.Controls.Add(txtPin);

            // btnSubmit
            btnSubmit = new Button();
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Text = "Register";
            btnSubmit.Size = new Size(100, 25);
            btnSubmit.Location = new Point(10, 150);
            btnSubmit.Click += new EventHandler(btnSubmit_Click);
            this.Controls.Add(btnSubmit);

            // btnBack
            btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 25);
            btnBack.Location = new Point(10, 175);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            // Settings for the form itself
            this.Name = "RegisterForm";
            this.Text = "Register a new account";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Letters only! No spaces.", "Error");
                e.Handled = true;
            }
        }

        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Numbers only!", "Error");
                e.Handled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Library library = new Library();
            bool userFound = false;
            bool fieldsEmpty = true;
            bool invalidPin = true;
            bool invalidFields = true;


            // The following conditionals process the fields for invalid input
            foreach (LibraryReader user in library.UsersList)
            {
                if (txtUName.Text == user.UserName)
                {
                    userFound = true;
                }
            }

            if(!string.IsNullOrEmpty(txtFName.Text) &&
               !string.IsNullOrEmpty(txtLName.Text) &&
               !string.IsNullOrEmpty(txtPin.Text) &&
               !string.IsNullOrEmpty(txtUName.Text))
            {
                fieldsEmpty = false;
            }

            if(Regex.IsMatch(txtFName.Text, @"^[a-zA-Z]+$") &&
               Regex.IsMatch(txtLName.Text, @"^[a-zA-Z]+$") &&
               Regex.IsMatch(txtUName.Text, @"^[a-zA-Z]+$"))
            {
                invalidFields = false;
            }

            if(txtPin.Text.Length == 4 && Regex.IsMatch(txtPin.Text, "^[0-9]+$"))
            {
                invalidPin = false;
            }

            // Decide whether or not to process the info or not.
            // This depends whether or not invalid input was found.
            if (!userFound && !fieldsEmpty && !invalidPin && !invalidFields)
            {
                try
                {
                    using (StreamWriter w = new StreamWriter("Users.txt", true))
                    {
                        w.WriteLine("{0};{1};{2};{3};", txtUName.Text, txtFName.Text, txtLName.Text, txtPin.Text);
                    }
                    MessageBox.Show("Successfully registered.");
                }
                catch (Exception error)
                {
                    Console.Write(error);
                }
            }
            else if(userFound)
            {
                MessageBox.Show("Your username is already taken.");
                txtUName.Text = "";
            }
            else if(fieldsEmpty)
            {
                MessageBox.Show("One of the fields is empty.");
            }
            else if(invalidPin)
            {
                MessageBox.Show("You entered an invalid pin. 4 numbers are needed.");
                txtPin.Text = "";
            }
            else if(invalidFields)
            {
                MessageBox.Show("At least one of the fields contains an invalid character. Letters only.");
                txtFName.Text = "";
                txtLName.Text = "";
                txtUName.Text = "";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new WelcomeForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
