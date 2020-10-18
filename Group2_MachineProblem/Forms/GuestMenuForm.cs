using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    partial class GuestMenuForm
    {
        private Label lblHeader;
        private Button btnBrowse, btnSignOut;
        private void InitializeComponent()
        {
            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "You are signed in as Guest.";
            lblHeader.Size = new Size(150, 25);
            lblHeader.Location = new Point(10, 10);
            this.Controls.Add(lblHeader);

            // btnBrowse
            btnBrowse = new Button();
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Text = "Browse books";
            btnBrowse.Size = new Size(100, 25);
            btnBrowse.Location = new Point(10, 50);
            btnBrowse.Click += new EventHandler(btnBrowse_Click);
            this.Controls.Add(btnBrowse);

            // btnSignOut
            btnSignOut = new Button();
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Text = "Sign Out";
            btnSignOut.Size = new Size(100, 25);
            btnSignOut.Location = new Point(10, 75);
            btnSignOut.Click += new EventHandler(btnSignOut_Click);
            this.Controls.Add(btnSignOut);

            // Settings for the form itself
            this.Name = "GuestMenuForm";
            this.Text = "Guest Menu";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // TODO
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new WelcomeForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
