using System;
using System.IO;
using System.Windows.Forms;

namespace Roland
{
    public sealed partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // ::
        private void p_Load(object sender, EventArgs e)
        {
            this.wbRoot.Dock = DockStyle.Fill;
            this.wbRoot.ObjectForScripting = this;
            string t_url = Path.Combine(Application.StartupPath, "Root/Root.html");
            this.wbRoot.Navigate(t_url);

            this.tmRoot.Interval = 100;
            this.tmRoot.Start();
        }

        // ::
        private void p_tmRoot_Tick(object sender, EventArgs e)
        {
            object[] t_args = new object[3];
            t_args[0] = "p_Txt_Set";
            t_args[1] = "1";
            t_args[2] = DateTime.Now.ToLongTimeString() + " : " + DateTime.Now.ToString();
            this.wbRoot.Document.InvokeScript("p_flas3_Call", t_args);
        }

        private void p_btn1_Click(object sender, EventArgs e)
        {
            //object[] t_args = new object[3];
            //t_args[0] = "p_Txt_Set";
            //t_args[1] = "1";
            //t_args[2] = 1;
            //this.wbRoot.Document.InvokeScript("p_flas3_Call", t_args);
            //this.wbRoot.Document.InvokeScript("p_flas3_Call", new object[] {"p_Txt_Set", "1", "ABCD"});
        }

        public String operand(double a)
        {
            //MessageBox.Show("~~~~: " + a);
            return "유라씨";
        }

        public void gotoman()
        {
            MessageBox.Show("gotoman");
        }
        

    }
}
