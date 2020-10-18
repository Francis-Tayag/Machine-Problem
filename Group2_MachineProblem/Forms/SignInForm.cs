using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    partial class SignInForm
    {
        private Label lblHeader, lblUName, lblPin;
        private TextBox txtUName, txtPin;
        private Button btnBack;

        private void InitializeComponent()
        {
            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Sign In";
            lblHeader.Size = new Size(70, 25);
            lblHeader.Location = new Point(10, 10);
            this.Controls.Add(lblHeader);

            // lblName
            lblUName = new Label();
            lblUName.Name = "lblUName";
            lblUName.Text = "Username:";
            lblUName.Size = new Size(70, 25);
            lblUName.Location = new Point(10, 50);
            this.Controls.Add(lblUName);

            // lblPin
            lblPin = new Label();
            lblPin.Name = "lblPin";
            lblPin.Text = "PIN:";
            lblPin.Size = new Size(70, 25);
            lblPin.Location = new Point(10, 75);
            this.Controls.Add(lblPin);

            // txtUName
            txtUName = new TextBox();
            txtUName.Name = "txtUName";
            txtUName.Size = new Size(100, 50);
            txtUName.Location = new Point(100, 50);
            this.Controls.Add(txtUName);

            // txtPin
            txtPin = new TextBox();
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(100, 50);
            txtPin.Location = new Point(100, 75);
            txtPin.KeyUp += new KeyEventHandler(txtPin_KeyUp);
            this.Controls.Add(txtPin);

            // btnBack
            btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 25);
            btnBack.Location = new Point(10, 175);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            // Settings for the form itself
            this.Name = "SignInForm";
            this.Text = "Sign In";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
        private void txtPin_KeyUp(object sender, KeyEventArgs e)
        {
            // TODO
            // TESTING
            if(txtUName.Text == "test" && txtPin.Text == "1234") {
                this.Hide();
                var f = new ReaderMenuForm(txtUName.Text);
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else if(txtUName.Text == "admin" && txtPin.Text == "1234")
            {
                this.Hide();
                var f = new LibrarianMenuForm();
                f.Closed += (s, args) => this.Close();
                f.Show();
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
    