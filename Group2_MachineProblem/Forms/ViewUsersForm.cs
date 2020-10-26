using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Group2_MachineProblem
{
    class ViewUsersForm : Form
    {
        private DataGridView dgvUsers = new DataGridView();
        private DataTable dt = new DataTable();
        private Button btnBack;
        private Label lblHeader, lblSearch, lblBy;
        private ComboBox cbSearchBy;
        private TextBox txtSearch;

        public ViewUsersForm()
        {
            LoadControls();
        }

        private void LoadControls()
        {
            // Settings for the form itself
            this.Name = "ViewUsersForm";
            this.Text = "View Users";
            this.Size = new Size(550, 470);
            this.MinimumSize = new Size(550, 470);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // dt - data table
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("First Name", typeof(string));
            dt.Columns.Add("Last Name", typeof(string));
            dt.Columns.Add("PIN No.", typeof(string));
            //dt.Columns.Add("Books borrowed", typeof(string));

            // lblHeader
            lblHeader = new Label();
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "View Users";
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

            // txtSearch
            txtSearch = new TextBox();
            txtSearch.Name = "txtUName";
            txtSearch.Size = new Size(100, 50);
            txtSearch.Location = new Point(60, 50);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            this.Controls.Add(txtSearch);

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
            cbSearchBy.Items.Add("Username");
            cbSearchBy.SelectedItem = "Username";
            cbSearchBy.Items.Add("First Name");
            cbSearchBy.Items.Add("Last Name");
            cbSearchBy.Items.Add("PIN No.");
            //cbSearchBy.Items.Add("Books Borrowed");
            cbSearchBy.SelectedIndexChanged += new EventHandler(cbSearchBy_SelectedIndexChanged);
            this.Controls.Add(cbSearchBy);

            // dgvUsers
            dgvUsers = new DataGridView();
            dgvUsers.AutoGenerateColumns = true;
            dgvUsers.DataSource = dt;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true; // makes the DataGridView uneditable
            dgvUsers.Location = new Point(10, 80);
            dgvUsers.Size = new Size(443, 150);
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvUsers.GridColor = Color.Black;
            dgvUsers.RowHeadersVisible = false;
            this.Controls.Add(dgvUsers);
            PopulateDataGridView();

            // btnBack
            btnBack = new Button();
            btnBack.Name = "btnBack";
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 25);
            btnBack.Location = new Point(10, 400);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string selected = cbSearchBy.SelectedItem.ToString();
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", selected, txtSearch.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new LibrarianMenuForm();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbSearchBy.SelectedItem.ToString();
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", selected, txtSearch.Text);
        }

        private void PopulateDataGridView()
        {
            Library library = new Library();
            List<List<string>> dataList = new List<List<string>>();

            // add the data to the datalist
            foreach (LibraryReader user in library.UsersList)
            {
                dataList.Add(new List<string> { user.UserName, user.FirstName, user.LastName, user.Pin});
                //dataList.Add(new List<string> { user.UserName, user.FirstName, user.LastName, user.Pin, user.BooksBorrowed});
            }

            // unpack the list
            foreach(List<string> subList in dataList)
            {
                // add data to rows
                dt.Rows.Add(new string[] { subList[0], subList[1], subList[2], subList[3]});
                //dt.Rows.Add(new string[] { subList[0], subList[1], subList[2], subList[3], subList[4] });
            }

        }

        
    }
}
