
namespace BugTrackerApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBugs = new System.Windows.Forms.DataGridView();
            this.btnAddBug = new System.Windows.Forms.Button();
            this.btnDeleteBug = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSortSeverity = new System.Windows.Forms.Button();
            this.btnSortStatus = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblOpen = new System.Windows.Forms.Label();
            this.lblInProgress = new System.Windows.Forms.Label();
            this.lblClosed = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBugs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBugs
            // 
            this.dgvBugs.AllowUserToAddRows = false;
            this.dgvBugs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBugs.Location = new System.Drawing.Point(0, 0);
            this.dgvBugs.Name = "dgvBugs";
            this.dgvBugs.ReadOnly = true;
            this.dgvBugs.Size = new System.Drawing.Size(814, 250);
            this.dgvBugs.TabIndex = 0;
            this.dgvBugs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBugs_CellContentClick);
            // 
            // btnAddBug
            // 
            this.btnAddBug.FlatAppearance.BorderSize = 0;
            this.btnAddBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBug.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddBug.Location = new System.Drawing.Point(94, 292);
            this.btnAddBug.Name = "btnAddBug";
            this.btnAddBug.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddBug.Size = new System.Drawing.Size(140, 45);
            this.btnAddBug.TabIndex = 1;
            this.btnAddBug.Text = "Add Bug";
            this.btnAddBug.UseVisualStyleBackColor = true;
            this.btnAddBug.Click += new System.EventHandler(this.btnAddBug_Click);
            // 
            // btnDeleteBug
            // 
            this.btnDeleteBug.FlatAppearance.BorderSize = 0;
            this.btnDeleteBug.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBug.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteBug.Location = new System.Drawing.Point(330, 292);
            this.btnDeleteBug.Name = "btnDeleteBug";
            this.btnDeleteBug.Size = new System.Drawing.Size(140, 45);
            this.btnDeleteBug.TabIndex = 2;
            this.btnDeleteBug.Text = "Delete Bug";
            this.btnDeleteBug.UseVisualStyleBackColor = true;
            this.btnDeleteBug.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Location = new System.Drawing.Point(605, 292);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 45);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update Status";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(56, 256);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(178, 25);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSortSeverity
            // 
            this.btnSortSeverity.Location = new System.Drawing.Point(330, 256);
            this.btnSortSeverity.Name = "btnSortSeverity";
            this.btnSortSeverity.Size = new System.Drawing.Size(140, 25);
            this.btnSortSeverity.TabIndex = 5;
            this.btnSortSeverity.Text = "Sort by Severity ↑↓";
            this.btnSortSeverity.UseVisualStyleBackColor = true;
            this.btnSortSeverity.Click += new System.EventHandler(this.btnSortSeverity_Click);
            // 
            // btnSortStatus
            // 
            this.btnSortStatus.Location = new System.Drawing.Point(605, 256);
            this.btnSortStatus.Name = "btnSortStatus";
            this.btnSortStatus.Size = new System.Drawing.Size(138, 25);
            this.btnSortStatus.TabIndex = 6;
            this.btnSortStatus.Text = "Sort by Status ↑↓";
            this.btnSortStatus.UseVisualStyleBackColor = true;
            this.btnSortStatus.Click += new System.EventHandler(this.btnSortStatus_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(643, 415);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(75, 23);
            this.btnExportCsv.TabIndex = 7;
            this.btnExportCsv.Text = "Export CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(93, 358);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(43, 13);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Total: 0";
            // 
            // lblOpen
            // 
            this.lblOpen.Location = new System.Drawing.Point(93, 404);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(45, 13);
            this.lblOpen.TabIndex = 9;
            this.lblOpen.Text = "Open: 0";
            // 
            // lblInProgress
            // 
            this.lblInProgress.Location = new System.Drawing.Point(327, 358);
            this.lblInProgress.Name = "lblInProgress";
            this.lblInProgress.Size = new System.Drawing.Size(72, 13);
            this.lblInProgress.TabIndex = 10;
            this.lblInProgress.Text = "In Progress: 0";
            // 
            // lblClosed
            // 
            this.lblClosed.Location = new System.Drawing.Point(327, 404);
            this.lblClosed.Name = "lblClosed";
            this.lblClosed.Size = new System.Drawing.Size(51, 13);
            this.lblClosed.TabIndex = 11;
            this.lblClosed.Text = "Closed: 0";
            // 
            // lblEmpty
            // 
            this.lblEmpty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpty.Location = new System.Drawing.Point(162, 60);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(461, 104);
            this.lblEmpty.TabIndex = 12;
            this.lblEmpty.Text = "No bugs found 🐞";
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.lblClosed);
            this.Controls.Add(this.lblInProgress);
            this.Controls.Add(this.lblOpen);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnSortStatus);
            this.Controls.Add(this.btnSortSeverity);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDeleteBug);
            this.Controls.Add(this.btnAddBug);
            this.Controls.Add(this.dgvBugs);
            this.Name = "Form1";
            this.Text = "Bug Tracker App";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBugs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBugs;
        private System.Windows.Forms.Button btnAddBug;
        private System.Windows.Forms.Button btnDeleteBug;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSortSeverity;
        private System.Windows.Forms.Button btnSortStatus;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.Label lblInProgress;
        private System.Windows.Forms.Label lblClosed;
        private System.Windows.Forms.Label lblEmpty;
    }
}

