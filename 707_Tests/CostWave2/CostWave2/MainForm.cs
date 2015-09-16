using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CostWave2
{
    public sealed partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // ::
        private void p_Load(object sender, EventArgs ea)
        {
            //SqlConnection t_sconn;
        }

        // ::
        private void p_btnOpen_Click(object sender, EventArgs ea)
        {
            p_btnClear_Click(null, null);

            const string t_ConnStr = @"Data Source=HOBIS\SQLEXPRESS;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            SqlConnection t_sconn = null;
            SqlCommand t_scomm = null;
            SqlDataAdapter t_sda = null;
            DataSet t_ds = null;

            try
            {
                t_sconn = new SqlConnection();
                t_sconn.ConnectionString = t_ConnStr;

                t_scomm = new SqlCommand();
                t_scomm.Connection = t_sconn;
                t_scomm.CommandText = @"SELECT [No]
                                            ,[Email]
                                            ,[Password]
                                            ,[Disc]
                                        FROM [DataServer].[dbo].[Users]
                                    GO";
                t_sda = new SqlDataAdapter(t_scomm);
                t_ds = new DataSet();

                t_sda.Fill(t_ds, "Users");

                this.dgvMain.DataSource = t_ds.Tables[0];
                //this.dgvMain.DataMember = "Users";

                //this.dgvMain.DataSource
                //t_ds.Clear();
                //this.dgvMain.Rows.Clear();
                //this.dgvMain.Columns.Clear();
                //this.dgvMain.Data

                //DataTable t_dt = (DataTable)this.dgvMain.DataSource;
                //t_dt.Clear();
            }
            catch { }

            try
            {
                t_sconn.Close();
            }
            catch { }
        }

        // ::
        private void p_btnClear_Click(object sender, EventArgs ea)
        {
            try
            {
                DataTable t_dt = (DataTable)this.dgvMain.DataSource;
                t_dt.Clear();
            }
            catch { }

            try
            {
                this.dgvMain.Columns.Clear();
            }
            catch { }
        }
    }
}
