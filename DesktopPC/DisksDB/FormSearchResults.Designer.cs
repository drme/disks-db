using DisksDB.Library;

namespace DisksDB.UserInterface
{
    partial class FormSearchResults
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetSearch1 = new Library.DataSetSearch();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSearch1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.fileDateDataGridViewTextBoxColumn,
            this.diskDataGridViewTextBoxColumn,
            this.boxDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn});
            this.dataGridView1.ContextMenuStrip = this.contextMenu;
            this.dataGridView1.DataSource = this.filesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(734, 447);
            this.dataGridView1.TabIndex = 0;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fileDateDataGridViewTextBoxColumn
            // 
            this.fileDateDataGridViewTextBoxColumn.DataPropertyName = "FileDate";
            this.fileDateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.fileDateDataGridViewTextBoxColumn.Name = "fileDateDataGridViewTextBoxColumn";
            this.fileDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diskDataGridViewTextBoxColumn
            // 
            this.diskDataGridViewTextBoxColumn.DataPropertyName = "Disk";
            this.diskDataGridViewTextBoxColumn.HeaderText = "Disk";
            this.diskDataGridViewTextBoxColumn.Name = "diskDataGridViewTextBoxColumn";
            this.diskDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // boxDataGridViewTextBoxColumn
            // 
            this.boxDataGridViewTextBoxColumn.DataPropertyName = "Box";
            this.boxDataGridViewTextBoxColumn.HeaderText = "Box";
            this.boxDataGridViewTextBoxColumn.Name = "boxDataGridViewTextBoxColumn";
            this.boxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToFileToolStripMenuItem,
            this.goToDiskToolStripMenuItem,
            this.goToBoxToolStripMenuItem,
            this.goToCategoryToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(149, 92);
            // 
            // goToFileToolStripMenuItem
            // 
            this.goToFileToolStripMenuItem.Name = "goToFileToolStripMenuItem";
            this.goToFileToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.goToFileToolStripMenuItem.Text = "Go to File";
            this.goToFileToolStripMenuItem.Click += new System.EventHandler(this.goToFileToolStripMenuItem_Click);
            // 
            // goToDiskToolStripMenuItem
            // 
            this.goToDiskToolStripMenuItem.Name = "goToDiskToolStripMenuItem";
            this.goToDiskToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.goToDiskToolStripMenuItem.Text = "Go to Disk";
            this.goToDiskToolStripMenuItem.Click += new System.EventHandler(this.goToDiskToolStripMenuItem_Click);
            // 
            // goToBoxToolStripMenuItem
            // 
            this.goToBoxToolStripMenuItem.Name = "goToBoxToolStripMenuItem";
            this.goToBoxToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.goToBoxToolStripMenuItem.Text = "Go to Box";
            this.goToBoxToolStripMenuItem.Click += new System.EventHandler(this.goToBoxToolStripMenuItem_Click);
            // 
            // goToCategoryToolStripMenuItem
            // 
            this.goToCategoryToolStripMenuItem.Name = "goToCategoryToolStripMenuItem";
            this.goToCategoryToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.goToCategoryToolStripMenuItem.Text = "Go to Category";
            this.goToCategoryToolStripMenuItem.Click += new System.EventHandler(this.goToCategoryToolStripMenuItem_Click);
            // 
            // filesBindingSource
            // 
            this.filesBindingSource.DataMember = "Files";
            this.filesBindingSource.DataSource = typeof(DataSetSearch);
            // 
            // dataSetSearch1
            // 
            this.dataSetSearch1.DataSetName = "DataSetSearch";
            this.dataSetSearch1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dataSetSearch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FormSearchResults
            // 
            this.ClientSize = new System.Drawing.Size(734, 447);
            this.Controls.Add(this.dataGridView1);
            this.DockableAreas = WeifenLuo.WinFormsUI.DockAreas.Document;
            this.Name = "FormSearchResults";
            this.Text = "Search Results";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSearchResults_FormClosing);
            this.Load += new System.EventHandler(this.FormSearchResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.filesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetSearch1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource filesBindingSource;
        private Library.DataSetSearch dataSetSearch1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem goToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToCategoryToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diskDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
    }
}
