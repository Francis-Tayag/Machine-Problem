using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Group2_MachineProblem
{
    class ModifyBookForm : Form
    {
        Library library = new Library();
        private TextBox SearchBox;
        private Button SaveButton, btnBack;
        private DataGridView dgv;
        private DataTable dt;
        private Label lblHeader, lblSearch, lblBy;
        private ComboBox cbSearchBy;

        public ModifyBookForm()
        {
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
            this.Text = "Modify Book Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Size = new Size(520, 350);
            this.MinimumSize = new Size(520, 350);

            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Modify Book";
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
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = false;
            this.Controls.Add(dgv);
            PopulateDataGridView();

            // btnBack
            btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 25);
            btnBack.Location = new Point(10, 250);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            // SAVE BUTTON CONTROL

            this.SaveButton = new Button();
            this.SaveButton.Text = "Save";
            this.SaveButton.Location = new Point(125, 250);
            SaveButton.Click += new EventHandler(SaveButton_Click);
            this.Controls.Add(SaveButton);
        }

        private void PopulateDataGridView()
        {
            List<List<string>> dataList = new List<List<string>>();

            // add the data to the datalist
            foreach (Book book in library.BooksList)
            {
                dataList.Add(new List<string> { book.Title, book.DatePub, book.Edition, book.Genre, book.Authors});
            }

            // unpack the list
            foreach (List<string> subList in dataList)
            {
                // add data to rows
                dt.Rows.Add(new string[] { subList[0], subList[1], subList[2], subList[3], subList[4] });
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Save the information to Books.txt
            Library library = new Library();
            bool hasEmptyFields = false;
            bool hasInvalidFields = false;
            bool duplicateFound = false;

            // The following conditionals process the fields for invalid input
            var duplicates = dt.AsEnumerable().GroupBy(x => x["Title"]).Where(x => x.Count() > 1);
            if (duplicates.Count() > 0)
            {
                duplicateFound = true;
            }

            foreach (DataRow row in dt.Rows)
            {
                if (string.IsNullOrEmpty(row["Title"].ToString()) ||
                    string.IsNullOrEmpty(row["Date Pub"].ToString()) ||
                    string.IsNullOrEmpty(row["Edition"].ToString()) ||
                    string.IsNullOrEmpty(row["Genre"].ToString()) ||
                    string.IsNullOrEmpty(row["Authors"].ToString()))
                {
                    Console.WriteLine("Empty fields");
                    hasEmptyFields = true;
                    break;
                }

                if (!Regex.IsMatch(row["Title"].ToString(), @"^[a-zA-Z0-9\s\,\:\.\-]+$") ||
                    !Regex.IsMatch(row["Date Pub"].ToString(), @"^[a-zA-Z0-9\s\,\:\.\-]+$") ||
                    !Regex.IsMatch(row["Edition"].ToString(), @"^[a-zA-Z0-9\s\,\:\.\-]+$") ||
                    !Regex.IsMatch(row["Genre"].ToString(), @"^[a-zA-Z0-9\s\,\:\.\-]+$") ||
                    !Regex.IsMatch(row["Authors"].ToString(), @"^[a-zA-Z0-9\s\,\:\.\-]+$"))
                {
                    Console.WriteLine("Invalid fields");
                    hasInvalidFields = true;
                    break;
                }
            }

            // Decide whether or not to process the info or not.
            // This depends whether or not invalid input was found.
            if (!hasEmptyFields && !hasInvalidFields && !duplicateFound)
            {
                try
                {
                    using (StreamWriter w = new StreamWriter("Books.txt", false))
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string[] authors = row["Authors"].ToString().Split(',');
                            w.WriteLine("{0};{1};{2};{3};{4};", row["Title"].ToString(), row["Date Pub"].ToString(), row["Edition"].ToString(),
                                                                row["Genre"].ToString(), string.Join("|", authors));
                        }
                    }
                    MessageBox.Show("Changes have been saved.");
                }
                catch (Exception error)
                {
                    Console.Write(error);
                }
            }
            else if (duplicateFound)
            {
                MessageBox.Show("Input book is already in the library. Changes not saved.");
            }
            else if (hasEmptyFields)
            {
                MessageBox.Show("One of the fields is empty. Changes not saved.");
            }
            else if (hasInvalidFields)
            {
                MessageBox.Show("You entered an invalid input. Please check the fields again.\n Changes not saved.");
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new LibrarianMenuForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
