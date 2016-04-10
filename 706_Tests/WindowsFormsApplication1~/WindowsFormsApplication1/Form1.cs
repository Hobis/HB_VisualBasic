using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public sealed partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // ::
        private void p_This_Load(object sender, EventArgs ea)
        {
            this.WindowState = FormWindowState.Maximized;

            string a;
            this.p_Power(out a);
            MessageBox.Show(a);
        }

        private void p_Power(out string a)
        {
            a = "!!!!!!!!!";
        }

        // ::
        protected override void OnResize(EventArgs ea)
        {
            //base.OnResize(ea);

            //MessageBox.Show("OnResize");
        }

        // ::
        protected override void OnSizeChanged(EventArgs e)
        {
            //base.OnSizeChanged(e);

            //MessageBox.Show("OnSizeChanged");
        }


        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MAXIMIZE = 0xF030;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg.Equals(WM_SYSCOMMAND)) // WM_SYSCOMMAND
            {
                // Check your window state here
                if (m.WParam.Equals(new IntPtr(SC_MAXIMIZE))) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    // THe window is being maximized
                    return;
                }
            }

            base.WndProc(ref m);
        }
    }
}
