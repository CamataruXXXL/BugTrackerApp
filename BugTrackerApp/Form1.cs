using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BugTrackerApp;
using System.IO;
using System.Linq;
namespace BugTrackerApp


{
    public partial class Form1 : Form
    {
        List<Bug> bugs = new List<Bug>();
        int nextId = 1;
        bool sortSeverityAsc = true;
        bool sortStatusAsc = true;
        string currentSearch = "";
        private void Form_BugCreated(Bug bug)
        {
            bugs.Add(bug);
            DatabaseHelper.AddBug(bug);
            int rowIndex = dgvBugs.Rows.Add(
                          bug.Id,
                          bug.Title,
                          bug.Description,
                          bug.Severity,
                          bug.Status,
                          bug.CreatedAt
                                        );

            DataGridViewRow row = dgvBugs.Rows[rowIndex];

            if (bug.Status == "Open")
            {
                row.Cells["Status"].Style.BackColor = Color.White;
                row.Cells["Status"].Style.ForeColor = Color.Black;

                row.Cells["Status"].Style.SelectionBackColor = Color.White;
                row.Cells["Status"].Style.SelectionForeColor = Color.Black;
            }
            else if (bug.Status == "In Progress")
            {
                row.Cells["Status"].Style.BackColor = Color.LightGray;
                row.Cells["Status"].Style.ForeColor = Color.Black;

                row.Cells["Status"].Style.SelectionBackColor = Color.LightGray;
                row.Cells["Status"].Style.SelectionForeColor = Color.Black;
            }
            else if (bug.Status == "Closed")
            {
                row.Cells["Status"].Style.BackColor = Color.FromArgb(45, 45, 45);
                row.Cells["Status"].Style.ForeColor = Color.White;
            }
            dgvBugs.ClearSelection();
            nextId++;
            UpdateStats();
            UpdateEmptyState();
        }

        private void ApplyRowColors(DataGridViewRow row, Bug bug)
        {
            // RESET complet (IMPORTANT pentru refresh/sort/search)
            row.Cells["Status"].Style.BackColor = Color.White;
            row.Cells["Status"].Style.ForeColor = Color.Black;
            row.DefaultCellStyle.BackColor = Color.White;
            row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 120, 215);
            row.DefaultCellStyle.SelectionForeColor = Color.White;

            // SEVERITY
            if (bug.Severity == "High")
                row.Cells["Severity"].Style.BackColor = Color.Red;
            else if (bug.Severity == "Medium")
                row.Cells["Severity"].Style.BackColor = Color.Orange;
            else if (bug.Severity == "Low")
                row.Cells["Severity"].Style.BackColor = Color.LightGreen;

            // STATUS (FIX CONSISTENT UI)
            if (bug.Status == "Open")
            {
                row.Cells["Status"].Style.BackColor = Color.White;
                row.Cells["Status"].Style.ForeColor = Color.Black;
            }
            else if (bug.Status == "In Progress")
            {
                row.Cells["Status"].Style.BackColor = Color.FromArgb(200, 200, 200); // light gray
                row.Cells["Status"].Style.ForeColor = Color.Black;
            }
            else if (bug.Status == "Closed")
            {
                row.Cells["Status"].Style.BackColor = Color.FromArgb(80, 80, 80); // dark gray (NU black)
                row.Cells["Status"].Style.ForeColor = Color.White;
            }

