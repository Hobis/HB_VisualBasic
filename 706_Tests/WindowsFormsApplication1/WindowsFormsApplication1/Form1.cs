using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
     delegate void _CallBack();

    public partial class Form1 : Form
    {
        #region !! 초기화 영역
        public Form1()
        {
            InitializeComponent();

            this.Load += this.p_Load;
        }

        // ::
        private void p_Load(object sender, EventArgs e)
        {
            this.btnStart.Click += this.p_btnStart_Click;
        }

        #endregion

        // ::
        private void p_btnStart_Click(object sender, EventArgs e)
        {
            //Thread t_th = new Thread((ThreadStart)delegate()
            //{
            //    Thread.Sleep(1000);
            //});
            //t_th.IsBackground = true;
            //t_th.Start();
            

            //IAsyncResult t_ar = null;

            ////Action t_ac;
            ////for (int i = 0; i < 10; i++)
            ////{
            //    _CallBack t_cb = delegate()
            //    {
            //        //for (int j = 0; j < 2; j++)
            //        //{
            //            Thread.Sleep(1000);
            //        //}
            //        //t_cb.EndInvoke(t_ar);
            //    };
            //    t_ar = t_cb.BeginInvoke((AsyncCallback)delegate(IAsyncResult ar) {
            //        t_cb.EndInvoke(ar);
            //        MessageBox.Show("끝났어요.");
            //    }, null);
            ////}


            //_CallBack t_cb = delegate()
            //{
            //    Thread.Sleep(2000);
            //    this.textBox1.Invoke((MethodInvoker)delegate()
            //    {
            //        this.textBox1.AppendText(":::: " + Environment.NewLine);
            //    });
            //    //Thread.CurrentThread.Interrupt();
            //};
            ////t_cb.BeginInvoke((AsyncCallback)t_cb.EndInvoke, null);
            ////t_cb.EndInvoke(t_cb.BeginInvoke(null, null));
            //for (int i = 0; i < 99999; i++)
            //{
            //    t_cb.BeginInvoke(null, null);
            //    //IAsyncResult t_ar = t_cb.BeginInvoke((AsyncCallback)t_cb.EndInvoke, null);
            //    //t_ar.
            //    //Thread
            //    //t_ar.IsCompleted = true;
            //    //t_cb.
            //}
            
            //t_cb.EndInvoke(t_ar);





            for (int i = 0; i < 99999; i++)
            {
                _CallBack t_cb = delegate()
                {
                    Thread.Sleep(2000);
                    this.textBox1.Invoke((MethodInvoker)delegate()
                    {
                        this.textBox1.AppendText(":::: " + Environment.NewLine);
                    });
                };
                t_cb.BeginInvoke((AsyncCallback)t_cb.EndInvoke, null);
            }

/*
            for (int i = 0; i < 999; i++)
            {
                new Thread((ThreadStart)delegate()
                {
                    Thread.Sleep(2000);
                    this.textBox1.Invoke((MethodInvoker)delegate()
                    {
                        this.textBox1.AppendText("~~~~");
                    });
                }).Start();
            }*/



        }



    }
}
