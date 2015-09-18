using System;
using System.Collections.Generic;
using System.Text;

namespace DisksDB.Utils
{
    public class OpenGLControl : System.Windows.Forms.Control
    {
        public OpenGLControl()
        {
            this.HandleCreated += new EventHandler(OpenGLControl_HandleCreated);
        }

        void OpenGLControl_HandleCreated(object sender, EventArgs e)
        {
            System.Drawing.Graphics g = this.CreateGraphics();

            Init(g.GetHdc());
        }

        private void Init(IntPtr hdc)
        {
            try
            {
                this.ogl = new OpenGL(this.Handle, hdc);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        public virtual void Render()
        {
        }

        private OpenGL ogl = null;
    }
}
