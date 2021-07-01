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
            

            string userName = textBox1.Text;
            string passWords = textBox2.Text;
            String ConString = String.Format("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id ={0}; Password ={1}", userName, passWords);
            con = new OracleConnection(ConString);

            frmBacSi xemBs = new frmBacSi();
            this.Hide();
            xemBs.ShowDialog();
            textBox1.Clear();
            textBox2.Clear();
            this.ActiveControl = textBox1;
            this.Show();

        }
    }
}
