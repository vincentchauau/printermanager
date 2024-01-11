namespace QuanLyInAn
{
    partial class fMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.gvInAn = new System.Windows.Forms.DataGridView();
            this.gvRow = new System.Windows.Forms.DataGridView();
            this.gvPopup = new System.Windows.Forms.DataGridView();
            this.mnPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnInAn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btTodayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRow = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.searchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gvInAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPopup)).BeginInit();
            this.mnPopup.SuspendLayout();
            this.mnInAn.SuspendLayout();
            this.mnRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvInAn
            // 
            this.gvInAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvInAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvInAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvInAn.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvInAn.EnableHeadersVisualStyles = false;
            this.gvInAn.Location = new System.Drawing.Point(0, 81);
            this.gvInAn.Margin = new System.Windows.Forms.Padding(6);
            this.gvInAn.Name = "gvInAn";
            this.gvInAn.RowHeadersWidth = 50;
            this.gvInAn.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gvInAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvInAn.Size = new System.Drawing.Size(818, 264);
            this.gvInAn.TabIndex = 2;
            this.gvInAn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInAn_CellClick);
            this.gvInAn.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInAn_CellEndEdit);
            this.gvInAn.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvInAn_CellFormatting);
            this.gvInAn.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvInAn_CellValueChanged);
            this.gvInAn.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvInAn_EditingControlShowing);
            this.gvInAn.SelectionChanged += new System.EventHandler(this.gvInAn_SelectionChanged);
            this.gvInAn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvInAn_KeyUp);
            this.gvInAn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvInAn_MouseDown);
            // 
            // gvRow
            // 
            this.gvRow.AllowUserToAddRows = false;
            this.gvRow.AllowUserToDeleteRows = false;
            this.gvRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvRow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvRow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gvRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvRow.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvRow.EnableHeadersVisualStyles = false;
            this.gvRow.Location = new System.Drawing.Point(0, 2);
            this.gvRow.Margin = new System.Windows.Forms.Padding(6);
            this.gvRow.Name = "gvRow";
            this.gvRow.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvRow.Size = new System.Drawing.Size(818, 76);
            this.gvRow.TabIndex = 3;
            this.gvRow.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvRow_KeyUp);
            this.gvRow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvRow_MouseDown);
            // 
            // gvPopup
            // 
            this.gvPopup.AllowUserToAddRows = false;
            this.gvPopup.AllowUserToDeleteRows = false;
            this.gvPopup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvPopup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPopup.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvPopup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvPopup.EnableHeadersVisualStyles = false;
            this.gvPopup.Location = new System.Drawing.Point(0, 2);
            this.gvPopup.Margin = new System.Windows.Forms.Padding(6);
            this.gvPopup.Name = "gvPopup";
            this.gvPopup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPopup.Size = new System.Drawing.Size(818, 343);
            this.gvPopup.TabIndex = 4;
            this.gvPopup.Visible = false;
            this.gvPopup.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gvPopup_KeyUp);
            this.gvPopup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvPopup_MouseDown);
            // 
            // mnPopup
            // 
            this.mnPopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.mnPopup.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.emailToolStripMenuItem});
            this.mnPopup.Name = "mnPopup";
            this.mnPopup.Size = new System.Drawing.Size(132, 64);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(131, 30);
            this.printToolStripMenuItem.Text = "&Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(131, 30);
            this.emailToolStripMenuItem.Text = "&Email";
            this.emailToolStripMenuItem.Click += new System.EventHandler(this.emailToolStripMenuItem_Click);
            // 
            // mnInAn
            // 
            this.mnInAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.mnInAn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.ttTodayToolStripMenuItem,
            this.btTodayToolStripMenuItem,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.setupToolStripMenuItem});
            this.mnInAn.Name = "mnInAn";
            this.mnInAn.Size = new System.Drawing.Size(192, 184);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.searchToolStripMenuItem.Text = "Tất Cả";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchAllToolStripMenuItem_Click);
            // 
            // ttTodayToolStripMenuItem
            // 
            this.ttTodayToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttTodayToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.ttTodayToolStripMenuItem.Name = "ttTodayToolStripMenuItem";
            this.ttTodayToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.ttTodayToolStripMenuItem.Text = "TT Hôm Nay";
            this.ttTodayToolStripMenuItem.Click += new System.EventHandler(this.ttTodayToolStripMenuItem_Click);
            // 
            // btTodayToolStripMenuItem
            // 
            this.btTodayToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTodayToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.btTodayToolStripMenuItem.Name = "btTodayToolStripMenuItem";
            this.btTodayToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.btTodayToolStripMenuItem.Text = "BT Hôm Nay";
            this.btTodayToolStripMenuItem.Click += new System.EventHandler(this.btTodayToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.importToolStripMenuItem.Text = "Nhập DL";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.exportToolStripMenuItem.Text = "Xuất DL";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setupToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.setupToolStripMenuItem.Text = "Cấu Hình";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // mnRow
            // 
            this.mnRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.mnRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem1,
            this.clearToolStripMenuItem1});
            this.mnRow.Name = "mnRow";
            this.mnRow.Size = new System.Drawing.Size(162, 64);
            // 
            // searchToolStripMenuItem1
            // 
            this.searchToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchToolStripMenuItem1.ForeColor = System.Drawing.Color.Blue;
            this.searchToolStripMenuItem1.Name = "searchToolStripMenuItem1";
            this.searchToolStripMenuItem1.Size = new System.Drawing.Size(161, 30);
            this.searchToolStripMenuItem1.Text = "Tìm Kiếm";
            this.searchToolStripMenuItem1.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearToolStripMenuItem1.ForeColor = System.Drawing.Color.Blue;
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            this.clearToolStripMenuItem1.Size = new System.Drawing.Size(161, 30);
            this.clearToolStripMenuItem1.Text = "Xoá";
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(819, 347);
            this.Controls.Add(this.gvPopup);
            this.Controls.Add(this.gvRow);
            this.Controls.Add(this.gvInAn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "fMain";
            this.Text = "QUẢN LÝ MÁY IN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvInAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPopup)).EndInit();
            this.mnPopup.ResumeLayout(false);
            this.mnInAn.ResumeLayout(false);
            this.mnRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView gvInAn;
        private System.Windows.Forms.DataGridView gvRow;
        private System.Windows.Forms.DataGridView gvPopup;
        private System.Windows.Forms.ContextMenuStrip mnPopup;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnInAn;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ttTodayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btTodayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip mnRow;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
    }
}

