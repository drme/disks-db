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
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Image panel for showing some images (like: front covers, back covers, ...)
	/// </summary>
	class ControlImagePanel : UserControl
	{
		public delegate void ChangeHandler(object sender, EventArgs e);

		private PictureBox imageBox;
		private Button newButton;
		private ComboBox imagesBox;
		public event ChangeHandler Changed;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ControlImagePanel()
		{
			InitializeComponent();

			this.ReadOnly = false;
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.imageBox = new System.Windows.Forms.PictureBox();
			this.newButton = new System.Windows.Forms.Button();
			this.imagesBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// imageBox
			// 
			this.imageBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.imageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.imageBox.Location = new System.Drawing.Point(8, 8);
			this.imageBox.Name = "imageBox";
			this.imageBox.Size = new System.Drawing.Size(168, 96);
			this.imageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imageBox.TabIndex = 0;
			this.imageBox.TabStop = false;
			// 
			// newButton
			// 
			this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.newButton.Enabled = false;
			this.newButton.Location = new System.Drawing.Point(104, 112);
			this.newButton.Name = "newButton";
			this.newButton.TabIndex = 1;
			this.newButton.Text = "New...";
			this.newButton.Click += new System.EventHandler(this.newButton_Click);
			// 
			// imagesBox
			// 
			this.imagesBox.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.imagesBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.imagesBox.Location = new System.Drawing.Point(8, 112);
			this.imagesBox.Name = "imagesBox";
			this.imagesBox.Size = new System.Drawing.Size(88, 21);
			this.imagesBox.TabIndex = 2;
			this.imagesBox.SelectedIndexChanged += new System.EventHandler(this.imagesBox_SelectedIndexChanged);
			// 
			// ImagePanel
			// 
			this.Controls.Add(this.imagesBox);
			this.Controls.Add(this.newButton);
			this.Controls.Add(this.imageBox);
			this.Name = "ImagePanel";
			this.Size = new System.Drawing.Size(184, 144);
			this.ResumeLayout(false);

		}

		#endregion

		public void ShowImage(Image img)
		{
			if (null == img)
			{
				return;
			}

			foreach (Image i in this.imagesBox.Items)
			{
				if (i.Id == img.Id)
				{
					this.imagesBox.SelectedItem = i;
				}
			}
		}

		public Image SelectedImage
		{
			get
			{
				return (Image) this.imagesBox.SelectedItem;
			}
		}

		public bool ReadOnly
		{
			get
			{
				return !this.imageBox.Enabled;
			}
			set
			{
				this.imageBox.Enabled = !value;
				this.newButton.Enabled = !value;
				//this.resetButton.Enabled = !value;
			}
		}

		private void imagesBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.imageBox.Image = ((Image) this.imagesBox.SelectedItem).Picture;

			if (null != Changed)
			{
				Changed(sender, e);
			}
		}

		public void FillList()
		{
			if (null != imgFact)
			{
				this.imagesBox.Items.Clear();

				foreach (Object o in imgFact.GetImages())
				{
					this.imagesBox.Items.Add(o);
				}
			}
		}

		private void newButton_Click(object sender, EventArgs e)
		{
			FormAddImage f = new FormAddImage();
			f.ShowDialog();
			if (f.DialogResult == DialogResult.OK)
			{
				try
				{
					Image img = this.imgFact.AddImage(f.ImageTitle, f.ImageFile, null);
					this.FillList();

					foreach (Image imgLst in this.imagesBox.Items)
					{
						if (imgLst.Id == img.Id)
						{
							this.imagesBox.SelectedItem = imgLst;
							break;
						}
					}

				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					Debug.WriteLine(ex.StackTrace);
				}
			}
			f.Dispose();
		}

		public ImageFactory ImgFact
		{
			set
			{
				imgFact = value;
				FillList();
			}
		}

		private ImageFactory imgFact = null;
	}
}