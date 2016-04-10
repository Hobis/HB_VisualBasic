using System;
using System.Windows.Forms;


namespace CaseByLogical_001
{
    public sealed partial class MainForm : Form
    {
        // ::
        public MainForm()
        {
            InitializeComponent();

            this.p_initOnce();
        }

        // ::
        private void p_Load(object sender, EventArgs ea)
        {
            this.Text = "CaseByLogical Ver 1.01";

            this._richTextBox1.MaxLength = 99999;
        }

        // ::
        private void p_initOnce()
        {

        }
    }
}
