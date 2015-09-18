using System;
using System.Drawing;

namespace DisksDB.UserInterface.ToolBar
{
	/// <summary>
	/// Summary description for ToolBar2xSeparator.
	/// </summary>
	public class ToolBar2xSeparator : ToolBar2xButtonBase
	{
		public ToolBar2xSeparator() : base(null, null)
		{
		}
		
		internal override int Width
		{
			get
			{
				return 4;
			}
		}

		internal override void Paint(Graphics g, int startx, bool selected, bool pressed)
		{
			g.DrawLine(System.Drawing.SystemPens.ControlDark, startx + 1, 3, startx + 1, height+0);
		}
	}
}
