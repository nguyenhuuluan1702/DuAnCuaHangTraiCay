using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanTraiCay
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }


        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          
                Application.Exit();
            
        }
    

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Kết nối sql
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-1R2Q7BD;Initial Catalog=Quanlybantraicay3;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txbLoginName.Text;
                string mk = txbPW.Text;
                string sql = "select *from NguoiDung where TaiKhoan ='" + tk + "' and MatKhau= '" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
                    frmMain h = new frmMain();
                    this.Hide();
                    h.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu sai!");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối");
            }
            

           
        }

        private void pbhide_Click(object sender, EventArgs e)
        {
            if (txbPW.PasswordChar == '\0')
            {
                pbeye.BringToFront();
                txbPW.PasswordChar = '*';
            }
        }

        private void pbeye_Click(object sender, EventArgs e)
        {
            if (txbPW.PasswordChar == '*')
            {
                pbhide.BringToFront();
                txbPW.PasswordChar = '\0';
            }
        }

        private void Login_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

       
    }
}
