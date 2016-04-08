using AxShockwaveFlashObjects;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace PFOv
{
    public sealed partial class FrmRoot : Form
    {
        #region "#_MainInit"

        public FrmRoot()
        {
            InitializeComponent();
        }

        // ::
        private void p_Load(object sender, EventArgs e)
        {
            this.Text = "PFOv Ver 1.02b (.NET Framework 2.0)";

            string t_url = Path.Combine(Application.StartupPath, "FlaRoot.swf");
            this.flaObj.LoadMovie(0, t_url);
            this.flaObj.Menu = false;
            this.flaObj.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(p_flaObj_FlashCall);

            //this.timer1.Interval = 1;
            //this.timer1.Tick += new EventHandler(p_timer1_Tick);
            //this.timer1.Start();
        }


        //private void p_timer1_Tick(object sender, EventArgs e)
        //{
        //    DateTime t_dt = DateTime.Now;
        //    string t_v = t_dt.ToString() + " : " + t_dt.Millisecond.ToString("d3");
        //    //this.label1.Text = t_v;

        //    this.flaObj.CallFunction
        //    (
        //        "<invoke name=\"Fla_TimeLoop\" returntype=\"xml\">" +
        //            "<arguments>" +
        //                "<string>" + t_v + "</string>" +
        //            "</arguments>" +
        //        "</invoke>"
        //    );

        //    //System.GC.Collect();
        //}






        // ::
        private bool p_flaObj_IsArgsEmpty(XmlNodeList xargs)
        {
            if ((xargs != null) && (xargs.Count > 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // ::
        private void p_flaObj_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        {
            // <invoke name="Frm_Exit" returntype="xml"><arguments></arguments></invoke>
            XmlDocument t_xd = new XmlDocument();
            t_xd.LoadXml(e.request);
            //MessageBox.Show("t_xd: " + t_xd.InnerXml);

            XmlAttributeCollection t_xac = t_xd.FirstChild.Attributes;
            string t_callName = t_xac.Item(0).InnerText;

            XmlNodeList t_xnl = t_xd.GetElementsByTagName("arguments");
            XmlNode t_xn = t_xnl[0];

            XmlNodeList t_xargs = t_xn.ChildNodes;

            switch (t_callName)
            {
            case "Frm_Exit":
                {
                    /*
                    this.Invoke((MethodInvoker)delegate()
                    {
                        //this.Close();
                        Application.Exit();
                        //Application.ExitThread();
                    });*/
                    //this.Close();
                    //Application.ExitThread();
                    Application.Exit();
                    break;
                }
            case "Frm_TimeLoop":
                {
                    if (!p_flaObj_IsArgsEmpty(t_xargs))
                    {
                        //this.label1.Text = t_xargs[0].InnerText;
                    }
                    break;
                }
            }
        }

        #endregion



        #region "#_SubProjector"


        #endregion
    }
}
