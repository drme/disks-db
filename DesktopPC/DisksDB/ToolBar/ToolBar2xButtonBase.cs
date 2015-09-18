using System;
using System.Drawing;
using System.Windows.Forms;

namespace DisksDB.UserInterface.ToolBar
{
	/// <summary>
	/// Summary description for ToolBar2xButtonBase.
	/// </summary>
	public class ToolBar2xButtonBase
	{
		public event EventHandler Click;
		protected Icon img;
		protected Image imgGrayScale;
		protected int height = 22;
		protected ToolBar2x parent;
		protected bool enabled = true;

		public ToolBar2xButtonBase(Icon img, ToolBar2x parent)
		{
			this.parent = parent;
			this.img = img;
			MakeGrayScaleImage();
		}

		public bool Enabled
		{
			get
			{
				return this.enabled;
			}
			set
			{
				this.enabled = value;
				this.parent.Invalidate();
				this.parent.Update();
			}
		}
        
		private void MakeGrayScaleImage()
		{
			if (null != this.img)
			{
				this.imgGrayScale = new Bitmap(this.img.ToBitmap(), this.height - 6, this.height - 6);
			}
		}

		internal void SetHeight(int height)
		{
			if (this.height != height)
			{
				this.height = height;
				MakeGrayScaleImage();
			}
		}

		internal void OnClick()
		{
			if (this.enabled == true)
			{
				if (null != this.Click)
				{
					this.Click(this, EventArgs.Empty);
				}
			}
		}

		internal virtual int Width
		{
			get
			{
				return this.height;
			}
		}

		internal virtual void Paint(Graphics g, int startx, bool selected, bool pressed)
		{
			if (true == this.enabled)
			{
				if (true == pressed)
				{
					if (true == selected)
					{
						g.DrawRectangle(ColorsHelper.PenSelectionBorder, startx, 2, height-1, height-1);
						g.FillRectangle(ColorsHelper.BrushSelectionInside, startx + 1, 3, this.height - 2, height - 2);
						g.DrawIcon(this.img, new Rectangle(startx + 3, 5, this.height - 6, this.height - 6));
					} 
					else
					{
						g.DrawRectangle(ColorsHelper.PenSelectionBorder, startx, 2, height-1, height-1);
						g.FillRectangle(ColorsHelper.BrushSelectionInside, startx + 1, 3, this.height - 2, height - 2);
						ControlPaint.DrawImageDisabled(g, this.imgGrayScale, startx + 3, 5, ColorsHelper.ColorSelectionInside);
						g.DrawIcon(this.img, new Rectangle(startx + 2, 4, this.height - 6, this.height - 6));
					}
				} 
				else
				{
					if (true == selected)
					{
						g.DrawRectangle(ColorsHelper.PenSelectionBorder, startx, 2, height-1, height-1);
						g.FillRectangle(ColorsHelper.BrushSelectionInside, startx + 1, 3, this.height - 2, height - 2);
						ControlPaint.DrawImageDisabled(g, this.imgGrayScale, startx + 3, 5, ColorsHelper.ColorSelectionInside);
						g.DrawIcon(this.img, new Rectangle(startx + 2, 4, this.height - 6, this.height - 6));
					} 
					else
					{
						g.DrawIcon(this.img, new Rectangle(startx + 3, 5, this.height - 6, this.height - 6));
					}
				}
			} 
			else
			{
				ControlPaint.DrawImageDisabled(g, this.imgGrayScale, startx + 3, 5, System.Drawing.SystemColors.Control);
			}
		}
	}
}
