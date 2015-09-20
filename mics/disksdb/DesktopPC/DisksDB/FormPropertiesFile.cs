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
using System.ComponentModel;

namespace DisksDB.UserInterface
{
	class FormPropertiesFile : FormPropertiesBase
	{
		private IContainer components = null;

		public FormPropertiesFile(TreeNodeFile f)
		{
			InitializeComponent();

			this.textBoxTitle.Text = f.GetName();
			
			if (f.GetSize() >= 0)
			{
				this.textBoxDescription.Text += "File Size: " + f.GetSize() + " bytes\r\n";
			}

			this.textBoxDescription.Text += "Creation date : " + f.GetDate().ToString();

			this.Text = f.GetName() + " - Properties";
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

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Name = "tabControl1";
			// 
			// tabPage1
			// 
			this.tabPage1.Name = "tabPage1";
			// 
			// label1
			// 
			this.label1.Name = "label1";
			// 
			// label3
			// 
			this.label3.Name = "label3";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.Text = "";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.ReadOnly = true;
			this.textBoxTitle.Text = "";
			// 
			// FormPropertiesFile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 389);
			this.Name = "FormPropertiesFile";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
	}
}