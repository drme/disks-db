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
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using DisksDB.DataBase;
using Image = System.Drawing.Image;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FormImagePreview.
	/// </summary>
	public class FormImagePreview : FormPrintable
	{
		private Panel panel1;
		private PictureBox pictureBox1;
		private PrintDocument printDocument;
		private CoverProperties coverProperties = new CoverProperties();
        private DataBase.Image image = null;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private IContainer components;

		public FormImagePreview()
		{
			InitializeComponent();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.ContextMenuStrip = this.contextMenuStrip1;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 269);
            this.panel1.TabIndex = 0;
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.exportToolStripMenuItem.Text = "Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintPage);
            this.printDocument.QueryPageSettings += new System.Drawing.Printing.QueryPageSettingsEventHandler(this.QueryPageSettings);
            // 
            // FormImagePreview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(592, 269);
            this.Controls.Add(this.panel1);
            this.DockableAreas = WeifenLuo.WinFormsUI.DockAreas.Document;
            this.Name = "FormImagePreview";
            this.NeedPrinting = true;
            this.TabText = "Image Preview";
            this.Text = "Image Preview";
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		public void ShowImage(DataBase.Image img)
		{
			if (null != img)
			{
				this.pictureBox1.Image = img.Picture;
				this.pictureBox1.Width = img.Picture.Width;
				this.pictureBox1.Height = img.Picture.Height;
				this.image = img;

				switch (img.ImageType)
				{
					case EnumImageCategories.FrontImage:
						this.coverProperties.Width = 120;
						this.coverProperties.Height = 120;
						this.printDocument.DefaultPageSettings.Landscape = true;
						break;
					case EnumImageCategories.BackImage:
						this.coverProperties.Width = 151;
						this.coverProperties.Height = 118;
						this.printDocument.DefaultPageSettings.Landscape = false;
						break;
					default:
						break;
				}

				base.OnSourceChanged(EventArgs.Empty);
			}
			else
			{
				this.pictureBox1.Image = null;
			}

            this.panel1_Resize(null, EventArgs.Empty);
		}

		private void PrintPage(object sender, PrintPageEventArgs e)
		{
			if (null == this.image)
			{
				e.HasMorePages = false;

				return;
			}

			float xOffset = e.PageBounds.Left + e.MarginBounds.Left;
			float yOffset = e.PageBounds.Top + e.MarginBounds.Top;

			if (this.image.ImageType == EnumImageCategories.FrontImage)
			{
				float width = this.coverProperties.Width/2.54f*10.0f;
				float height = this.coverProperties.Height/2.54f*10.0f;

				if (null != this.pictureBox1.Image)
				{
					e.Graphics.DrawImage(this.pictureBox1.Image, xOffset + width, yOffset + 0, width, height);
				}

				e.Graphics.DrawRectangle(Pens.Black, xOffset + 0, yOffset + 0, width, height);
				e.Graphics.DrawRectangle(Pens.Black, xOffset + width, yOffset + 0, width, height);
			}
			else if (this.image.ImageType == EnumImageCategories.BackImage)
			{
				float width = this.coverProperties.Width/2.54f*10.0f;
				float height = this.coverProperties.Height/2.54f*10.0f;

				if (null != this.pictureBox1.Image)
				{
					e.Graphics.DrawImage(this.pictureBox1.Image, xOffset + 0, yOffset + 0, width, height);
				}

				e.Graphics.DrawRectangle(Pens.Black, xOffset + 0, yOffset + 0, width, height);
			}

			e.HasMorePages = false;
		}

		private void QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
			//e.PageSettings.Landscape = true;
		}

		public Image SelectedImage
		{
			get { return this.pictureBox1.Image; }
		}

		public override PrintDocument PrintDocument
		{
			get { return this.printDocument; }
		}

		public override DocumentProperties PrintProperties
		{
			get { return this.coverProperties; }
		}

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.ExportImage(this.image, this);
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (null != this.pictureBox1.Image)
            {
                float ratio = ((float)this.panel1.Width / (float)this.panel1.Height);
                float r = ((float)this.pictureBox1.Image.Width / (float)this.pictureBox1.Image.Height);

                if (ratio > 1.0f)
                {
                    this.pictureBox1.Height = this.panel1.Height - 16;
                    this.pictureBox1.Width = (int)(this.pictureBox1.Height * r);
                }
                else
                {
                    this.pictureBox1.Width = this.panel1.Width - 16;
                    this.pictureBox1.Height = (int)(this.pictureBox1.Width * r);
                }

                if (this.pictureBox1.Width > this.panel1.Width - 16)
                {
                    this.pictureBox1.Width = this.panel1.Width - 16;
                    this.pictureBox1.Height = (int)(this.pictureBox1.Width / r);
                } 
            }
        }
	}

	public class CoverProperties : DocumentProperties
	{
		[DefaultValue(122)]
		public int Width
		{
			get { return width; }
			set { width = value; }
		}

		[DefaultValue(122)]
		public int Height
		{
			get { return height; }
			set { height = value; }
		}

		private int width = 122;
		private int height = 122;
	}
}