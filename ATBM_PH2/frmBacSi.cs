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
    public partial class frmBacSi : Form
    {
        public frmBacSi()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from truong.ho_so_benh_nhan".ToUpper();

            OracleCommand cmd = new OracleCommand(query, Login.con);

            cmd.Connection.Open();

            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;

            cmd.Connection.Close();
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
                String query = String.Format("update truong.ho_so_benh_nhan\n" +
                                             "set ket_luan_bs = truong.crypt_hosobenhnhan.encrypt(ket_luan_bs,to_char(ma_kbenh))\n" +
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String query = String.Format("update truong.ho_so_benh_nhan\n" +
                                             "set ket_luan_bs = truong.crypt_hosobenhnhan.decrypt(ket_luan_bs,to_char(ma_kbenh))\n" +
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            button4_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "select * from truong.don_thuoc".ToUpper();

            OracleCommand cmd = new OracleCommand(query, Login.con);

            cmd.Connection.Open();

            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = dt;

            cmd.Connection.Close();
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
            String query = String.Format("select * from truong.ct_don_thuoc where ma_don_thuoc = '{0}'".ToUpper(), maDonThuoc);

            OracleCommand cmd = new OracleCommand(query, Login.con);

            cmd.Connection.Open();

            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = dt;

            cmd.Connection.Close();
        }
    }
}
