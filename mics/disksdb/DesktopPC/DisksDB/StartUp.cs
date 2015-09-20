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
using DisksDB.UserInterface;
using DisksDB.Utils;
using System;
using System.Threading;
using System.Windows.Forms;

namespace DisksDB
{
	/// <summary>
	/// Entry point class of the application.
	/// </summary>
	public class StartUp
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main()
		{
            Mutex mx = null;

            bool own = false;

            try
            {
                mx = new Mutex(true, "DisksDB.{5C592533-5E1A-48cb-864C-982359997CA2}", out own);
                
                if (true == own)
                {
                    try
                    {
                        Thread.CurrentThread.Name = "DisksDB main Thread";
                        Application.EnableVisualStyles();
                        Application.DoEvents();
                        Application.Run(new FormMain());
                    }
                    catch (Exception ex)
                    {
                        Logger.LogException(ex);
                    }
                }
            }
            finally
            {
                if ((mx != null) && (true == own))
                {
                    mx.ReleaseMutex();
                }
            }
		}
	}
}
