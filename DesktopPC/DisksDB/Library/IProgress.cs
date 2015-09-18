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
namespace DisksDB.DataBase
{
	/// <summary>
	/// Progress notification interface.
	/// Consists of two parts:
	/// Totall progress. And step detalization by one step.
	/// For example (Adding 100 disks, and each disks has some files)
	/// So Total() and Progress() measures disks count and
	/// TotallSmall() and ProgressSmall() measures files count in current disk.
	/// </summary>
	public interface IProgress
	{
		void Started();
		void Total(long total);
		void Progress(long progress);
		void Finished();
		void Canceled();
		bool ToCancel();
		void Failed(string message);
		void Message(string message);
		
		/// <summary>
		/// Detailed total count of one step.
		/// </summary>
		/// <param name="totall"></param>
		void TotallSmall(long totall);

		/// <summary>
		/// Advances by step count of detailed count.
		/// </summary>
		/// <param name="progress"></param>
		void ProgressSmall(long progress);
	}
}
