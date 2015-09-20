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
using DisksDB.Utils;
using DisksDB.Language;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FormAbout.
	/// </summary>
	class FormAbout : FormI18N
	{
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.PictureBox pictureBox1;
		private DisksDB.Language.Label label1;
		private DisksDB.Language.Label label2;
		private DisksDB.Language.Label label3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormAbout()
		{
			InitializeComponent();

			try
			{
				this.Icon = new System.Drawing.Icon(MyResources.GetStream("App.ico"));
				this.pictureBox1.Image = new System.Drawing.Bitmap(MyResources.GetStream("wellcomeImage.png"));


				this.richTextBox1.Text = MyResources.GetText("gpl.txt");
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormAbout));
			this.buttonClose = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new DisksDB.Language.Label();
			this.label2 = new DisksDB.Language.Label();
			this.label3 = new DisksDB.Language.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonClose.Location = new System.Drawing.Point(386, 322);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.TabIndex = 0;
			this.buttonClose.Text = "Ok";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(168, 320);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(168, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(296, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "DisksDB";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(168, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(296, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Version 1.132 beta";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(168, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(296, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Build: 200602182245";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(168, 88);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(296, 224);
			this.richTextBox1.TabIndex = 5;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// linkLabel1
			// 
			this.linkLabel1.Location = new System.Drawing.Point(168, 64);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(296, 16);
			this.linkLabel1.TabIndex = 6;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://disksdb.sourceforge.net/";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DisksDBLinkClicked);
			// 
			// FormAbout
			// 
			this.AcceptButton = this.buttonClose;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(466, 351);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.buttonClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			this.ResumeLayout(false);

		}
		#endregion

		private void DisksDBLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = "http://disksdb.sourceforge.net/";
            process.Start();
		}
	}
}
