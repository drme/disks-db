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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using DisksDB.DataBase;
using DisksDB.Utils;

namespace DisksDB.UserInterface
{
	public class FormCopyDataBase : DisksDB.UserInterface.FormWizardBase, IProgress
	{
		private System.Windows.Forms.PropertyGrid propertyGrid;
		private System.Windows.Forms.ComboBox comboBox1;
		private DisksDB.Language.Label label1;
		private DisksDB.Language.Label label2;
		private System.Windows.Forms.TabPage tabPageStart;
		private System.Windows.Forms.TabPage tabPageTargetDataBase;
		private System.Windows.Forms.TabPage tabPageMigtationProgress;
		private System.Windows.Forms.TabPage tabPageDone;
		private DisksDB.Language.Label label4;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ProgressBar progressBarFilesDone;
		private System.Windows.Forms.Label labelDisk;
		private System.Windows.Forms.TextBox textBoxTransferLog;
		private DisksDB.UserInterface.ControlDonePage controlDonePage1;
		private DisksDB.UserInterface.ControlDonePage controlDonePage2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBarTotall;
		private System.Windows.Forms.TabPage tabPageBegin;
		private DisksDB.UserInterface.ControlDonePage controlDonePage3;
		private DisksDB.DataBase.DataBase dataBase;

