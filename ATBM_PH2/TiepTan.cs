using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM_PH2
{
    public partial class TiepTan : Form
    {
        public TiepTan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            try
            {
                int first = dateTimePicker1.Text.IndexOf(' ');
                int last = dateTimePicker1.Text.IndexOf(' ', first + 1);
                String tempDate = dateTimePicker1.Value.ToString("dd/MM/yy");
                tempDate = tempDate.Substring(0, 3) + dateTimePicker1.Text.Substring(first + 1, last - first - 1) + tempDate.Substring(5);
                string query = String.Format("INSERT INTO qlbv_pdb.BENH_NHAN (MA_BNHAN,HO_TEN,NGAY_SINH,DIA_CHI,SDT) VALUES ('{0}','{1}','{2}','{3}','{4}')", textBox2.Text, textBox1.Text, tempDate, textBox3.Text, textBox4.Text).ToUpper();


                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();
                DataSet dataset = new DataSet();

                cmd.ExecuteNonQuery();

                cmd.Connection.Close();
                MessageBox.Show("Thanh cong");
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = String.Format("SELECT * FROM qlbv_pdb.BENH_NHAN WHERE MA_BNHAN = '{0}'", textBox6.Text).ToUpper();


                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
                

                cmd.Connection.Close();
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

 
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {


                String query = "SELECT MESSAGE,TO_WHOM,KHOA,REGION,LABEL_TO_CHAR(OLS_NHANVIEN) AS LABEL FROM QLBV_PDB.announcements".ToUpper();
                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView2.DataSource = dt;

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Login.con.Close();
            }
        }

        private void TiepTan_Load(object sender, EventArgs e)
        {
            Login.con.Close();
        }
    }
}
