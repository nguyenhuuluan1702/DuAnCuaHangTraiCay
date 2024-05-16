using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QuanLyBanTraiCay.Class;

namespace QuanLyBanTraiCay
{
    public partial class frmDMTraiCay : Form
    {
        DataTable tblTC;
        public frmDMTraiCay()
        {
            InitializeComponent();
        }


        /*public static void FillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            String str = "Data Source=DESKTOP-1R2Q7BD;Initial Catalog=Quanlybantraicay1;Integrated Security=True";
            // Tạo một đối tượng SqlConnection để kết nối với cơ sở dữ liệu
            SqlConnection Con = new SqlConnection(str); // Thay yourConnectionString bằng chuỗi kết nối thực tế của bạn

            // Gán giá trị cho biến sql
            sql = "SELECT MaLoai, TenLoai FROM tblLoaiTraiCay"; // Lấy mã và tên loại trái cây từ bảng LoaiTraiCay

            // Gán giá trị cho các tham số ma và ten
            ma = "MaLoai"; // Trường giá trị
            ten = "TenLoai"; // Trường hiển thị

            // Tạo một đối tượng SqlDataAdapter để lấy dữ liệu từ cơ sở dữ liệu
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);

            // Tạo một đối tượng DataTable để lưu trữ dữ liệu
            DataTable table = new DataTable();

            // Đổ dữ liệu vào DataTable
            dap.Fill(table);

            // Thiết lập DataSource, ValueMember và DisplayMember cho ComboBox
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }*/

        private void frmDMTraiCay_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblLoaiTraiCay";
            txtMaTraiCay.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cboMaLoaiTraiCay, "MaLoaiTraiCay", "TenLoaiTraiCay");
            cboMaLoaiTraiCay.SelectedIndex = -1;
            ResetValues();
            dgvTraiCay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //nạp dữ liệu
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblTraiCay";
            tblTC = Functions.GetDataToTable(sql);
            dgvTraiCay.DataSource = tblTC;
            dgvTraiCay.Columns[0].HeaderText = "Mã Trái Cây";
            dgvTraiCay.Columns[1].HeaderText = "Tên Trái Cây";
            dgvTraiCay.Columns[2].HeaderText = "Mã Loại Trái Cây";
            dgvTraiCay.Columns[3].HeaderText = "Số lượng";
            dgvTraiCay.Columns[4].HeaderText = "Đơn giá nhập";
            dgvTraiCay.Columns[5].HeaderText = "Đơn giá bán";
            //dgvTraiCay.Columns[6].HeaderText = "Ảnh";
            dgvTraiCay.Columns[6].HeaderText = "Ghi chú";
            dgvTraiCay.Columns[0].Width = 80;
            dgvTraiCay.Columns[1].Width = 140;
            dgvTraiCay.Columns[2].Width = 80;
            dgvTraiCay.Columns[3].Width = 80;
            dgvTraiCay.Columns[4].Width = 100;
            dgvTraiCay.Columns[5].Width = 100;
            //dgvTraiCay.Columns[6].Width = 200;
            dgvTraiCay.Columns[6].Width = 300;
            dgvTraiCay.AllowUserToAddRows = false;
            dgvTraiCay.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        //khởi tạo lại giá trị
        private void ResetValues()
        {
            txtMaTraiCay.Text = "";
            txtTenTraiCay.Text = "";
            cboMaLoaiTraiCay.Text = "";
            txtSoLuong.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = false;
            txtDonGiaBan.Enabled = false;
            txtGhiChu.Text = "";
        }

