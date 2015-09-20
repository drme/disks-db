/*
===========================================================================
Copyright (C) 2015 Sarunas

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
using DisksDB.DataBase;
using DisksDB.Utils;
using System;
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FormOptions.
	/// </summary>
	class FormOptions : Form
	{
		private Button buttonOk;
		private ListView listView1;
		private Label labelTitle;
		private Label label1;
		private ComboBox comboBox1;
		private DisksDB.DataBase.DataBase db;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private DisksDB.UserInterface.ControlMyTab tabControl1;
		private System.Windows.Forms.TabPage tabPageDataBase;
		private System.Windows.Forms.TabPage tabPageUserInterface;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBoxLanguage;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TabPage tabPagePocketPC;
		private System.Windows.Forms.CheckBox checkBoxAllowSync;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.CheckBox cbUseActiveSync;
		private System.ComponentModel.IContainer components;

		public FormOptions(DisksDB.DataBase.DataBase db)
		{
			this.db = db;
			InitializeComponent();
			this.imageList.Images.Add(MyResources.GetBitmap("database.png"));
            this.imageList.Images.Add(FileIcons.GetSystemIcon(141, true));
            this.imageList.Images.Add(FileIcons.GetSystemIcon(200, true));
            this.listView1.Items[0].ImageIndex = 0;
            this.listView1.Items[1].ImageIndex = 1;
            this.listView1.Items[2].ImageIndex = 2;
            this.comboBox1.DataSource = new DisksDB.DataBase.DBLayersScanner().LoadModules();

            this.checkBoxAllowSync.Checked = SyncServer.Instance.IsRunning;
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Data Base");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("User Interface");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Pocket PC");
            this.buttonOk = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.labelTitle = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tabControl1 = new DisksDB.UserInterface.ControlMyTab();
            this.tabPageDataBase = new System.Windows.Forms.TabPage();
            this.buttonReset = new System.Windows.Forms.Button();
            this.tabPageUserInterface = new System.Windows.Forms.TabPage();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPagePocketPC = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUseActiveSync = new System.Windows.Forms.CheckBox();
            this.checkBoxAllowSync = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageDataBase.SuspendLayout();
            this.tabPageUserInterface.SuspendLayout();
            this.tabPagePocketPC.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(568, 434);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listView1.LargeImageList = this.imageList;
            this.listView1.Location = new System.Drawing.Point(8, 8);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(96, 418);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.StateImageList = this.imageList;
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList.ImageSize = new System.Drawing.Size(32, 32);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.labelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(112, 8);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(608, 23);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Data Base";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DisplayMember = "Name";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(8, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(600, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "ClassName";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Base Access Layer";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid1.Location = new System.Drawing.Point(8, 64);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(600, 290);
            this.propertyGrid1.TabIndex = 4;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackBrushColor = System.Drawing.SystemColors.Control;
            this.tabControl1.Controls.Add(this.tabPageDataBase);
            this.tabControl1.Controls.Add(this.tabPageUserInterface);
            this.tabControl1.Controls.Add(this.tabPagePocketPC);
            this.tabControl1.Location = new System.Drawing.Point(104, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 418);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageDataBase
            // 
            this.tabPageDataBase.Controls.Add(this.buttonReset);
            this.tabPageDataBase.Controls.Add(this.label1);
            this.tabPageDataBase.Controls.Add(this.comboBox1);
            this.tabPageDataBase.Controls.Add(this.propertyGrid1);
            this.tabPageDataBase.Location = new System.Drawing.Point(4, 25);
            this.tabPageDataBase.Name = "tabPageDataBase";
            this.tabPageDataBase.Size = new System.Drawing.Size(616, 389);
            this.tabPageDataBase.TabIndex = 0;
            this.tabPageDataBase.Text = "Data Base";
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(536, 362);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Initialize";
            this.toolTip.SetToolTip(this.buttonReset, "Initializes database");
            this.buttonReset.Click += new System.EventHandler(this.InitializeClick);
            // 
            // tabPageUserInterface
            // 
            this.tabPageUserInterface.Controls.Add(this.comboBoxLanguage);
            this.tabPageUserInterface.Controls.Add(this.label2);
            this.tabPageUserInterface.Location = new System.Drawing.Point(4, 25);
            this.tabPageUserInterface.Name = "tabPageUserInterface";
            this.tabPageUserInterface.Size = new System.Drawing.Size(616, 389);
            this.tabPageUserInterface.TabIndex = 1;
            this.tabPageUserInterface.Text = "User Interface";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.Location = new System.Drawing.Point(8, 32);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(600, 21);
            this.comboBoxLanguage.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Language";
            // 
            // tabPagePocketPC
            // 
            this.tabPagePocketPC.Controls.Add(this.textBox1);
            this.tabPagePocketPC.Controls.Add(this.label3);
            this.tabPagePocketPC.Controls.Add(this.cbUseActiveSync);
            this.tabPagePocketPC.Controls.Add(this.checkBoxAllowSync);
            this.tabPagePocketPC.Location = new System.Drawing.Point(4, 25);
            this.tabPagePocketPC.Name = "tabPagePocketPC";
            this.tabPagePocketPC.Size = new System.Drawing.Size(616, 389);
            this.tabPagePocketPC.TabIndex = 2;
            this.tabPagePocketPC.Text = "Pocket PC";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(8, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(600, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(600, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Syncrozniation application on Pocket PC (no need to edit)";
            this.label3.Visible = false;
            // 
            // cbUseActiveSync
            // 
            this.cbUseActiveSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUseActiveSync.Location = new System.Drawing.Point(8, 32);
            this.cbUseActiveSync.Name = "cbUseActiveSync";
            this.cbUseActiveSync.Size = new System.Drawing.Size(600, 24);
            this.cbUseActiveSync.TabIndex = 1;
            this.cbUseActiveSync.Text = "Start synchronization on Deveice connection";
            this.cbUseActiveSync.Visible = false;
            // 
            // checkBoxAllowSync
            // 
            this.checkBoxAllowSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxAllowSync.Location = new System.Drawing.Point(8, 8);
            this.checkBoxAllowSync.Name = "checkBoxAllowSync";
            this.checkBoxAllowSync.Size = new System.Drawing.Size(600, 24);
            this.checkBoxAllowSync.TabIndex = 0;
            this.checkBoxAllowSync.Text = "Allow synching with Pocket PC";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(649, 434);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(728, 463);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(734, 488);
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormOptions_Closing);
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDataBase.ResumeLayout(false);
            this.tabPageUserInterface.ResumeLayout(false);
            this.tabPagePocketPC.ResumeLayout(false);
            this.tabPagePocketPC.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private void FormOptions_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (DialogResult.OK == this.DialogResult)
			{
				try
				{
					DBLayerItem di = (DBLayerItem)this.comboBox1.SelectedItem;
					//string xml = Serializer.ObjectToString(di.Layer.ConfigObject);
					//DisksDB.Config.Config.Instance.SetValue("Layer " + di.ClassName, xml);
					this.db.SetDataBase(di.FullPath, di.ClassName);
					//this.db.SetConfig(di.Layer.ConfigObject);

					DisksDB.Config.Config.Instance.SetValue("DefaultLayerFile", di.FullPath);
					DisksDB.Config.Config.Instance.SetValue("DefaultLayerClass", di.ClassName);

                    di.Layer.SaveConfig(DisksDB.Config.Config.Instance);

					try
					{
						Language.I18N.Instance.Language = (Language.Language)this.comboBoxLanguage.SelectedItem;
					} 
					catch (Exception) {}

                    //if (true == this.cbUseActiveSync.Checked)
                    //{
                    //    DisksDB.DataBase.DataBase.Instance.WriteRegistryKeys();						
                    //}
                    //else
                    //{
                    //    DisksDB.DataBase.DataBase.Instance.RemoveRegistryKeys();
                    //}

                    Config.Config.Instance.SetValue("SyncServerRunning", this.checkBoxAllowSync.Checked);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.Message);
				}
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				DBLayerItem di = (DBLayerItem)this.comboBox1.SelectedItem;
				this.propertyGrid1.SelectedObject = di.Layer.ConfigObject;
			}
			catch (Exception ex)
			{
                Logger.LogException(ex);
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.labelTitle.Text = this.tabControl1.SelectedTab.Text;
		}

		private void FormOptions_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.comboBoxLanguage.DataSource = Language.I18N.Instance.Languages;
				this.comboBoxLanguage.DisplayMember = "Name";
				this.comboBoxLanguage.ValueMember = "Id";

				Language.Language lng = Language.I18N.Instance.Language;

                if (null != lng)
                {
                    foreach (Language.Language lng1 in this.comboBoxLanguage.Items)
                    {
                        if (lng1.Id == lng.Id)
                        {
                            this.comboBoxLanguage.SelectedItem = lng1;
                            break;
                        }
                    }
                }

				this.cbUseActiveSync.Checked = DataBase.DataBase.Instance.IsActiveSync;

                this.comboBox1_SelectedIndexChanged(sender, e);
			}
			catch (Exception ex)
			{
                Logger.LogException(ex);
			}
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.listView1.Items[0].Selected == true)
			{
				this.tabControl1.SelectedIndex = 0;
			}
			else if (this.listView1.Items[1].Selected == true)
			{
				this.tabControl1.SelectedIndex = 1;
			}
			else if (this.listView1.Items[2].Selected == true)
			{
				this.tabControl1.SelectedIndex = 2;
			}
		}

		private void InitializeClick(object sender, System.EventArgs e)
		{
			DBLayerItem di = (DBLayerItem)this.comboBox1.SelectedItem;
			di.InitDataBase(false);
		}
	}
}
