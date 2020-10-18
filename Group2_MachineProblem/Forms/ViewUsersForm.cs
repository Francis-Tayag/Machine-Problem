using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    partial class ViewUsersForm
    {
        private DataGridView dgvUsers = new DataGridView();
        private void InitializeComponent()
        {
            // dgvUsers
            dgvUsers = new DataGridView();
            dgvUsers.ColumnCount = 5;

            dgvUsers.Name = "dgvUsers";
            dgvUsers.Location = new Point(8, 8);
            dgvUsers.Size = new Size(500, 250);
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvUsers.GridColor = Color.Black;
            dgvUsers.RowHeadersVisible = false;

            dgvUsers.Columns[0].Name = "Username";
            dgvUsers.Columns[1].Name = "First Name";
            dgvUsers.Columns[2].Name = "Last Name";
            dgvUsers.Columns[3].Name = "PIN No.";
            dgvUsers.Columns[4].Name = "Books borrowed";

            this.Controls.Add(dgvUsers);

            // Settings for the form itself
            this.Name = "ViewUsersForm";
            this.Text = "View Users";
            this.Size = new Size(1000, 500);
            this.MinimumSize = new Size(250, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}
