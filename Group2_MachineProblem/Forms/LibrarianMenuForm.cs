using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Group2_MachineProblem
{
    class LibrarianMenuForm : Form
    {
        private Label lblHeader;
        private Button btnViewHistory, btnModifyBook, btnAddBook, btnViewUsers, btnSignOut;

        public LibrarianMenuForm()
        {
            LoadControls();
        }
        private void LoadControls()
        {
            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "You are signed in as Admin.";
            lblHeader.Size = new Size(200, 25);
            lblHeader.Location = new Point(10, 10);
            this.Controls.Add(lblHeader);

            // btnViewHistory
            btnViewHistory = new Button();
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Text = "View Borrowings";
            btnViewHistory.Size = new Size(100, 25);
            btnViewHistory.Location = new Point(10, 50);
            btnViewHistory.Click += new EventHandler(btnViewHistory_Click);
            this.Controls.Add(btnViewHistory);

            // btnModifyBook
            btnModifyBook = new Button();
            btnModifyBook.Name = "btnModifyBook";
            btnModifyBook.Text = "Modify a Book";
            btnModifyBook.Size = new Size(100, 25);
            btnModifyBook.Location = new Point(10, 75);
            btnModifyBook.Click += new EventHandler(btnModifyBook_Click);
            this.Controls.Add(btnModifyBook);

            // btnAddBook
            btnAddBook = new Button();
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Text = "Add a book";
            btnAddBook.Size = new Size(100, 25);
            btnAddBook.Location = new Point(10, 100);
            btnAddBook.Click += new EventHandler(btnAddBook_Click);
            this.Controls.Add(btnAddBook);

            // btnViewUsers
            btnViewUsers = new Button();
            btnViewUsers.Name = "btnViewUsers";
            btnViewUsers.Text = "View Users";
            btnViewUsers.Size = new Size(100, 25);
            btnViewUsers.Location = new Point(10, 125);
            btnViewUsers.Click += new EventHandler(btnViewUsers_Click);
            this.Controls.Add(btnViewUsers);

            // btnSignOut
            btnSignOut = new Button();
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Text = "Sign Out";
            btnSignOut.Size = new Size(100, 25);
            btnSignOut.Location = new Point(10, 150);
            btnSignOut.Click += new EventHandler(btnSignOut_Click);
            this.Controls.Add(btnSignOut);

            // Settings for the form itself
            this.Name = "AdminMenuForm";
            this.Text = "Admin Menu";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new BorrowHistoryForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnModifyBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new ModifyBookForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new AddBookForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void btnViewUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new ViewUsersForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
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
