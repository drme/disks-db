using System;
using System.Drawing;
using Microsoft.Win32;

namespace DisksDB.UserInterface.ToolBar
{
	/// <summary>
	/// Summary description for ColorsHelper.
	/// </summary>
	public class ColorsHelper
	{
		internal static Pen PenSelectionBorder;
		internal static Brush BrushSelectionInside;
		internal static Pen PenSeparatorColor;
		internal static Brush BrushBackColor;
		internal static Color ColorSelectionInside;

		static ColorsHelper()
		{
			SetColors();

		//	SystemEvents.UserPreferenceChanged +=new UserPreferenceChangedEventHandler(SystemEvents_UserPreferenceChanged);
		}

		private static void SetColors()
		{
			PenSelectionBorder = System.Drawing.SystemPens.Highlight;
			ColorSelectionInside = ApplyAlphaBlend(PenSelectionBorder.Color, System.Drawing.SystemColors.Window, 70.0f/255.0f);
			BrushSelectionInside = new SolidBrush(ColorSelectionInside);
			PenSeparatorColor = System.Drawing.SystemPens.ControlDark;
			BrushBackColor =  new SolidBrush(ApplyAlphaBlend(System.Drawing.SystemColors.Control, System.Drawing.SystemColors.Window, 220.0f/255.0f));
		}

		private static void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
		{
			SetColors();
		}

		private static Color ApplyAlphaBlend(Color src, Color dst, float alpha)
		{
			// src * alpha + dst * (1 - alpha)
			return Color.FromArgb(ApplyAlphaBlend(src.R, dst.R, alpha), ApplyAlphaBlend(src.G, dst.G, alpha), ApplyAlphaBlend(src.B, dst.B, alpha));
		}

		private static int ApplyAlphaBlend(byte src, byte dst, float alpha)
		{
			return (int)(src * alpha + dst * (1 - alpha));
		}
	}
}
