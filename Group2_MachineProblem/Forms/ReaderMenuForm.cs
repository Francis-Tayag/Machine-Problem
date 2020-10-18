using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    partial class ReaderMenuForm
    {
        private Label lblHeader;
        private Button btnBrowse, btnBorrow, btnReturnBooks, btnSignOut;
        private void InitializeComponent()
        {
            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "You are signed in as " + this.uname + ".";
            lblHeader.Size = new Size(200, 25);
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

            // btnBorrow
            btnBorrow = new Button();
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Text = "Borrow books";
            btnBorrow.Size = new Size(100, 25);
            btnBorrow.Location = new Point(10, 75);
            btnBorrow.Click += new EventHandler(btnBorrow_Click);
            this.Controls.Add(btnBorrow);

            // btnReturnBooks
            btnReturnBooks = new Button();
            btnReturnBooks.Name = "btnReturnBooks";
            btnReturnBooks.Text = "Return books";
            btnReturnBooks.Size = new Size(100, 25);
            btnReturnBooks.Location = new Point(10, 100);
            btnReturnBooks.Click += new EventHandler(btnReturnBooks_Click);
            this.Controls.Add(btnReturnBooks);

            // btnSignOut
            btnSignOut = new Button();
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Text = "Sign Out";
            btnSignOut.Size = new Size(100, 25);
            btnSignOut.Location = new Point(10, 125);
            btnSignOut.Click += new EventHandler(btnSignOut_Click);
            this.Controls.Add(btnSignOut);

            // Settings for the form itself
            this.Name = "ReaderMenuForm";
            this.Text = "Reader Menu";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btnReturnBooks_Click(object sender, EventArgs e)
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
