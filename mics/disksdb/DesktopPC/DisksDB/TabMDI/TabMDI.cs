using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DisksDB.UserInterface.TabMDI
{
	/// <summary>
	/// Summary description for TabMDI.
	/// </summary>
	public class TabMDI : System.Windows.Forms.Control
	{
		private delegate void RefreshHandler();

		class TabButton
		{
			public int x;
			public TabPage panel;
		}

		private Font normalFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		private Font boldFont = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		private int selected = -1;
		private StringFormat stringFormat = new StringFormat();
		private int posx = 0;
		private System.Windows.Forms.Timer timer;
		private bool dir = false;
		private System.Drawing.SolidBrush grayBrush = new System.Drawing.SolidBrush(System.Drawing.SystemColors.Control);
		private System.Drawing.SolidBrush textBrush1 = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(85, 85, 85));
		//private System.Drawing.SolidBrush textBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
		protected System.Drawing.Color bgColor = System.Drawing.Color.FromArgb(247, 243, 233);
		protected System.Drawing.SolidBrush bgBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(247, 243, 233));
		private System.Collections.ArrayList buttonList = new System.Collections.ArrayList();
		private CXButton cxButton1;
		private CLButton clButton1;
		private CRButton crButton1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TabMDI()
		{
			// TODO: Add any initialization after the InitForm call
			this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint
				| System.Windows.Forms.ControlStyles.AllPaintingInWmPaint
				| System.Windows.Forms.ControlStyles.DoubleBuffer
							
				, true);



			// This call is required by the Windows.Forms Form Designer.
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;


			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

			this.cxButton1.Click += new System.EventHandler(this.cxButton_Click);

			this.clButton1.MouseDown += new MouseEventHandler(this.clButton_Press);
			this.clButton1.MouseUp += new MouseEventHandler(this.clButton_Release);

			this.crButton1.MouseDown += new MouseEventHandler(this.crButton_Press);
			this.crButton1.MouseUp += new MouseEventHandler(this.crButton_Release);

			this.timer = new System.Windows.Forms.Timer();//this.components);
			this.timer.Enabled = false;
			this.timer.Interval = 2;

			this.timer.Tick += new System.EventHandler(this.OnTimerTick);

			this.cxButton1.Enabled = false;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cxButton1 = new CXButton();
			this.clButton1 = new CLButton();
			this.crButton1 = new CRButton();
			this.SuspendLayout();
			// 
			// cxButton1
			// 
			this.cxButton1.Location = new System.Drawing.Point(680, 8);
			this.cxButton1.Name = "cxButton1";
			this.cxButton1.Size = new System.Drawing.Size(16, 16);
			this.cxButton1.TabIndex = 0;
			this.cxButton1.Text = "cxButton1";
			// 
			// clButton1
			// 
			this.clButton1.Location = new System.Drawing.Point(648, 8);
			this.clButton1.Name = "clButton1";
			this.clButton1.Size = new System.Drawing.Size(16, 16);
			this.clButton1.TabIndex = 1;
			this.clButton1.Text = "clButton1";
			// 
			// crButton1
			// 
			this.crButton1.Location = new System.Drawing.Point(664, 8);
			this.crButton1.Name = "crButton1";
			this.crButton1.Size = new System.Drawing.Size(16, 16);
			this.crButton1.TabIndex = 2;
			this.crButton1.Text = "crButton1";
			// 
			// TabMDI
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.crButton1,
																		  this.clButton1,
																		  this.cxButton1});
			this.Name = "TabMDI";
			this.Size = new System.Drawing.Size(704, 22);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(this.bgBrush, 0, 0, this.Width, this.Height);
			e.Graphics.DrawLine(System.Drawing.Pens.White, 0, 20, this.Width - 1, 20);
			e.Graphics.FillRectangle(this.grayBrush, 0, 21, this.Width, 3);//this.Height);
			//e.Graphics.DrawLine(this.grayPen, 0, this.Height - 1, this.Width - 1, this.Height - 1);
		}

		private void DrawSelectedButton(TabMDI.TabButton b, System.Drawing.Graphics g)
		{
			g.DrawLine(System.Drawing.Pens.White, b.x, 2, b.x, 20);
			g.DrawLine(System.Drawing.Pens.White, b.x, 2, b.x + b.panel.width, 2);
			g.DrawLine(System.Drawing.Pens.Black, b.x + b.panel.width  - 1, 3, b.x + b.panel.width - 1, 20);
			g.FillRectangle(this.grayBrush, b.x + 1, 3, b.panel.width - 2, 21);

			Rectangle rect = new Rectangle(b.x, 2 + 2, b.panel.width, 17);
			g.DrawString(b.panel.Text, this.boldFont, System.Drawing.Brushes.Black, rect, this.stringFormat);
		}

		private void DrawButton(TabMDI.TabButton b, System.Drawing.Graphics g)
		{
			Rectangle rect = new Rectangle(b.x, 2 + 2, b.panel.width, 17);
			g.DrawString(b.panel.Text, this.normalFont, this.textBrush1, rect, this.stringFormat);
		}

		private void RenderButtons(System.Drawing.Graphics g)
		{
			for (int i = 0; i < this.buttonList.Count; i++)
			{
				TabMDI.TabButton b = (TabMDI.TabButton)this.buttonList[i];
		
				if (i == this.selected)
				{
					DrawSelectedButton(b, g);
				} 
				else
				{
					DrawButton(b, g);

					if (i + 1 != this.selected)
					{
						g.DrawLine(System.Drawing.Pens.Gray, b.x + b.panel.width  - 1, 4, b.x + b.panel.width  - 1, 18);
					}
				}
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			this.OnPaintBackground(e);
			this.RenderButtons(e.Graphics);
			e.Graphics.FillRectangle(this.bgBrush, this.Width - 54, 2, 52, 18);
			e.Graphics.DrawLine(System.Drawing.Pens.White, this.Width - 54, 20, this.Width - 3, 20);
			if (this.drawBorder)
			{
				this.OnDrawBorder(e);
			}
		}

		private void PlaceButtons()
		{
			int x = 3;

			for (int i = 0; i < this.buttonList.Count; i++)
			{
				TabMDI.TabButton b = (TabMDI.TabButton)this.buttonList[i];
				
				b.x = posx + x;
				//				b.y = 2;

				x += b.panel.width;
			}

			if (this.buttonList.Count > 0)
			{
				this.clButton1.Enable = (
					((TabButton)this.buttonList[this.buttonList.Count - 1]).x
					+ 
					((TabButton)this.buttonList[this.buttonList.Count - 1]).panel.width
					> this.Width - 52);

				this.crButton1.Enable = (
					((TabButton)this.buttonList[0]).x < 0);

			}
		}

		private void ResizeButton(int id, bool large)
		{
			if (id < 0) return;

			Graphics g = Graphics.FromHwnd(this.Handle);
			TabButton but = (TabButton)this.buttonList[id];

			if (large)
			{
				but.panel.width = (int)(g.MeasureString(but.panel.Text, this.boldFont).Width * 1.2);
			} 
			else
			{
				but.panel.width = (int)(g.MeasureString(but.panel.Text, this.normalFont).Width * 1.2);
			}
		}

		internal void ResizeButton(TabPage page, bool large)
		{
			Graphics g = Graphics.FromHwnd(this.Handle);

			if (large)
			{
				page.width = (int)(g.MeasureString(page.text, this.boldFont).Width * 1.2);
			} 
			else
			{
				page.width = (int)(g.MeasureString(page.text, this.normalFont).Width * 1.2);
			}
		}

		private void ResizeButtons()
		{
			for (int i = 0; i < this.buttonList.Count; i++)
			{
				ResizeButton(i, i == selected);
			}
		}

		public void Add(string text, Form f)
		{
			TabButton but = new TabButton();
			//			but.y = 2;

			TabPage panel = new TabPage();

			Control c = f.Controls[0];

			c.Parent = null;

			panel.Controls.Add(c);

			but.panel = panel;
			but.panel.text = f.Text; //text;
			this.Controls.Add(panel);
			//panel.Visible = true;
			Activate(but);

			panel.tabControl = this;
			panel.Location = new System.Drawing.Point(2, 24);
			panel.Size = new System.Drawing.Size(this.Width-4, this.Height - 26);

			this.buttonList.Add(but);
			if (this.selected >= 0)
			{
				ResizeButton(this.selected, false);
			}
			this.selected = this.buttonList.Count - 1;
			ResizeButton(this.selected, true);
			PlaceButtons();
			Invalidate();

			this.cxButton1.Enabled = this.SelectedTab.IsCloseable;

			if (null != this.SelectedIndexChanged) this.SelectedIndexChanged(this, null);

			panel.Activate();
		}

		private void clButton_Press(object sender, MouseEventArgs e)
		{
			this.timer.Enabled = true;
			dir = false;
		}

		private void clButton_Release(object sender, MouseEventArgs e)
		{
			this.timer.Enabled = false;
		}

		private void crButton_Press(object sender, MouseEventArgs e)
		{
			this.timer.Enabled = true;
			dir = true;
		}

		private void crButton_Release(object sender, MouseEventArgs e)
		{
			this.timer.Enabled = false;
		}

		private void OnTimerTick(object sender, System.EventArgs e)
		{
			if (dir)
			{
				if (this.posx < 0)
				{
					this.posx += 5;

					if (this.crButton1.Enable == false)
					{
						this.timer.Enabled = false;
					}

				}
			} 
			else
			{
				if ( ((TabButton)this.buttonList[this.buttonList.Count - 1]).x > 0)
				{
					this.posx -= 5;

					if (this.clButton1.Enable == false)
					{
						this.timer.Enabled = false;
					}
				}
			}

			PlaceButtons();
			Invalidate();
		}

		private void Activate(TabButton b)
		{
			foreach (TabButton b1 in this.buttonList)
			{
				if (b == b1)
				{
					b1.panel.Visible = true;
					b1.panel.Activate();
				}
				else
				{
					b1.panel.Visible = false;
				}
				
			}
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			int x = e.X;
			int y = e.Y;

			for (int i = 0; i < this.buttonList.Count; i++)
			{
				TabButton b = (TabButton)this.buttonList[i];

				if ( (x >= b.x) && ( x <= b.x + b.panel.width))
				{
					if (b.x < 0)
					{
						this.posx += (b.x * -1);
					}

					if (this.selected >= 0)
					{
						ResizeButton(this.selected, false);
					}
					this.selected = i;
					Activate(b);
					ResizeButton(this.selected, true);
					PlaceButtons();
					Invalidate();
					if (null != this.SelectedIndexChanged) this.SelectedIndexChanged(this, null);
					this.cxButton1.Enabled = this.SelectedTab.IsCloseable;
					return;
				}
			}
		}
		
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			this.cxButton1.Location = new System.Drawing.Point(this.Width - 20, 4);
			this.crButton1.Location = new System.Drawing.Point(this.Width - 36, 4);
			this.clButton1.Location = new System.Drawing.Point(this.Width - 52, 4);

			foreach (TabButton b in this.buttonList)
			{
				b.panel.Location = new System.Drawing.Point(2, 24);
				b.panel.Size = new System.Drawing.Size(this.Width-4, this.Height - 26);
			}

			Invalidate();
			Update();
		}

		private void cxButton_Click(object sender, System.EventArgs e)
		{
			this.Remove(this.SelectedTab);
			//
			//			//((TabButton)this.buttonList[this.selected]).form.Close();
			//
			//			this.buttonList.RemoveAt(this.selected);
			//			this.selected--;
			//
			//			if ( (this.selected < 0) && (this.buttonList.Count > 0) ) this.selected = 0;
			//			ResizeButton(this.selected, true);
			//			PlaceButtons();
			//			Invalidate();
			//
			//			if (this.selected < 0) this.cxButton1.Enabled = false;
			//			if (this.buttonList.Count <= 0) this.cxButton1.Enabled = false;
		}

		public void Remove(TabPage page)
		{
			for (int i = 0; i < this.buttonList.Count; i++)
			{
				TabButton b = (TabButton)this.buttonList[i];

				if (b.panel == page)
				{
					this.buttonList.RemoveAt(i);
					this.Controls.Remove(page);

					if (i == this.selected) this.selected--;

					if ( (this.selected < 0) && (this.buttonList.Count > 0) ) this.selected = 0;
					if (this.selected >= 0) this.SelectedTab.Visible = true;
					ResizeButton(this.selected, true);
					PlaceButtons();
					Invalidate();

					this.cxButton1.Enabled = this.SelectedTab.IsCloseable;
					SelectedIndexChanged(this, null);
					this.SelectedTab.Activate();

					if (this.selected < 0) this.cxButton1.Enabled = false;
					if (this.buttonList.Count <= 0) this.cxButton1.Enabled = false;
					page.OnClose();

					return;
				}
			}
		}

		private void OnDrawBorder(System.Windows.Forms.PaintEventArgs e)
		{
			e.Graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.SystemBrushes.ControlDark),
				0, 0, this.Width - 1, this.Height - 1);

			e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.SystemBrushes.ControlLight),
				1, 1, 1, this.Height - 2);

			e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.SystemBrushes.ControlLight),
				1, this.Height - 2, this.Width - 2, this.Height - 2);

			e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.SystemBrushes.ControlLight),
				this.Width - 2, 1, this.Width - 2, this.Height - 2);

			//			e.Graphics.DrawLine(new System.Drawing.Pen(System.Drawing.SystemBrushes.ControlDark),
			//				this.Width - 2, 1, this.Width - 1, 1
			//				);
		}


		public bool DrawBorder
		{
			set
			{
				this.drawBorder = value;
				Invalidate();
				Update();
			}
			get
			{
				return this.drawBorder;
			}
		}

		protected bool	drawBorder = false;

		public int SelectedIndex
		{
			get
			{
				return this.selected;
			}
			//			set
			//			{
			//			}
		}


		public event EventHandler SelectedIndexChanged;

		public int TabCount
		{
			get
			{
				return this.buttonList.Count;
			}
		}

		public TabPage SelectedTab
		{
			get
			{
				return ((TabButton)this.buttonList[this.selected]).panel;
			}
		}

		private void ReNew1()
		{
			ResizeButtons();
			PlaceButtons();
			Update();
			Invalidate();
		}

		internal void ReNew()
		{
			Invoke(new TabMDI.RefreshHandler(this.ReNew1));
		}

		public ArrayList TabPages
		{
			get
			{
				ArrayList p = new ArrayList();
				foreach (TabButton b in this.buttonList)
				{
					p.Add(b.panel);
				}

				return p;
			}
		}
	}

	public class TabPage : System.Windows.Forms.Panel
	{
		private delegate void OnActivatedHandler();

		internal TabMDI	tabControl	= null;
		internal string	text		= "";
		internal int	width		= 0;

		internal void SetTabControl(TabMDI tabControl)
		{
			this.tabControl = tabControl;
		}

		public void OnClose()
		{
		}

		public bool IsCloseable
		{
			get
			{
				return false;
			}
		}

		private void Close1()
		{
			tabControl.Remove(this);
		}

		//		public void Close()
		//		{
		//			Invoke(new OnCloseHandler(this.Close1));
		//		}

		public override string Text
		{
			set
			{
				this.text = value;
				if (null != this.tabControl) this.tabControl.ReNew(); else
				{
					//					throw new System.Exception("FGHDFH");
				}
			}
			get
			{
				return this.text;
			}
		}

		internal void Activate()
		{
			Invoke(new OnActivatedHandler(this.OnActivated));
		}

		protected virtual void OnActivated()
		{
		}
	}


	internal sealed class CXButton : CButtonBase
	{
		private void OnPaintX(System.Drawing.Graphics g, bool lower, int x, int y)
		{
			if (lower == false)
			{
				x++;
				y++;
			}
			g.DrawLine(System.Drawing.Pens.Black, x+0, y+0, x+6, y+6);
			g.DrawLine(System.Drawing.Pens.Black, x+1, y+0, x+7, y+6);
			g.DrawLine(System.Drawing.Pens.Black, x+6, y+0, x+0, y+6);
			g.DrawLine(System.Drawing.Pens.Black, x+7, y+0, x+1, y+6);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			OnPaintBackGround(e);
			if (this.mouseOver) OnPaintXBorder(e.Graphics, !this.mouseUp, 0, 0);
			OnPaintX(e.Graphics, this.mouseUp, 3, 3);
		}
	}

	internal sealed class CRButton : CButtonBase
	{
		private bool enabled = false;

		private System.Drawing.Point[] p = new System.Drawing.Point[3] 
		{
			new System.Drawing.Point(5+0, 3+0),
			new System.Drawing.Point(5+0, 3+8),
			new System.Drawing.Point(5+4, 3+4)
		};

		protected override void OnPaint(PaintEventArgs e)
		{
			OnPaintBackGround(e);
			if (this.mouseOver) OnPaintXBorder(e.Graphics, !this.mouseUp, 0, 0);

			if (enabled)
			{
				e.Graphics.FillPolygon(System.Drawing.Brushes.Black, p);
			} 
			else
			{
				e.Graphics.DrawLine(System.Drawing.Pens.Black, 5+0, 3+0, 5+0, 3+8);
				e.Graphics.DrawLine(System.Drawing.Pens.Black, 5+0, 3+0, 5+4, 3+4);
				e.Graphics.DrawLine(System.Drawing.Pens.Black, 5+0, 3+8, 5+4, 3+4);
			}
		}

		public bool Enable
		{
			set
			{
				base.Enabled = value;
				this.enabled = value;
				Invalidate();
				Update();
			}
			get
			{
				return this.enabled;
			}
		}
	}

	sealed internal class CLButton : CButtonBase
	{
		private bool enabled = true;
		private System.Drawing.Point[] p = new System.Drawing.Point[3] 
		{
			new System.Drawing.Point(4+4, 3+0),
			new System.Drawing.Point(4+4, 3+8),
			new System.Drawing.Point(4+0, 3+4)
		};

		protected override void OnPaint(PaintEventArgs e)
		{
			OnPaintBackGround(e);
			if (this.mouseOver) OnPaintXBorder(e.Graphics, !this.mouseUp, 0, 0);
			if (enabled)
			{
				e.Graphics.FillPolygon(System.Drawing.Brushes.Black, p);
			} 
			else
			{
				//e.Graphics.DrawLines(System.Drawing.Pens.Black, p);
				e.Graphics.DrawLine(System.Drawing.Pens.Black, 4+4, 3+0, 4+4, 3+8);
				e.Graphics.DrawLine(System.Drawing.Pens.Black, 4+4, 3+0, 4+0, 3+4);
				e.Graphics.DrawLine(System.Drawing.Pens.Black, 4+4, 3+8, 4+0, 3+4);
			}
		}

		public bool Enable
		{
			set
			{
				base.Enabled = value;
				this.enabled = value;
				Invalidate();
				Update();
			}
			get
			{
				return this.enabled;
			}
		}
	}
	internal class CButtonBase : System.Windows.Forms.Button
	{
		protected System.Drawing.Color bgColor = System.Drawing.Color.FromArgb(247, 243, 233);
		protected System.Drawing.SolidBrush bgBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(247, 243, 233));

		protected bool mouseUp = true;
		protected bool mouseOver = false;

		public CButtonBase()
		{
		}

		protected void OnPaintXBorder(System.Drawing.Graphics g, bool lower, int x, int y)
		{
			if (lower)
			{
				g.DrawLine(System.Drawing.Pens.Black, x+0, y+0, x+13, y+0);
				g.DrawLine(System.Drawing.Pens.Black, x+0, y+0, x+0, y+13);

				g.DrawLine(new System.Drawing.Pen(System.Drawing.SystemColors.Control), x+0, y+14, x+13, y+14);
				g.DrawLine(new System.Drawing.Pen(System.Drawing.SystemColors.Control), x+13, y+14, x+13, y+1);
			} 
			else
			{
				g.DrawLine(System.Drawing.Pens.LightGray, x+0, y+0, x+13, y+0);
				g.DrawLine(System.Drawing.Pens.LightGray, x+0, y+0, x+0, y+13);

				g.DrawLine(System.Drawing.Pens.Black, x+0, y+14, x+13, y+14);
				g.DrawLine(System.Drawing.Pens.Black, x+13, y+14, x+13, y+1);
			}
		}

		protected virtual void OnPaintBackGround(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(this.bgBrush, 0, 0, this.Width, this.Height);
		}

		//		protected override void OnPaint(PaintEventArgs e)
		//		{
		//			OnPaintBackGround(e);
		//
		//
		//
		//			if (this.mouseOver) OnPaintXBorder(e.Graphics, !this.mouseUp, 0, 0);
		//
		//			//OnPaintX(e.Graphics, this.mouseUp, 3, 3);
		//
		//			//OnPaintArrowLeft(e.Graphics, this.mouseUp, 3, 3);
		//
		//		}

		protected override void OnMouseDown(MouseEventArgs mea)
		{
			if (mea.Button == MouseButtons.Left)
			{
				mouseUp = false;
			}

			base.OnMouseDown(mea);

			this.Invalidate();
		}

		protected override void OnMouseMove(MouseEventArgs mea)
		{
			base.OnMouseMove(mea);

			if ( (mea.X < 0) || (mea.Y < 0) || (mea.X > this.Width) || (mea.Y > this.Height))
			{
				this.mouseOver = false;
				Invalidate();
				Update();
				return;
			}
			
			if (this.mouseOver == false)
			{
				mouseOver = true;
			} 
			else
			{
				this.mouseOver = true;
			}

			Invalidate();
			Update();
		}

		protected override void OnMouseUp(MouseEventArgs mea)
		{
			if (mea.Button == MouseButtons.Left)
				mouseUp = true;

			base.OnMouseUp(mea);

			Invalidate();
			Update();
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			mouseOver = false;
			Invalidate();
			Update();
		}
	}
}
