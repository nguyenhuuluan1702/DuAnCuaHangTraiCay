using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sử dụng thư viện để làm việc SQL server
using QuanLyBanTraiCay.Class; //Sử dụng class Functions.cs

namespace QuanLyBanTraiCay
{
    public partial class frmDMLoaiTraiCay : Form
    {
        DataTable tblLTC; //Chứa dữ liệu bảng Loại Trái Cây
        public frmDMLoaiTraiCay()
        {
            InitializeComponent();
        }

        private void frmDMLoaiTraiCay_Load(object sender, EventArgs e)
        {
            txtMaLoaiTraiCay.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView(); //Hiển thị bảng tblChatLieu
            dgvLoaiTraiCay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT* FROM tblLoaiTraiCay";
            tblLTC = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvLoaiTraiCay.DataSource = tblLTC; //Nguồn dữ liệu            
            dgvLoaiTraiCay.Columns[0].HeaderText = "Mã Loại Trái Cây";
            dgvLoaiTraiCay.Columns[1].HeaderText = "Tên Loại Trái Cây";
            dgvLoaiTraiCay.Columns[0].Width = 100;
            dgvLoaiTraiCay.Columns[1].Width = 300;
            dgvLoaiTraiCay.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiTraiCay.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvLoaiTraiCay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiTraiCay.Focus();
                return;
            }
            if (tblLTC.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoaiTraiCay.Text = dgvLoaiTraiCay.CurrentRow.Cells["MaLoaiTraiCay"].Value.ToString();
            txtTenLoaiTraiCay.Text = dgvLoaiTraiCay.CurrentRow.Cells["TenLoaiTraiCay"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaLoaiTraiCay.Enabled = true; //cho phép nhập mới
            txtMaLoaiTraiCay.Focus();
        }

        private void ResetValue()
        {
            txtMaLoaiTraiCay.Text = "";
            txtMaLoaiTraiCay.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaLoaiTraiCay.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã loại trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiTraiCay.Focus();
                return;
            }
            if (txtTenLoaiTraiCay.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên loại trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiTraiCay.Focus();
                return;
            }
            sql = "Select MaLoaiTraiCay From tblLoaiTraiCay where MaLoaiTraiCay=N'" + txtMaLoaiTraiCay.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại trái cây này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiTraiCay.Focus();
                return;
            }

            sql = "INSERT INTO tblLoaiTraiCay VALUES(N'" +
                txtMaLoaiTraiCay.Text + "',N'" + txtTenLoaiTraiCay.Text + "')";
            Class.Functions.RunSQL(sql); //Thực hiện câu lệnh sql
            LoadDataGridView(); //Nạp lại DataGridView
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLoaiTraiCay.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblLTC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoaiTraiCay.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenLoaiTraiCay.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên loại trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblLoaiTraiCay SET TenLoaiTraiCay=N'" +
                txtTenLoaiTraiCay.Text.ToString() +
                "' WHERE MaLoaiTraiCay=N'" + txtMaLoaiTraiCay.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblLTC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaLoaiTraiCay.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblLoaiTraiCay WHERE MaLoaiTraiCay=N'" + txtMaLoaiTraiCay.Text + "'";
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLoaiTraiCay.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLoaiTraiCay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiTraiCay.Focus();
                return;
            }
            if (tblLTC.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaLoaiTraiCay.Text = dgvLoaiTraiCay.CurrentRow.Cells["MaLoaiTraiCay"].Value.ToString();
            txtTenLoaiTraiCay.Text = dgvLoaiTraiCay.CurrentRow.Cells["TenLoaiTraiCay"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }
        private int DemSoHangLoaiTraiCay()
        {
            int soHang = 0;
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-1R2Q7BD;Initial Catalog=Quanlybantraicay3;Integrated Security=True";

            // Tạo đối tượng SqlConnection
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM tblLoaiTraiCay";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    soHang = (int)command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DemSoHangLoaiTraiCay: " + ex.Message);
                // Xử lý lỗi khi thực hiện truy vấn
            }
            finally
            {
                connection.Close();
            }

            return soHang;
        }
        private void btnTKLoaiTC_Click(object sender, EventArgs e)
        {
            int soHang = DemSoHangLoaiTraiCay();
            MessageBox.Show("Số loại trái cây là: " + soHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }
