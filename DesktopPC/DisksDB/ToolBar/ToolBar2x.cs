using System;
using System.Collections;
using System.Windows.Forms;

namespace DisksDB.UserInterface.ToolBar
{
	/// <summary>
	/// Summary description for ToolBar2x.
	/// </summary>
	public class ToolBar2x : System.Windows.Forms.Control
	{
		public ArrayList buttons = new ArrayList();
		private int mouseX = -1;
		private int mouseY = -1;
		private ToolBar2xButtonBase pressedButton = null;

		public ToolBar2x()
		{
			this.SetStyle(//System.Windows.Forms.ControlStyles.UserPaint
				 System.Windows.Forms.ControlStyles.AllPaintingInWmPaint
				|  System.Windows.Forms.ControlStyles.DoubleBuffer
							
				, true);

			this.Height = 26;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(ColorsHelper.BrushBackColor, 1, 1, this.Width - 2, this.Height - 2);

			for (int i = 2; i < this.Height-2; i += 2)
			{
				e.Graphics.DrawLine(ColorsHelper.PenSeparatorColor, 3, i, 5, i);
			}

			int startX = 6;

			foreach (ToolBar2xButtonBase button in this.buttons)
			{
				button.SetHeight(this.Height - 4);

				int newStartX = startX + button.Width;

				bool selected = ((mouseX >= startX) && (mouseX <= newStartX) && (mouseY >= 1) && (mouseY <= this.Height));

				if (null != this.pressedButton)
				{
					if (this.pressedButton != button)
					{
						selected = false;
					}
				}

                button.Paint(e.Graphics, startX, selected, this.pressedButton == button);

				startX = newStartX;
			}
		}

		private ToolBar2xButtonBase PressedButton(int x, int y)
		{
			int startX = 6;

			foreach (ToolBar2xButtonBase button in this.buttons)
			{
				int newStartX = startX + button.Width;

				bool selected = ((x >= startX) && (x <= newStartX) && (y >= 1) && (y <= this.Height));

				if (true == selected)
				{
					return button;
				}

				startX = newStartX;
			}

			return null;
		}

