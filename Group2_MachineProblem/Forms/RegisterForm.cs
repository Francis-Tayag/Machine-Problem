using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    partial class RegisterForm
    {
        private Label lblFName, lblLName, lblUName, lblPin;
        private TextBox txtFName, txtLName, txtUName, txtPin;
        private Button btnSubmit, btnBack;

        private void InitializeComponent()
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

            // lblError
            //lblError = new Label();
            //lblError.Name = "lblError";
            //lblError.Text = "Sample";
            //lblError.ForeColor = Color.Red;
            //lblError.Visible = false;
            //lblError.Size = new Size(300, 25);
            //lblError.Location = new Point(20, 180);
            //this.Controls.Add(lblError);

            // txtFName
            txtFName = new TextBox();
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(100, 50);
            txtFName.Location = new Point(110, 15);
            this.Controls.Add(txtFName);

            // txtLName
            txtLName = new TextBox();
            txtLName.Name = "txtLName";
            txtLName.Size = new Size(100, 50);
            txtLName.Location = new Point(110, 45);
            this.Controls.Add(txtLName);

            // txtUName
            txtUName = new TextBox();
            txtUName.Name = "txtUName";
            txtUName.Size = new Size(100, 50);
            txtUName.Location = new Point(110, 75);
            this.Controls.Add(txtUName);

            // txtPin
            txtPin = new TextBox();
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(100, 50);
            txtPin.Location = new Point(110, 105);
            txtPin.MaxLength = 4;
            txtPin.PasswordChar = '*';
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
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // TODO
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
