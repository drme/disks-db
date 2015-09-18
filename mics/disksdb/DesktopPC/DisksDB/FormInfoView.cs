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
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for InfoView.
	/// </summary>
	public class FormInfoView : WeifenLuo.WinFormsUI.DockContent, INativeRename
	{
		private ListView listView;
		private ColumnHeader columnHeaderName;
		private ColumnHeader columnHeaderSize;
		private ColumnHeader columnHeaderType;
		private ColumnHeader columnHeaderDate;
		private System.Windows.Forms.ContextMenu contextMenu;
		public event EventHandlerItemSelected ItemSelected;
		private MenuEdit mnu = new MenuEdit();
		private IListItem rootItem = null;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private Container components = null;

		public FormInfoView()
		{
			InitializeComponent();
			LoadSettings();
			this.contextMenu.MenuItems.AddRange(this.mnu.MenuItems);
			this.mnu.SetEditor(this);
			this.listView.AfterLabelEdit += new LabelEditEventHandler(AfterLabelEdit);
			this.contextMenu.Popup += new EventHandler(ContextMenuPopup);
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
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderDate = new System.Windows.Forms.ColumnHeader();
			this.contextMenu = new System.Windows.Forms.ContextMenu();
			this.SuspendLayout();
			// 
			// listView
			// 
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					   this.columnHeaderName,
																					   this.columnHeaderSize,
																					   this.columnHeaderType,
																					   this.columnHeaderDate});
			this.listView.ContextMenu = this.contextMenu;
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.Location = new System.Drawing.Point(0, 0);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(621, 148);
			this.listView.TabIndex = 1;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 229;
			// 
			// columnHeaderSize
			// 
			this.columnHeaderSize.Text = "Size";
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			// 
			// columnHeaderDate
			// 
			this.columnHeaderDate.Text = "Date Modified";
			this.columnHeaderDate.Width = 80;
			// 
			// contextMenu
			// 
			this.contextMenu.Popup += new System.EventHandler(this.contextMenu_Popup);
			// 
			// FormInfoView
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(621, 148);
			this.Controls.Add(this.listView);
			this.DockableAreas = WeifenLuo.WinFormsUI.DockAreas.Document;
			this.Name = "FormInfoView";
			this.Text = "Explorer";
			this.ResumeLayout(false);

		}

		#endregion

//		public ListView List
//		{
//			get
//			{
//				return this.listView;
//			}
//		}

		public void SetRootItem(IListItem rootItem)
		{
			this.rootItem = rootItem;

            this.Invoke(new UpdateListHandler(this.FillListInternal));
        }

        private delegate void UpdateListHandler();

        private void FillList()
		{
            this.Invoke(new UpdateListHandler(this.FillListInternal));
        }

        private void FillListInternal()
        {
            if (null != this.rootItem)
            {
                this.listView.Items.Clear();

                if (null != this.rootItem.ChildNodes)
                {
                    foreach (Object o in this.rootItem.ChildNodes)
                    {
                        if (o is IListItem)
                        {
                            IListItem i = (IListItem)o;

                            if (false == i.IsDeleted())
                            {
                                this.listView.Items.Add(new ListItem(i));
                            }
                        }
                    }
                }
            }	
        }

		private void OnItemSelected(IListItem item)
		{
			if (null != this.ItemSelected)
			{
				this.ItemSelected(item);
			}
		}

		private void listView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ( (null != this.listView.SelectedItems) && (this.listView.SelectedItems.Count > 0) )
			{
				if (this.listView.SelectedItems[0] is ListItem)
				{
					ListItem li = (ListItem)this.listView.SelectedItems[0];

					OnItemSelected(li.IListItem);
				}
			}		
		}

		public ImageList Images
		{
			set
			{
				this.listView.SmallImageList = value;
			}
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			SaveSettings();
			base.OnClosing (e);
		}

		private void SaveSettings()
		{
			foreach (ColumnHeader h in this.listView.Columns)
			{
				DisksDB.Config.Config.Instance.SetValue("FormInfoView_" + h.Text, h.Width.ToString());
			}		
		}

		private void LoadSettings()
		{
			foreach (ColumnHeader h in this.listView.Columns)
			{
				string o = DisksDB.Config.Config.Instance.GetValue("FormInfoView_" + h.Text);

				if (null != o)
				{
					try
					{
						h.Width = int.Parse(o);
					}
					catch (Exception)
					{
					}
				}
			}
		}

		private void contextMenu_Popup(object sender, System.EventArgs e)
		{
			if ( (null != this.listView.SelectedItems) && (this.listView.SelectedItems.Count > 0) )
			{
				if (this.listView.SelectedItems[0] is ListItem)
				{
					ListItem li = (ListItem)this.listView.SelectedItems[0];
					this.mnu.UpdateMenu(li.IListItem);
				}
			}
		}

		public void BeginEdit()
		{
			this.listView.LabelEdit = true;

			if ( (null != this.listView.SelectedItems) && (this.listView.SelectedItems.Count > 0) )
			{
				if (this.listView.SelectedItems[0] is ListItem)
				{
					ListItem li = (ListItem)this.listView.SelectedItems[0];
					//this.mnu.UpdateMenu(li.IListItem);

					li.BeginEdit();
					//li.
				}
			}		
		}

		private void AfterLabelEdit(object sender, LabelEditEventArgs e)
		{
			if (e.Label != null)
			{
				if ( (null != this.listView.SelectedItems) && (this.listView.SelectedItems.Count > 0) )
				{
					if (this.listView.SelectedItems[0] is ListItem)
					{
						ListItem li = (ListItem)this.listView.SelectedItems[0];
						li.IListItem.Rename(e.Label);
					}
				}		
			}		

			this.listView.LabelEdit = false;
		}

		private void ContextMenuPopup(object sender, EventArgs e)
		{
			IListItem ili = null;

			if ( (null != this.listView.SelectedItems) && (this.listView.SelectedItems.Count > 0) )
			{
				if (this.listView.SelectedItems[0] is ListItem)
				{
					ListItem li = (ListItem)this.listView.SelectedItems[0];
					ili = li.IListItem;
				}
			}

			if (null != ili)
			{
				this.mnu.UpdateMenu(ili);
			} 
			else
			{
				this.mnu.UpdateMenu(this.rootItem);
			} 
		}

		public void ReFillList(IListItem item)
		{
			if (item == this.rootItem)
			{
				FillList();
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}


		private void listView_DoubleClick(object sender, System.EventArgs e)
		{
			if ( (null != this.listView.SelectedItems) && (this.listView.SelectedItems.Count > 0) )
			{
				if (this.listView.SelectedItems[0] is ListItem)
				{
					ListItem li = (ListItem)this.listView.SelectedItems[0];
					li.IListItem.Open();
				}
			}
		}
	}
}
