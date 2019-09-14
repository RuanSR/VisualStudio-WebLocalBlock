namespace WebLocalBlock
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupURL = new System.Windows.Forms.GroupBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.groupURLs = new System.Windows.Forms.GroupBox();
            this.dtgUrl = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Locked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnRemove = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupURL.SuspendLayout();
            this.tools.SuspendLayout();
            this.groupURLs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgUrl)).BeginInit();
            this.SuspendLayout();
            // 
            // groupURL
            // 
            this.groupURL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupURL.Controls.Add(this.txtUrl);
            this.groupURL.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupURL.Location = new System.Drawing.Point(0, 25);
            this.groupURL.Name = "groupURL";
            this.groupURL.Size = new System.Drawing.Size(284, 44);
            this.groupURL.TabIndex = 0;
            this.groupURL.TabStop = false;
            this.groupURL.Text = "Search or Add URLS";
            // 
            // txtUrl
            // 
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Location = new System.Drawing.Point(3, 16);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(278, 20);
            this.txtUrl.TabIndex = 0;
            // 
            // tools
            // 
            this.tools.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator,
            this.btnAbout});
            this.tools.Location = new System.Drawing.Point(0, 0);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(284, 25);
            this.tools.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(60, 22);
            this.btnAbout.Text = "About";
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // groupURLs
            // 
            this.groupURLs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupURLs.Controls.Add(this.dtgUrl);
            this.groupURLs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupURLs.Location = new System.Drawing.Point(0, 69);
            this.groupURLs.Name = "groupURLs";
            this.groupURLs.Size = new System.Drawing.Size(284, 193);
            this.groupURLs.TabIndex = 2;
            this.groupURLs.TabStop = false;
            this.groupURLs.Text = "URLs";
            // 
            // dtgUrl
            // 
            this.dtgUrl.AllowUserToAddRows = false;
            this.dtgUrl.AllowUserToDeleteRows = false;
            this.dtgUrl.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgUrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgUrl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.URL,
            this.Locked,
            this.btnEdit,
            this.btnRemove});
            this.dtgUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgUrl.Location = new System.Drawing.Point(3, 16);
            this.dtgUrl.Name = "dtgUrl";
            this.dtgUrl.RowHeadersVisible = false;
            this.dtgUrl.Size = new System.Drawing.Size(278, 174);
            this.dtgUrl.TabIndex = 0;
            this.dtgUrl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewUrl_CellContentClick);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Edit";
            this.dataGridViewImageColumn1.Image = global::WebLocalBlock.Properties.Resources.edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 35;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Del.";
            this.dataGridViewImageColumn2.Image = global::WebLocalBlock.Properties.Resources.remove;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 35;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // URL
            // 
            this.URL.HeaderText = "URL";
            this.URL.Name = "URL";
            this.URL.Width = 150;
            // 
            // Locked
            // 
            this.Locked.HeaderText = "Locked";
            this.Locked.Name = "Locked";
            this.Locked.Width = 45;
            // 
            // btnEdit
            // 
            this.btnEdit.HeaderText = "Edit";
            this.btnEdit.Image = global::WebLocalBlock.Properties.Resources.edit;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Width = 35;
            // 
            // btnRemove
            // 
            this.btnRemove.HeaderText = "Del.";
            this.btnRemove.Image = global::WebLocalBlock.Properties.Resources.remove;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Width = 35;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.groupURLs);
            this.Controls.Add(this.groupURL);
            this.Controls.Add(this.tools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WEB<LOCAL>BLOCK";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupURL.ResumeLayout(false);
            this.groupURL.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.groupURLs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgUrl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupURL;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton btnAbout;
        private System.Windows.Forms.GroupBox groupURLs;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.DataGridView dtgUrl;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Locked;
        private System.Windows.Forms.DataGridViewImageColumn btnEdit;
        private System.Windows.Forms.DataGridViewImageColumn btnRemove;
    }
}