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
using BLL;
using DTO;

namespace GUI
{
    public partial class fDMDoChoi : Form
    {
        DataTable tblDC;
        public fDMDoChoi()
        {
            InitializeComponent();
        }

        private void fDMDoChoi_Load(object sender, EventArgs e)
        {
            DoChoiBLL dcBLL = new DoChoiBLL();
            string sql;
            sql = "SELECT * from tblTheLoai";
            txtMaDC.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            LoadDataGridView();
            dcBLL.fillCombo(sql, cboMaTL, "MaTL", "TenTL");
            cboMaTL.SelectedIndex = 0;

        }


        private void ResetValues()
        {
            txtMaDC.Text = "";
            txtTenDC.Text = "";
            cboMaTL.Text = "";
            txtSoLuong.Text = "0";
            txtGiaNhap.Text = "0";
            txtGiaBan.Text = "0";
            txtSoLuong.Enabled = true;
            txtGiaNhap.Enabled = false;
            txtGiaBan.Enabled = false;
            txtAnh.Text = "";
            picAnh.Image = null;
            txtGhiChu.Text = "";
        }


        private void LoadDataGridView()
        {
            DoChoiBLL dcBLL = new DoChoiBLL();
            string sql;
            sql = "SELECT * from tblDoChoi";
            tblDC = dcBLL.GetDataToTable(sql);
            dgvDanhSach.DataSource = tblDC;
            dgvDanhSach.Columns[0].HeaderText = "Mã đồ chơi";
            dgvDanhSach.Columns[1].HeaderText = "Tên đồ chơi";
            dgvDanhSach.Columns[2].HeaderText = "Thể loại";
            dgvDanhSach.Columns[3].HeaderText = "Số lượng";
            dgvDanhSach.Columns[4].HeaderText = "Đơn giá nhập";
            dgvDanhSach.Columns[5].HeaderText = "Đơn giá bán";
            dgvDanhSach.Columns[6].HeaderText = "Ảnh";
            dgvDanhSach.Columns[7].HeaderText = "Ghi chú";
            dgvDanhSach.Columns[0].Width = 80;
            dgvDanhSach.Columns[1].Width = 140;
            dgvDanhSach.Columns[2].Width = 80;
            dgvDanhSach.Columns[3].Width = 80;
            dgvDanhSach.Columns[4].Width = 100;
            dgvDanhSach.Columns[5].Width = 100;
            dgvDanhSach.Columns[6].Width = 200;
            dgvDanhSach.Columns[7].Width = 300;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvDanhSach_Click(object sender, EventArgs e)
        {
            DoChoiBLL dcBLL = new DoChoiBLL();
            string MaTL;
            string sql;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDC.Focus();
                return;
            }
            if (tblDC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaDC.Text = dgvDanhSach.CurrentRow.Cells["MaDC"].Value.ToString();
            txtTenDC.Text = dgvDanhSach.CurrentRow.Cells["TenDC"].Value.ToString();
            MaTL = dgvDanhSach.CurrentRow.Cells["MaTL"].Value.ToString();
            sql = "SELECT TenTL FROM tblTheLoai WHERE MaTL=N'" + MaTL + "'";
            cboMaTL.Text = dcBLL.GetFieldValues(sql);
            txtSoLuong.Text = dgvDanhSach.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtGiaNhap.Text = dgvDanhSach.CurrentRow.Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = dgvDanhSach.CurrentRow.Cells["GiaBan"].Value.ToString();
            sql = "SELECT Anh FROM tblDoChoi WHERE MaDC=N'" + txtMaDC.Text + "'";
            txtAnh.Text = dcBLL.GetFieldValues(sql);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            sql = "SELECT GhiChu FROM tblDoChoi WHERE MaDC = N'" + txtMaDC.Text + "'";
            txtGhiChu.Text = dcBLL.GetFieldValues(sql);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaDC.Enabled = true;
            txtMaDC.Focus();
            txtSoLuong.Enabled = true;
            txtGiaNhap.Enabled = true;
            txtGiaBan.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DoChoiBLL dcDAO = new DoChoiBLL();
            string sql;
            if (txtMaDC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã đồ chơi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDC.Focus();
                return;
            }
            if (txtTenDC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đồ chơi ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDC.Focus();
                return;
            }
            if (cboMaTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaTL.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho đồ chơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }

            sql = "SELECT MaDC FROM tblDoChoi WHERE MaDC=N'" + txtMaDC.Text.Trim() + "'";
            if (dcDAO.CheckKey(sql))
            {
                MessageBox.Show("Mã đồ chơi này đã tồn tại, bạn phải chọn mã đồi chơi  khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDC.Focus();
                return;
            }
            DoChoiDTO toy = new DoChoiDTO();
            toy.MaDC = txtMaDC.Text.Trim();
            toy.TenDC = txtTenDC.Text.Trim();
            toy.MaTL = cboMaTL.SelectedValue.ToString();
            toy.SoLuong = int.Parse(txtSoLuong.Text.Trim());
            toy.GiaNhap = double.Parse(txtGiaNhap.Text);
            toy.GiaBan = double.Parse(txtGiaBan.Text);
            toy.Anh = txtAnh.Text.Trim();
            toy.GhiChu = txtGhiChu.Text.Trim();

            dcDAO.ThemDoChoi(toy);
            MessageBox.Show("Thêm Đồ chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            //ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtMaDC.Enabled = false;
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            DoChoiBLL dcBLL = new DoChoiBLL();

       
            if (tblDC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaDC.Focus();
                return;
            }
            if (txtTenDC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đồ chơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDC.Focus();
                return;
            }
            if (cboMaTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaTL.Focus();
                return;
            }
            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho đồ chơi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAnh.Focus();
                return;
            }
            string maDC = txtMaDC.Text;
            string tenDC = txtTenDC.Text;
            string maTL = cboMaTL.SelectedValue.ToString();
            int soLuong = int.Parse(txtSoLuong.Text);
            string Anh = txtAnh.Text;
            string ghiChu = txtGhiChu.Text;

            dcBLL.CapNhatDoChoi(maDC,tenDC,maTL,soLuong,Anh,ghiChu);
            MessageBox.Show("Cập nhật Đồ chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadDataGridView();
            ResetValues();
            btnHuy.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DoChoiBLL dcBLL = new DoChoiBLL();

            if (tblDC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dcBLL.XoaDoChoi(txtMaDC.Text.Trim());
                MessageBox.Show("Xóa Đồ chơi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDataGridView();
                ResetValues();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DoChoiBLL dcBLL = new DoChoiBLL();

            if ((txtMaDC.Text == "") && (txtTenDC.Text == "") && (cboMaTL.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDC = txtMaDC.Text;
            string tenDC = txtTenDC.Text;
            string maTL = cboMaTL.SelectedIndex.ToString();


            tblDC = dcBLL.TimKiemDoChoi(maDC,tenDC,maTL);
            if (tblDC.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblDC.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDanhSach.DataSource = tblDC;
            ResetValues();
        }

        private void btnHienThiDanhSach_Click(object sender, EventArgs e)
        {
            DoChoiBLL dcBLL = new DoChoiBLL();
            string sql;
            sql = "SELECT * FROM tblDoChoi";
            tblDC = dcBLL.GetDataToTable(sql);
            dgvDanhSach.DataSource = tblDC;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
