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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	class ControlNewCover : UserControl
	{
		private PictureBox pictureBox1;
		private ComboBox comboBox1;
		private Button newButton;
		private Label topLabel;
		private Container components = null;
		private ImageFactory imgFact = null;
        private delegate Image GetImageHangler();

		public ControlNewCover()
		{
			InitializeComponent();
		}

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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.newButton = new System.Windows.Forms.Button();
			this.topLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(8, 32);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(153, 104);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(8, 146);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(73, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ImagesSelectedIndexChanged);
			// 
			// newButton
			// 
			this.newButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.newButton.BackColor = System.Drawing.SystemColors.Control;
			this.newButton.Location = new System.Drawing.Point(83, 144);
			this.newButton.Name = "newButton";
			this.newButton.Size = new System.Drawing.Size(78, 23);
			this.newButton.TabIndex = 2;
			this.newButton.Text = "New...";
			this.newButton.Click += new System.EventHandler(this.NewButtonClick);
			// 
			// topLabel
			// 
			this.topLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.topLabel.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.topLabel.Location = new System.Drawing.Point(8, 8);
			this.topLabel.Name = "topLabel";
			this.topLabel.Size = new System.Drawing.Size(152, 16);
			this.topLabel.TabIndex = 3;
			// 
			// ControlNewCover
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.topLabel);
			this.Controls.Add(this.newButton);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "ControlNewCover";
			this.Size = new System.Drawing.Size(168, 176);
			this.ResumeLayout(false);

		}

		#endregion

		public string Title
		{
			set
			{
				this.topLabel.Text = value;
			}
			get
			{
				return this.topLabel.Text;
			}
		}

		public Image Image
		{
			get
			{
				try
				{
                    return (Image)this.Invoke(new GetImageHangler(this.GetImage));
				}
				catch (Exception)
				{
                    try
                    {
                        return GetImage();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
				}
			}
		}

		private void FillImages()
		{
			try
			{
				this.comboBox1.Items.Clear();
				var images = this.imgFact.GetImages();

				foreach (Image img in images)
				{
					this.comboBox1.Items.Add(img);
				}

				if (this.comboBox1.Items.Count > 0)
				{
					this.comboBox1.SelectedIndex = 0;
				}
			}
			catch (Exception)
			{
			}
		}

		public void FillImages(ImageFactory imgFact)
		{
			this.imgFact = imgFact;
			FillImages();
		}

		private void ImagesSelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Image img = (Image) this.comboBox1.SelectedItem;
				this.pictureBox1.Image = img.Picture;
			}
			catch (Exception)
			{
			}
		}

		private void NewButtonClick(object sender, EventArgs e)
		{
			FormAddImage faddImg = new FormAddImage();
			if (DialogResult.OK == faddImg.ShowDialog())
			{
				try
				{
					Image img = this.imgFact.AddImage(faddImg.ImageTitle, faddImg.ImageFile, null);
					this.FillImages();

					foreach (Image imgLst in this.comboBox1.Items)
					{
						if (imgLst.Id == img.Id)
						{
							this.comboBox1.SelectedItem = imgLst;
							break;
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}

        private Image GetImage()
        {
            return (Image)this.comboBox1.SelectedItem;
        }
	}
}
