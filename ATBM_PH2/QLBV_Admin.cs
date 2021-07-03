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
    public partial class QLBV_Admin : Form
    {
        public QLBV_Admin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "select AUDIT_TYPE,SESSION_ID,DB_USER,OBJECT_NAME,STATEMENT_TYPE from DBA_COMMON_AUDIT_TRAIL where OBJECT_SCHEMA='QLBV_PDB' AND AUDIT_TYPE = 'Standard Audit'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "select SESSION_ID,OBJECT_NAME,POLICY_NAME,SQL_TEXT,statement_type,extended_timestamp from DBA_FGA_AUDIT_TRAIL".ToUpper();
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

        private void button4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from QLBV_PDB.ho_so_benh_nhan".ToUpper();

                OracleCommand cmd = new OracleCommand(query, Login.con);

                cmd.Connection.Open();

                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView4.DataSource = dt;

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

        private void QLBV_Admin_Load(object sender, EventArgs e)
        {
           
                Login.con.Close();
            
        }
    }
}
