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
    class AddBookForm : Form
    {
        private Label lblHeader, lblTitle, lblAuthor, lblDatePub, lblGenre, lblEdition;
        private TextBox txtTitle, txtAuthor, txtDatePub, txtGenre, txtEdition;
        private Button btnAddBook, btnBack;

        public AddBookForm()
        {
            LoadControls();
        }
        private void LoadControls()
        {
            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Add Book";
            lblHeader.Size = new Size(70, 25);
            lblHeader.Location = new Point(10, 10);
            this.Controls.Add(lblHeader);

            // lblTitle
            lblTitle = new Label();
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Title: ";
            lblTitle.Size = new Size(70, 25);
            lblTitle.Location = new Point(10, 75);
            this.Controls.Add(lblTitle);

            // lblAuthor
            lblAuthor = new Label();
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Text = "Author(s): ";
            lblAuthor.Size = new Size(70, 25);
            lblAuthor.Location = new Point(10, 100);
            this.Controls.Add(lblAuthor);

            // lblDatePub
            lblDatePub = new Label();
            lblDatePub.Name = "lblDatePub";
            lblDatePub.Text = "Date Pub.: ";
            lblDatePub.Size = new Size(70, 25);
            lblDatePub.Location = new Point(10, 125);
            this.Controls.Add(lblDatePub);

            // lblGenre
            lblGenre = new Label();
            lblGenre.Name = "lblGenre";
            lblGenre.Text = "Genre: ";
            lblGenre.Size = new Size(70, 25);
            lblGenre.Location = new Point(10, 150);
            this.Controls.Add(lblGenre);

            // lblEdition
            lblEdition = new Label();
            lblEdition.Name = "lblEdition";
            lblEdition.Text = "Edition: ";
            lblEdition.Size = new Size(70, 25);
            lblEdition.Location = new Point(10, 175);
            this.Controls.Add(lblEdition);

            // txtTitle
            txtTitle = new TextBox();
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(145, 50);
            txtTitle.Location = new Point(80, 75);
            txtTitle.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtTitle);

            // txtAuthor
            txtAuthor = new TextBox();
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(145, 50);
            txtAuthor.Location = new Point(80, 100);
            txtAuthor.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtAuthor);

            // txtDatePub
            txtDatePub = new TextBox();
            txtDatePub.Name = "txtDatePub";
            txtDatePub.Size = new Size(145, 50);
            txtDatePub.Location = new Point(80, 125);
            txtDatePub.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtDatePub);

            // txtGenre
            txtGenre = new TextBox();
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(145, 50);
            txtGenre.Location = new Point(80, 150);
            txtGenre.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtGenre);

            // txtEdition
            txtEdition = new TextBox();
            txtEdition.Name = "txtEdition";
            txtEdition.Size = new Size(145, 50);
            txtEdition.Location = new Point(80, 175);
            txtEdition.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
            this.Controls.Add(txtEdition);

            // btnAddBook
            btnAddBook = new Button();
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Text = "Add Book";
            btnAddBook.Size = new Size(100, 25);
            btnAddBook.Location = new Point(10, 225);
            btnAddBook.Click += new EventHandler(btnAddBook_Click);
            this.Controls.Add(btnAddBook);

            // btnBack
            btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 25);
            btnBack.Location = new Point(10, 250);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            // Settings for the form itself
            this.Name = "AddBookForm";
            this.Text = "Add Book";
            this.Size = new Size(250, 250);
            this.MinimumSize = new Size(250, 350);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == ";" || e.KeyChar.ToString() == "|")
            {
                e.Handled = true;
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            Library library = new Library();
            bool fieldsEmpty = true;
            bool invalidFields = true;
            bool bookFound = false;

            // The following conditionals process the fields for invalid input
            foreach (Book book in library.BooksList)
            {
                if (txtTitle.Text == book.Title)
                {
                    bookFound = true;
                }
            }

            if (!string.IsNullOrEmpty(txtTitle.Text) &&
               !string.IsNullOrEmpty(txtDatePub.Text) &&
               !string.IsNullOrEmpty(txtEdition.Text) &&
               !string.IsNullOrEmpty(txtGenre.Text) &&
               !string.IsNullOrEmpty(txtAuthor.Text))
            {
                fieldsEmpty = false;
            }
            if (Regex.IsMatch(txtTitle.Text, @"^[a-zA-Z0-9\s\,\:\.\-]+$") &&
               Regex.IsMatch(txtDatePub.Text, @"^[a-zA-Z0-9\s\,\:\.\-]+$") &&
               Regex.IsMatch(txtEdition.Text, @"^[a-zA-Z0-9\s\,\:\.\-]+$") &&
               Regex.IsMatch(txtGenre.Text, @"^[a-zA-Z0-9\s\,\:\.\-]+$") &&
               Regex.IsMatch(txtAuthor.Text, @"^[a-zA-Z0-9\s\,\:\.\-]+$"))
            {
                invalidFields = false;
            }

            // Decide whether or not to process the info or not.
            // This depends whether or not invalid input was found.
            if (!fieldsEmpty && !invalidFields && !bookFound)
            {
                string[] authors = txtAuthor.Text.Split(',');
                try
                {
                    using (StreamWriter w = File.AppendText("Books.txt"))
                    {
                        w.WriteLine("{0};{1};{2};{3};{4};", txtTitle.Text, txtDatePub.Text, txtEdition.Text, txtGenre.Text, string.Join("|", authors));
                        MessageBox.Show("Book added");
                    }
                }
                catch (Exception error)
                {
                    Console.Write(error);
                }
            }
            else if (bookFound)
            {
                MessageBox.Show("Input book is already in the library.");
                txtTitle.Text = "";
            }
            else if (fieldsEmpty)
            {
                MessageBox.Show("One of the fields is empty.");
            }
            else if (invalidFields)
            {
                MessageBox.Show("You entered an invalid input. Please check the fields again.");
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new LibrarianMenuForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
