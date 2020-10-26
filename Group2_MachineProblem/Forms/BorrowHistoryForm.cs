// TODO
// Maybe add a search function?

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Group2_MachineProblem
{
    class BorrowHistoryForm : Form
    {
        private static DataGridView dgvBorrower;
        private static Button btnBack;
        private static DataTable dt;
        public BorrowHistoryForm()
        {
            LoadControls();
        }
        private void LoadControls()
        {
            // data table
            dt = new DataTable();
            dt.Columns.Add("Borrower", typeof(string));
            dt.Columns.Add("Book", typeof(string));

            //Data grid view
            dgvBorrower = new DataGridView();
            dgvBorrower.DataSource = dt;
            dgvBorrower.Name = "dgvBorrower";
            dgvBorrower.Location = new Point(10, 10);
            dgvBorrower.Size = new Size(200, 150);
            dgvBorrower.ReadOnly = true;
            dgvBorrower.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBorrower.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBorrower.ScrollBars = ScrollBars.Vertical; //Show scroll bar when height limit exceeds
            dgvBorrower.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvBorrower.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvBorrower.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvBorrower.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvBorrower.GridColor = Color.Black;
            dgvBorrower.RowHeadersVisible = false;
            this.Controls.Add(dgvBorrower);
            PopulateDGV();

            //Back button
            btnBack = new Button();
            btnBack.Text = "Back";
            btnBack.Size = new Size(100, 35);
            btnBack.Location = new Point(10, 200);
            btnBack.Click += new EventHandler(btnBack_Click);
            this.Controls.Add(btnBack);

            //Window form
            this.Name = "BorrowHistoryForm";
            this.Text = "Borrow History";
            this.Size = new Size(350, 300);
            this.MinimumSize = new Size(350, 300);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private static void PopulateDGV()
        {
            List<List<string>> dataList = new List<List<string>>();
            Library library = new Library();
            string name = "";
            string book;

            // add the data to the datalist
            foreach (string line in library.Borrowings)
            {
                name = line.Split(';')[0];
                book = line.Split(';')[1];
                dataList.Add(new List<string> { name, book });
            }

            // unpack the list
            foreach (List<string> subList in dataList)
            {
                // add data to rows
                dt.Rows.Add(new string[] { subList[0], subList[1] });
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