		public FormCopyDataBase(DisksDB.DataBase.DataBase dataBase)
		{
			this.dataBase = dataBase;

			InitializeComponent();

			try
			{
				this.Icon = new Icon(MyResources.GetStream("database.ico"));
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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabPageStart = new System.Windows.Forms.TabPage();
			this.controlDonePage2 = new DisksDB.UserInterface.ControlDonePage();
			this.tabPageTargetDataBase = new System.Windows.Forms.TabPage();
			this.label2 = new DisksDB.Language.Label();
			this.label1 = new DisksDB.Language.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.tabPageMigtationProgress = new System.Windows.Forms.TabPage();
			this.progressBarTotall = new System.Windows.Forms.ProgressBar();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxTransferLog = new System.Windows.Forms.TextBox();
			this.labelDisk = new System.Windows.Forms.Label();
			this.progressBarFilesDone = new System.Windows.Forms.ProgressBar();
			this.label4 = new DisksDB.Language.Label();
			this.tabPageDone = new System.Windows.Forms.TabPage();
			this.controlDonePage1 = new DisksDB.UserInterface.ControlDonePage();
			this.tabPageBegin = new System.Windows.Forms.TabPage();
			this.controlDonePage3 = new DisksDB.UserInterface.ControlDonePage();
			this.pagesPanel.SuspendLayout();
			this.tabPageStart.SuspendLayout();
			this.tabPageTargetDataBase.SuspendLayout();
			this.tabPageMigtationProgress.SuspendLayout();
			this.tabPageDone.SuspendLayout();
			this.tabPageBegin.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Name = "pictureBox1";
			// 
			// pagesPanel
			// 
			this.pagesPanel.Controls.Add(this.tabPageStart);
			this.pagesPanel.Controls.Add(this.tabPageTargetDataBase);
			this.pagesPanel.Controls.Add(this.tabPageBegin);
			this.pagesPanel.Controls.Add(this.tabPageMigtationProgress);
			this.pagesPanel.Controls.Add(this.tabPageDone);
			this.pagesPanel.Name = "pagesPanel";
			// 
			// tabPageStart
			// 
			this.tabPageStart.Controls.Add(this.controlDonePage2);
			this.tabPageStart.Location = new System.Drawing.Point(4, 6);
			this.tabPageStart.Name = "tabPageStart";
			this.tabPageStart.Size = new System.Drawing.Size(332, 302);
			this.tabPageStart.TabIndex = 0;
			this.tabPageStart.Text = "tabPage1";
			// 
			// controlDonePage2
			// 
			this.controlDonePage2.BackColor = System.Drawing.Color.White;
			this.controlDonePage2.Comment = "Click Next to begin";
			this.controlDonePage2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlDonePage2.FinishText = "This wizzard will help you to copy your data to another database.";
			this.controlDonePage2.Location = new System.Drawing.Point(0, 0);
			this.controlDonePage2.Name = "controlDonePage2";
			this.controlDonePage2.Size = new System.Drawing.Size(332, 302);
			this.controlDonePage2.TabIndex = 0;
			this.controlDonePage2.Title = "Transfer DataBase";
			// 
			// tabPageTargetDataBase
			// 
			this.tabPageTargetDataBase.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageTargetDataBase.Controls.Add(this.label2);
			this.tabPageTargetDataBase.Controls.Add(this.label1);
			this.tabPageTargetDataBase.Controls.Add(this.comboBox1);
			this.tabPageTargetDataBase.Controls.Add(this.propertyGrid);
			this.tabPageTargetDataBase.Location = new System.Drawing.Point(4, 5);
			this.tabPageTargetDataBase.Name = "tabPageTargetDataBase";
			this.tabPageTargetDataBase.Size = new System.Drawing.Size(332, 303);
			this.tabPageTargetDataBase.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(8, 280);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(312, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Click \"Next\" to begin copying.";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Destination database";
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(8, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(312, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.LAyerChanged);
			// 
			// propertyGrid
			// 
			this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.propertyGrid.CommandsBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.CommandsVisibleIfAvailable = true;
			this.propertyGrid.HelpVisible = false;
			this.propertyGrid.LargeButtons = false;
			this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid.Location = new System.Drawing.Point(8, 48);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new System.Drawing.Size(312, 224);
			this.propertyGrid.TabIndex = 0;
			this.propertyGrid.Text = "propertyGrid1";
			this.propertyGrid.ToolbarVisible = false;
			this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// tabPageMigtationProgress
			// 
			this.tabPageMigtationProgress.BackColor = System.Drawing.SystemColors.Window;
			this.tabPageMigtationProgress.Controls.Add(this.progressBarTotall);
			this.tabPageMigtationProgress.Controls.Add(this.label3);
			this.tabPageMigtationProgress.Controls.Add(this.textBoxTransferLog);
			this.tabPageMigtationProgress.Controls.Add(this.labelDisk);
			this.tabPageMigtationProgress.Controls.Add(this.progressBarFilesDone);
			this.tabPageMigtationProgress.Controls.Add(this.label4);
			this.tabPageMigtationProgress.Location = new System.Drawing.Point(4, 6);
			this.tabPageMigtationProgress.Name = "tabPageMigtationProgress";
			this.tabPageMigtationProgress.Size = new System.Drawing.Size(332, 302);
			this.tabPageMigtationProgress.TabIndex = 2;
			// 
			// progressBarTotall
			// 
			this.progressBarTotall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarTotall.Location = new System.Drawing.Point(8, 80);
			this.progressBarTotall.Name = "progressBarTotall";
			this.progressBarTotall.Size = new System.Drawing.Size(312, 16);
			this.progressBarTotall.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(312, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Disk files:";
			// 
			// textBoxTransferLog
			// 
			this.textBoxTransferLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTransferLog.Location = new System.Drawing.Point(8, 144);
			this.textBoxTransferLog.Multiline = true;
			this.textBoxTransferLog.Name = "textBoxTransferLog";
			this.textBoxTransferLog.ReadOnly = true;
			this.textBoxTransferLog.Size = new System.Drawing.Size(312, 151);
			this.textBoxTransferLog.TabIndex = 3;
			this.textBoxTransferLog.Text = "";
			// 
			// labelDisk
			// 
			this.labelDisk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDisk.Location = new System.Drawing.Point(8, 32);
			this.labelDisk.Name = "labelDisk";
			this.labelDisk.Size = new System.Drawing.Size(312, 40);
			this.labelDisk.TabIndex = 2;
			// 
			// progressBarFilesDone
			// 
			this.progressBarFilesDone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBarFilesDone.Location = new System.Drawing.Point(8, 120);
			this.progressBarFilesDone.Name = "progressBarFilesDone";
			this.progressBarFilesDone.Size = new System.Drawing.Size(312, 16);
			this.progressBarFilesDone.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(312, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Transferring database";
			// 
			// tabPageDone
			// 
			this.tabPageDone.Controls.Add(this.controlDonePage1);
			this.tabPageDone.Location = new System.Drawing.Point(4, 6);
			this.tabPageDone.Name = "tabPageDone";
			this.tabPageDone.Size = new System.Drawing.Size(332, 302);
			this.tabPageDone.TabIndex = 3;
			// 
			// controlDonePage1
			// 
			this.controlDonePage1.BackColor = System.Drawing.Color.White;
			this.controlDonePage1.Comment = "Click Finish to close this wizard";
			this.controlDonePage1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlDonePage1.FinishText = "Data Base migration has been successfully completed. You now can switch database " +
				"by using Tools->Options menu.";
			this.controlDonePage1.Location = new System.Drawing.Point(0, 0);
			this.controlDonePage1.Name = "controlDonePage1";
			this.controlDonePage1.Size = new System.Drawing.Size(332, 302);
			this.controlDonePage1.TabIndex = 1;
			this.controlDonePage1.Title = "Migration is completed";
			// 
			// tabPageBegin
			// 
			this.tabPageBegin.Controls.Add(this.controlDonePage3);
			this.tabPageBegin.Location = new System.Drawing.Point(4, 6);
			this.tabPageBegin.Name = "tabPageBegin";
			this.tabPageBegin.Size = new System.Drawing.Size(332, 302);
			this.tabPageBegin.TabIndex = 4;
			this.tabPageBegin.Text = "tabPageBegin";
			// 
			// controlDonePage3
			// 
			this.controlDonePage3.BackColor = System.Drawing.Color.White;
			this.controlDonePage3.Comment = "To continue click next";
			this.controlDonePage3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.controlDonePage3.FinishText = "Continuing removes all data on target database and adds new data from source data" +
				"base.";
			this.controlDonePage3.Location = new System.Drawing.Point(0, 0);
			this.controlDonePage3.Name = "controlDonePage3";
			this.controlDonePage3.Size = new System.Drawing.Size(332, 302);
			this.controlDonePage3.TabIndex = 0;
			this.controlDonePage3.Title = "Begin transfer";
			// 
			// FormCopyDataBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(494, 350);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormCopyDataBase";
			this.Text = "Transfer DataBase";
			this.Load += new System.EventHandler(this.FormLoad);
			this.pagesPanel.ResumeLayout(false);
			this.tabPageStart.ResumeLayout(false);
			this.tabPageTargetDataBase.ResumeLayout(false);
			this.tabPageMigtationProgress.ResumeLayout(false);
			this.tabPageDone.ResumeLayout(false);
			this.tabPageBegin.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormLoad(object sender, System.EventArgs e)
		{
			this.comboBox1.DataSource = new DisksDB.DataBase.DBLayersScanner().LoadModules();
		}

		private void LAyerChanged(object sender, System.EventArgs e)
		{
			try
			{
				DBLayerItem di = (DBLayerItem)this.comboBox1.SelectedItem;
				//this.propertyGrid.SelectedObject = di.Layer.ConfigObject;
			}
			catch (Exception)
			{
			}		
		}

		private void ThreadProc()
		{
			DBLayerItem di = (DBLayerItem)this.comboBox1.SelectedItem;
			this.dataBase.TransferDataBase(di.Layer, this);
			this.CanClose = true;
			MoveNext();
		}

		private void CopyDataBase()
		{
			Thread thread = new Thread(new ThreadStart(ThreadProc));

			thread.Start();
		}

		protected override void OnNextClick()
		{
			base.OnNextClick();

			if (this.pagesPanel.SelectedTab == this.tabPageMigtationProgress)
			{
				this.CanClose = false;
				DisableButtons();
				CopyDataBase();
			}
		}	

		public void Finished()
		{
		}

		public void Canceled()
		{
		}

		public void Total(long total)
		{
			this.progressBarTotall.Maximum = (int)total;
		}

		public bool ToCancel()
		{
			return false;
		}

		public void Failed(string message)
		{
		}

		public void Progress(long progress)
		{
			if (progress > this.progressBarTotall.Maximum)
			{
				return;
			}

			this.progressBarTotall.Value = (int)progress;
		}

		public void Started()
		{
		}

		public void Message(string message)
		{
			Invoke(new EventHandlerTransferDiskMessage(TransferDiskMessage), new object[] { message } );
		}

		private void TransferDiskMessage(string msg)
		{
			this.labelDisk.Text = "Transerring disk " + msg;
			this.textBoxTransferLog.Text += "Transerring disk " + msg + "\r\n";
		}

		public void TotallSmall(long total)
		{
			this.progressBarFilesDone.Maximum = (int)total;
		}

		public void ProgressSmall(long progress)
		{
			if (progress > this.progressBarFilesDone.Maximum)
			{
				return;
			}

			this.progressBarFilesDone.Value = (int)progress;
		}

		private delegate void EventHandlerTransferDiskMessage(string msg);
	}
}
