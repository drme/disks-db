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
	/// Summary description for FormPrintable.
	/// </summary>
	public class FormPrintable : Language.FormI18NDC
	{
		[DefaultValue(false)]
		public bool NeedPrinting
		{
			get
			{
				return this.needPrinting;
			}
			set
			{
				this.needPrinting = value;
			}
		}

		[DefaultValue(true)]
		public bool NeedPrintPreview
		{
			get
			{
				return this.needPrintPreview;
			}
			set
			{
				this.needPrintPreview = value;
			}
		}

		[Browsable(false)]
		public virtual System.Drawing.Printing.PrintDocument PrintDocument
		{
			get
			{
				return null;
			}
		}

		[Browsable(false)]
		public virtual DocumentProperties PrintProperties
		{
			get
			{
				return null;
			}
		}

		public virtual DialogResult ShowPageSetup()
		{
			System.Windows.Forms.PageSetupDialog dlg = new PageSetupDialog();
			dlg.Document = this.PrintDocument;
			return dlg.ShowDialog();
		}

		public virtual void Print()
		{
			if (null != this.PrintDocument)
			{
				System.Windows.Forms.PrintDialog pd = new PrintDialog();
				pd.Document = this.PrintDocument;

				if (DialogResult.OK == pd.ShowDialog())
				{
					this.PrintDocument.Print();	
				}		
			}
		}

		protected virtual void OnSourceChanged(EventArgs e)
		{
			if (null != this.SourceChanged)
			{
				this.SourceChanged(this, e);
			}
		}

		public event EventHandler SourceChanged;
		private bool needPrinting = false;
		private bool needPrintPreview = true;
	}

	[Description("Document properties")]
	public class DocumentProperties
	{
	}
}
