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
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Base Form for all properties dialogs.
	/// </summary>
	public class FormPropertiesBase : Form
	{
		private Button applyButton;
		private Button cancelButton;
		private Button okButton;
		protected TabControl tabControl1;
		protected TabPage tabPage1;
		protected Label label1;
		protected Label label3;
		protected TextBox textBoxDescription;
		protected TextBox textBoxTitle;
		protected bool loaded = false;
		protected ToolTip toolTip1;
		protected HelpProvider helpProvider1;
		private IContainer components;

		public FormPropertiesBase()
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

		protected virtual void SaveChanges()
		{
			MessageBox.Show("SAVE CHANGES");
		}

		protected void SetUpdated()
		{
			this.applyButton.Enabled = true;
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.applyButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// applyButton
			// 
			this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.applyButton.Enabled = false;
			this.applyButton.Location = new System.Drawing.Point(240, 360);
			this.applyButton.Name = "applyButton";
			this.applyButton.TabIndex = 0;
			this.applyButton.Text = "Apply";
			this.toolTip1.SetToolTip(this.applyButton, "Applies changes");
			this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.helpProvider1.SetHelpKeyword(this.cancelButton, "asdfasdfasdf");
			this.helpProvider1.SetHelpString(this.cancelButton, "dfasdf");
			this.cancelButton.Location = new System.Drawing.Point(160, 360);
			this.cancelButton.Name = "cancelButton";
			this.helpProvider1.SetShowHelp(this.cancelButton, true);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Cancel";
			this.toolTip1.SetToolTip(this.cancelButton, "Rejects changes and closes window");
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(80, 360);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.toolTip1.SetToolTip(this.okButton, "Acepts changes and closes window");
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(304, 344);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBoxDescription);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.textBoxTitle);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(296, 318);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			// 
			// textBoxDescription
			// 
			this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxDescription.Location = new System.Drawing.Point(8, 64);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(280, 248);
			this.textBoxDescription.TabIndex = 5;
			this.textBoxDescription.Text = "textBoxDescription";
			this.textBoxDescription.TextChanged += new System.EventHandler(this.textBoxDescription_TextChanged);
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(280, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Description";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTitle.Location = new System.Drawing.Point(8, 24);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(280, 20);
			this.textBoxTitle.TabIndex = 1;
			this.textBoxTitle.Text = "textBoxTitle";
			this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(280, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title";
			// 
			// FormPropertiesBase
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(320, 389);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.applyButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPropertiesBase";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Properties";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormPropertiesBase_Closing);
			this.Load += new System.EventHandler(this.FormPropertiesBase_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private void applyButton_Click(object sender, EventArgs e)
		{
			SaveChanges();
			this.applyButton.Enabled = false;
		}

		private void FormPropertiesBase_Closing(object sender, CancelEventArgs e)
		{
			if (DialogResult.OK == this.DialogResult)
			{
				if (true == this.applyButton.Enabled)
				{
					try
					{
						SaveChanges();
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						e.Cancel = true;
					}
				}
			}
		}

		private void FormPropertiesBase_Load(object sender, EventArgs e)
		{
			this.applyButton.Enabled = false;
			loaded = true;
		}

		private void textBoxTitle_TextChanged(object sender, EventArgs e)
		{
			if (loaded == true)
			{
				SetUpdated();
			}
		}

		private void textBoxDescription_TextChanged(object sender, EventArgs e)
		{
			if (loaded == true)
			{
				SetUpdated();
			}
		}
	}
}