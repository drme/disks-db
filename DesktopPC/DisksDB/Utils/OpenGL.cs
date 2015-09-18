using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DisksDB.Utils
{
    public class OpenGL
    {
        public OpenGL(IntPtr hWnd, IntPtr hDC)
        {
            this.hWnd = hWnd;
            this.hDC = hDC;

            InitPixelFormat();
            InitRenderContext();

            LoadLibrary("opengl32.dll");

            string v1 = glGetString(0x2f00);
            string v2 = glGetString(0x2f01);
            string v3 = glGetString(0x2f02);
            string v4 = glGetString(0x2f03);

            System.Diagnostics.Debug.WriteLine(v1);
        }

        private void InitPixelFormat()
        {
            PIXELFORMATDESCRIPTOR pfd;

            pfd.nSize = 40;
            pfd.nVersion = 1;
            pfd.dwFlags = PFD_DRAW_TO_WINDOW + PFD_SUPPORT_OPENGL + /*PFD_GENERIC_ACCELERATED |*/ PFD_DOUBLEBUFFER;
            pfd.iPixelType = 0; // PFD_TYPE_RGBA == 0
            pfd.cColorBits = 32;
            pfd.cRedBits = 0;
            pfd.cRedShift = 0;
            pfd.cGreenBits = 0;
            pfd.cGreenShift = 0;
            pfd.cBlueBits = 0;
            pfd.cBlueShift = 0;
            pfd.cAlphaBits = 0;
            pfd.cAlphaShift = 0;
            pfd.cAccumBits = 0;
            pfd.cAccumRedBits = 0;
            pfd.cAccumGreenBits = 0;
            pfd.cAccumBlueBits = 0;
            pfd.cAccumAlphaBits = 0;
            pfd.cDepthBits = 24;
            pfd.cStencilBits = 8;
            pfd.cAuxBuffers = 0;
            pfd.iLayerType = 0; // PFD_MAIN_PLANE == 0
            pfd.bReserved = 0;
            pfd.dwLayerMask = 0;
            pfd.dwVisibleMask = 0;
            pfd.dwDamageMask = 0;

            //this.hDC = GetDC(this.hWnd);

            int iPixFormat = ChoosePixelFormat(hDC, ref pfd);
	
		    if (iPixFormat == 0 )
		    {
			    //::ReleaseDC(m_hWnd, hDC);

			    //WriteLine(L"^CRender^7: can't Find Selected PixelFormat");
			
			    //return false;
		    }

		int f = DescribePixelFormat(this.hDC, iPixFormat, 40, ref pfd);

        //    bool generic_format = pfd.dwFlags & PFD_GENERIC_FORMAT;
        //bool generic_accelerated = pfd.dwFlags & PFD_GENERIC_ACCELERATED;

            /*
		if (generic_format && ! generic_accelerated)
		{
			//::ReleaseDC(m_hWnd, hDC);

			//WriteLine(L"^CRender^7: Hardware aceeleration not found");
		

			//return false;
		}
		else if (generic_format && generic_accelerated)
		{
//			WriteLine(L"Render: Hardware Acceleration found");
		}
		else if (! generic_format && ! generic_accelerated)
		{
//			WriteLine(L"Render: Hardware Acceleration found");
		}


             * */
		bool k = SetPixelFormat(this.hDC, iPixFormat, ref pfd);
		//{
		//	::ReleaseDC(m_hWnd, hDC);

		//	WriteLine(L"^CRender^7: Can't Set PixelFormat");
		
		//	return false;
		//}

		//WriteLine(Utils::String(L"Render: Pixel Format ") + iPixFormat + L" selected\n");

//		::ReleaseDC(m_hWnd, hDC);

//		return true;


        if (k == true)
        {
        }

       // ReleaseDC(this.hWnd, this.hDC);
        }

        private void InitRenderContext()
        {
            //this.hDC = GetDC(this.hWnd);
            this.hRC = wglCreateContext(this.hDC);

            UInt32 f = GetLastError();



            bool rez = wglMakeCurrent(this.hDC, this.hRC);

            if (rez == true)
            {
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        struct PIXELFORMATDESCRIPTOR
        {
            public UInt16 nSize; 
            public UInt16 nVersion;
            public UInt32 dwFlags;
            public byte iPixelType;
            public byte cColorBits;
            public byte cRedBits;
            public byte cRedShift;
            public byte cGreenBits;
            public byte cGreenShift;
            public byte cBlueBits;
            public byte cBlueShift;
            public byte cAlphaBits;
            public byte cAlphaShift;
            public byte cAccumBits;
            public byte cAccumRedBits;
            public byte cAccumGreenBits;
            public byte cAccumBlueBits;
            public byte cAccumAlphaBits;
            public byte cDepthBits;
            public byte cStencilBits;
            public byte cAuxBuffers;
            public byte iLayerType;
            public byte bReserved;
            public UInt32 dwLayerMask;
            public UInt32 dwVisibleMask;
            public UInt32 dwDamageMask;
        }

        private static uint PFD_DOUBLEBUFFER            = 0x00000001;
        private static uint PFD_STEREO                  = 0x00000002;
        private static uint PFD_DRAW_TO_WINDOW          = 0x00000004;
        private static uint PFD_DRAW_TO_BITMAP          = 0x00000008;
        private static uint PFD_SUPPORT_GDI             = 0x00000010;
        private static uint PFD_SUPPORT_OPENGL          = 0x00000020;
        private static uint PFD_GENERIC_FORMAT          = 0x00000040;
        private static uint PFD_NEED_PALETTE            = 0x00000080;
        private static uint PFD_NEED_SYSTEM_PALETTE     = 0x00000100;
        private static uint PFD_SWAP_EXCHANGE           = 0x00000200;
        private static uint PFD_SWAP_COPY               = 0x00000400;
        private static uint PFD_SWAP_LAYER_BUFFERS      = 0x00000800;
        private static uint PFD_GENERIC_ACCELERATED     = 0x00001000;
        private static uint PFD_SUPPORT_DIRECTDRAW      = 0x00002000;

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("kernel32.dll")]
        private static extern UInt32 GetLastError();

        [DllImport("opengl32.dll")]
        private static extern Int32 wglCreateContext(IntPtr hDC);

        [DllImport("opengl32.dll")]
        private static extern bool wglMakeCurrent(IntPtr hDC, Int32 hRC);

        [DllImport("gdi32.dll")]
        private static extern int ChoosePixelFormat(IntPtr hDC, ref PIXELFORMATDESCRIPTOR pdf);

        [DllImport("gdi32.dll")]
        private static extern int DescribePixelFormat(IntPtr hdc, int iPixelFormat, uint nBytes, ref PIXELFORMATDESCRIPTOR ppfd);

        [DllImport("gdi32.dll")]
        private static extern bool SetPixelFormat(IntPtr hDC, int iPixelFormat, ref PIXELFORMATDESCRIPTOR pdf);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hDC, IntPtr hWnd);

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string strFileName);

        [DllImport("opengl32.dll")]
        private static extern string glGetString(int name);
        
        private IntPtr hWnd = IntPtr.Zero;
        private IntPtr hDC = IntPtr.Zero;
        private Int32 hRC = 0;
    }
}
