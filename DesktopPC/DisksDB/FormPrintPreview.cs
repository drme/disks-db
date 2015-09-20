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
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for FormPrintPreview.
	/// </summary>
	class FormPrintPreview : FormPrintable
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox comboBoxZoom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
		private FormPrintable printableForm = null;

		public FormPrintPreview(FormPrintable fp)
		{
			this.printableForm = fp;

			InitializeComponent();

			this.propertyGrid1.SelectedObject = fp.PrintProperties;
			this.printPreviewControl1.Document = fp.PrintDocument;
			fp.SourceChanged += new EventHandler(RefreshClick);

			this.comboBoxZoom.SelectedIndex = 7;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormPrintPreview));
			this.panel1 = new System.Windows.Forms.Panel();
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxZoom = new System.Windows.Forms.ComboBox();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.printPreviewControl1);
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(752, 405);
			this.panel1.TabIndex = 0;
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.AutoZoom = false;
			this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Size = new System.Drawing.Size(748, 292);
			this.printPreviewControl1.TabIndex = 3;
			this.printPreviewControl1.Zoom = 0.3;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Highlight;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 292);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(748, 5);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Info;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.comboBoxZoom);
			this.panel2.Controls.Add(this.propertyGrid1);
			this.panel2.Controls.Add(this.button1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 297);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(748, 104);
			this.panel2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(336, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Zoom";
			// 
			// comboBoxZoom
			// 
			this.comboBoxZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxZoom.Items.AddRange(new object[] {
															  "10 %",
															  "20 %",
															  "30 %",
															  "40 %",
															  "50 %",
															  "60 %",
															  "70 %",
															  "80 %",
															  "90 %",
															  "100 %"});
			this.comboBoxZoom.Location = new System.Drawing.Point(336, 32);
			this.comboBoxZoom.Name = "comboBoxZoom";
			this.comboBoxZoom.Size = new System.Drawing.Size(121, 21);
			this.comboBoxZoom.TabIndex = 7;
			this.comboBoxZoom.SelectedIndexChanged += new System.EventHandler(this.ZoomChanged);
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.propertyGrid1.CommandsBackColor = System.Drawing.SystemColors.Info;
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(8, 8);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(320, 88);
			this.propertyGrid1.TabIndex = 6;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Location = new System.Drawing.Point(664, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "Update";
			this.button1.Click += new System.EventHandler(this.RefreshClick);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(17, 17);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// FormPrintPreview
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(752, 405);
			this.Controls.Add(this.panel1);
			this.Name = "FormPrintPreview";
			this.NeedPrinting = true;
			this.NeedPrintPreview = false;
			this.Text = "Print Preview";
			this.Load += new System.EventHandler(this.PrintPreviewLoad);
			this.Closed += new System.EventHandler(this.PrintPreviewClosed);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override DialogResult ShowPageSetup()
		{
			if (DialogResult.OK == this.printableForm.ShowPageSetup())
			{
				this.printPreviewControl1.InvalidatePreview();

				return DialogResult.OK;
			}

			return DialogResult.Cancel;
		}

		public override void Print()
		{
			this.printableForm.Print();
		}

		private void ZoomChanged(object sender, System.EventArgs e)
		{
			this.printPreviewControl1.Zoom = ((float)this.comboBoxZoom.SelectedIndex + 1.0f) * 0.1f;
		}

		private void RefreshClick(object sender, EventArgs e)
		{
			this.printPreviewControl1.InvalidatePreview();
		}

		private void PrintPreviewClosed(object sender, System.EventArgs e)
		{
			this.printableForm.SourceChanged -=	new EventHandler(RefreshClick);
		}

		private void PrintPreviewLoad(object sender, System.EventArgs e)
		{
			this.splitter1.Location = new Point(0, this.Height - 105);
		}
	}
}