            // 🔥 SEARCH HIGHLIGHT (safe + vizibil + nu strică selectarea)
            if (!string.IsNullOrEmpty(currentSearch))
            {
                bool match =
                    (bug.Title?.ToLower().Contains(currentSearch) ?? false) ||
                    (bug.Description?.ToLower().Contains(currentSearch) ?? false) ||
                    (bug.Status?.ToLower().Contains(currentSearch) ?? false) ||
                    (bug.Severity?.ToLower().Contains(currentSearch) ?? false);

                if (match)
                {
                    if (bug.Severity == "High")
                    {
                        // modern soft red
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                    }
                    else if (bug.Severity == "Medium")
                    {
                        // warm amber
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 220);
                    }
                    else if (bug.Severity == "Low")
                    {
                        // mint green
                        row.DefaultCellStyle.BackColor = Color.FromArgb(230, 255, 240);
                    }

                    row.DefaultCellStyle.ForeColor = Color.Black;

                    row.DefaultCellStyle.SelectionBackColor =
                        Color.FromArgb(0, 120, 215);

                    row.DefaultCellStyle.SelectionForeColor =
                        Color.White;
                }
            }
        }

        private void UpdateStats()
        {
            lblTotal.Text = "Total: " + bugs.Count;

            lblOpen.Text = "Open: " +
                bugs.Count(b => b.Status == "Open");

            lblInProgress.Text = "In Progress: " +
                bugs.Count(b => b.Status == "In Progress");

            lblClosed.Text = "Closed: " +
                bugs.Count(b => b.Status == "Closed");
            StyleStat(lblTotal, Color.FromArgb(236, 240, 241), Color.FromArgb(52, 73, 94));
            StyleStat(lblOpen, Color.FromArgb(255, 235, 235), Color.FromArgb(231, 76, 60));
            StyleStat(lblInProgress, Color.FromArgb(255, 248, 225), Color.FromArgb(243, 156, 18));
            StyleStat(lblClosed, Color.FromArgb(235, 255, 240), Color.FromArgb(39, 174, 96));
        }
        private void UpdateEmptyState()
        {
            lblEmpty.Visible = dgvBugs.Rows.Count == 0;
        }
        void StyleStat(Label lbl, Color back, Color fore)
        {
            lbl.BackColor = back;
            lbl.ForeColor = fore;
            lbl.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lbl.Padding = new Padding(10);
        }
        public Form1()
        {
            InitializeComponent();
            lblEmpty.Visible = false;
            txtSearch.AutoSize = false;
            txtSearch.Size = new Size(210, 25);
            txtSearch.MinimumSize = new Size(210, 25);
            txtSearch.MaximumSize = new Size(210, 25);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            lblTotal.Size = new Size(150,35);
            lblOpen.Size = new Size(150,35);
            lblInProgress.Size = new Size(150, 35);
            lblClosed.Size = new Size(150, 35);

            lblTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblOpen.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblInProgress.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblClosed.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            lblOpen.TextAlign = ContentAlignment.MiddleCenter;
            lblInProgress.TextAlign = ContentAlignment.MiddleCenter;
            lblClosed.TextAlign = ContentAlignment.MiddleCenter;
            // ===================== PREMIUM HOVER SYSTEM =====================

            void AddHover(Button btn, Color hoverColor, Color normalColor)
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                btn.BackColor = normalColor;

                btn.MouseEnter += (s, e) =>
                {
                    btn.BackColor = hoverColor;
                    btn.Width += 2;
                };

                btn.MouseLeave += (s, e) =>
                {
                    btn.BackColor = normalColor;
                    btn.Width -= 2;
                };
            }
            this.Text = "Bug Tracker Pro";
            dgvBugs.CellDoubleClick += dgvBugs_CellDoubleClick;

            // FORM STYLE
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Font = new Font("Segoe UI", 9);

            // SEARCH BOX
            txtSearch.Font = new Font("Segoe UI", 10);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Text = "Search...";
            txtSearch.ForeColor = Color.Gray;

            txtSearch.GotFocus += RemoveText;
            txtSearch.LostFocus += AddText;

            // DATAGRIDVIEW STYLE
            dgvBugs.EnableHeadersVisualStyles = false;
            dgvBugs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvBugs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvBugs.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvBugs.BackgroundColor = Color.White;

            dgvBugs.BorderStyle = BorderStyle.None;

            dgvBugs.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvBugs.GridColor = Color.LightGray;

            dgvBugs.RowHeadersVisible = false;

            dgvBugs.RowHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvBugs.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvBugs.ColumnHeadersHeight = 40;

            dgvBugs.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(45, 45, 48);
            dgvBugs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvBugs.ColumnHeadersHeight = 35;
            dgvBugs.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvBugs.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvBugs.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvBugs.DefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvBugs.DefaultCellStyle.Padding =
                new Padding(3);

            dgvBugs.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvBugs.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(0, 120, 215);

            dgvBugs.DefaultCellStyle.SelectionForeColor =
                Color.White;

            dgvBugs.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);

            dgvBugs.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvBugs.RowTemplate.Height = 32;

            dgvBugs.MultiSelect = false;

            dgvBugs.ReadOnly = true;

            dgvBugs.AllowUserToAddRows = false;

            dgvBugs.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvBugs.AutoGenerateColumns = false;

            // BUTTONS STYLE

            // ADD
            btnAddBug.FlatStyle = FlatStyle.Flat;
            btnAddBug.FlatAppearance.BorderSize = 0;
            btnAddBug.BackColor = Color.FromArgb(0, 120, 215);
            btnAddBug.ForeColor = Color.White;
            btnAddBug.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnAddBug.Text = "Add Bug";
            btnAddBug.Font = new Font("Segoe UI Emoji", 9, FontStyle.Bold);
            // DELETE
            btnDeleteBug.FlatStyle = FlatStyle.Flat;
            btnDeleteBug.FlatAppearance.BorderSize = 0;
            btnDeleteBug.BackColor = Color.FromArgb(200, 60, 60);
            btnDeleteBug.ForeColor = Color.White;
            btnDeleteBug.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnDeleteBug.Text = "Delete";
            btnDeleteBug.Font = new Font("Segoe UI Emoji", 9, FontStyle.Bold);
            // UPDATE
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.BackColor = Color.FromArgb(255, 140, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnUpdate.Text = "Update";
            btnUpdate.Font = new Font("Segoe UI Emoji", 9, FontStyle.Bold);
            // EXPORT
            btnExportCsv.FlatStyle = FlatStyle.Flat;
            btnExportCsv.FlatAppearance.BorderSize = 0;
            btnExportCsv.BackColor = Color.FromArgb(40, 167, 69);
            btnExportCsv.ForeColor = Color.White;
            btnExportCsv.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnExportCsv.Text = "📁 Export CSV";
            btnExportCsv.Font = new Font("Segoe UI Emoji", 9, FontStyle.Bold);
            // SORT BUTTONS
            btnSortSeverity.FlatStyle = FlatStyle.Flat;
            btnSortSeverity.FlatAppearance.BorderSize = 0;
            btnSortSeverity.BackColor = Color.FromArgb(70, 70, 70);
            btnSortSeverity.ForeColor = Color.White;
            btnSortSeverity.Font = new Font("Segoe UI", 9);

            btnSortStatus.FlatStyle = FlatStyle.Flat;
            btnSortStatus.FlatAppearance.BorderSize = 0;
            btnSortStatus.BackColor = Color.FromArgb(70, 70, 70);
            btnSortStatus.ForeColor = Color.White;
            btnSortStatus.Font = new Font("Segoe UI", 9);

            btnSortSeverity.Text = "Severity ↓";
            btnSortStatus.Text = "Status ↓";
            // ADD
            AddHover(btnAddBug,
                Color.FromArgb(0, 102, 204),   
                Color.FromArgb(0, 120, 215));  // normal

            // DELETE
            AddHover(btnDeleteBug,
                    Color.FromArgb(170, 50, 50),   // hover roșu mai soft
                    Color.FromArgb(200, 60, 60));  // normal

            // UPDATE
            AddHover(btnUpdate,
                 Color.FromArgb(210, 120, 0),   // hover portocaliu mai cald
                 Color.FromArgb(255, 140, 0));  // normal

            // EXPORT
            AddHover(btnExportCsv,
                Color.FromArgb(30, 140, 70),   // hover verde mai soft
                Color.FromArgb(40, 167, 69));  // normal

            // SORT
            AddHover(btnSortSeverity,
                Color.FromArgb(110, 110, 110),
                Color.FromArgb(70, 70, 70));
            // DATABASE
            DatabaseHelper.InitializeDatabase();

            // COLUMNS
            dgvBugs.Columns.Add("Id", "Id");
            dgvBugs.Columns.Add("Title", "Title");
            dgvBugs.Columns.Add("Description", "Description");
            dgvBugs.Columns.Add("Severity", "Severity");
            dgvBugs.Columns.Add("Status", "Status");
            dgvBugs.Columns.Add("CreatedAt", "Created");

            dgvBugs.Columns["CreatedAt"].DefaultCellStyle.Format =
                "dd/MM/yyyy HH:mm";
            dgvBugs.Columns["Severity"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            dgvBugs.Columns["Status"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // LOAD BUGS
            bugs = DatabaseHelper.LoadBugs();

            foreach (Bug bug in bugs)
            {
                int rowIndex = dgvBugs.Rows.Add(
                    bug.Id,
                    bug.Title,
                    bug.Description,
                    bug.Severity,
                    bug.Status,
                    bug.CreatedAt
                );

                ApplyRowColors(dgvBugs.Rows[rowIndex], bug);
            }

            // NEXT ID
            if (bugs.Count > 0)
            {
                nextId = bugs.Max(b => b.Id) + 1;
            }

            // STATS
            UpdateStats();
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if(txtSearch.Text=="Search...")
            {
                txtSearch.Text = string.Empty ;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Search...";
            }
        }

        private void dgvBugs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvBugs.SelectedRows.Count == 0)
            {

                MessageBox.Show("Please select a bug first.");
                return;
            }

            int selectedId = Convert.ToInt32(dgvBugs.SelectedRows[0].Cells[0].Value);

            Bug bug = bugs.FirstOrDefault(b => b.Id == selectedId);

            if (bug != null)
            {
                // schimbăm statusul
                if (bug.Status == "Open")
                    bug.Status = "In Progress";
                else if (bug.Status == "In Progress")
                    bug.Status = "Closed";
                else
                    bug.Status = "Open";

                // actualizăm UI-ul
                dgvBugs.SelectedRows[0].Cells["Status"].Value = bug.Status;
                ApplyRowColors(dgvBugs.SelectedRows[0], bug);
                DatabaseHelper.UpdateBugStatus(bug);
                //dgvBugs.SelectedRows[0].Cells[4].Value = bug.Status;
                dgvBugs.ClearSelection();
                UpdateEmptyState();
                MessageBox.Show("Status updated!");
                UpdateStats();
            }
        }

        private void btnAddBug_Click(object sender, EventArgs e)
        {
            AddBugForm form = new AddBugForm(nextId);
            form.StartPosition = FormStartPosition.CenterParent;
            form.BugCreated += Form_BugCreated;
            form.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBugs.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bug first.");
                return;
            }

           
            //sau int selectedId = Convert.ToInt32(dgvBugs.SelectedRows[0].Cells[0].Value);
              DialogResult result = MessageBox.Show              
            ("Are you sure you want to delete this bug?",
             "Confirm Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Warning );

        if (result == DialogResult.No)
         {
             return;
        } 
            int selectedId = (int)dgvBugs.SelectedRows[0].Cells["Id"].Value;
            // ștergem din listă
            Bug bugToRemove = bugs.FirstOrDefault(b => b.Id == selectedId); 

            if (bugToRemove != null)
            {
                bugs.Remove(bugToRemove);
            }

            // ștergem din UI
            DatabaseHelper.DeleteBug(selectedId);
            dgvBugs.Rows.RemoveAt(dgvBugs.SelectedRows[0].Index);
            MessageBox.Show("Bug deleted!");
            UpdateStats();
            UpdateEmptyState();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // ignorăm placeholder-ul
            if (txtSearch.Text == "Search...")
                return;

            string searchText = txtSearch.Text.ToLower().Trim();

            // dacă e gol -> reload complet
            if (string.IsNullOrWhiteSpace(searchText))
            {
                currentSearch = "";
                RefreshGrid(bugs);
                return;
            }

            currentSearch = searchText;

            List<Bug> filteredBugs = bugs
                .Where(b =>
                    b.Title.ToLower().Contains(searchText) ||
                    b.Description.ToLower().Contains(searchText) ||
                    b.Status.ToLower().Contains(searchText) ||
                    b.Severity.ToLower().Contains(searchText)
                )
                .ToList();

            RefreshGrid(filteredBugs);
        }

        private void RefreshGrid(List<Bug> bugList)
        {
            dgvBugs.Rows.Clear();

            foreach (Bug bug in bugList)
            {
                int rowIndex = dgvBugs.Rows.Add(
                    bug.Id,
                    bug.Title,
                    bug.Description,
                    bug.Severity,
                    bug.Status,
                    bug.CreatedAt
                );

                ApplyRowColors(dgvBugs.Rows[rowIndex], bug);
            }

            dgvBugs.ClearSelection();
            UpdateEmptyState();
        }

        private int GetSeverityWeight(string severity)
        {
            if (severity == "High") return 1;
            if (severity == "Medium") return 2;
            if (severity == "Low") return 3;
            return 4;
        }

        private void btnSortSeverity_Click(object sender, EventArgs e)
        {
            if (sortSeverityAsc)
            {
                bugs = bugs
                    .OrderBy(b => GetSeverityWeight(b.Severity))
                    .ToList();

                btnSortSeverity.Text = "Severity ↓";
            }
            else
            {
                bugs = bugs
                    .OrderByDescending(b => GetSeverityWeight(b.Severity))
                    .ToList();

                btnSortSeverity.Text = "Severity ↑";
            }

            sortSeverityAsc = !sortSeverityAsc;
            RefreshGrid(bugs);
        }

        private int GetStatusWeight(string status)
        {
            if (status == "Open") return 1;
            if (status == "In Progress") return 2;
            if (status == "Closed") return 3;
            return 4;
        }
        private void btnSortStatus_Click(object sender, EventArgs e)
        {
            if (sortStatusAsc)
            {
                bugs = bugs
                    .OrderBy(b => GetStatusWeight(b.Status))
                    .ToList();

                btnSortStatus.Text = "Status ↓";
            }
            else
            {
                bugs = bugs
                    .OrderByDescending(b => GetStatusWeight(b.Status))
                    .ToList();

                btnSortStatus.Text = "Status ↑";
            }

            sortStatusAsc = !sortStatusAsc;
            RefreshGrid(bugs);
        }

        private void dgvBugs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int selectedId = Convert.ToInt32(dgvBugs.Rows[e.RowIndex].Cells["Id"].Value);

            Bug selectedBug = bugs.FirstOrDefault(b => b.Id == selectedId);

            if (selectedBug == null)
                return;
            dgvBugs.ClearSelection();
            AddBugForm editForm = new AddBugForm(selectedBug);
            editForm.StartPosition = FormStartPosition.CenterParent;
            editForm.ShowDialog();
            RefreshGrid(bugs);
            UpdateStats();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Save Bugs as CSV";
            saveFileDialog.FileName = "bugs.csv";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> lines = new List<string>();

                // Header
                lines.Add("Id,Title,Description,Severity,Status,CreatedAt");

                // Data
                foreach (Bug bug in bugs)
                {
                    lines.Add($"{bug.Id},{bug.Title},{bug.Description},{bug.Severity},{bug.Status},{bug.CreatedAt}");
                }

                File.WriteAllLines(saveFileDialog.FileName, lines);

                MessageBox.Show("CSV exported successfully!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

    
        
    