        private void dgvTraiCay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaLoaiTraiCay;
            string sql;

            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTraiCay.Focus();
                return;
            }

            if (tblTC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMaTraiCay.Text = dgvTraiCay.CurrentRow.Cells["MaTraiCay"].Value.ToString();
            txtTenTraiCay.Text = dgvTraiCay.CurrentRow.Cells["TenTraiCay"].Value.ToString();
            MaLoaiTraiCay = dgvTraiCay.CurrentRow.Cells["MaLoaiTraiCay"].Value.ToString();
            sql = "SELECT TenLoaiTraiCay FROM tblLoaiTraiCay WHERE MaLoaiTraiCay=N'" + MaLoaiTraiCay + "'";
            cboMaLoaiTraiCay.Text = Functions.GetFieldValues(sql);
            txtSoLuong.Text = dgvTraiCay.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtDonGiaNhap.Text = dgvTraiCay.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txtDonGiaBan.Text = dgvTraiCay.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            sql = "SELECT Anh FROM tblTraiCay WHERE MaTraiCay=N'" + txtMaTraiCay.Text + "'";

            // Use Path.Combine to construct a valid file path
            /*string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", Functions.GetFieldValues(sql));

            try
            {
                picAnh.Image = Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            sql = "SELECT GhiChu FROM tblTraiCay WHERE MaTraiCay = N'" + txtMaTraiCay.Text + "'";
            txtGhiChu.Text = Functions.GetFieldValues(sql);

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
            ResetValues();
            txtMaTraiCay.Enabled = true;
            txtMaTraiCay.Focus();
            txtSoLuong.Enabled = true;
            txtDonGiaNhap.Enabled = true;
            txtDonGiaBan.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTraiCay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTraiCay.Focus();
                return;
            }
            if (txtTenTraiCay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTraiCay.Focus();
                return;
            }
            if (cboMaLoaiTraiCay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoaiTraiCay.Focus();
                return;
            }

            /*if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho trái cây ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMo.Focus();
                return;
            }*/

            sql = "SELECT MaTraiCay FROM tblTraiCay WHERE MaTraiCay=N'" + txtMaTraiCay.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã trái cây này đã tồn tại, bạn phải chọn mã trái cây khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTraiCay.Focus();
                return;
            }
            sql = "INSERT INTO tblTraiCay(MaTraiCay,TenTraiCay,MaLoaiTraiCay,SoLuong,DonGiaNhap, DonGiaBan,Ghichu) VALUES(N'"
                + txtMaTraiCay.Text.Trim() + "',N'" + txtTenTraiCay.Text.Trim() +
                "',N'" + cboMaLoaiTraiCay.SelectedValue.ToString() +
                "'," + txtSoLuong.Text.Trim() + "," + txtDonGiaNhap.Text +
                "," + txtDonGiaBan.Text + ",N'" + txtGhiChu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaTraiCay.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTraiCay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTraiCay.Focus();
                return;
            }
            if (txtTenTraiCay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTraiCay.Focus();
                return;
            }
            if (cboMaLoaiTraiCay.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã loại trái cây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaLoaiTraiCay.Focus();
                return;
            }
           
            sql = "UPDATE tblTraiCay SET TenTraiCay=N'" + txtTenTraiCay.Text.Trim().ToString() +
                "',MaLoaiTraiCay=N'" + cboMaLoaiTraiCay.SelectedValue.ToString() +
                "',SoLuong=" + txtSoLuong.Text +
                ",GhiChu=N'" + txtGhiChu.Text + "' WHERE MaTraiCay=N'" + txtMaTraiCay.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTraiCay.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblTraiCay WHERE MaTraiCay=N'" + txtMaTraiCay.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaTraiCay.Enabled = false;
        }

        /*private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgMo = new OpenFileDialog();
            dlgMo.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgMo.FilterIndex = 2;
            dlgMo.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgMo.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgMo.FileName);
                txtAnh.Text = dlgMo.FileName;
            }
        }*/

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtMaTraiCay.Text == "") && (txtTenTraiCay.Text == "") && (cboMaLoaiTraiCay.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * from tblTraiCay WHERE 1=1";
            if (txtMaTraiCay.Text != "")
                sql += " AND MaTraiCay LIKE N'%" + txtMaTraiCay.Text + "%'";
            if (txtTenTraiCay.Text != "")
                sql += " AND TenTraiCay LIKE N'%" + txtTenTraiCay.Text + "%'";
            if (cboMaLoaiTraiCay.Text != "")
                sql += " AND MaLoaiTraiCay LIKE N'%" + cboMaLoaiTraiCay.SelectedValue + "%'";
            tblTC = Functions.GetDataToTable(sql);
            if (tblTC.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblTC.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTraiCay.DataSource = tblTC;
            ResetValues();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaTraiCay,TenTraiCay,MaLoaiTraiCay,SoLuong,DonGiaNhap,DonGiaBan,GhiChu FROM tblTraiCay";
            tblTC = Functions.GetDataToTable(sql);
            dgvTraiCay.DataSource = tblTC;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
