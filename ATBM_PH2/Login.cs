using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;


namespace ATBM_PH2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static OracleConnection con;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int check = 0;
                string userName = textBox1.Text;
                string passWords = textBox2.Text;
                Program.log_id = textBox1.Text;

                if (userName.ToLower().Contains("nv"))
                {
                    check = 1;
                    if (userName.ToLower() == "nv4")
                    {
                        check = 2;
                    }
                    if (userName.ToLower() == "nv5")
                    {
                        check = 3;
                    }
                }
                else
                {
                    check = 3;
                }
                String ConString = String.Format("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = PDBTEST1))); User Id ={0}; Password ={1}", userName, passWords);


                con = new OracleConnection(ConString);
                con.Open();
                switch (check)
                {
                    case 1:
                        frmBacSi xemBs = new frmBacSi();
                        this.Hide();
                        xemBs.ShowDialog();
                        break;
                    case 2:
                        TiepTan tieptan = new TiepTan();
                        this.Hide();
                        tieptan.ShowDialog();
                        break;
                    case 3:
                        QLBV_Admin admin = new QLBV_Admin();
                        this.Hide();
                        admin.ShowDialog();
                        break;
                        break;
                }

                textBox1.Clear();
                textBox2.Clear();
                this.ActiveControl = textBox1;
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Login.con.Close();
            }

        }
    }
}
