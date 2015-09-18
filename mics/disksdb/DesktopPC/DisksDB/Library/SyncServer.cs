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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DisksDB.Utils;

namespace DisksDB.DataBase
{
	/// <summary>
	/// Summary description for SyncServer.
	/// </summary>
	public class SyncServer
	{
		private SyncServer()
		{
			this.mutex.WaitOne();

			this.sharedMem = new SharedMemory(true, "DisksDB.SharedMem1.{5A76CE94-3E60-4773-B897-62E7FE2A0053}", 10);

			this.sharedMem.Data = true;

			this.mutex.ReleaseMutex();
		}

		private void UpdateIsRunning()
		{
			this.mutex.WaitOne();

			bool run = (bool)this.sharedMem.Data;

			this.mutex.ReleaseMutex();

			if (false == run)
			{
				Stop();	
			}
		}

		public static SyncServer Instance
		{
			get
			{
				if (null == syncServer)
				{
					syncServer = new SyncServer();
				}

				return syncServer;
			}
		}

		public void Start(bool exitOnclientDisconnect)
		{
			this.shutdownOnClientDisconnect = exitOnclientDisconnect;
			Start();
		}

		public void Start()
		{
            Start("192.168.55.100");
		}

		public void Start(string listenAddress)
		{
            if (true == this.IsRunning)
            {
                return;
            }

            this.server = new TcpListener(IPAddress.Any, defaultServerPort);

			this.server.Start();

			this.IsRunning = true;

			this.thread = new Thread(new ThreadStart(ThreadProc));
            this.thread.Priority = ThreadPriority.Lowest;
			this.thread.Start();
		}

		public void Stop()
		{
			this.IsRunning = false;
		}

		public void WaitForExit()
		{
			if (null != this.thread)
			{
				this.thread.Join();
			}
		}

		public bool IsRunning
		{
			get
			{
				lock (this)
				{
					return this.running;
				}
			}
			set
			{
				lock (this)
				{
					this.running = value;
				}
			}
		}

		private void ThreadProc()
		{
			while (true == this.IsRunning)
			{
				UpdateIsRunning();

				Thread.Sleep(defaultSleep);
                
				if (true == this.server.Pending())
				{
					ServiceClient();

					if (true == this.shutdownOnClientDisconnect)
					{
						break;
					}
				}
			}
		}

