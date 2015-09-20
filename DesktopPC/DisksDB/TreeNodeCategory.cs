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
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using DisksDB.DataBase;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Represents cd category in disks tree.
	/// </summary>
	class TreeNodeCategory : TreeNodeBase
	{
		private bool nodesLoaded = false;
		private DisksDB.DataBase.DataBase db = null;
		private DataBase.Category cat = null;
		private static string defaultCategoryName = "New Category";
		private static string defaultCategoryDescription = "";
		private static string deleteQuestion = "Are you sure want to delete Category?";
		private static string deleteQuestionCaption = "Are you sure want to delete Category?";
		protected TreeViewCatalog trv;

		/// <summary>
		/// Constructs TreeNode object from database Category object
		/// </summary>
		/// <param name="db">database object</param>
		/// <param name="cat">category object</param>
		/// <param name="trv">tree view</param>
		public TreeNodeCategory(DisksDB.DataBase.DataBase db, DataBase.Category cat, TreeViewCatalog trv) : base(cat.Name, cat, true, true, "Category", -1, DateTime.Now, true, false, true, true, false)
		{
			Debug.Assert(null != trv);

			this.trv = trv;
			this.db = db;
			this.cat = cat;
			this.ImageIndex = TreeImages.Category;
			this.SelectedImageIndex = TreeImages.CategoryOpen;
			this.cat.NameChanged += new EventHandler(NameChanged);
			this.cat.ChildItemAdded += new EventHandlerItemAdded(ChildItemAdded);
			this.cat.ChildItemRemoved += new EventHandlerItemRemoved(ChildItemRemoved);
			this.cat.ChildsChanged += new EventHandler(ChildsChanged);
		}

		/// <summary>
		/// Adds new category
		/// </summary>
		public override void CreateNewCategory()
		{
			FormNewCategory fNewCat = new FormNewCategory();
			fNewCat.CategoryName = defaultCategoryName;
			fNewCat.CategoryDescription = defaultCategoryDescription;

			if (DialogResult.OK == fNewCat.ShowDialog())
			{
				this.cat.AddCategory(fNewCat.CategoryName, fNewCat.CategoryDescription);
			}
		}

		/// <summary>
		/// Deletes category
		/// </summary>
		public override void Delete()
		{
			if (true == this.cat.IsRoot)
			{
				return;
			}

			if (ErrorMessenger.QuestionMessage(null, deleteQuestionCaption, deleteQuestion) == DialogResult.Yes)
			{
				this.cat.Delete();
			}
		}

		/// <summary>
		/// Renames category.
		/// </summary>
		/// <param name="name">new name</param>
		public override void Rename(string name)
		{
			this.cat.Name = name;
		}

		/// <summary>
		/// Returns name of category
		/// </summary>
		/// <returns>category name</returns>
		public override string GetName()
		{
			return this.cat.Name;
		}

		/// <summary>
		/// Shows Dialog to edit, view category properties.
		/// </summary>
		public override void ShowProperties()
		{
			new FormPopertiesCategory(this.cat).ShowDialog();
		}

		/// <summary>
		/// Causes tree node to get its child nodes
		/// </summary>
		public override void LoadTreeNodeChilds()
		{
			if (true == this.nodesLoaded)
			{
				return;
			}

			if (true == this.cat.IsRoot)
			{
				this.trv.Nodes.Clear();
			}
			else
			{
				this.Nodes.Clear();
			}

			var lst = this.cat.ChildCategories;

			if (null != lst)
			{
				foreach (DataBase.Category c in lst)
				{
					if (false == c.IsDeleted)
					{
						TreeNodeCategory cc = new TreeNodeCategory(this.db, c, this.trv);

						if (true == this.cat.IsRoot)
						{
							this.trv.Nodes.Add(cc);
						}
						else
						{
							this.Nodes.Add(cc);
						}
					}
				}
			}

			var childBoxes = this.cat.ChildCDBoxes;

			if (null != lst)
			{
				foreach (DataBase.Box r in childBoxes)
				{
					if (false == r.IsDeleted)
					{
						TreeNodeBox b = new TreeNodeBox(this.db, r, this.trv);

						if (true == this.cat.IsRoot)
						{
							this.trv.Nodes.Add(b);
						}
						else
						{
							this.Nodes.Add(b);
						}
					}
				}
			}

			this.nodesLoaded = true;
		}

		public override IEnumerable ChildNodes
		{
			get
			{
				LoadTreeNodeChilds();

				if (true == this.cat.IsRoot)
				{
					return this.trv.Nodes;
				}
				else
				{
					return this.Nodes;
				}
			}
		}

		public override void CreateNewBox()
		{
			FormNewCDBox f = new FormNewCDBox(this.db);

			if (DialogResult.OK == f.ShowDialog())
			{
				try
				{
					this.cat.AddCDBox(f.BoxName, f.BoxDescription, f.BoxType, f.BoxFront, f.BoxBack, f.BoxInlay);
				}
				catch (Exception ex)
				{
					ErrorMessenger.ErrorMessage(this.TreeView, "Error ocured while adding a cd box", ex);
				}
			}
		}

		private void NameChanged(object sender, EventArgs e)
		{
			this.Text = this.cat.Name;
		}

		private void RemoveItem(TreeNodeCollection lst, BaseObject obj)
		{
			LoadTreeNodeChilds();

			if (obj is DataBase.Category)
			{
				DataBase.Category c = (DataBase.Category) obj;

				for (int i = 0; i < lst.Count; i++)
				{
					if (lst[i] is TreeNodeCategory)
					{
						TreeNodeCategory cc = (TreeNodeCategory) lst[i];

						if (cc.cat == c)
						{
							lst.RemoveAt(i);
							return;
						}
					}
				}
			}
			else if (obj is DataBase.Box)
			{
				DataBase.Box b = (DataBase.Box) obj;

				for (int i = 0; i < lst.Count; i++)
				{
					if (lst[i] is TreeNodeBox)
					{
						TreeNodeBox bb = (TreeNodeBox) lst[i];

						if (bb.InternalBox == b)
						{
							lst.Remove(bb);
							return;
						}
					}
				}
			}
		}

		private void AddItem(TreeNodeCollection lst, BaseObject obj)
		{
			LoadTreeNodeChilds();

			if (obj is DataBase.Category)
			{
				DataBase.Category c = (DataBase.Category) obj;

				int pos = 0;

				for (pos = 0; (pos < lst.Count) && (lst[pos] is TreeNodeCategory); pos++)
				{
					TreeNodeCategory cc = (TreeNodeCategory) lst[pos];

					if (cc.cat.Name.CompareTo(c.Name) >= 0)
					{
						lst.Insert(pos, new TreeNodeCategory(this.db, c, this.trv));
						return;
					}
				}

				lst.Insert(pos, new TreeNodeCategory(this.db, c, this.trv));
			}
			else if (obj is DataBase.Box)
			{
				DataBase.Box b = (DataBase.Box) obj;

				int pos = 0;

				for (pos = 0; pos < lst.Count; pos++)
				{
					if (lst[pos] is TreeNodeBox)
					{
						TreeNodeBox bb = (TreeNodeBox) lst[pos];

						if (bb.InternalBox.Name.CompareTo(b.Name) >= 0)
						{
							lst.Insert(pos, new TreeNodeBox(this.db, b, this.trv));
							return;
						}
					}
				}

				lst.Insert(pos, new TreeNodeBox(this.db, b, this.trv));
			}
		}

		private void ChildItemAdded(BaseObject item)
		{
			if (true == this.cat.IsRoot)
			{
				this.trv.Invoke(new EventHandlerNodesUpdated(AddItem), new object[] {this.trv.Nodes, item});
			}
			else
			{
				this.TreeView.Invoke(new EventHandlerNodesUpdated(AddItem), new object[] {this.Nodes, item});
			}
		}

		private void ChildItemRemoved(BaseObject item)
		{
			if (true == this.cat.IsRoot)
			{
				this.trv.Invoke(new EventHandlerNodesUpdated(RemoveItem), new object[] {this.trv.Nodes, item});
			}
			else
			{
				this.TreeView.Invoke(new EventHandlerNodesUpdated(RemoveItem), new object[] {this.Nodes, item});
			}
		}

		public DataBase.Category InternalCategory
		{
			get
			{
				return this.cat;
			}
		}

		private void ChildsChanged(object sender, EventArgs e)
		{
			this.trv.ReFillList(this);
		}

		public override void Refresh()
		{
			this.nodesLoaded = false;
			LoadTreeNodeChilds();
		}

		public override void Open()
		{
			this.trv.SelectedNode = this;
		}
	}
}