using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x216 || m.Msg == 0x214)
            { // WM_MOVING || WM_SIZING
                // Keep the window square
                return;
/*
                RECT rc = (RECT)Marshal.PtrToStructure(m.LParam, typeof(RECT));
                int w = rc.Right - rc.Left;
                int h = rc.Bottom - rc.Top;
                int z = w > h ? w : h;
                rc.Bottom = rc.Top + z;
                rc.Right = rc.Left + z;
                Marshal.StructureToPtr(rc, m.LParam, false);
                m.Result = (IntPtr)1;*/
                return;
            }
            base.WndProc(ref m);
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