		private void ServiceClient()
		{
            try
            {
                this.thread.Priority = ThreadPriority.Normal;

                TcpClient tcpClient = this.server.AcceptTcpClient();

                Debug.WriteLine("Client connected from " + tcpClient.ToString());

                Stream stream = tcpClient.GetStream();

                StreamReader sr = new StreamReader(stream, Encoding.UTF7);

                string str = null;

                OnClientConnected();

                while (null != (str = sr.ReadLine()))
                {
                    if (true == ParseCommand(str, tcpClient))
                    {
                        break;
                    }
                }

                tcpClient.Close();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
            finally
            {
                this.thread.Priority = ThreadPriority.Lowest;

                OnClientDisconnected();
            }
		}

		private string BuildBoxes(string str)
		{
			string[] ids = str.Split('|');

			long[] lids = new long[ids.Length - 2];

			DateTime lastSync = new DateTime(long.Parse(ids[1]));

			for (int i = 2; i < ids.Length; i++)
			{
				lids[i - 2] = long.Parse(ids[i]);
			}

			DataSetSync ds = DataBase.Instance.LowAccessLayer.GetBoxesChanges(lastSync, lids);

			StringBuilder sb = new StringBuilder();

			foreach (DataSetSync.BoxesRow dr in ds.Boxes.Rows)
			{
				sb.Append("|");
				sb.Append(dr.id);

				switch (dr.Flag)
				{
					case 2:
						sb.Append("|d");
						break;
					case 1:
						sb.Append("|u|");
						sb.Append(dr.Name);
						sb.Append('|');
						sb.Append(dr.Category);
						//sb.Append('|');
						//sb.Append(dr.Description);
						break;
					default:
						sb.Append("|i|");
						sb.Append(dr.Name);
						sb.Append('|');
						sb.Append(dr.Category);
						//sb.Append('|');
						//sb.Append(dr.Description);
						break;
				}
			}

			return sb.ToString();
		}

		private string BuildDisks(string str)
		{
			string[] ids = str.Split('|');

			DateTime lastSync = new DateTime(long.Parse(ids[1]));

			long[] lids = new long[ids.Length - 2];


			for (int i = 2; i < ids.Length; i++)
			{
				lids[i - 2] = long.Parse(ids[i]);
			}

			DataSetSync ds = DataBase.Instance.LowAccessLayer.GetDisksChanges(lastSync, lids);

			StringBuilder sb = new StringBuilder();

			foreach (DataSetSync.DisksRow dr in ds.Disks.Rows)
			{
				sb.Append("|");
				sb.Append(dr.id);

				switch (dr.Flag)
				{
					case 2:
						sb.Append("|d");
						break;
					case 1:
						sb.Append("|u|");
						sb.Append(dr.Name);
						sb.Append('|');
						sb.Append(dr.Box);
						//sb.Append('|');
						//sb.Append(dr.Description);
						break;
					default:
						sb.Append("|i|");
						sb.Append(dr.Name);
						sb.Append('|');
						sb.Append(dr.Box);
						//sb.Append('|');
						//sb.Append(dr.Description);
						break;
				}
			}

			return sb.ToString();
		}

		private void SendFiles(string str, TcpClient tcpClient)
		{
			/**
			 * Breaked in parts files list sending
			 */

			string[] ids = str.Split('|');

			long id = long.Parse(ids[1]);

			DataSetSync ds = DataBase.Instance.LowAccessLayer.GetFiles(id);

//			long packets = (long)Math.Ceiling((double)ds.Files.Rows.Count / 1000.0);

			//SendMessage("f" + BuildFiles(str), tcpClient);

			StringBuilder sb = null;

			//sb.Append("|");
			//sb.Append(id);

			int cnt = 0;

			foreach (DataSetSync.FilesRow dr in ds.Files.Rows)
			{
				if (cnt == 0)
				{
					sb = new StringBuilder();

					sb.Append("f|");
					sb.Append(id);
				}

				sb.Append("|");
				sb.Append(dr.id);
				sb.Append("|");
				sb.Append(dr.Name);
				sb.Append('|');
				sb.Append(dr.IsParentNull() ? "" : dr.Parent.ToString());
				sb.Append('|');
				sb.Append(dr.Size);
				sb.Append('|');
				sb.Append(dr.Attributes);
				sb.Append('|');
				sb.Append(dr.Date.Ticks);

				cnt++;

				if (cnt == 1000)
				{
					SendMessage(sb.ToString(), tcpClient);

					cnt = 0;
				}
			}

			if (cnt > 0)
			{
				SendMessage(sb.ToString(), tcpClient);

				cnt = 0;
			}

			SendMessage("e", tcpClient);
		}

		private string BuildCategories(string str)
		{
			string[] ids = str.Split('|');

			long[] lids = new long[ids.Length - 2];

			DateTime lastSync = new DateTime(long.Parse(ids[1]));

			for (int i = 2; i < ids.Length; i++)
			{
				lids[i - 2] = long.Parse(ids[i]);
			}

			DataSetSync ds = DataBase.Instance.LowAccessLayer.GetCategoriesChanges(lastSync, lids);

			StringBuilder sb = new StringBuilder();

			foreach (DataSetSync.CategoriesRow dr in ds.Categories.Rows)
			{
				sb.Append("|");
				sb.Append(dr.id);

				switch (dr.Flag)
				{
					case 2:
						sb.Append("|d");
						break;
					case 1:
						sb.Append("|u|");
						sb.Append(dr.Name);
						sb.Append('|');
						sb.Append(dr.IsParentNull() ? "" : dr.Parent.ToString());
						//sb.Append('|');
						//sb.Append(dr.Description);
						break;
					default:
						sb.Append("|i|");
						sb.Append(dr.Name);
						sb.Append('|');
						sb.Append(dr.IsParentNull() ? "" : dr.Parent.ToString());
						//sb.Append('|');
						//sb.Append(dr.Description);
						break;
				}
			}

			return sb.ToString();
		}

		private bool ParseCommand(string str, TcpClient tcpClient)
		{
			Debug.WriteLine("Got Command [" + str + "]");

			if (str.Length <= 0)
			{
				return false;
			}

			switch (str[0])
			{
				case 'q':
					return true;
				case 'i':
					SendMessage("i|" + DataBase.Instance.LowAccessLayer.GetDataBaseId(), tcpClient);
					break;
				case 'c':
					SendMessage("c" + BuildCategories(str), tcpClient);
					break;
				case 'b':
					SendMessage("b" + BuildBoxes(str), tcpClient);
					break;
				case 'd':
					SendMessage("d" + BuildDisks(str), tcpClient);
					break;
				case 'f':
					//SendMessage("f" + BuildFiles(str), tcpClient);
					SendFiles(str, tcpClient);
					break;
				default:
					Debug.WriteLine("Unrecognized command [" + str + "]");
					break;
			}

			return false;
		}

		private void SendMessage(string msg, TcpClient tcpClient)
		{
			msg += "\n";

			byte[] buf = new byte[Encoding.UTF7.GetByteCount(msg)];

			int len = Encoding.UTF7.GetBytes(msg, 0, msg.Length, buf, 0);

			tcpClient.GetStream().Write(buf, 0, len);
		}

        public void Kill()
        {
            if (null != this.thread)
            {
                this.thread.Abort();
            }
        }

        protected void OnClientConnected()
        {
            if (null != ClientConnected)
            {
                ClientConnected();
            }
        }

        protected void OnClientDisconnected()
        {
            if (null != ClientDisconnected)
            {
                ClientDisconnected();
            }
        }

        public delegate void ClientConnectedEvent();
        public delegate void ClientDisconnectedEvent();

        public event ClientConnectedEvent ClientConnected;
        public event ClientDisconnectedEvent ClientDisconnected;
		private TcpListener server = null;
		private bool running = false;
		private Thread thread = null;
		private string listenAddress = null;
		private static SyncServer syncServer = null;
		private static TimeSpan defaultSleep = new TimeSpan(1000);
		private static int defaultServerPort = 29465;
		private bool shutdownOnClientDisconnect = false;
		private SharedMemory sharedMem = null;
		private Mutex mutex = new Mutex(false, "DisksDB.Mutex.{5A76CE94-3E60-4773-B897-62E7FE2A0053}");
    }
}
