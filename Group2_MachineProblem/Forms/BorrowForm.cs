using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Group2_MachineProblem
{
    class BorrowForm : Form
    {
        Library library = new Library();
        private TextBox SearchBox, txtBorrow;
        private Button btnBack, btnBorrow;
        private DataGridView dgv;
        private DataTable dt;
        private Label lblHeader, lblSearch, lblBy;
        private ComboBox cbSearchBy;

        private string uname = "Unknown user";
        public BorrowForm(string uname)
        {
            this.uname = uname;
            LoadControls();
        }

        private void LoadControls()
        {
            // dt - data table
            dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Date Pub", typeof(string));
            dt.Columns.Add("Edition", typeof(string));
            dt.Columns.Add("Genre", typeof(string));
            dt.Columns.Add("Authors", typeof(string));

            // FORM SPECIFICATIONS
            this.Text = "Borrow Books";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new Size(520, 400);
            this.MinimumSize = new Size(520, 350);

            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Borrow Books";
            lblHeader.Size = new Size(200, 25);
            lblHeader.Location = new Point(10, 10);
            this.Controls.Add(lblHeader);

            // lblSearch
            lblSearch = new Label();
            lblSearch.Name = "lblSearch";
            lblSearch.Text = "Search: ";
            lblSearch.Size = new Size(45, 10);
            lblSearch.Location = new Point(10, 50);
            this.Controls.Add(lblSearch);

            // SEARCH BOX CONTROL
            this.SearchBox = new TextBox();
            this.SearchBox.Size = new Size(100, 50);
            this.SearchBox.Location = new Point(60, 50);
            this.SearchBox.TextChanged += new EventHandler(SearchBox_TextChanged);
            this.Controls.Add(SearchBox);

            // lblBy
            lblBy = new Label();
            lblBy.Name = "lblHeader";
            lblBy.Text = "By: ";
            lblBy.Size = new Size(25, 15);
            lblBy.Location = new Point(160, 50);
            this.Controls.Add(lblBy);

            // cbSearchBy
            cbSearchBy = new ComboBox();
            cbSearchBy.Name = "cbSearchBy";
            cbSearchBy.Size = new Size(100, 50);
            cbSearchBy.Location = new Point(190, 50);
            cbSearchBy.DropDownStyle = ComboBoxStyle.DropDownList; // disables typing
            cbSearchBy.Items.Add("Title");
            cbSearchBy.SelectedItem = "Title";
            cbSearchBy.Items.Add("Date Pub");
            cbSearchBy.Items.Add("Edition");
            cbSearchBy.Items.Add("Genre");
            cbSearchBy.Items.Add("Authors");
            cbSearchBy.SelectedIndexChanged += new EventHandler(cbSearchBy_SelectedIndexChanged);
            this.Controls.Add(cbSearchBy);

            // DataGridView CONTROL
            dgv = new DataGridView();
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            dgv.Name = "dgv";
            dgv.Location = new Point(10, 80);
            dgv.Size = new Size(443, 150);
            dgv.ReadOnly = true; // makes the DataGridView uneditable
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = false;
            this.Controls.Add(dgv);
            PopulateDataGridView();

            // btnBorrow
            btnBorrow = new Button();
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Text = "Borrow";
            btnBorrow.Size = new Size(100, 25);
            btnBorrow.Location = new Point(10, 250);
            btnBorrow.Click += new EventHandler(btnBorrow_Click);
            this.Controls.Add(btnBorrow);

            // txtBorrow
            txtBorrow = new TextBox();
            txtBorrow.Name = "txtBorrow";
            txtBorrow.Size = new Size(200, 25);
            txtBorrow.Location = new Point(120, 250);
            this.Controls.Add(txtBorrow);

            // btnBack
            btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 25);
            btnBack.Location = new Point(10, 300);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);
        }

        private void PopulateDataGridView()
        {
            List<List<string>> dataList = new List<List<string>>();

            // add the data to the datalist
            foreach (Book book in library.BooksList)
            {
                dataList.Add(new List<string> { book.Title, book.DatePub, book.Edition, book.Genre, book.Authors });
            }

            // unpack the list
            foreach (List<string> subList in dataList)
            {
                // add data to rows
                dt.Rows.Add(new string[] { subList[0], subList[1], subList[2], subList[3], subList[4] });
            }
        }

        private void AddBorrowing()
        {
            try
            {
                using (StreamWriter w = new StreamWriter("Borrowings.txt", true))
                {
                    w.WriteLine("{0};{1};", this.uname, txtBorrow.Text);
                }
                MessageBox.Show("Book was borrowed.");
            }
            catch (Exception error)
            {
                Console.Write(error);
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string selected = cbSearchBy.SelectedItem.ToString();
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", selected, SearchBox.Text);
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbSearchBy.SelectedItem.ToString();
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", selected, SearchBox.Text);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            Library library = new Library();
            string name = "";
            bool bookFound = false;
            bool alreadyBorrowed = false;
            foreach (string line in library.Borrowings)
            {
                name = line.Split(';')[0];

                if (name == this.uname)
                {
                    MessageBox.Show("You may borrow only one book.");
                    alreadyBorrowed = true;
                    break;
                }
            }

            if(!alreadyBorrowed)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (txtBorrow.Text == row["Title"].ToString())
                    {
                        bookFound = true;
                        break;
                    }
                }
            }

            if (bookFound)
            {
                AddBorrowing();
            }
            else if(!bookFound && !alreadyBorrowed)
            {
                MessageBox.Show("Book was not found. Input must have exact cases.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new ReaderMenuForm(this.uname);
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
