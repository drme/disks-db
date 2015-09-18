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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DisksDB.DataBase;
using System;
using DisksDB.Utils;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for NewCDForm.
	/// </summary>
	public class FormNewCDBox : FormWizardBase
	{
		private ControlNewCover frontPage;
		private ControlNewCover inlayPage;
		private ControlNewCover backPage;
		private ControlDonePage donePage;
		private Container components = null;
		private TabPage tabPageGeneralInfo;
		private TabPage tabPageFrontCover;
		private TabPage tabPageBackCover;
		private TabPage tabPageInlayCover;
		private TabPage tabPageDone;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox textBoxName;
		private TextBox textBoxDesc;
		private ComboBox comboBoxTyp;

		public FormNewCDBox(DisksDB.DataBase.DataBase db)
		{
			InitializeComponent();
			FillTypes(db);
			this.frontPage.FillImages(db.FrontImages);
			this.backPage.FillImages(db.BackImages);
			this.inlayPage.FillImages(db.InlayImages);

			try
			{
				this.Icon = new System.Drawing.Icon(MyResources.GetStream("App.ico"));
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
			this.frontPage = new DisksDB.UserInterface.ControlNewCover();
			this.inlayPage = new DisksDB.UserInterface.ControlNewCover();
			this.backPage = new DisksDB.UserInterface.ControlNewCover();
			this.donePage = new DisksDB.UserInterface.ControlDonePage();
			this.tabPageGeneralInfo = new System.Windows.Forms.TabPage();
			this.comboBoxTyp = new System.Windows.Forms.ComboBox();
			this.textBoxDesc = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPageFrontCover = new System.Windows.Forms.TabPage();
			this.tabPageBackCover = new System.Windows.Forms.TabPage();
			this.tabPageInlayCover = new System.Windows.Forms.TabPage();
			this.tabPageDone = new System.Windows.Forms.TabPage();
			this.pagesPanel.SuspendLayout();
			this.tabPageGeneralInfo.SuspendLayout();
			this.tabPageFrontCover.SuspendLayout();
			this.tabPageBackCover.SuspendLayout();
			this.tabPageInlayCover.SuspendLayout();
			this.tabPageDone.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Name = "pictureBox1";
			// 
			// pagesPanel
			// 
			this.pagesPanel.Controls.Add(this.tabPageGeneralInfo);
			this.pagesPanel.Controls.Add(this.tabPageFrontCover);
			this.pagesPanel.Controls.Add(this.tabPageBackCover);
			this.pagesPanel.Controls.Add(this.tabPageInlayCover);
			this.pagesPanel.Controls.Add(this.tabPageDone);
			this.pagesPanel.Name = "pagesPanel";
			// 
			// frontPage
			// 
			this.frontPage.BackColor = System.Drawing.Color.White;
			this.frontPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.frontPage.Location = new System.Drawing.Point(0, 0);
			this.frontPage.Name = "frontPage";
			this.frontPage.Size = new System.Drawing.Size(332, 303);
			this.frontPage.TabIndex = 3;
			this.frontPage.Title = "CD Box front cover";
			// 
			// inlayPage
			// 
			this.inlayPage.BackColor = System.Drawing.Color.White;
			this.inlayPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.inlayPage.Location = new System.Drawing.Point(0, 0);
			this.inlayPage.Name = "inlayPage";
			this.inlayPage.Size = new System.Drawing.Size(332, 303);
			this.inlayPage.TabIndex = 4;
			this.inlayPage.Title = "CD box inlay";
			// 
			// backPage
			// 
			this.backPage.BackColor = System.Drawing.Color.White;
			this.backPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.backPage.Location = new System.Drawing.Point(0, 0);
			this.backPage.Name = "backPage";
			this.backPage.Size = new System.Drawing.Size(332, 303);
			this.backPage.TabIndex = 5;
			this.backPage.Title = "CD Box back cover";
			// 
			// donePage
			// 
			this.donePage.BackColor = System.Drawing.Color.White;
			this.donePage.Comment = "Click finish to close this wizzard";
			this.donePage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.donePage.FinishText = "CD box successfully added";
			this.donePage.Location = new System.Drawing.Point(0, 0);
			this.donePage.Name = "donePage";
			this.donePage.Size = new System.Drawing.Size(332, 302);
			this.donePage.TabIndex = 7;
			this.donePage.Title = "Finished";
			// 
			// tabPageGeneralInfo
			// 
			this.tabPageGeneralInfo.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageGeneralInfo.Controls.Add(this.comboBoxTyp);
			this.tabPageGeneralInfo.Controls.Add(this.textBoxDesc);
			this.tabPageGeneralInfo.Controls.Add(this.label3);
			this.tabPageGeneralInfo.Controls.Add(this.label2);
			this.tabPageGeneralInfo.Controls.Add(this.textBoxName);
			this.tabPageGeneralInfo.Controls.Add(this.label1);
			this.tabPageGeneralInfo.Location = new System.Drawing.Point(4, 6);
			this.tabPageGeneralInfo.Name = "tabPageGeneralInfo";
			this.tabPageGeneralInfo.Size = new System.Drawing.Size(332, 302);
			this.tabPageGeneralInfo.TabIndex = 0;
			this.tabPageGeneralInfo.Text = "tabPage1";
			// 
			// comboBoxTyp
			// 
			this.comboBoxTyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTyp.Location = new System.Drawing.Point(8, 272);
			this.comboBoxTyp.Name = "comboBoxTyp";
			this.comboBoxTyp.Size = new System.Drawing.Size(312, 21);
			this.comboBoxTyp.TabIndex = 2;
			// 
			// textBoxDesc
			// 
			this.textBoxDesc.Location = new System.Drawing.Point(8, 64);
			this.textBoxDesc.Multiline = true;
			this.textBoxDesc.Name = "textBoxDesc";
			this.textBoxDesc.Size = new System.Drawing.Size(312, 184);
			this.textBoxDesc.TabIndex = 1;
			this.textBoxDesc.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 256);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(312, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Type";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(312, 16);
			this.label2.TabIndex = 9;
			this.label2.Text = "Description";
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(8, 24);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(312, 20);
			this.textBoxName.TabIndex = 0;
			this.textBoxName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(320, 16);
			this.label1.TabIndex = 7;
			this.label1.Text = "Box Name";
			// 
			// tabPageFrontCover
			// 
			this.tabPageFrontCover.Controls.Add(this.frontPage);
			this.tabPageFrontCover.Location = new System.Drawing.Point(4, 5);
			this.tabPageFrontCover.Name = "tabPageFrontCover";
			this.tabPageFrontCover.Size = new System.Drawing.Size(332, 303);
			this.tabPageFrontCover.TabIndex = 1;
			this.tabPageFrontCover.Text = "tabPage2";
			// 
			// tabPageBackCover
			// 
			this.tabPageBackCover.Controls.Add(this.backPage);
			this.tabPageBackCover.Location = new System.Drawing.Point(4, 5);
			this.tabPageBackCover.Name = "tabPageBackCover";
			this.tabPageBackCover.Size = new System.Drawing.Size(332, 303);
			this.tabPageBackCover.TabIndex = 2;
			this.tabPageBackCover.Text = "tabPage3";
			// 
			// tabPageInlayCover
			// 
			this.tabPageInlayCover.Controls.Add(this.inlayPage);
			this.tabPageInlayCover.Location = new System.Drawing.Point(4, 5);
			this.tabPageInlayCover.Name = "tabPageInlayCover";
			this.tabPageInlayCover.Size = new System.Drawing.Size(332, 303);
			this.tabPageInlayCover.TabIndex = 3;
			this.tabPageInlayCover.Text = "tabPage4";
			// 
			// tabPageDone
			// 
			this.tabPageDone.Controls.Add(this.donePage);
			this.tabPageDone.Location = new System.Drawing.Point(4, 6);
			this.tabPageDone.Name = "tabPageDone";
			this.tabPageDone.Size = new System.Drawing.Size(332, 302);
			this.tabPageDone.TabIndex = 4;
			this.tabPageDone.Text = "tabPage5";
			// 
			// FormNewCDBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 352);
			this.Name = "FormNewCDBox";
			this.Text = "New CD Box";
			this.Load += new System.EventHandler(this.FormNewCDBox_Load);
			this.pagesPanel.ResumeLayout(false);
			this.tabPageGeneralInfo.ResumeLayout(false);
			this.tabPageFrontCover.ResumeLayout(false);
			this.tabPageBackCover.ResumeLayout(false);
			this.tabPageInlayCover.ResumeLayout(false);
			this.tabPageDone.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void FillTypes(DisksDB.DataBase.DataBase db)
		{
			if (null == db)
			{
				return;
			}

			ArrayList lst = db.BoxTypes;

			this.comboBoxTyp.DataSource = lst;
		}

		private void FormNewCDBox_Load(object sender, System.EventArgs e)
		{
			this.textBoxName.Focus();
		}

		public string BoxName
		{
			get
			{
				return this.textBoxName.Text;
			}
			set
			{
				this.textBoxName.Text = value;
			}
		}

		public string BoxDescription
		{
			get
			{
				return this.textBoxDesc.Text;
			}
			set
			{
				this.textBoxDesc.Text = value;
			}
		}

		public BoxType BoxType
		{
			get
			{
				return (BoxType) this.comboBoxTyp.SelectedItem;
			}
		}

		public Image BoxFront
		{
			get
			{
				return this.frontPage.Image;
			}
		}

		public Image BoxBack
		{
			get
			{
				return this.backPage.Image;
			}
		}

		public Image BoxInlay
		{
			get
			{
				return this.inlayPage.Image;
			}
		}
	}
}