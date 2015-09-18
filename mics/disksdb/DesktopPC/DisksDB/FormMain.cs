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
using System.Drawing;
using System.Windows.Forms;
using DisksDB.Utils;
using DisksDB.Language;
using DisksDB.DataBase;
using DisksDB.UserInterface.ToolBar;
using WeifenLuo.WinFormsUI;
using System.Reflection;

namespace DisksDB.UserInterface
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FormMain : Language.FormI18N
	{
		private FormDisksTree formDisks = null;
		private FormSummary formSummary = null;
		private FormImagesExplorer imagesExplorer = null;
		private TreeViewImages imagesTree = null;
		private FormImagePreview imagePreview = null;
		private IContainer components;
		private StatusBar statusBar1;
		private ImageList mainImageList16x16;
		private StatusBarPanel statusBarPanel1;
		private StatusBarPanel statusBarPanel2;
		private TreeViewCatalog cdTreeview;
		private FormInfoView infoView = null;
		private MenuItem menuItemOptions;
		private MenuItem menuItemFile;
		private MenuItem menuItemExit;
		private MenuItem menuItemTools;
		private MenuItem menuItemPageSetup;
		private MenuItem menuItemPrint;
		private MenuItem menuItemHelp;
		private MenuItem menuItemAbout;
		private MenuItem menuItemEdit;
		private FormSearchResults searchResultsForm = null;
		private System.Windows.Forms.MenuItem menuItemPrintPreview;
		private System.Windows.Forms.MenuItem menuItemWindows;
		private System.Windows.Forms.MenuItem menuItemImagesExplorer;
		private System.Windows.Forms.MenuItem menuItemDisksExporer;
		private System.Windows.Forms.MenuItem menuItemItemPreview;
		private System.Windows.Forms.MenuItem menuItemLanguages;
		private System.Windows.Forms.StatusBarPanel statusBarPanelMemory;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.ImageList imageListCatalog;
		private ToolBar2x toolBar2x1;
		private MenuEdit mnu = new MenuEdit();
		private ToolBar2xButtonBase buttonPrint;
        private System.Windows.Forms.MenuItem menuItemTransferDataBase;
		private WeifenLuo.WinFormsUI.DockPanel dockPanel;
		private ToolBar2xButtonBase buttonUp;
        private delegate void UpdateTextHandler(Component c, string text);

		public FormMain()
		{
			InitializeComponent();
			InitializeToolBar();

			this.cdTreeview = new TreeViewCatalog(this.imageListCatalog);
			
			InitializeDockingWindows();
			
			ShowDisksExplorer(null, EventArgs.Empty);

			this.cdTreeview.DataBase = DisksDB.DataBase.DataBase.Instance;
			this.cdTreeview.InfoVew = this.infoView;
			this.cdTreeview.LoadTree();
			this.menuItemEdit.MenuItems.AddRange(this.mnu.MenuItems);
			this.cdTreeview.ItemSelected += new EventHandlerItemSelected(ControlItemSelected);

            InitSyncServer(Config.Config.Instance.GetValue("SyncServerRunning", false));

            SyncServer.Instance.ClientConnected += new SyncServer.ClientConnectedEvent(Instance_ClientConnected);
            SyncServer.Instance.ClientDisconnected += new SyncServer.ClientDisconnectedEvent(Instance_ClientDisconnected);
		}

        public void SetCursor(Cursor cursor)
        {
            this.Cursor = cursor;
        }

        private void Instance_ClientDisconnected()
        {
            Invoke(new UpdateTextHandler(UpdateText), this.statusBarPanel1, I18N.Instance.GetText("Client disconnected", "Client disconnected"));
            Invoke(new UpdateTextHandler(UpdateText), this.statusBarPanel1, I18N.Instance.GetText("Sync done", "Sync done"));
        }

        private void Instance_ClientConnected()
        {
            Invoke(new UpdateTextHandler(UpdateText), this.statusBarPanel1, I18N.Instance.GetText("Client connected", "Client connected"));
            Invoke(new UpdateTextHandler(UpdateText), this.statusBarPanel1, I18N.Instance.GetText("Synchronizing with PDA", "Synchronizing with PDA"));
        }

        private void UpdateText(Component c, string text)
        {
            try
            {
                if (null != c)
                {
                    PropertyInfo pi = c.GetType().GetProperty("Text");

                    if (null != pi)
                    {
                        pi.SetValue(c, text, null);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

		internal FormSearchResults SearchResultsForm
		{
			get
			{
				if (null == this.searchResultsForm)
				{
					this.searchResultsForm = new FormSearchResults(this);
					this.searchResultsForm.Show(this.dockPanel);
					this.searchResultsForm.Closed += new EventHandler(searchResultsForm_Closed);
				}

				return this.searchResultsForm;
			}
		}

		protected void InitializeDockingWindows()
		{
			this.SuspendLayout();

			this.formDisks = new FormDisksTree();
			this.cdTreeview.Dock = DockStyle.Fill;
			this.formDisks.Controls.Add(this.cdTreeview);
			this.formDisks.Show(this.dockPanel);

			FormSearch fs = new FormSearch(this, DisksDB.DataBase.DataBase.Instance);
			fs.Show(this.dockPanel);

			this.ResumeLayout();

			this.formDisks.Show(this.dockPanel);
		}

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemPageSetup = new System.Windows.Forms.MenuItem();
            this.menuItemPrintPreview = new System.Windows.Forms.MenuItem();
            this.menuItemPrint = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemTools = new System.Windows.Forms.MenuItem();
            this.menuItemOptions = new System.Windows.Forms.MenuItem();
            this.menuItemLanguages = new System.Windows.Forms.MenuItem();
            this.menuItemTransferDataBase = new System.Windows.Forms.MenuItem();
            this.menuItemWindows = new System.Windows.Forms.MenuItem();
            this.menuItemImagesExplorer = new System.Windows.Forms.MenuItem();
            this.menuItemDisksExporer = new System.Windows.Forms.MenuItem();
            this.menuItemItemPreview = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.mainImageList16x16 = new System.Windows.Forms.ImageList(this.components);
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelMemory = new System.Windows.Forms.StatusBarPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.imageListCatalog = new System.Windows.Forms.ImageList(this.components);
            this.dockPanel = new WeifenLuo.WinFormsUI.DockPanel();
            this.toolBar2x1 = new DisksDB.UserInterface.ToolBar.ToolBar2x();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMemory)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemTools,
            this.menuItemWindows,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemPageSetup,
            this.menuItemPrintPreview,
            this.menuItemPrint,
            this.menuItemExit});
            this.menuItemFile.Text = "File";
            // 
            // menuItemPageSetup
            // 
            this.menuItemPageSetup.Index = 0;
            this.menuItemPageSetup.Text = "Page Setup...";
            this.menuItemPageSetup.Click += new System.EventHandler(this.PageSetup);
            // 
            // menuItemPrintPreview
            // 
            this.menuItemPrintPreview.Index = 1;
            this.menuItemPrintPreview.Text = "Print Preview...";
            this.menuItemPrintPreview.Click += new System.EventHandler(this.PrintPreview);
            // 
            // menuItemPrint
            // 
            this.menuItemPrint.Index = 2;
            this.menuItemPrint.Text = "Print...";
            this.menuItemPrint.Click += new System.EventHandler(this.PrintClick);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.ExitClick);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.Text = "Edit";
            // 
            // menuItemTools
            // 
            this.menuItemTools.Index = 2;
            this.menuItemTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOptions,
            this.menuItemLanguages,
            this.menuItemTransferDataBase});
            this.menuItemTools.Text = "Tools";
            // 
            // menuItemOptions
            // 
            this.menuItemOptions.Index = 0;
            this.menuItemOptions.Text = "Options...";
            this.menuItemOptions.Click += new System.EventHandler(this.OptionsClick);
            // 
            // menuItemLanguages
            // 
            this.menuItemLanguages.Index = 1;
            this.menuItemLanguages.Text = "Languages...";
            this.menuItemLanguages.Visible = false;
            this.menuItemLanguages.Click += new System.EventHandler(this.LanguagesClick);
            // 
            // menuItemTransferDataBase
            // 
            this.menuItemTransferDataBase.Index = 2;
            this.menuItemTransferDataBase.Text = "Transfer DataBase...";
            this.menuItemTransferDataBase.Visible = false;
            this.menuItemTransferDataBase.Click += new System.EventHandler(this.CopyDataBaseClick);
            // 
            // menuItemWindows
            // 
            this.menuItemWindows.Index = 3;
            this.menuItemWindows.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemImagesExplorer,
            this.menuItemDisksExporer,
            this.menuItemItemPreview});
            this.menuItemWindows.Text = "Windows";
            // 
            // menuItemImagesExplorer
            // 
            this.menuItemImagesExplorer.Index = 0;
            this.menuItemImagesExplorer.Text = "Images Explorer";
            this.menuItemImagesExplorer.Click += new System.EventHandler(this.ShowHideImagesExplorer);
            // 
            // menuItemDisksExporer
            // 
            this.menuItemDisksExporer.Index = 1;
            this.menuItemDisksExporer.Text = "Disks Explorer";
            this.menuItemDisksExporer.Click += new System.EventHandler(this.ShowDisksExplorer);
            // 
            // menuItemItemPreview
            // 
            this.menuItemItemPreview.Index = 2;
            this.menuItemItemPreview.Text = "Item Preview";
            this.menuItemItemPreview.Click += new System.EventHandler(this.ShowItemPreview);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 4;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "About...";
            this.menuItemAbout.Click += new System.EventHandler(this.AboutClick);
            // 
            // mainImageList16x16
            // 
            this.mainImageList16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainImageList16x16.ImageStream")));
            this.mainImageList16x16.TransparentColor = System.Drawing.Color.Magenta;
            this.mainImageList16x16.Images.SetKeyName(0, "");
            this.mainImageList16x16.Images.SetKeyName(1, "");
            this.mainImageList16x16.Images.SetKeyName(2, "");
            this.mainImageList16x16.Images.SetKeyName(3, "");
            this.mainImageList16x16.Images.SetKeyName(4, "");
            this.mainImageList16x16.Images.SetKeyName(5, "");
            this.mainImageList16x16.Images.SetKeyName(6, "");
            this.mainImageList16x16.Images.SetKeyName(7, "");
            this.mainImageList16x16.Images.SetKeyName(8, "");
            this.mainImageList16x16.Images.SetKeyName(9, "");
            this.mainImageList16x16.Images.SetKeyName(10, "");
            this.mainImageList16x16.Images.SetKeyName(11, "");
            this.mainImageList16x16.Images.SetKeyName(12, "");
            this.mainImageList16x16.Images.SetKeyName(13, "");
            this.mainImageList16x16.Images.SetKeyName(14, "");
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 189);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2,
            this.statusBarPanelMemory});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(824, 22);
            this.statusBar1.TabIndex = 1;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Text = "Ready";
            this.statusBarPanel1.Width = 150;
            // 
            // statusBarPanel2
            // 
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel2.Name = "statusBarPanel2";
            this.statusBarPanel2.Width = 561;
            // 
            // statusBarPanelMemory
            // 
            this.statusBarPanelMemory.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.statusBarPanelMemory.Name = "statusBarPanelMemory";
            this.statusBarPanelMemory.Width = 97;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 10000;
            this.timer.Tick += new System.EventHandler(this.MemUpdate);
            // 
            // imageListCatalog
            // 
            this.imageListCatalog.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListCatalog.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListCatalog.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel.Location = new System.Drawing.Point(0, 26);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Size = new System.Drawing.Size(824, 163);
            this.dockPanel.TabIndex = 9;
            // 
            // toolBar2x1
            // 
            this.toolBar2x1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar2x1.Location = new System.Drawing.Point(0, 0);
            this.toolBar2x1.Name = "toolBar2x1";
            this.toolBar2x1.Size = new System.Drawing.Size(824, 26);
            this.toolBar2x1.TabIndex = 8;
            this.toolBar2x1.Text = "toolBar2x1";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(824, 211);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar2x1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "FormMain";
            this.Text = "CD/DVD Catalog";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.AppClosing);
            this.Load += new System.EventHandler(this.FormLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelMemory)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private void ExitClick(object sender, EventArgs e)
		{
			Close();
		}

		private void MoveUpButtonClick(object sender, EventArgs e)
		{
			this.cdTreeview.MoveUp();
		}

		private void OptionsClick(object sender, EventArgs e)
		{
			FormOptions f = new FormOptions(DisksDB.DataBase.DataBase.Instance);

            if (DialogResult.OK == f.ShowDialog())
            {
                InitSyncServer(Config.Config.Instance.GetValue("SyncServerRunning", false));
            }
		}

		private void AppClosing(object sender, CancelEventArgs e)
		{
            Config.Config.Instance.SetValue("SyncServerRunning", SyncServer.Instance.IsRunning);

            SyncServer.Instance.Stop();
            SyncServer.Instance.Kill();
            SyncServer.Instance.WaitForExit();

			if (null != this.infoView)
			{
				this.infoView.Close();	
			}

			DisksDB.Config.Config.Instance.Save();
		}

		private void InitializeToolBar()
		{
			ToolBar2xButtonBase buttonNew = new ToolBar2xButtonBase(MyResources.GetIcon("new.ico"), this.toolBar2x1);
			ToolBar2xButtonBase buttonDelete = new ToolBar2xButtonBase(FileIcons.GetSystemIcon(131, false), this.toolBar2x1);
			ToolBar2xButtonBase buttonProperties = new ToolBar2xButtonBase(FileIcons.GetSystemIcon(134, false), this.toolBar2x1);
			ToolBar2xSeparator buttonSpace = new ToolBar2xSeparator();
            ToolBar2xButtonBase buttonUp = new ToolBar2xButtonBase(FileIcons.GetSystemIcon(146, false), this.toolBar2x1);

            this.buttonPrint = new ToolBar2xButtonBase(FileIcons.GetSystemIcon(16, false), this.toolBar2x1);
			this.buttonPrint.Click += new EventHandler(PrintClick);

			this.toolBar2x1.Buttons.Add(buttonNew);
			this.toolBar2x1.Buttons.Add(buttonDelete);
			this.toolBar2x1.Buttons.Add(buttonProperties);
			this.toolBar2x1.Buttons.Add(buttonSpace);
			this.toolBar2x1.Buttons.Add(buttonUp);
			this.toolBar2x1.Buttons.Add(this.buttonPrint);

			buttonNew.Click += new EventHandler(buttonNew_Click);
			buttonProperties.Click += new EventHandler(buttonProperties_Click);
			buttonDelete.Click += new EventHandler(buttonDelete_Click);
            buttonUp.Click += new EventHandler(MoveUpButtonClick);
		}

		private void PrintClick(object sender, EventArgs args)
		{
			if (this.dockPanel.ActiveDocument is FormPrintable)
			{
				FormPrintable fp = (FormPrintable)this.dockPanel.ActiveDocument;
				fp.Print();
			}
		}

		private void ShowHideImagesExplorer(object sender, EventArgs e)
		{
			if (null == this.imagesTree)
			{
				this.imagePreview = new FormImagePreview();
				this.imagePreview.Show(this.dockPanel);
				this.imagesTree = new TreeViewImages(DisksDB.DataBase.DataBase.Instance, this.imagePreview);
				this.imagesTree.ItemSelected += new EventHandlerItemSelected(ControlItemSelected);
				this.imagesTree.ImageList = this.imageListCatalog;
				this.imagesExplorer = new FormImagesExplorer();
				this.imagesTree.Dock = DockStyle.Fill;
				this.imagesExplorer.Controls.Add(this.imagesTree);
				this.imagesExplorer.Icon = FileIcons.GetFileIcon(".bmp");
				this.imagesExplorer.Show(this.dockPanel);
				this.menuItemImagesExplorer.Checked = true;
				this.imagesTree.ItemSelected += new EventHandlerItemSelected(ControlItemSelected);
			} 
			else
			{
				this.imagePreview.Close();
				this.imagesTree = null;
				this.imagesExplorer.Close();
				this.menuItemImagesExplorer.Checked = false;
			}
		}

		private void ControlItemSelected(IListItem item)
		{
			this.mnu.UpdateMenu(item);

			if (null != this.formSummary)
			{
				if (item is DisksDB.UserInterface.TreeNodeDisk)
				{
					DisksDB.UserInterface.TreeNodeDisk d = (DisksDB.UserInterface.TreeNodeDisk)item;
					this.formSummary.ShowItem(d.InternalDisk);
				} 
				else if (item is DisksDB.UserInterface.TreeNodeBox)
				{
					DisksDB.UserInterface.TreeNodeBox b = (DisksDB.UserInterface.TreeNodeBox)item;
					this.formSummary.ShowItem(b.InternalBox);
				}
				else if (item is DisksDB.UserInterface.TreeNodeFile)
				{
					DisksDB.UserInterface.TreeNodeFile f = (DisksDB.UserInterface.TreeNodeFile)item;
					this.formSummary.ShowItem(f.InternalFile);
				}
				else if (item is DisksDB.UserInterface.TreeNodeCategory)
				{
					DisksDB.UserInterface.TreeNodeCategory c = (DisksDB.UserInterface.TreeNodeCategory)item;
					this.formSummary.ShowItem(c.InternalCategory);
				}
				else if (item is DisksDB.UserInterface.TreeNodeImage)
				{
					DisksDB.UserInterface.TreeNodeImage i = (DisksDB.UserInterface.TreeNodeImage)item;
					this.formSummary.ShowItem(i.InternalImage);
				} 
			}
		}

		private void AboutClick(object sender, System.EventArgs e)
		{
			FormAbout fa = new FormAbout();
			fa.ShowDialog();
			fa.Dispose();
		}

		private void ActiveDocumentChanged(object sender, System.EventArgs e)
		{
			this.buttonPrint.Enabled = false;
			this.menuItemPrint.Enabled = false;
			this.menuItemPrintPreview.Enabled = false;
			this.menuItemPageSetup.Enabled = false;

			if (this.dockPanel.ActiveDocument is FormPrintable)
			{
				FormPrintable dc = (FormPrintable)this.dockPanel.ActiveDocument;

				if (true == dc.NeedPrinting)
				{
					this.buttonPrint.Enabled = true;
					this.menuItemPrint.Enabled = true;
					this.menuItemPrintPreview.Enabled = dc.NeedPrintPreview;
					this.menuItemPageSetup.Enabled = true;
				}
			}
		}

		private void ShowDisksExplorer(object sender, System.EventArgs e)
		{
			if (null == this.infoView)
			{
				this.infoView = new FormInfoView();
				this.cdTreeview.InfoVew = this.infoView;
				this.infoView.Images = this.imageListCatalog;
				this.infoView.ItemSelected += new EventHandlerItemSelected(ControlItemSelected);
				this.infoView.Show(this.dockPanel);
				this.infoView.Closed += new EventHandler(InfoViewClosed);
			} 
			else
			{
				this.infoView.Close();
				this.infoView = null;
			}		

			this.menuItemDisksExporer.Checked = (null != this.infoView);
		}

		private void InfoViewClosed(object sender, EventArgs e)
		{
			this.cdTreeview.InfoVew = null;
			this.infoView.ItemSelected -= new EventHandlerItemSelected(ControlItemSelected);
			this.infoView = null;

			this.menuItemDisksExporer.Checked = false;
		}

		private void ShowItemPreview(object sender, System.EventArgs e)
		{
			if (null == this.formSummary)
			{
				this.formSummary = new FormSummary();
				this.formSummary.Closed += new EventHandler(FormSummaryClosed);
				this.formSummary.Show(this.dockPanel);
			} 
			else
			{
				this.formSummary.Close();
			}		

			this.menuItemItemPreview.Checked = (null != this.formSummary);
		}

		private void FormSummaryClosed(object sender, EventArgs e)
		{
			this.formSummary.Dispose();
			this.formSummary = null;
			this.menuItemItemPreview.Checked = false;
		}

		private void LanguagesClick(object sender, System.EventArgs e)
		{
			Language.FormTextsEditor f = new FormTextsEditor();
			f.Show(this.dockPanel);
		}

		private void PrintPreview(object sender, System.EventArgs e)
		{
			if (this.dockPanel.ActiveDocument is FormPrintable)
			{
				FormPrintable fp = (FormPrintable)this.dockPanel.ActiveDocument;

				FormPrintPreview fpv = new FormPrintPreview(fp);
				fpv.Show(this.dockPanel);
			}
		}

		private void PageSetup(object sender, System.EventArgs e)
		{
			if (this.dockPanel.ActiveDocument is FormPrintable)
			{
				FormPrintable fp = (FormPrintable)this.dockPanel.ActiveDocument;
                fp.ShowPageSetup();
			}
		}

		public void GoToCategory(long categoryId)
		{
			TreeNodeCategory tnc = GetCategory(categoryId);
	
			if (null != tnc)
			{
				this.cdTreeview.SelectedNode = tnc;
				this.cdTreeview.Select();
				return;
			}				
		}

		public TreeNodeBox GoToBox(long categoryId, long boxId)
		{
			TreeNodeCategory tnc = GetCategory(categoryId);

			if (null != tnc)
			{
				foreach (TreeNode tn in tnc.ChildNodes)
				{
					if (tn is TreeNodeBox)
					{
						TreeNodeBox tnb = (TreeNodeBox)tn;

						if (tnb.InternalBox.Id == boxId)
						{
							this.cdTreeview.SelectedNode = tnb;
							this.cdTreeview.Select();
							return tnb;
						}
					}
				}
			}

			return null;
		}

		public TreeNodeDisk GoToDisk(long categoryId, long boxId, long diskId)
		{
			TreeNodeBox tnb = GoToBox(categoryId, boxId);

			if (null != tnb)
			{
				foreach (TreeNode tn in tnb.ChildNodes)
				{
					if (tn is TreeNodeDisk)
					{
						TreeNodeDisk tnd = (TreeNodeDisk)tn;

						if (tnd.InternalDisk.Id == diskId)
						{
							this.cdTreeview.SelectedNode = tnd;
							this.cdTreeview.Select();
							return tnd;
						}
					}
				}
			}

			return null;
		}

		public void GoToFile(long categoryId, long boxId, long diskId, long fileParentId)
		{
			TreeNodeDisk tnd = GoToDisk(categoryId, boxId, diskId);

			if (null != tnd)
			{
				foreach (TreeNode tn in tnd.ChildNodes)
				{
					if (tn is TreeNodeFile)
					{
						TreeNodeFile tnf = (TreeNodeFile)tn;

						TreeNodeFile tf = GoToFile(tnf, fileParentId);

						if (null != tf)
						{
							this.cdTreeview.SelectedNode = tf;
							this.formDisks.Show();
							this.cdTreeview.Select();
							return;
						}
					}
				}
			}
		}

		private TreeNodeFile GoToFile(TreeNodeFile parent, long fileId)
		{
			if (parent.InternalFile.Id == fileId)
			{
				return parent;
			}

			foreach (TreeNode tn in parent.ChildNodes)
			{
				if (tn is TreeNodeFile)
				{
					TreeNodeFile tnf = (TreeNodeFile)tn;

					if (tnf.InternalFile.Attributes == 1)
					{
						TreeNodeFile tf = GoToFile(tnf, fileId);

						if (null != tf)
						{
							return tf;
						}
					}
				}
			}

			return null;
		}

		private TreeNodeCategory GetCategory(long id)
		{
			foreach (TreeNode tn in this.cdTreeview.Nodes)
			{
				if (tn is TreeNodeCategory)
				{
					TreeNodeCategory tnc = GetCategory((TreeNodeCategory)tn, id);

					if (null != tnc)
					{
						return tnc;
					}				
				}
			}

			return null;
		}

		private TreeNodeCategory GetCategory(TreeNodeCategory parent, long id)
		{
			if (parent.InternalCategory.Id == id)
			{
				return parent;
			}

			foreach (TreeNode tn in parent.ChildNodes)
			{
				if (tn is TreeNodeCategory)
				{
					TreeNodeCategory tnc = GetCategory((TreeNodeCategory)tn, id);

					if (null != tnc)
					{
						return tnc;
					}
				}
			}

			return null;
		}

		private void searchResultsForm_Closed(object sender, EventArgs e)
		{
			this.searchResultsForm = null;
		}

		private void MemUpdate(object sender, System.EventArgs e)
		{
			this.statusBarPanelMemory.Text = (GC.GetTotalMemory(false) / 1024 / 1024) + " MB";
		}

		private void FormLoaded(object sender, System.EventArgs e)
		{
			if (false == DisksDB.Config.Config.Instance.ConfigFileExists)
			{
				FormFirstRun f = new FormFirstRun(DisksDB.DataBase.DataBase.Instance);
				f.ShowDialog();
			}		
		}

		private void CopyDataBaseClick(object sender, System.EventArgs e)
		{
			FormCopyDataBase f = new FormCopyDataBase(DisksDB.DataBase.DataBase.Instance);
			f.ShowDialog();
			f.Dispose();
		}

		private void buttonNew_Click(object sender, EventArgs e)
		{
			System.Windows.Forms.ContextMenu m = new System.Windows.Forms.ContextMenu();

			foreach (MenuItem mi in this.mnu.MenuItems[0].MenuItems)
			{
				m.MenuItems.Add(mi.CloneMenu());
			}

			m.Show(this.toolBar2x1, new System.Drawing.Point(0, this.toolBar2x1.Height));
		}

		private void buttonProperties_Click(object sender, EventArgs e)
		{
			this.mnu.PropertiesClick(sender, e);
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			this.mnu.DeleteClick(sender, e);
		}

        private void InitSyncServer(bool start)
        {
            if (true == start)
            {
                try
                {
                    SyncServer.Instance.Start();
                }
                catch (Exception ex)
                {
                    Logger.LogException(ex);
                    Language.I18N.Instance.MessageShow(this, ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SyncServer.Instance.Stop();
            }
        }
	}
}
