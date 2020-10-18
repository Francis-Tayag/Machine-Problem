using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace Group2_MachineProblem
{
    partial class AddBookForm
    {
        private Label lblHeader, lblId, lblTitle, lblAuthor, lblDatePub, lblGenre, lblEdition;
        private TextBox txtId, txtTitle, txtAuthor, txtDatePub, txtGenre, txtEdition;
        private Button btnAddBook, btnBack;
        private void InitializeComponent()
        {
            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Add Book";
            lblHeader.Size = new Size(70, 25);
            lblHeader.Location = new Point(10, 10);
            this.Controls.Add(lblHeader);

            // lblId
            lblId = new Label();
            lblId.Name = "lblId";
            lblId.Text = "ID: ";
            lblId.Size = new Size(70, 25);
            lblId.Location = new Point(10, 50);
            this.Controls.Add(lblId);

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

            // txtId
            txtId = new TextBox();
            txtId.Name = "txtId";
            txtId.Size = new Size(145, 50);
            txtId.Location = new Point(80, 50);
            this.Controls.Add(txtId);

            // txtTitle
            txtTitle = new TextBox();
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(145, 50);
            txtTitle.Location = new Point(80, 75);
            this.Controls.Add(txtTitle);

            // txtAuthor
            txtAuthor = new TextBox();
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(145, 50);
            txtAuthor.Location = new Point(80, 100);
            this.Controls.Add(txtAuthor);

            // txtDatePub
            txtDatePub = new TextBox();
            txtDatePub.Name = "txtDatePub";
            txtDatePub.Size = new Size(145, 50);
            txtDatePub.Location = new Point(80, 125);
            this.Controls.Add(txtDatePub);

            // txtGenre
            txtGenre = new TextBox();
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(145, 50);
            txtGenre.Location = new Point(80, 150);
            this.Controls.Add(txtGenre);

            // txtEdition
            txtEdition = new TextBox();
            txtEdition.Name = "txtEdition";
            txtEdition.Size = new Size(145, 50);
            txtEdition.Location = new Point(80, 175);
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

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // TODO
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
