using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    partial class WelcomeForm
    {
        private Label lblTitle;
        private Button btnSignIn, btnSignInGuest, btnRegister, btnCredits;

        private void InitializeComponent()
        {
            // lblTitle
            lblTitle = new Label();
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Welcome to the Digital Library";
            lblTitle.Size = new Size(100, 25);
            lblTitle.Location = new Point(10, 10);
            this.Controls.Add(lblTitle);

            // btnSignIn
            btnSignIn = new Button();
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Text = "Sign in";
            btnSignIn.Size = new Size(100, 25);
            btnSignIn.Location = new Point(10, 50);
            btnSignIn.Click += new EventHandler(btnSignIn_Click);
            this.Controls.Add(btnSignIn);

            // btnSignInGuest
            btnSignInGuest = new Button();
            btnSignInGuest.Name = "btnSignInGuest";
            btnSignInGuest.Text = "Sign in as guest";
            btnSignInGuest.Size = new Size(100, 25);
            btnSignInGuest.Location = new Point(10, 75);
            btnSignInGuest.Click += new EventHandler(btnSignInGuest_Click);
            this.Controls.Add(btnSignInGuest);

            // btnSignInGuest
            btnRegister = new Button();
            btnRegister.Name = "btnRegister";
            btnRegister.Text = "Register";
            btnRegister.Size = new Size(100, 25);
            btnRegister.Location = new Point(10, 100);
            btnRegister.Click += new EventHandler(btnRegister_Click);
            this.Controls.Add(btnRegister);

            // btnCredits
            btnCredits = new Button();
            btnCredits.Name = "btnCredits";
            btnCredits.Text = "?";
            btnCredits.Size = new Size(25, 25);
            btnCredits.Location = new Point(250, 225);
            btnCredits.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            btnCredits.Click += new EventHandler(btnCredits_Click);
            this.Controls.Add(btnCredits);

            // Settings for the form itself
            this.Name = "WelcomeForm";
            this.Text = "Welcome to the Digital Library";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new SignInForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnSignInGuest_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new GuestMenuForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new RegisterForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            // this shows the credits
            string header = "A Machine Problem Project by Group 2:\n";
            string members = "TAYAG, Francis Michael\n" + "OLIVAREZ, Karl Ulrich\n" +
                             "RAPISTA, A.G. Matthew\n" + "MARASIGAN, Miguel Christian\n" +
                             "GURION, Sherald Ryoj";
            string message = header + members;
            string title = "Credits";
            MessageBox.Show(message, title);
        }
    }
}
