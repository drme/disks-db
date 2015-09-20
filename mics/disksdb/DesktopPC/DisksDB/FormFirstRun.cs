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
using System.Drawing;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FormFirstRun.
	/// </summary>
	class FormFirstRun : FormWizardBase
	{
		private System.Windows.Forms.TabPage tabPage4;
		private DisksDB.UserInterface.ControlDonePage controlDonePage1;
		private System.Windows.Forms.ComboBox comboBoxLanguage;
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.ComboBox comboBoxDbLayers;
		private System.Windows.Forms.Label label4;
		private DisksDB.Language.Label label5;
		private DisksDB.Language.Label labelTitle;
		private DisksDB.Language.Label labelNext;
		private DisksDB.Language.Label labelTitleBottom;
		private DisksDB.Language.Label labelTitleStep1;
		private DisksDB.Language.Label labelTitleStep2;
		private System.Windows.Forms.TabPage tabPageTitle;
		private System.Windows.Forms.TabPage tabPageLanguage;
		private System.Windows.Forms.Label labelUserInterfaceLanguage;
		private System.Windows.Forms.TabPage tabPageDataBase;
		private System.Windows.Forms.Label labelDataBase;
		private DisksDB.DataBase.DataBase db;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormFirstRun(DisksDB.DataBase.DataBase db)
		{
			this.db = db;
			InitializeComponent();

			try
			{
				this.Icon = new Icon(MyResources.GetStream("App.ico"));
				this.pictureBox1.Image = new System.Drawing.Bitmap(MyResources.GetStream("wellcomeImage.png"));
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormFirstRun));
			this.tabPageLanguage = new System.Windows.Forms.TabPage();
			this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
			this.labelUserInterfaceLanguage = new System.Windows.Forms.Label();
			this.tabPageDataBase = new System.Windows.Forms.TabPage();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.comboBoxDbLayers = new System.Windows.Forms.ComboBox();
			this.labelDataBase = new System.Windows.Forms.Label();
			this.tabPageTitle = new System.Windows.Forms.TabPage();
			this.labelTitleStep2 = new DisksDB.Language.Label();
			this.labelTitleStep1 = new DisksDB.Language.Label();
			this.labelTitleBottom = new DisksDB.Language.Label();
			this.labelNext = new DisksDB.Language.Label();
			this.labelTitle = new DisksDB.Language.Label();
			this.label5 = new DisksDB.Language.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.controlDonePage1 = new DisksDB.UserInterface.ControlDonePage();
			this.pagesPanel.SuspendLayout();
			this.tabPageLanguage.SuspendLayout();
			this.tabPageDataBase.SuspendLayout();
			this.tabPageTitle.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Name = "pictureBox1";
			// 
			// pagesPanel
			// 
			this.pagesPanel.Controls.Add(this.tabPageTitle);
			this.pagesPanel.Controls.Add(this.tabPageLanguage);
			this.pagesPanel.Controls.Add(this.tabPageDataBase);
			this.pagesPanel.Controls.Add(this.tabPage4);
			this.pagesPanel.Name = "pagesPanel";
			// 
			// tabPageLanguage
			// 
			this.tabPageLanguage.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageLanguage.Controls.Add(this.comboBoxLanguage);
			this.tabPageLanguage.Controls.Add(this.labelUserInterfaceLanguage);
			this.tabPageLanguage.Location = new System.Drawing.Point(4, 5);
			this.tabPageLanguage.Name = "tabPageLanguage";
			this.tabPageLanguage.Size = new System.Drawing.Size(332, 303);
			this.tabPageLanguage.TabIndex = 0;
			// 
			// comboBoxLanguage
			// 
			this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLanguage.Location = new System.Drawing.Point(8, 32);
			this.comboBoxLanguage.Name = "comboBoxLanguage";
			this.comboBoxLanguage.Size = new System.Drawing.Size(312, 21);
			this.comboBoxLanguage.TabIndex = 1;
			this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.LanguageIndexChanged);
			// 
			// labelUserInterfaceLanguage
			// 
			this.labelUserInterfaceLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelUserInterfaceLanguage.Location = new System.Drawing.Point(8, 8);
			this.labelUserInterfaceLanguage.Name = "labelUserInterfaceLanguage";
			this.labelUserInterfaceLanguage.Size = new System.Drawing.Size(312, 24);
			this.labelUserInterfaceLanguage.TabIndex = 0;
			this.labelUserInterfaceLanguage.Text = "User interface language";
			// 
			// tabPageDataBase
			// 
			this.tabPageDataBase.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageDataBase.Controls.Add(this.propertyGrid);
			this.tabPageDataBase.Controls.Add(this.comboBoxDbLayers);
			this.tabPageDataBase.Location = new System.Drawing.Point(4, 5);
			this.tabPageDataBase.Name = "tabPageDataBase";
			this.tabPageDataBase.Size = new System.Drawing.Size(332, 303);
			this.tabPageDataBase.TabIndex = 1;
			this.tabPageDataBase.Text = "tabPage2";
			// 
			// propertyGrid
			// 
			this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid.CommandsBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.CommandsVisibleIfAvailable = true;
			this.propertyGrid.HelpVisible = false;
			this.propertyGrid.LargeButtons = false;
			this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid.Location = new System.Drawing.Point(8, 56);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(312, 240);
			this.propertyGrid.TabIndex = 2;
			this.propertyGrid.Text = "propertyGrid1";
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// comboBoxDbLayers
			// 
			this.comboBoxDbLayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxDbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxDbLayers.Location = new System.Drawing.Point(8, 32);
			this.comboBoxDbLayers.Name = "comboBoxDbLayers";
			this.comboBoxDbLayers.Size = new System.Drawing.Size(312, 21);
			this.comboBoxDbLayers.TabIndex = 1;
			this.comboBoxDbLayers.SelectedIndexChanged += new System.EventHandler(this.LayerChanged);
			// 
			// labelDataBase
			// 
			this.labelDataBase.Location = new System.Drawing.Point(0, 0);
			this.labelDataBase.Name = "labelDataBase";
			this.labelDataBase.TabIndex = 0;
			// 
			// tabPageTitle
			// 
			this.tabPageTitle.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageTitle.Controls.Add(this.labelTitleStep2);
			this.tabPageTitle.Controls.Add(this.labelTitleStep1);
			this.tabPageTitle.Controls.Add(this.labelTitleBottom);
			this.tabPageTitle.Controls.Add(this.labelNext);
			this.tabPageTitle.Controls.Add(this.labelTitle);
			this.tabPageTitle.Location = new System.Drawing.Point(4, 5);
			this.tabPageTitle.Name = "tabPageTitle";
			this.tabPageTitle.Size = new System.Drawing.Size(332, 303);
			this.tabPageTitle.TabIndex = 2;
			// 
			// labelTitleStep2
			// 
			this.labelTitleStep2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitleStep2.Location = new System.Drawing.Point(8, 120);
			this.labelTitleStep2.Name = "labelTitleStep2";
			this.labelTitleStep2.Size = new System.Drawing.Size(312, 23);
			this.labelTitleStep2.TabIndex = 4;
			this.labelTitleStep2.Text = "● Disks database files location selection";
			// 
			// labelTitleStep1
			// 
			this.labelTitleStep1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitleStep1.Location = new System.Drawing.Point(8, 96);
			this.labelTitleStep1.Name = "labelTitleStep1";
			this.labelTitleStep1.Size = new System.Drawing.Size(312, 24);
			this.labelTitleStep1.TabIndex = 3;
			this.labelTitleStep1.Text = "● User interface language selection";
			// 
			// labelTitleBottom
			// 
			this.labelTitleBottom.Location = new System.Drawing.Point(8, 56);
			this.labelTitleBottom.Name = "labelTitleBottom";
			this.labelTitleBottom.Size = new System.Drawing.Size(312, 40);
			this.labelTitleBottom.TabIndex = 2;
			this.labelTitleBottom.Text = "This setup wizard will help to set your application. It consists of two steps:";
			// 
			// labelNext
			// 
			this.labelNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelNext.Location = new System.Drawing.Point(8, 280);
			this.labelNext.Name = "labelNext";
			this.labelNext.Size = new System.Drawing.Size(312, 16);
			this.labelNext.TabIndex = 1;
			this.labelNext.Text = "Click \"Next\" to continue";
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(8, 16);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(312, 23);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "This is a great time to setup you application";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(0, 0);
			this.label5.Name = "label5";
			this.label5.TabIndex = 0;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.controlDonePage1);
			this.tabPage4.Location = new System.Drawing.Point(4, 5);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(332, 303);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "tabPage4";
			// 
			// controlDonePage1
			// 
			this.controlDonePage1.BackColor = System.Drawing.Color.White;
			this.controlDonePage1.Comment = "Click finish to close this wizzard.";
			this.controlDonePage1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlDonePage1.FinishText = "You can further customize you application by choosing Tools->Options menu.";
			this.controlDonePage1.Location = new System.Drawing.Point(0, 0);
			this.controlDonePage1.Name = "controlDonePage1";
			this.controlDonePage1.Size = new System.Drawing.Size(332, 303);
			this.controlDonePage1.TabIndex = 1;
			this.controlDonePage1.Title = "Setup done";
			// 
			// FormFirstRun
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(494, 350);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormFirstRun";
			this.Text = "DisksDB setup wizzard";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormFirstRunClosing);
			this.Load += new System.EventHandler(this.FormLoaded);
			this.pagesPanel.ResumeLayout(false);
			this.tabPageLanguage.ResumeLayout(false);
			this.tabPageDataBase.ResumeLayout(false);
			this.tabPageTitle.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormLoaded(object sender, System.EventArgs e)
		{
			this.comboBoxLanguage.DataSource = Language.I18N.Instance.Languages;
			this.comboBoxLanguage.DisplayMember = "Name";
			this.comboBoxLanguage.ValueMember = "Id";

			Language.Language lng = Language.I18N.Instance.Language;

			foreach (Language.Language lng1 in this.comboBoxLanguage.Items)
			{
				if (lng1.Id == lng.Id)
				{
					this.comboBoxLanguage.SelectedItem = lng1;
					break;
				}
			}

			this.comboBoxDbLayers.DataSource = new DisksDB.DataBase.DBLayersScanner().LoadModules();
		}

		private void LanguageIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				Language.I18N.Instance.Language = (Language.Language)this.comboBoxLanguage.SelectedItem;
			} 
			catch (Exception)
			{
			}		
		}

		private void LayerChanged(object sender, System.EventArgs e)
		{
			try
			{
				DBLayerItem di = (DBLayerItem)this.comboBoxDbLayers.SelectedItem;
				this.propertyGrid.SelectedObject = di.Layer.ConfigObject;
			}
			catch (Exception)
			{
			}		
		}

		private void FormFirstRunClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				DBLayerItem di = (DBLayerItem)this.comboBoxDbLayers.SelectedItem;
				DisksDB.Config.Config.Instance.SetValue("DefaultLayerFile", di.FullPath);
				DisksDB.Config.Config.Instance.SetValue("DefaultLayerClass", di.ClassName);
                di.Layer.SaveConfig(DisksDB.Config.Config.Instance);
				di.InitDataBase(true);
				this.db.SetDataBase(di.FullPath, di.ClassName);
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
		}
	}
}
