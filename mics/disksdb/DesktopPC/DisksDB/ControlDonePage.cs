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
using System.ComponentModel;
using System.Windows.Forms;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for DonePageControl.
	/// </summary>
	public class ControlDonePage : UserControl
	{
		private Label label1;
		private Label label2;
		private Label label3;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public ControlDonePage()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte) (0)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(232, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "big text";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(288, 184);
			this.label2.TabIndex = 1;
			this.label2.Text = "small text";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 280);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(288, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "close text";
			// 
			// DonePageControl
			// 
			this.BackColor = System.Drawing.Color.White;
			this.Controls.AddRange(new System.Windows.Forms.Control[]
				{
					this.label3,
					this.label2,
					this.label1
				});
			this.Name = "DonePageControl";
			this.Size = new System.Drawing.Size(335, 312);
			this.ResumeLayout(false);

		}

		#endregion

		public string Title
		{
			get
			{
				return this.label1.Text;
			}
			set
			{
                if (this.IsHandleCreated)
                {
                    this.Invoke(new SetTextHandler(this.SetText), this.label1, value);
                }
                else
                {
                    this.label1.Text = value;
                }
            }
		}

		public string FinishText
		{
			get
			{
				return this.label2.Text;
			}
			set
			{
                if (this.IsHandleCreated)
                {
                    this.Invoke(new SetTextHandler(this.SetText), this.label2, value);
                }
                else
                {
                    this.label2.Text = value;
                }
            }
		}

		public string Comment
		{
			get
			{
				return this.label3.Text;
			}
			set
			{
                if (this.IsHandleCreated)
                {
                    this.Invoke(new SetTextHandler(this.SetText), this.label3, value);
                }
                else
                {
                    this.label3.Text = value;
                }
            }
		}

        private void SetText(Control c, string text)
        {
            c.Text = text;
        }

        private delegate void SetTextHandler(Control c, string text);
	}
}