		public ArrayList Buttons
		{
			get
			{
				return this.buttons;
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			this.mouseX = e.X;
			this.mouseY = e.Y;

//			if ( (this.mouseX >= 0) && (this.mouseX <= 6) && (this.mouseY >= 0) && (this.mouseY <= this.Height) )
//			{
//				this.Cursor = Cursors.SizeAll;
//			} 
//			else
//			{
//				this.Cursor = Cursors.Arrow;
//			}

			this.Invalidate();
			this.Update();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave (e);

			this.mouseX = -1;
			this.mouseY = -1;

//			this.Cursor = Cursors.Arrow;

			this.Invalidate();
			this.Update();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			ToolBar2xButtonBase button = PressedButton(e.X, e.Y);

			if (null != button)
			{
				if (button == this.pressedButton)
				{
					button.OnClick();
				}
			}		

			this.pressedButton = null;
			this.Invalidate();
			this.Update();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			ToolBar2xButtonBase button = PressedButton(e.X, e.Y);

			if (null != button)
			{
				this.pressedButton = button;
				this.Invalidate();
				this.Update();
			}
		}




















//				this.cxButton1.Click += new System.EventHandler(this.cxButton_Click);

//				this.clButton1.MouseDown += new MouseEventHandler(this.clButton_Press);
//				this.clButton1.MouseUp += new MouseEventHandler(this.clButton_Release);

//				this.crButton1.MouseDown += new MouseEventHandler(this.crButton_Press);
//				this.crButton1.MouseUp += new MouseEventHandler(this.crButton_Release);


//			private void clButton_Press(object sender, MouseEventArgs e)
//			{
//				this.timer.Enabled = true;
//				dir = false;
//			}

//			private void clButton_Release(object sender, MouseEventArgs e)
//			{
//				this.timer.Enabled = false;
//			}

//			private void crButton_Press(object sender, MouseEventArgs e)
//			{
//				this.timer.Enabled = true;
//				dir = true;
//			}

//			private void crButton_Release(object sender, MouseEventArgs e)
//			{
//				this.timer.Enabled = false;
//			}

//			private void OnTimerTick(object sender, System.EventArgs e)
//			{
//				if (dir)
//				{
//					if (this.posx < 0)
//					{
//						this.posx += 5;
//
//						if (this.crButton1.Enable == false)
//						{
//							this.timer.Enabled = false;
//						}
//
//					}
//				} 
//				else
//				{
//					if ( ((TabButton)this.buttonList[this.buttonList.Count - 1]).x > 0)
//					{
//						this.posx -= 5;
//
//						if (this.clButton1.Enable == false)
//						{
//							this.timer.Enabled = false;
//						}
//					}
//				}
//
//				PlaceButtons();
//				Invalidate();
//			}

//			private void Activate(TabButton b)
//			{
//				foreach (TabButton b1 in this.buttonList)
//				{
//					if (b == b1)
//					{
//						b1.panel.Visible = true;
//						b1.panel.Activate();
//					}
//					else
//					{
//						b1.panel.Visible = false;
//					}
//				
//				}
//			}
		
			protected  void OnMouseDown1(MouseEventArgs e)
			{
				int x = e.X;
				int y = e.Y;

//				for (int i = 0; i < this.buttonList.Count; i++)
//				{
//					TabButton b = (TabButton)this.buttonList[i];
//
//					if ( (x >= b.x) && ( x <= b.x + b.panel.width))
//					{
//						if (b.x < 0)
//						{
//							this.posx += (b.x * -1);
//						}
//
//						if (this.selected >= 0)
//						{
//							ResizeButton(this.selected, false);
//						}
//						this.selected = i;
//						Activate(b);
//						ResizeButton(this.selected, true);
//						PlaceButtons();
//						Invalidate();
//						if (null != this.SelectedIndexChanged) this.SelectedIndexChanged(this, null);
//						this.cxButton1.Enabled = this.SelectedTab.IsCloseable;
//						return;
//					}
//				}
			}
		
//			protected override void OnResize(EventArgs e)
//			{
//				base.OnResize(e);
//
////				this.cxButton1.Location = new System.Drawing.Point(this.Width - 20, 4);
////				this.crButton1.Location = new System.Drawing.Point(this.Width - 36, 4);
////				this.clButton1.Location = new System.Drawing.Point(this.Width - 52, 4);
////
////				foreach (TabButton b in this.buttonList)
////				{
////					b.panel.Location = new System.Drawing.Point(2, 24);
////					b.panel.Size = new System.Drawing.Size(this.Width-4, this.Height - 26);
////				}
//
//				Invalidate();
//				Update();
//			}

//			private void cxButton_Click(object sender, System.EventArgs e)
//			{
//				this.Remove(this.SelectedTab);
//				//
//				//			//((TabButton)this.buttonList[this.selected]).form.Close();
//				//
//				//			this.buttonList.RemoveAt(this.selected);
//				//			this.selected--;
//				//
//				//			if ( (this.selected < 0) && (this.buttonList.Count > 0) ) this.selected = 0;
//				//			ResizeButton(this.selected, true);
//				//			PlaceButtons();
//				//			Invalidate();
//				//
//				//			if (this.selected < 0) this.cxButton1.Enabled = false;
//				//			if (this.buttonList.Count <= 0) this.cxButton1.Enabled = false;
//			}

//			public void Remove(TabPage page)
//			{
//				for (int i = 0; i < this.buttonList.Count; i++)
//				{
//					TabButton b = (TabButton)this.buttonList[i];
//
//					if (b.panel == page)
//					{
//						this.buttonList.RemoveAt(i);
//						this.Controls.Remove(page);
//
//						if (i == this.selected) this.selected--;
//
//						if ( (this.selected < 0) && (this.buttonList.Count > 0) ) this.selected = 0;
//						if (this.selected >= 0) this.SelectedTab.Visible = true;
//						ResizeButton(this.selected, true);
//						PlaceButtons();
//						Invalidate();
//
//						this.cxButton1.Enabled = this.SelectedTab.IsCloseable;
//						SelectedIndexChanged(this, null);
//						this.SelectedTab.Activate();
//
//						if (this.selected < 0) this.cxButton1.Enabled = false;
//						if (this.buttonList.Count <= 0) this.cxButton1.Enabled = false;
//						page.OnClose();
//
//						return;
//					}
//				}
//			}


			private void ReNew1()
			{
//				ResizeButtons();
//				PlaceButtons();
				Update();
				Invalidate();
			}

			internal void ReNew()
			{
//				Invoke(new TabMDI.RefreshHandler(this.ReNew1));
			}

	}
}
