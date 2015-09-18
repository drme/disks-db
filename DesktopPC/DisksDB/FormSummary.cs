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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FormSummary.
	/// </summary>
	public class FormSummary : WeifenLuo.WinFormsUI.DockContent
	{
		private System.Windows.Forms.Panel panelBack;
		private DisksDB.UserInterface.ControlMyTab tabControl1;
		private System.Windows.Forms.TabPage tabPageCategory;
		private System.Windows.Forms.TabPage tabPageBox;
		private System.Windows.Forms.TabPage tabPageDisk;
		private System.Windows.Forms.TabPage tabPageFolder;
		private System.Windows.Forms.TabPage tabPageImage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.Label labelFolderName;
		private DisksDB.Language.Label label6;
		private DisksDB.Language.Label labelFolderDate;
		private PanelIcon panelFolderIcon;
		private DisksDB.UserInterface.PanelIcon panelCategoryIcon;
		private System.Windows.Forms.Label labelCategoryName;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBoxImage;
		private System.Windows.Forms.Label labelCategoryDescription;
		private DisksDB.DataBase.BaseObject activeItem;

		public FormSummary()
		{
			InitializeComponent();
			this.panelFolderIcon.BackIcon = FileIcons.GetFolderIcon(null, true, true);
			this.panelCategoryIcon.BackIcon = FileIcons.GetFolderIcon(null, true, true);
		}

		public void ShowItem(DisksDB.DataBase.Image image)
		{
			SetItem(image);

			try
			{
				this.pictureBoxImage.Image = image.Picture;
				this.pictureBoxImage.Size = image.Picture.Size;
			}
			catch (Exception ex)
			{
			}

			this.tabControl1.SelectedTab = this.tabPageImage;
		}

		public void ShowItem(DisksDB.DataBase.File file)
		{
			SetItem(file);

			this.labelFolderName.Text = file.Name;
			this.labelFolderDate.Text = file.Date.ToString();
			this.tabControl1.SelectedTab = this.tabPageFolder;
		}

		public void ShowItem(DisksDB.DataBase.Category category)
		{
			SetItem(category);

			this.labelCategoryName.Text = category.Name;
			this.labelCategoryDescription.Text = category.Description;
			this.tabControl1.SelectedTab = this.tabPageCategory;
		}

		public void ShowItem(DisksDB.DataBase.Disk disk)
		{
			SetItem(disk);

			if (null != disk.Image.Picture)
			{
				this.pictureBox1.Image = disk.Image.Picture;
			}

			this.label1.Text = disk.Name;
			this.label2.Text = "";
			this.tabControl1.SelectedTab = this.tabPageDisk;
		}

		public void ShowItem(DisksDB.DataBase.Box box)
		{
			SetItem(box);

			if (null != box.FrontCover.Picture)
			{
				this.pictureBox2.Image = box.FrontCover.Picture;
			}

			if (null != box.BackCover.Picture)
			{
				this.pictureBox3.Image = box.BackCover.Picture;
			}

			if (null != box.InlayCover.Picture)
			{
				this.pictureBox4.Image = box.InlayCover.Picture;
			}

			this.label3.Text = box.Name;
			this.label4.Text = box.Description;
	
			this.tabControl1.SelectedTab = this.tabPageBox;
		}

		public void ShowItem(DisksDB.DataBase.BaseObject baseObject)
		{
			if (null == baseObject)
			{
				return;
			}

			if (baseObject is Disk)
			{
				this.ShowItem((Disk)baseObject);
			} 
			else if (baseObject is Box)
			{
				this.ShowItem((Box)baseObject);
			}
			else if (baseObject is File)
			{
				this.ShowItem((File)baseObject);
			}
			else if (baseObject is Category)
			{
				this.ShowItem((Category)baseObject);
			}
			else if (baseObject is DisksDB.DataBase.Image)
			{
				this.ShowItem((DisksDB.DataBase.Image)baseObject);
			}
		}

		private void SetItem(DisksDB.DataBase.BaseObject item)
		{
			if (this.activeItem != item)
			{
				if (null != this.activeItem)
				{
					this.activeItem.NameChanged -= new EventHandler(ItemNameChanged);
				}

				this.activeItem = item;

				item.NameChanged += new EventHandler(ItemNameChanged);
			}
		}

		private void ItemNameChanged(object sender, EventArgs e)
		{
			ShowItem(this.activeItem);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelBack = new System.Windows.Forms.Panel();
			this.tabControl1 = new DisksDB.UserInterface.ControlMyTab();
			this.tabPageCategory = new System.Windows.Forms.TabPage();
			this.panelCategoryIcon = new DisksDB.UserInterface.PanelIcon();
			this.labelCategoryName = new System.Windows.Forms.Label();
			this.tabPageBox = new System.Windows.Forms.TabPage();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPageFolder = new System.Windows.Forms.TabPage();
			this.panelFolderIcon = new DisksDB.UserInterface.PanelIcon();
			this.labelFolderDate = new DisksDB.Language.Label();
			this.label6 = new DisksDB.Language.Label();
			this.labelFolderName = new System.Windows.Forms.Label();
			this.tabPageImage = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.tabPageDisk = new System.Windows.Forms.TabPage();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelCategoryDescription = new System.Windows.Forms.Label();
			this.panelBack.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageCategory.SuspendLayout();
			this.tabPageBox.SuspendLayout();
			this.tabPageFolder.SuspendLayout();
			this.tabPageImage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPageDisk.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelBack
			// 
			this.panelBack.BackColor = System.Drawing.SystemColors.Window;
			this.panelBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelBack.Controls.Add(this.tabControl1);
			this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelBack.Location = new System.Drawing.Point(0, 0);
			this.panelBack.Name = "panelBack";
			this.panelBack.Size = new System.Drawing.Size(856, 421);
			this.panelBack.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.BackBrushColor = System.Drawing.Color.White;
			this.tabControl1.Controls.Add(this.tabPageCategory);
			this.tabControl1.Controls.Add(this.tabPageBox);
			this.tabControl1.Controls.Add(this.tabPageFolder);
			this.tabControl1.Controls.Add(this.tabPageImage);
			this.tabControl1.Controls.Add(this.tabPageDisk);
			this.tabControl1.Location = new System.Drawing.Point(0, -20);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(852, 436);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPageCategory
			// 
			this.tabPageCategory.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageCategory.Controls.Add(this.labelCategoryDescription);
			this.tabPageCategory.Controls.Add(this.panelCategoryIcon);
			this.tabPageCategory.Controls.Add(this.labelCategoryName);
			this.tabPageCategory.Location = new System.Drawing.Point(4, 25);
			this.tabPageCategory.Name = "tabPageCategory";
			this.tabPageCategory.Size = new System.Drawing.Size(844, 407);
			this.tabPageCategory.TabIndex = 0;
			this.tabPageCategory.Text = "Category";
			// 
			// panelCategoryIcon
			// 
			this.panelCategoryIcon.BackIcon = null;
			this.panelCategoryIcon.Location = new System.Drawing.Point(8, 8);
			this.panelCategoryIcon.Name = "panelCategoryIcon";
			this.panelCategoryIcon.Size = new System.Drawing.Size(32, 32);
			this.panelCategoryIcon.TabIndex = 11;
			// 
			// labelCategoryName
			// 
			this.labelCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCategoryName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelCategoryName.Location = new System.Drawing.Point(48, 16);
			this.labelCategoryName.Name = "labelCategoryName";
			this.labelCategoryName.Size = new System.Drawing.Size(784, 23);
			this.labelCategoryName.TabIndex = 8;
			// 
			// tabPageBox
			// 
			this.tabPageBox.AutoScroll = true;
			this.tabPageBox.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageBox.Controls.Add(this.pictureBox4);
			this.tabPageBox.Controls.Add(this.pictureBox3);
			this.tabPageBox.Controls.Add(this.pictureBox2);
			this.tabPageBox.Controls.Add(this.label4);
			this.tabPageBox.Controls.Add(this.label3);
			this.tabPageBox.Location = new System.Drawing.Point(4, 25);
			this.tabPageBox.Name = "tabPageBox";
			this.tabPageBox.Size = new System.Drawing.Size(844, 407);
			this.tabPageBox.TabIndex = 1;
			this.tabPageBox.Text = "Box";
			// 
			// pictureBox4
			// 
			this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox4.Location = new System.Drawing.Point(490, 488);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(264, 240);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 4;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox3.Location = new System.Drawing.Point(490, 264);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(264, 216);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 3;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox2.Location = new System.Drawing.Point(490, 16);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(264, 240);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 2;
			this.pictureBox2.TabStop = false;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(8, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(474, 336);
			this.label4.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(474, 23);
			this.label3.TabIndex = 0;
			// 
			// tabPageFolder
			// 
			this.tabPageFolder.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageFolder.Controls.Add(this.panelFolderIcon);
			this.tabPageFolder.Controls.Add(this.labelFolderDate);
			this.tabPageFolder.Controls.Add(this.label6);
			this.tabPageFolder.Controls.Add(this.labelFolderName);
			this.tabPageFolder.Location = new System.Drawing.Point(4, 25);
			this.tabPageFolder.Name = "tabPageFolder";
			this.tabPageFolder.Size = new System.Drawing.Size(844, 407);
			this.tabPageFolder.TabIndex = 3;
			this.tabPageFolder.Text = "Folder";
			// 
			// panelFolderIcon
			// 
			this.panelFolderIcon.BackIcon = null;
			this.panelFolderIcon.Location = new System.Drawing.Point(8, 8);
			this.panelFolderIcon.Name = "panelFolderIcon";
			this.panelFolderIcon.Size = new System.Drawing.Size(32, 32);
			this.panelFolderIcon.TabIndex = 7;
			// 
			// labelFolderDate
			// 
			this.labelFolderDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelFolderDate.Location = new System.Drawing.Point(112, 48);
			this.labelFolderDate.Name = "labelFolderDate";
			this.labelFolderDate.Size = new System.Drawing.Size(720, 23);
			this.labelFolderDate.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 48);
			this.label6.Name = "label6";
			this.label6.TabIndex = 2;
			this.label6.Text = "Creation date:";
			// 
			// labelFolderName
			// 
			this.labelFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelFolderName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelFolderName.Location = new System.Drawing.Point(48, 16);
			this.labelFolderName.Name = "labelFolderName";
			this.labelFolderName.Size = new System.Drawing.Size(784, 23);
			this.labelFolderName.TabIndex = 1;
			// 
			// tabPageImage
			// 
			this.tabPageImage.Controls.Add(this.panel1);
			this.tabPageImage.Location = new System.Drawing.Point(4, 25);
			this.tabPageImage.Name = "tabPageImage";
			this.tabPageImage.Size = new System.Drawing.Size(844, 407);
			this.tabPageImage.TabIndex = 5;
			this.tabPageImage.Text = "Image";
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.SystemColors.Window;
			this.panel1.Controls.Add(this.pictureBoxImage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(844, 407);
			this.panel1.TabIndex = 0;
			// 
			// pictureBoxImage
			// 
			this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(448, 296);
			this.pictureBoxImage.TabIndex = 0;
			this.pictureBoxImage.TabStop = false;
			// 
			// tabPageDisk
			// 
			this.tabPageDisk.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageDisk.Controls.Add(this.pictureBox1);
			this.tabPageDisk.Controls.Add(this.label2);
			this.tabPageDisk.Controls.Add(this.label1);
			this.tabPageDisk.Location = new System.Drawing.Point(4, 25);
			this.tabPageDisk.Name = "tabPageDisk";
			this.tabPageDisk.Size = new System.Drawing.Size(844, 407);
			this.tabPageDisk.TabIndex = 2;
			this.tabPageDisk.Text = "Disk";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(488, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(352, 352);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(464, 328);
			this.label2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(464, 23);
			this.label1.TabIndex = 0;
			// 
			// labelCategoryDescription
			// 
			this.labelCategoryDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCategoryDescription.Location = new System.Drawing.Point(8, 48);
			this.labelCategoryDescription.Name = "labelCategoryDescription";
			this.labelCategoryDescription.Size = new System.Drawing.Size(824, 352);
			this.labelCategoryDescription.TabIndex = 12;
			// 
			// FormSummary
			// 
			this.AllowRedocking = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 421);
			this.Controls.Add(this.panelBack);
			this.DockableAreas = WeifenLuo.WinFormsUI.DockAreas.Document;
			this.Name = "FormSummary";
			this.TabText = "Summary";
			this.Text = "Summary";
			this.panelBack.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPageCategory.ResumeLayout(false);
			this.tabPageBox.ResumeLayout(false);
			this.tabPageFolder.ResumeLayout(false);
			this.tabPageImage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tabPageDisk.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
