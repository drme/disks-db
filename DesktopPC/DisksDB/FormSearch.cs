/*
===========================================================================
Copyright (C) 2005 Sarunas

This file is part of DisksDB source code.

DisksDB source code is free software; you can redistribute it
and/or modify it under the terms of the GNU General Public License as
published by the Free Software Foundation; either version 2 of the License,
or (at your option) any later version.

DisksDB source code is distributed in the hope that it will be
useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with DisksDB; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
===========================================================================
*/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DisksDB.Language;
using DisksDB.DataBase;
using DisksDB.Utils;
using Label = System.Windows.Forms.Label;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for SearchForm.
	/// </summary>
	public class FormSearch : FormI18NDC
	{
		private ComboBox comboBoxSearch;
		private CheckBox checkBoxLessThan;
		private CheckBox checkBoxEquals;
		private ComboBox comboBoxMoreThan;
		private ComboBox comboBoxLessThan;
		private ComboBox comboBoxEquals;
		private FormMain mainApp;
		private DisksDB.DataBase.DataBase dataBase;
		private ErrorProvider errorProvider;
		private ToolTip toolTip;
		private CheckBox checkBoxMoreThan;
		private Button buttonSearch;
		private NumericUpDown numericUpDownMoreThan;
		private Panel panelBack;
		private NumericUpDown numericUpDownLessThan;
		private NumericUpDown numericUpDownEquals;
		private Label labelFileName;
		private IContainer components;

		public FormSearch(FormMain mainApp, DisksDB.DataBase.DataBase dataBase)
		{
			InitializeComponent();

			FillComboBoxesItems();

			this.mainApp = mainApp;
			this.dataBase = dataBase;

			this.comboBoxMoreThan.SelectedIndex = 2;
			this.comboBoxLessThan.SelectedIndex = 2;
			this.comboBoxEquals.SelectedIndex = 2;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearch));
            this.labelFileName = new System.Windows.Forms.Label();
            this.comboBoxSearch = new System.Windows.Forms.ComboBox();
            this.checkBoxMoreThan = new System.Windows.Forms.CheckBox();
            this.checkBoxLessThan = new System.Windows.Forms.CheckBox();
            this.checkBoxEquals = new System.Windows.Forms.CheckBox();
            this.comboBoxMoreThan = new System.Windows.Forms.ComboBox();
            this.comboBoxLessThan = new System.Windows.Forms.ComboBox();
            this.comboBoxEquals = new System.Windows.Forms.ComboBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelBack = new System.Windows.Forms.Panel();
            this.numericUpDownEquals = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLessThan = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMoreThan = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLessThan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoreThan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.Location = new System.Drawing.Point(8, 8);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(520, 16);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "File name:";
            // 
            // comboBoxSearch
            // 
            this.comboBoxSearch.Location = new System.Drawing.Point(8, 24);
            this.comboBoxSearch.Name = "comboBoxSearch";
            this.comboBoxSearch.Size = new System.Drawing.Size(520, 21);
            this.comboBoxSearch.TabIndex = 0;
            this.toolTip.SetToolTip(this.comboBoxSearch, "File name to search, you can use wildchars such as *, ?");
            this.comboBoxSearch.TextChanged += new System.EventHandler(this.SearchTextChanged);
            this.comboBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchKeyDown);
            // 
            // checkBoxMoreThan
            // 
            this.checkBoxMoreThan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxMoreThan.Location = new System.Drawing.Point(8, 56);
            this.checkBoxMoreThan.Name = "checkBoxMoreThan";
            this.checkBoxMoreThan.Size = new System.Drawing.Size(520, 14);
            this.checkBoxMoreThan.TabIndex = 1;
            this.checkBoxMoreThan.Text = "More than";
            this.checkBoxMoreThan.CheckedChanged += new System.EventHandler(this.MoreThanCheckedChanged);
            // 
            // checkBoxLessThan
            // 
            this.checkBoxLessThan.Location = new System.Drawing.Point(8, 128);
            this.checkBoxLessThan.Name = "checkBoxLessThan";
            this.checkBoxLessThan.Size = new System.Drawing.Size(484, 16);
            this.checkBoxLessThan.TabIndex = 4;
            this.checkBoxLessThan.Text = "Less than";
            this.checkBoxLessThan.CheckedChanged += new System.EventHandler(this.LessThanCheckedChanged);
            // 
            // checkBoxEquals
            // 
            this.checkBoxEquals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxEquals.Location = new System.Drawing.Point(8, 200);
            this.checkBoxEquals.Name = "checkBoxEquals";
            this.checkBoxEquals.Size = new System.Drawing.Size(520, 16);
            this.checkBoxEquals.TabIndex = 7;
            this.checkBoxEquals.Text = "Equals";
            this.checkBoxEquals.CheckedChanged += new System.EventHandler(this.EqualsCheckedChanged);
            // 
            // comboBoxMoreThan
            // 
            this.comboBoxMoreThan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMoreThan.Enabled = false;
            this.comboBoxMoreThan.Items.AddRange(new object[] {
            "bytes",
            "KB",
            "MB",
            "GB"});
            this.comboBoxMoreThan.Location = new System.Drawing.Point(8, 96);
            this.comboBoxMoreThan.Name = "comboBoxMoreThan";
            this.comboBoxMoreThan.Size = new System.Drawing.Size(520, 21);
            this.comboBoxMoreThan.TabIndex = 3;
            // 
            // comboBoxLessThan
            // 
            this.comboBoxLessThan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLessThan.Enabled = false;
            this.comboBoxLessThan.Items.AddRange(new object[] {
            "bytes",
            "KB",
            "MB",
            "GB"});
            this.comboBoxLessThan.Location = new System.Drawing.Point(8, 168);
            this.comboBoxLessThan.Name = "comboBoxLessThan";
            this.comboBoxLessThan.Size = new System.Drawing.Size(520, 21);
            this.comboBoxLessThan.TabIndex = 6;
            // 
            // comboBoxEquals
            // 
            this.comboBoxEquals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEquals.Enabled = false;
            this.comboBoxEquals.Items.AddRange(new object[] {
            "bytes",
            "KB",
            "MB",
            "GB"});
            this.comboBoxEquals.Location = new System.Drawing.Point(8, 240);
            this.comboBoxEquals.Name = "comboBoxEquals";
            this.comboBoxEquals.Size = new System.Drawing.Size(520, 21);
            this.comboBoxEquals.TabIndex = 9;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Location = new System.Drawing.Point(453, 270);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.SearchClick);
            // 
            // panelBack
            // 
            this.panelBack.BackColor = System.Drawing.SystemColors.Window;
            this.panelBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelBack.Controls.Add(this.numericUpDownEquals);
            this.panelBack.Controls.Add(this.numericUpDownLessThan);
            this.panelBack.Controls.Add(this.numericUpDownMoreThan);
            this.panelBack.Controls.Add(this.checkBoxLessThan);
            this.panelBack.Controls.Add(this.labelFileName);
            this.panelBack.Controls.Add(this.comboBoxSearch);
            this.panelBack.Controls.Add(this.comboBoxMoreThan);
            this.panelBack.Controls.Add(this.checkBoxMoreThan);
            this.panelBack.Controls.Add(this.comboBoxLessThan);
            this.panelBack.Controls.Add(this.checkBoxEquals);
            this.panelBack.Controls.Add(this.comboBoxEquals);
            this.panelBack.Controls.Add(this.buttonSearch);
            this.panelBack.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(540, 516);
            this.panelBack.TabIndex = 12;
            // 
            // numericUpDownEquals
            // 
            this.numericUpDownEquals.Enabled = false;
            this.numericUpDownEquals.Location = new System.Drawing.Point(8, 217);
            this.numericUpDownEquals.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDownEquals.Name = "numericUpDownEquals";
            this.numericUpDownEquals.Size = new System.Drawing.Size(520, 20);
            this.numericUpDownEquals.TabIndex = 8;
            // 
            // numericUpDownLessThan
            // 
            this.numericUpDownLessThan.Enabled = false;
            this.numericUpDownLessThan.Location = new System.Drawing.Point(8, 145);
            this.numericUpDownLessThan.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDownLessThan.Name = "numericUpDownLessThan";
            this.numericUpDownLessThan.Size = new System.Drawing.Size(520, 20);
            this.numericUpDownLessThan.TabIndex = 5;
            // 
            // numericUpDownMoreThan
            // 
            this.numericUpDownMoreThan.Enabled = false;
            this.numericUpDownMoreThan.Location = new System.Drawing.Point(8, 73);
            this.numericUpDownMoreThan.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.numericUpDownMoreThan.Name = "numericUpDownMoreThan";
            this.numericUpDownMoreThan.Size = new System.Drawing.Size(520, 20);
            this.numericUpDownMoreThan.TabIndex = 2;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FormSearch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(540, 516);
            this.CloseButton = false;
            this.Controls.Add(this.panelBack);
            this.DockableAreas = WeifenLuo.WinFormsUI.DockAreas.DockLeft;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSearch";
            this.TabText = "Search";
            this.Text = "Search";
            this.ToolTipText = "Search";
            this.Resize += new System.EventHandler(this.Resized);
            this.panelBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLessThan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMoreThan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private void SearchClick(object sender, EventArgs e)
		{
			if (false == this.buttonSearch.Enabled)
			{
				return;
			}

			try
			{
                this.mainApp.SetCursor(Cursors.WaitCursor);

                long minSize = int.MinValue;
                long maxSize = int.MaxValue;
                long equSize = 0;

                if (true == this.checkBoxMoreThan.Checked)
                {
                    minSize = (long)this.numericUpDownMoreThan.Value * ((ItemSize)this.comboBoxMoreThan.SelectedItem).Multiplier;
                }

                if (true == this.checkBoxLessThan.Checked)
                {
                    maxSize = (long)this.numericUpDownLessThan.Value * ((ItemSize)this.comboBoxLessThan.SelectedItem).Multiplier;
                }

                if (true == this.checkBoxEquals.Checked)
                {
                    equSize = (long)this.numericUpDownEquals.Value * ((ItemSize)this.comboBoxEquals.SelectedItem).Multiplier;
                }

   //             f.SetData(this.dataBase.FindFile(this.comboBoxSearch.Text, this.checkBoxMoreThan.Checked, this.checkBoxLessThan.Checked, this.checkBoxEquals.Checked, minSize, maxSize, equSize));

                object[] objs = new object[] { this.comboBoxSearch.Text, minSize, maxSize, equSize };

                this.Enabled = false;
                this.panelBack.Cursor = Cursors.WaitCursor;
                System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SearchThreadFunc));
                thread.Name = "Search thread";
                thread.Start(objs);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
		}

        private void SearchThreadFunc(object values)
        {
            object[] objs = (object[])values;

            string text = (string)objs[0];
            long minSize = (long)objs[1];
            long maxSize = (long)objs[2];
            long equSize = (long)objs[3];

            DataSetSearch ds = this.dataBase.FindFile(text, this.checkBoxMoreThan.Checked, this.checkBoxLessThan.Checked, this.checkBoxEquals.Checked, minSize, maxSize, equSize);

            this.Invoke(new SearchDoneHandler(SearchDone), ds);
        }

        private void SearchDone(DataSetSearch ds)
        {
            FormSearchResults f = this.mainApp.SearchResultsForm;

            if (null != f)
            {
                f.SetData(ds);
            }

            this.panelBack.Cursor = Cursors.Default;
            this.comboBoxSearch.Items.Add(this.comboBoxSearch.Text);
            this.Enabled = true;

            this.mainApp.SetCursor(Cursors.Default);
        }

        private delegate void SearchDoneHandler(DataSetSearch ds);
        
		private void SearchTextChanged(object sender, EventArgs e)
		{
			this.buttonSearch.Enabled = false == "".Equals(this.comboBoxSearch.Text);
		}

		private void MoreThanCheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxMoreThan.Checked == false)
			{
				this.numericUpDownMoreThan.Enabled = false;
				this.comboBoxMoreThan.Enabled = false;
			}
			else
			{
				this.numericUpDownMoreThan.Enabled = true;
				this.comboBoxMoreThan.Enabled = true;
				this.checkBoxEquals.Checked = false;
			}
		}

		private void LessThanCheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxLessThan.Checked == false)
			{
				this.numericUpDownLessThan.Enabled = false;
				this.comboBoxLessThan.Enabled = false;
			}
			else
			{
				this.numericUpDownLessThan.Enabled = true;
				this.comboBoxLessThan.Enabled = true;
				this.checkBoxEquals.Checked = false;
			}
		}

		private void EqualsCheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxEquals.Checked == false)
			{
				this.numericUpDownEquals.Enabled = false;
				this.comboBoxEquals.Enabled = false;
			}
			else
			{
				this.numericUpDownEquals.Enabled = true;
				this.comboBoxEquals.Enabled = true;
				this.checkBoxMoreThan.Checked = false;
				this.checkBoxLessThan.Checked = false;
			}
		}

		private void SearchKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.SearchClick(sender, e);
			}
		}

		private void FillComboBoxesItems()
		{
			ItemSize[] items = new ItemSize[4];
			items[0] = new ItemSize(I18N.Instance.GetText("bytes", "bytes"), 1);
			items[1] = new ItemSize(I18N.Instance.GetText("KB", "KB"), 1024);
			items[2] = new ItemSize(I18N.Instance.GetText("MB", "MB"), 1024 * 1024);
			items[3] = new ItemSize(I18N.Instance.GetText("GB", "GB"), 1024 * 1024 * 1024);

			this.comboBoxMoreThan.DataSource = items;
			this.comboBoxLessThan.DataSource = items.Clone();
			this.comboBoxEquals.DataSource = items.Clone();
		}

		protected override void LanguageChanged(object sender, EventArgs e)
		{
			base.LanguageChanged(sender, e);
			this.FillComboBoxesItems();
		}

		private void Resized(object sender, EventArgs e)
		{
			/**
			 * Anchoring does not work correctly for some controls.
			 * In order to resolve this bug, manual resizing is being performed
			 */

			int width = this.panelBack.Width - 16;

			this.numericUpDownEquals.Width = width;
			this.numericUpDownMoreThan.Width = width;
			this.numericUpDownLessThan.Width = width;

			this.comboBoxEquals.Width = width;
			this.comboBoxMoreThan.Width = width;
			this.comboBoxLessThan.Width = width;
			this.comboBoxSearch.Width = width;

			this.checkBoxEquals.Width = width;
			this.checkBoxMoreThan.Width = width;
			this.checkBoxLessThan.Width = width;

			this.labelFileName.Width = width;
		}
	}

	[Serializable()]
	internal class ItemSize
	{
		public ItemSize(string name, long multiplier)
		{
			this.name = name;
			this.mult = multiplier;
		}

		public long Multiplier
		{
			get { return this.mult; }
		}

		public override string ToString()
		{
			return this.name;
		}

		private long mult;
		private string name;
	}
}