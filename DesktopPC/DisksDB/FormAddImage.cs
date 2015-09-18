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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;
using DisksDB.Utils;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for AddImageForm.
	/// </summary>
	public class FormAddImage : FormWizardBase
	{
		private string imageFileName = string.Empty;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBoxImagePreview;
		private System.Windows.Forms.Button buttonChooseImage;
		private System.Windows.Forms.TextBox textBoxName;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public FormAddImage()
		{
			InitializeComponent();

			try
			{
				this.Icon = FileIcons.GetFileIcon(".bmp");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAddImage));
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonChooseImage = new System.Windows.Forms.Button();
			this.pictureBoxImagePreview = new System.Windows.Forms.PictureBox();
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pagesPanel.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Name = "pictureBox1";
			// 
			// pagesPanel
			// 
			this.pagesPanel.Controls.Add(this.tabPage1);
			this.pagesPanel.Name = "pagesPanel";
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
			this.tabPage1.Controls.Add(this.buttonChooseImage);
			this.tabPage1.Controls.Add(this.pictureBoxImagePreview);
			this.tabPage1.Controls.Add(this.textBoxName);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(332, 303);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// buttonChooseImage
			// 
			this.buttonChooseImage.BackColor = System.Drawing.SystemColors.Control;
			this.buttonChooseImage.Location = new System.Drawing.Point(296, 272);
			this.buttonChooseImage.Name = "buttonChooseImage";
			this.buttonChooseImage.Size = new System.Drawing.Size(24, 23);
			this.buttonChooseImage.TabIndex = 3;
			this.buttonChooseImage.Text = "...";
			this.buttonChooseImage.Click += new System.EventHandler(this.ButtonChooseClick);
			// 
			// pictureBoxImagePreview
			// 
			this.pictureBoxImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxImagePreview.Location = new System.Drawing.Point(8, 48);
			this.pictureBoxImagePreview.Name = "pictureBoxImagePreview";
			this.pictureBoxImagePreview.Size = new System.Drawing.Size(312, 248);
			this.pictureBoxImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxImagePreview.TabIndex = 2;
			this.pictureBoxImagePreview.TabStop = false;
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(8, 24);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(312, 20);
			this.textBoxName.TabIndex = 1;
			this.textBoxName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Image name";
			// 
			// FormAddImage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(494, 350);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormAddImage";
			this.Text = "Add Image";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormAddImageClosing);
			this.pagesPanel.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void ButtonChooseClick(object sender, System.EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "Image files (*.jpg, *.png)|*.jpg;*.png|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;

			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.imageFileName = openFileDialog.FileName;

				string[] names = openFileDialog.FileName.Split('/', '\\');
				string name = "";

				if (names.Length > 0)
				{
					name = names[names.Length - 1];
				}

				this.textBoxName.Text = name;
				this.pictureBoxImagePreview.Image = null;
				this.pictureBoxImagePreview.Image = new Bitmap(openFileDialog.FileName);
				this.pictureBoxImagePreview.Update();
			}		
		}

		private void FormAddImageClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (DialogResult.OK == this.DialogResult)
			{
				if ( ("".Equals(this.textBoxName)) || ("".Equals(this.imageFileName)) )
				{
					MessageBox.Show(this, "Please select image and specify name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
					e.Cancel = true;
				}
			}
		}

		public string ImageTitle
		{
			get
			{
				return this.textBoxName.Text;
			}
		}

		public string ImageFile
		{
			get
			{
				return this.imageFileName;
			}
		}
	}
}