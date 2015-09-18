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
using System.Management;
using System.Threading;
using System.Windows.Forms;
using DisksDB.DataBase;
using DisksDB.Utils;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for NewDiskForm.
	/// </summary>
	public class FormNewDisk : FormWizardBase, IAddDiskProgress
	{
		private DisksDB.DataBase.Disk addedDisk = null;
		private delegate string GetDriveLetterDelegate();
		private delegate void AddedCDEvent();
		private ControlDonePage donePage;
		private ControlDonePage aboutToScan;
		private DataBase.Box box = null;
		private System.Windows.Forms.TabPage tabPageDisk;
		private System.Windows.Forms.TabPage tabPageDiskImage;
		private System.Windows.Forms.TabPage tabPageAboutToAdd;
		private System.Windows.Forms.TabPage tabPageAdding;
		private System.Windows.Forms.TabPage tabPageDone;
		private DisksDB.UserInterface.ControlNewCover diskImageChooser;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Label labelDiskSize;
		private System.Windows.Forms.Label labelDiskLabel;
		private System.Windows.Forms.CheckBox checkBoxAddFiles;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label labelDiskDescription;
		private System.Windows.Forms.GroupBox groupBoxDVDdrive;
		private System.Windows.Forms.Label labelDiskSizeText;
		private System.Windows.Forms.Label labelDiskLabelText;
		private System.Windows.Forms.Label labelDiskType;
		private System.Windows.Forms.Label labelDiskName;
		private System.Windows.Forms.ComboBox comboBoxDrive;
		private System.Windows.Forms.ComboBox comboBoxDiskType;
		private DisksDB.UserInterface.ControlNewCover diskImages;
		private DisksDB.UserInterface.ControlNewCover controlNewCover1;
		private System.Windows.Forms.ProgressBar progressBarAdding;
		private System.Windows.Forms.TextBox textBoxProgressLog;
		private System.Windows.Forms.Label labelScanning;
        private string driveLetter = "";
        private string diskName = "";
        private string description = "";
        private DiskType diskType = null;

		public FormNewDisk(DisksDB.DataBase.DataBase db, DataBase.Box box)
		{
			this.box = box;

			InitializeComponent();

			FillDrives();
			this.comboBoxDiskType.DataSource = db.DiskTypes;
			this.controlNewCover1.FillImages(db.DiskImages);
			this.textBoxName.Text = box.Name;
            this.diskType = (DiskType)db.DiskTypes[0];

			try
			{
				this.Icon = new System.Drawing.Icon(MyResources.GetStream("dvdbox.ico"));
				this.pictureBox1.Image = new System.Drawing.Bitmap(MyResources.GetStream("wellcomeImage.png"));
			}
			catch (Exception ex)
			{
				Logger.LogException(ex);
			}
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewDisk));
            this.donePage = new DisksDB.UserInterface.ControlDonePage();
            this.aboutToScan = new DisksDB.UserInterface.ControlDonePage();
            this.tabPageDisk = new System.Windows.Forms.TabPage();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDiskDescription = new System.Windows.Forms.Label();
            this.groupBoxDVDdrive = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelDiskSize = new System.Windows.Forms.Label();
            this.labelDiskLabel = new System.Windows.Forms.Label();
            this.labelDiskSizeText = new System.Windows.Forms.Label();
            this.labelDiskLabelText = new System.Windows.Forms.Label();
            this.comboBoxDrive = new System.Windows.Forms.ComboBox();
            this.checkBoxAddFiles = new System.Windows.Forms.CheckBox();
            this.comboBoxDiskType = new System.Windows.Forms.ComboBox();
            this.labelDiskType = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDiskName = new System.Windows.Forms.Label();
            this.tabPageDiskImage = new System.Windows.Forms.TabPage();
            this.controlNewCover1 = new DisksDB.UserInterface.ControlNewCover();
            this.diskImages = new DisksDB.UserInterface.ControlNewCover();
            this.diskImageChooser = new DisksDB.UserInterface.ControlNewCover();
            this.tabPageAboutToAdd = new System.Windows.Forms.TabPage();
            this.tabPageAdding = new System.Windows.Forms.TabPage();
            this.progressBarAdding = new System.Windows.Forms.ProgressBar();
            this.textBoxProgressLog = new System.Windows.Forms.TextBox();
            this.labelScanning = new System.Windows.Forms.Label();
            this.tabPageDone = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pagesPanel.SuspendLayout();
            this.tabPageDisk.SuspendLayout();
            this.groupBoxDVDdrive.SuspendLayout();
            this.tabPageDiskImage.SuspendLayout();
            this.tabPageAboutToAdd.SuspendLayout();
            this.tabPageAdding.SuspendLayout();
            this.tabPageDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            // 
            // pagesPanel
            // 
            this.pagesPanel.Controls.Add(this.tabPageDisk);
            this.pagesPanel.Controls.Add(this.tabPageDiskImage);
            this.pagesPanel.Controls.Add(this.tabPageAboutToAdd);
            this.pagesPanel.Controls.Add(this.tabPageAdding);
            this.pagesPanel.Controls.Add(this.tabPageDone);
            // 
            // donePage
            // 
            this.donePage.BackColor = System.Drawing.Color.White;
            this.donePage.Comment = "To close this wizard, click Finish.";
            this.donePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.donePage.FinishText = "Disk has been successfully added";
            this.donePage.Location = new System.Drawing.Point(0, 0);
            this.donePage.Name = "donePage";
            this.donePage.Size = new System.Drawing.Size(332, 302);
            this.donePage.TabIndex = 17;
            this.donePage.Title = "Disk added";
            // 
            // aboutToScan
            // 
            this.aboutToScan.BackColor = System.Drawing.Color.White;
            this.aboutToScan.Comment = "Click Next to begin adding disk";
            this.aboutToScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutToScan.FinishText = "Disk info has been collected an disk is about to be added";
            this.aboutToScan.Location = new System.Drawing.Point(0, 0);
            this.aboutToScan.Name = "aboutToScan";
            this.aboutToScan.Size = new System.Drawing.Size(332, 303);
            this.aboutToScan.TabIndex = 20;
            this.aboutToScan.Title = "About To Add Disk";
            // 
            // tabPageDisk
            // 
            this.tabPageDisk.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageDisk.Controls.Add(this.textBoxDescription);
            this.tabPageDisk.Controls.Add(this.labelDiskDescription);
            this.tabPageDisk.Controls.Add(this.groupBoxDVDdrive);
            this.tabPageDisk.Controls.Add(this.checkBoxAddFiles);
            this.tabPageDisk.Controls.Add(this.comboBoxDiskType);
            this.tabPageDisk.Controls.Add(this.labelDiskType);
            this.tabPageDisk.Controls.Add(this.textBoxName);
            this.tabPageDisk.Controls.Add(this.labelDiskName);
            this.tabPageDisk.Location = new System.Drawing.Point(4, 6);
            this.tabPageDisk.Name = "tabPageDisk";
            this.tabPageDisk.Size = new System.Drawing.Size(332, 302);
            this.tabPageDisk.TabIndex = 0;
            this.tabPageDisk.Text = "tabPage1";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(8, 192);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(312, 80);
            this.textBoxDescription.TabIndex = 7;
            // 
            // labelDiskDescription
            // 
            this.labelDiskDescription.Location = new System.Drawing.Point(8, 176);
            this.labelDiskDescription.Name = "labelDiskDescription";
            this.labelDiskDescription.Size = new System.Drawing.Size(312, 16);
            this.labelDiskDescription.TabIndex = 6;
            this.labelDiskDescription.Text = "Description";
            // 
            // groupBoxDVDdrive
            // 
            this.groupBoxDVDdrive.Controls.Add(this.buttonRefresh);
            this.groupBoxDVDdrive.Controls.Add(this.labelDiskSize);
            this.groupBoxDVDdrive.Controls.Add(this.labelDiskLabel);
            this.groupBoxDVDdrive.Controls.Add(this.labelDiskSizeText);
            this.groupBoxDVDdrive.Controls.Add(this.labelDiskLabelText);
            this.groupBoxDVDdrive.Controls.Add(this.comboBoxDrive);
            this.groupBoxDVDdrive.Location = new System.Drawing.Point(8, 88);
            this.groupBoxDVDdrive.Name = "groupBoxDVDdrive";
            this.groupBoxDVDdrive.Size = new System.Drawing.Size(312, 80);
            this.groupBoxDVDdrive.TabIndex = 5;
            this.groupBoxDVDdrive.TabStop = false;
            this.groupBoxDVDdrive.Text = "CD/DVD-ROM";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRefresh.Location = new System.Drawing.Point(232, 48);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.RefreshDiskDrives);
            // 
            // labelDiskSize
            // 
            this.labelDiskSize.Location = new System.Drawing.Point(112, 56);
            this.labelDiskSize.Name = "labelDiskSize";
            this.labelDiskSize.Size = new System.Drawing.Size(120, 16);
            this.labelDiskSize.TabIndex = 4;
            this.labelDiskSize.Text = "xx MB";
            // 
            // labelDiskLabel
            // 
            this.labelDiskLabel.Location = new System.Drawing.Point(112, 40);
            this.labelDiskLabel.Name = "labelDiskLabel";
            this.labelDiskLabel.Size = new System.Drawing.Size(120, 16);
            this.labelDiskLabel.TabIndex = 3;
            this.labelDiskLabel.Text = "Unnamed";
            // 
            // labelDiskSizeText
            // 
            this.labelDiskSizeText.Location = new System.Drawing.Point(8, 56);
            this.labelDiskSizeText.Name = "labelDiskSizeText";
            this.labelDiskSizeText.Size = new System.Drawing.Size(104, 16);
            this.labelDiskSizeText.TabIndex = 2;
            this.labelDiskSizeText.Text = "Disk size";
            // 
            // labelDiskLabelText
            // 
            this.labelDiskLabelText.Location = new System.Drawing.Point(8, 40);
            this.labelDiskLabelText.Name = "labelDiskLabelText";
            this.labelDiskLabelText.Size = new System.Drawing.Size(100, 16);
            this.labelDiskLabelText.TabIndex = 1;
            this.labelDiskLabelText.Text = "Disk label";
            // 
            // comboBoxDrive
            // 
            this.comboBoxDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrive.Location = new System.Drawing.Point(8, 16);
            this.comboBoxDrive.Name = "comboBoxDrive";
            this.comboBoxDrive.Size = new System.Drawing.Size(296, 21);
            this.comboBoxDrive.TabIndex = 0;
            this.comboBoxDrive.SelectedIndexChanged += new System.EventHandler(this.DiskDriveChanged);
            // 
            // checkBoxAddFiles
            // 
            this.checkBoxAddFiles.Checked = true;
            this.checkBoxAddFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddFiles.Location = new System.Drawing.Point(8, 280);
            this.checkBoxAddFiles.Name = "checkBoxAddFiles";
            this.checkBoxAddFiles.Size = new System.Drawing.Size(312, 16);
            this.checkBoxAddFiles.TabIndex = 4;
            this.checkBoxAddFiles.Text = "Add files";
            // 
            // comboBoxDiskType
            // 
            this.comboBoxDiskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDiskType.Location = new System.Drawing.Point(8, 64);
            this.comboBoxDiskType.Name = "comboBoxDiskType";
            this.comboBoxDiskType.Size = new System.Drawing.Size(312, 21);
            this.comboBoxDiskType.TabIndex = 3;
            this.comboBoxDiskType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDiskType_SelectedIndexChanged);
            // 
            // labelDiskType
            // 
            this.labelDiskType.Location = new System.Drawing.Point(8, 48);
            this.labelDiskType.Name = "labelDiskType";
            this.labelDiskType.Size = new System.Drawing.Size(312, 16);
            this.labelDiskType.TabIndex = 2;
            this.labelDiskType.Text = "Disk Type";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(8, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(312, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelDiskName
            // 
            this.labelDiskName.Location = new System.Drawing.Point(8, 8);
            this.labelDiskName.Name = "labelDiskName";
            this.labelDiskName.Size = new System.Drawing.Size(312, 16);
            this.labelDiskName.TabIndex = 0;
            this.labelDiskName.Text = "Disk name";
            // 
            // tabPageDiskImage
            // 
            this.tabPageDiskImage.Controls.Add(this.controlNewCover1);
            this.tabPageDiskImage.Location = new System.Drawing.Point(4, 5);
            this.tabPageDiskImage.Name = "tabPageDiskImage";
            this.tabPageDiskImage.Size = new System.Drawing.Size(332, 303);
            this.tabPageDiskImage.TabIndex = 1;
            this.tabPageDiskImage.Text = "tabPage1";
            // 
            // controlNewCover1
            // 
            this.controlNewCover1.BackColor = System.Drawing.Color.White;
            this.controlNewCover1.Location = new System.Drawing.Point(0, 0);
            this.controlNewCover1.Name = "controlNewCover1";
            this.controlNewCover1.Size = new System.Drawing.Size(328, 304);
            this.controlNewCover1.TabIndex = 0;
            this.controlNewCover1.Title = "Disk Image";
            // 
            // diskImages
            // 
            this.diskImages.BackColor = System.Drawing.Color.White;
            this.diskImages.Location = new System.Drawing.Point(0, 0);
            this.diskImages.Name = "diskImages";
            this.diskImages.Size = new System.Drawing.Size(168, 176);
            this.diskImages.TabIndex = 0;
            this.diskImages.Title = "";
            // 
            // diskImageChooser
            // 
            this.diskImageChooser.BackColor = System.Drawing.Color.White;
            this.diskImageChooser.Location = new System.Drawing.Point(0, 0);
            this.diskImageChooser.Name = "diskImageChooser";
            this.diskImageChooser.Size = new System.Drawing.Size(168, 176);
            this.diskImageChooser.TabIndex = 0;
            this.diskImageChooser.Title = "";
            // 
            // tabPageAboutToAdd
            // 
            this.tabPageAboutToAdd.Controls.Add(this.aboutToScan);
            this.tabPageAboutToAdd.Location = new System.Drawing.Point(4, 5);
            this.tabPageAboutToAdd.Name = "tabPageAboutToAdd";
            this.tabPageAboutToAdd.Size = new System.Drawing.Size(332, 303);
            this.tabPageAboutToAdd.TabIndex = 2;
            this.tabPageAboutToAdd.Text = "tabPage1";
            // 
            // tabPageAdding
            // 
            this.tabPageAdding.BackColor = System.Drawing.SystemColors.Window;
            this.tabPageAdding.Controls.Add(this.progressBarAdding);
            this.tabPageAdding.Controls.Add(this.textBoxProgressLog);
            this.tabPageAdding.Controls.Add(this.labelScanning);
            this.tabPageAdding.Location = new System.Drawing.Point(4, 5);
            this.tabPageAdding.Name = "tabPageAdding";
            this.tabPageAdding.Size = new System.Drawing.Size(332, 303);
            this.tabPageAdding.TabIndex = 3;
            // 
            // progressBarAdding
            // 
            this.progressBarAdding.Location = new System.Drawing.Point(6, 279);
            this.progressBarAdding.Name = "progressBarAdding";
            this.progressBarAdding.Size = new System.Drawing.Size(314, 16);
            this.progressBarAdding.TabIndex = 7;
            // 
            // textBoxProgressLog
            // 
            this.textBoxProgressLog.Enabled = false;
            this.textBoxProgressLog.Location = new System.Drawing.Point(6, 40);
            this.textBoxProgressLog.Multiline = true;
            this.textBoxProgressLog.Name = "textBoxProgressLog";
            this.textBoxProgressLog.Size = new System.Drawing.Size(312, 232);
            this.textBoxProgressLog.TabIndex = 6;
            // 
            // labelScanning
            // 
            this.labelScanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScanning.Location = new System.Drawing.Point(6, 7);
            this.labelScanning.Name = "labelScanning";
            this.labelScanning.Size = new System.Drawing.Size(314, 23);
            this.labelScanning.TabIndex = 5;
            this.labelScanning.Text = "Scan files";
            // 
            // tabPageDone
            // 
            this.tabPageDone.Controls.Add(this.donePage);
            this.tabPageDone.Location = new System.Drawing.Point(4, 6);
            this.tabPageDone.Name = "tabPageDone";
            this.tabPageDone.Size = new System.Drawing.Size(332, 302);
            this.tabPageDone.TabIndex = 4;
            // 
            // FormNewDisk
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(494, 350);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormNewDisk";
            this.Text = "New CD disk";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pagesPanel.ResumeLayout(false);
            this.tabPageDisk.ResumeLayout(false);
            this.tabPageDisk.PerformLayout();
            this.groupBoxDVDdrive.ResumeLayout(false);
            this.tabPageDiskImage.ResumeLayout(false);
            this.tabPageAboutToAdd.ResumeLayout(false);
            this.tabPageAdding.ResumeLayout(false);
            this.tabPageAdding.PerformLayout();
            this.tabPageDone.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public DisksDB.DataBase.Disk AddedDisk
		{
			get
			{
				return this.addedDisk;
			}
		}

		private void AddDisk()
		{
			if (this.checkBoxAddFiles.Checked == true)
			{
				Thread t = new Thread(new ThreadStart(this.AddingFilesThread));
				t.Start();
			}
			else
			{
				this.addedDisk = this.box.AddDisk(this.textBoxName.Text, (DiskType)this.comboBoxDiskType.SelectedItem, this.controlNewCover1.Image, this.DriveLetter, this, false);
				this.OnAdded();
			}
		}

		private void AddingFilesThread()
		{
			try
			{
				this.addedDisk = this.box.AddDisk(this.textBoxName.Text, this.diskType, this.controlNewCover1.Image, this.DriveLetter, this, true);
			}
			catch (Exception ex)
			{
				this.donePage.FinishText = "Error occured while adding Disk \r\n" + ex.Message + ex.StackTrace;
			}
			//this.Invoke(new AddedCDEvent(this.OnAdded));
		}
		
		private void OnAdded()
		{
			MoveNext();
		}

		public void AddingFile(string name)
		{
			//this.textBoxProgressLog.Text += "Adding " + name + "\r\n";
		}

		public bool ToCancel()
		{
			return false;
		}

		public void Failed(string message)
		{
            this.textBoxProgressLog.Invoke(new AddTextHandler(this.AddText), "Adding files failed\r\n");

			//this.textBoxProgressLog.Text += "Adding files failed\r\n";
			this.donePage.FinishText = "Error occured while adding Disk \r\n"; // + ex.Message;
			this.Invoke(new AddedCDEvent(this.OnAdded));
			this.addedDisk = null;
		}

		public void Finished()
		{
            this.textBoxProgressLog.Invoke(new AddTextHandler(this.AddText), "Adding files finished\r\n");
            //			this.textBoxProgressLog.Text += "Adding files finished\r\n";
			this.Invoke(new AddedCDEvent(this.OnAdded));
		}

		public void Canceled()
		{
            this.textBoxProgressLog.Invoke(new AddTextHandler(this.AddText), "Adding files canceled\r\n");
			//this.textBoxProgressLog.Text += "Adding files canceled\r\n";
			this.donePage.FinishText = "Error occured while adding Disk \r\n"; // + ex.Message;
			this.Invoke(new AddedCDEvent(this.OnAdded));
			this.addedDisk = null;
		}

		public void Total(long total)
		{
            this.textBoxProgressLog.Invoke(new AddTextHandler(this.AddText), "Total files: " + total + "\r\n");
            this.progressBarAdding.Invoke(new SetProgressTotalHandler(this.SetProgressTotal), (int)total);
        }

        private delegate void SetProgressTotalHandler(int total);
        private delegate void SetProgressValueHadler(int value);

        private void SetProgressTotal(int total)
        {
            this.progressBarAdding.Maximum = total;
        }

        private void SetProgressValue(int value)
        {
            this.progressBarAdding.Value = value;
        }

		public void Progress(long progress)
		{
			this.progressBarAdding.Invoke(new SetProgressValueHadler(this.SetProgressValue), (int)progress);
		}

		public void Started()
		{
            this.textBoxProgressLog.Invoke(new AddTextHandler(this.AddText), "Adding files started\r\n");
		}

		public void Message(string msg)
		{
		}

		public void TotallSmall(long totall)
		{
		}

		public void ProgressSmall(long progress)
		{
		}

		private void FillDrives()
		{
			this.comboBoxDrive.Items.Clear();

			ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT Name, Size, Description, VolumeName FROM Win32_LogicalDisk WHERE DriveType=5");
			ManagementObjectCollection queryCollection = query.Get();

			foreach (ManagementObject mo in queryCollection)
			{
				Object name = mo["Name"];
				Object size = mo["Size"];
				Object desc = mo["Description"];
				Object label = mo["VolumeName"];

				string n = ((null != name) ? (string) name : "") + " " + ((null != desc) ? (string) desc : "");
				long siz = (null != size) ? Convert.ToInt64(size) : 0;
				string lab = (null != label) ? (string) label : "";

				if (name != null)
				{
					this.comboBoxDrive.Items.Add(new DiskDrive(n, siz, lab, (string) name));
				}
			}

			if (this.comboBoxDrive.Items.Count > 0)
			{
				this.comboBoxDrive.SelectedIndex = 0;
			}
		}

		private void DiskDriveChanged(object sender, System.EventArgs e)
		{
			if (this.comboBoxDrive.SelectedItem is DiskDrive)
			{
				DiskDrive d = (DiskDrive) this.comboBoxDrive.SelectedItem;
				this.labelDiskSize.Text = Convert.ToString(d.Size/1024/1024) + " MB";
				this.labelDiskLabel.Text = d.Label;
			}		
		}

		private void RefreshDiskDrives(object sender, System.EventArgs e)
		{
			FillDrives();
		}

		private string GetDriveLetter()
		{
			if (this.comboBoxDrive.SelectedIndex >= 0)
			{
				return ((DiskDrive) this.comboBoxDrive.SelectedItem).DriveLetter;
			}
			else
			{
				return null;
			}
		}

		private string DriveLetter
		{
			get
			{
				object o = Invoke(new GetDriveLetterDelegate(GetDriveLetter));
				return (null == o) ? null : (string) o;
			}
		}

		protected override void OnNextClick()
		{
			base.OnNextClick();

			if (this.pagesPanel.SelectedTab == this.tabPageAdding)
			{
				if (null == this.DriveLetter)
				{
					MessageBox.Show("Disk drive must be selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					MoveBack();
					return;
				}

				if ("".Equals(this.textBoxName.Text))
				{
					MessageBox.Show("Not All input fields filled");
					MoveBack();
					return;
				}
				DisableButtons();
				AddDisk();
			}
		}

		private class DiskDrive
		{
			public DiskDrive(string name, long size, string label, string drive)
			{
				this.name = name;
				this.size = size;
				this.label = label;
				this.drive = drive;
			}

			public override string ToString()
			{
				return this.name;
			}

			public long Size
			{
				get
				{
					return this.size;
				}
			}

			public string Label
			{
				get
				{
					if (null == this.label)
					{
						return "";
					}
					else
					{
						return this.label;
					}
				}
			}

			public string DriveLetter
			{
				get
				{
					return this.drive;
				}
			}

			private long size = 0;
			private string name = null;
			private string label = null;
			private string drive = null;
		}

        private void AddText(string text)
        {
            this.textBoxProgressLog.Text += text;
        }

        private delegate void AddTextHandler(string text);

        private void comboBoxDiskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.diskType = (DiskType)this.comboBoxDiskType.SelectedItem;
        }
	}
}
