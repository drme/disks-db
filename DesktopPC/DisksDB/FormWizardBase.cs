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
	/// Summary description for AddImageForm.
	/// </summary>
	class FormWizardBase : Language.FormI18N
	{
		private string nextText = "Next >>";
		private string prevText = "<< Back";
		private string cancelText = "Cancel";
		private string finishText = "Finish";
		protected System.Windows.Forms.PictureBox pictureBox1;
		private GroupBox groupBox1;
		protected DisksDB.UserInterface.ControlMyTab pagesPanel;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.Button button5;
		private bool canClose = true;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public FormWizardBase()
		{
			InitializeComponent();
			Language.I18N.Instance.LanguageChanged += new EventHandler(OnLanguageChanged);
            PageChanged(this, EventArgs.Empty);
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pagesPanel = new DisksDB.UserInterface.ControlMyTab();
			this.button5 = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonBack = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(163, 312);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pagesPanel
			// 
			this.pagesPanel.BackBrushColor = System.Drawing.Color.White;
			this.pagesPanel.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.pagesPanel.ItemSize = new System.Drawing.Size(73, 1);
			this.pagesPanel.Location = new System.Drawing.Point(163, 0);
			this.pagesPanel.Multiline = true;
			this.pagesPanel.Name = "pagesPanel";
			this.pagesPanel.Padding = new System.Drawing.Point(0, 0);
			//this.pagesPanel.SelectedIndex = 0;
			this.pagesPanel.Size = new System.Drawing.Size(340, 312);
			this.pagesPanel.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.pagesPanel.TabIndex = 1;
			this.pagesPanel.SelectedIndexChanged += new System.EventHandler(this.PageChanged);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(0, 0);
			this.button5.Name = "button5";
			this.button5.TabIndex = 0;
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(416, 320);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// buttonNext
			// 
			this.buttonNext.Location = new System.Drawing.Point(328, 320);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.TabIndex = 3;
			this.buttonNext.Text = "Finish";
			this.buttonNext.Click += new System.EventHandler(this.ButtonNextClick);
			// 
			// buttonBack
			// 
			this.buttonBack.Enabled = false;
			this.buttonBack.Location = new System.Drawing.Point(248, 320);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.TabIndex = 4;
			this.buttonBack.Text = "<< Back";
			this.buttonBack.Click += new System.EventHandler(this.ButtonBackClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-8, 296);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(584, 18);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// FormWizardBase
			// 
			this.AcceptButton = this.buttonNext;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(494, 350);
			this.Controls.Add(this.buttonBack);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.pagesPanel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormWizardBase";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Enter Wizard Name Here";
			this.Closed += new System.EventHandler(this.FormWizzardClosed);
			this.ResumeLayout(false);

		}

		#endregion

		private void PageChanged(object sender, System.EventArgs e)
		{
			Language.I18N i18n = Language.I18N.Instance;

            if (this.pagesPanel.SelectedIndex == -1)
            {
                this.buttonBack.Enabled = false;
                this.buttonNext.Enabled = true;
                this.buttonCancel.Enabled = true;
                this.buttonBack.Text = i18n.GetText(this.Name + "/" + this.prevText, this.prevText);
                this.buttonCancel.Text = i18n.GetText(this.Name + "/" + this.cancelText, this.cancelText);
                this.buttonNext.Text = i18n.GetText(this.Name + "/" + this.nextText, this.nextText);
            }
            else if (this.pagesPanel.SelectedIndex == this.pagesPanel.TabPages.Count - 1)
			{
				// Last Page

                this.buttonBack.Enabled = false;
                this.buttonNext.Enabled = true;
                this.buttonCancel.Enabled = false;
                this.buttonBack.Text = i18n.GetText(this.Name + "/" + this.prevText, this.prevText);
                this.buttonCancel.Text = i18n.GetText(this.Name + "/" + this.cancelText, this.cancelText);
                this.buttonNext.Text = i18n.GetText(this.Name + "/" + this.finishText, this.finishText);
            } 
			else  if (this.pagesPanel.SelectedIndex == 0)
			{
				// First Page

				this.buttonBack.Enabled = false;
				this.buttonNext.Enabled = true;
				this.buttonCancel.Enabled = true;
				this.buttonBack.Text = i18n.GetText(this.Name + "/" + this.prevText, this.prevText);
				this.buttonCancel.Text = i18n.GetText(this.Name + "/" + this.cancelText, this.cancelText);
				this.buttonNext.Text = i18n.GetText(this.Name + "/" + this.nextText, this.nextText);
			}
			else
			{
				// Any other intermediate page

				this.buttonBack.Enabled = true;
				this.buttonNext.Enabled = true;
				this.buttonCancel.Enabled = true;
				this.buttonBack.Text = i18n.GetText(this.Name + "/" + this.prevText, this.prevText);
				this.buttonCancel.Text = i18n.GetText(this.Name + "/" + this.cancelText, this.cancelText);
				this.buttonNext.Text = i18n.GetText(this.Name + "/" + this.nextText, this.nextText);
			}
		}

		private void ButtonCancelClick(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void ButtonNextClick(object sender, System.EventArgs e)
		{
			if (this.pagesPanel.SelectedIndex == this.pagesPanel.TabPages.Count - 1)
			{
				this.DialogResult = DialogResult.OK;
				this.Close();
			} 
			else
			{
				if (this.pagesPanel.SelectedIndex + 1 < this.pagesPanel.TabPages.Count)
				{
					this.pagesPanel.SelectedIndex++;
				}
			}

			OnNextClick();
		}

		private void ButtonBackClick(object sender, System.EventArgs e)
		{
			if (this.pagesPanel.SelectedIndex - 1 >= 0)
			{
				this.pagesPanel.SelectedIndex--;
			}		
		}

		[DefaultValue("Next >>")]
		[Category("Buttons")]
		public string NextText
		{
			get
			{
				return nextText;
			}
			set
			{
				nextText = value;
			}
		}

		[DefaultValue("<< Back")]
		[Category("Buttons")]
		public string PrevText
		{
			get
			{
				return prevText;
			}
			set
			{
				prevText = value;
			}
		}

		[DefaultValue("Cancel")]
		[Category("Buttons")]
		public string CancelText
		{
			get
			{
				return cancelText;
			}
			set
			{
				cancelText = value;
			}
		}

		[DefaultValue("Finish")]
		[Category("Buttons")]
		public string FinishText
		{
			get
			{
				return finishText;
			}
			set
			{
				finishText = value;
			}
		}

		protected virtual void OnNextClick()
		{
		}

		protected void DisableButtons()
		{
			this.buttonBack.Enabled = false;
			this.buttonNext.Enabled = false;
			this.buttonCancel.Enabled = false;
		}

		protected void MoveNext()
		{
			Invoke(new EventHandler(ButtonNextClick), new object[] { this, EventArgs.Empty } );
		}

		protected void MoveBack()
		{
			ButtonBackClick(this, EventArgs.Empty);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

			if (this.pagesPanel.TabPages.Count == 1)
			{
				this.buttonBack.Enabled = false;
				this.buttonNext.Enabled = true;
				this.buttonCancel.Enabled = true;
				this.buttonBack.Text = this.prevText;
				this.buttonCancel.Text = this.cancelText;
				this.buttonNext.Text = this.finishText;
			}
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
			PageChanged(sender, e);
		}

		private void FormWizzardClosed(object sender, System.EventArgs e)
		{
			Language.I18N.Instance.LanguageChanged -= new EventHandler(OnLanguageChanged);		
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			if (false == this.canClose)
			{
				e.Cancel = true;
			}

			base.OnClosing(e);
		}

		[DefaultValue(false)]
		[Browsable(false)]
		public bool CanClose
		{
			get
			{
				return this.canClose;
			}
			set
			{
				this.canClose = value;
			}
		}
	}
}
