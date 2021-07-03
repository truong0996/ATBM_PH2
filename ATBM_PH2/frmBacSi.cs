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
using System.Windows;

namespace ATBM_PH2
{
    public partial class frmBacSi : Form
    {
        public frmBacSi()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from QLBV_PDB.ho_so_benh_nhan".ToUpper();

                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
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

        public string maKBenh = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            maKBenh = selectedRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String query = String.Format("update QLBV_PDB.ho_so_benh_nhan\n" +
                                             "set ket_luan_bs = QLBV_PDB.crypt_hosobenhnhan.encrypt(ket_luan_bs,to_char(ma_kbenh))\n" +
                                             "where ma_kbenh = '{0}'", maKBenh).ToUpper();


                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();
                cmd.ExecuteReader();
                cmd.Connection.Close();
                MessageBox.Show("Mã hoá thành công");
                button1_Click(sender, e);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String query = String.Format("update QLBV_PDB.ho_so_benh_nhan\n" +
                                             "set ket_luan_bs = QLBV_PDB.crypt_hosobenhnhan.decrypt(ket_luan_bs,to_char(ma_kbenh))\n" +
                                             "where ma_kbenh = '{0}'", maKBenh).ToUpper();


                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();
                cmd.ExecuteReader();
                cmd.Connection.Close();
                MessageBox.Show("Giải mã thành công");
                button1_Click(sender, e);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Login.con.Close();
            button1_Click(sender, e);
            button4_Click(sender, e);
            //try
            //{
            //    string query = String.Format("select ho_ten,vai-tro from QLBV_PDB.nhan_vien where ma_nv = {0}",Program.log_id).ToUpper();


            //    OracleCommand cmd = new OracleCommand(query, Login.con);

            //    cmd.Connection.Open();
            //    DataSet dataset = new DataSet();

            //    OracleDataReader reader = cmd.ExecuteReader();
            //    textBox3.Text = (String)reader["HO_TEN"];
            //    textBox4.Text = (String)reader["VAI_TRO"];
            //    cmd.Connection.Close();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    Login.con.Close();
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from QLBV_PDB.don_thuoc".ToUpper();

                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView2.DataSource = dt;

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

        public string maDonThuoc = "";
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            maDonThuoc = selectedRow.Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String query = String.Format("select * from QLBV_PDB.ct_don_thuoc where ma_don_thuoc = '{0}'".ToUpper(), maDonThuoc);

                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView2.DataSource = dt;
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {


                String query = "SELECT MESSAGE,TO_WHOM,KHOA,REGION,LABEL_TO_CHAR(OLS_NHANVIEN) AS LABEL FROM QLBV_PDB.announcements".ToUpper();
                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView3.DataSource = dt;

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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string query = String.Format("update QLBV_PDB.ho_so_benh_nhan set ket_luan_bs = '{0}' where ma_kbenh = '{1}'", textBox2.Text,textBox1.Text).ToUpper();


                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();
                DataSet dataset = new DataSet();

               cmd.ExecuteNonQuery();
               
                
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

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
