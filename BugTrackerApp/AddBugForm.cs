using System;
using System.Windows.Forms;

namespace BugTrackerApp
{
    public partial class AddBugForm : Form
    {
        public event Action<Bug> BugCreated;

        private int _id;
        private Bug editingBug = null;

        // ADD MODE
        public AddBugForm(int id)
        {
            InitializeComponent();

            _id = id;

            SetupSeverity();

            cmbSeverity.SelectedIndex = 0;
        }

        // EDIT MODE
        public AddBugForm(Bug bugToEdit)
        {
            InitializeComponent();

            editingBug = bugToEdit;

            _id = bugToEdit.Id;

            SetupSeverity();

            textBoxTitle.Text = bugToEdit.Title;
            textBox1.Text = bugToEdit.Description;

            cmbSeverity.SelectedItem = bugToEdit.Severity;
        }

        // COMMON SETUP (IMPORTANT - NO DUPLICATION)
        private void SetupSeverity()
        {
            cmbSeverity.Items.Clear();
            cmbSeverity.Items.Add("Low");
            cmbSeverity.Items.Add("Medium");
            cmbSeverity.Items.Add("High");

            cmbSeverity.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // VALIDATION BASIC 
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // EDIT MODE
            if (editingBug != null)
            {
                editingBug.Title = textBoxTitle.Text;
                editingBug.Description = textBox1.Text;
                editingBug.Severity = cmbSeverity.SelectedItem?.ToString() ?? "Low";

                DatabaseHelper.UpdateBug(editingBug);

                this.Close();
                return;
            }

            // ADD MODE
            Bug bug = new Bug()
            {
                Id = _id,
                Title = textBoxTitle.Text,
                Description = textBox1.Text,
                Severity = cmbSeverity.SelectedItem?.ToString() ?? "Low",
                Status = "Open",
                CreatedAt = DateTime.Now
            };

            BugCreated?.Invoke(bug);

            this.Close();
        }
    }
}