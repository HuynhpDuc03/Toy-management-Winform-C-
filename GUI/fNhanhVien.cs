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
using System.Globalization;


namespace GUI
{
    public partial class fNhanhVien : Form
    {
        public fNhanhVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text.Trim();
            nv.TenNV = txtTenNV.Text.Trim();

            if (cboGioiTinh.Text == "Nam")
            {
                nv.GioiTinh = true;
            }
            else
            {
                nv.GioiTinh = false;
            }
            nv.NgaySinh = DateTime.ParseExact(txtNgaySinh.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            nv.SDT = txtSDT.Text.Trim();
            nv.DiaChi = txtDiaChi.Text.Trim();
            nv.TenDangNhap = txtTenDangNhap.Text.Trim();
            nv.MatKhau = txtMatKhau.Text.Trim();

            NhanVienBLL nvBLL = new NhanVienBLL();
            bool kt = nvBLL.ThemNV(nv);
            if (kt)
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                HienThiDanhSachNhanVien();
            }
            ResetValues();
        }
        private void HienThiDanhSachNhanVien()
        {
            NhanVienBLL mhBLL = new NhanVienBLL();
            var ds = mhBLL.HienThiDanhSachNhanVien();
            dgvDanhSach.Rows.Clear();
            foreach (var item in ds)
            {
                string gioiTinh = item.GioiTinh ? "Nam" : "Nữ";
                dgvDanhSach.Rows.Add(item.MaNV, item.TenNV, gioiTinh, item.NgaySinh.ToString("dd/MM/yyyy"), item.SDT, item.DiaChi, item.TenDangNhap, item.MatKhau);

            }
        }

        private void fNhanhVien_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNhanVien();
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });
        }

        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";

        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
        }





        private void cboGioiTinh_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text.Trim();

            NhanVienBLL nvBLL = new NhanVienBLL();
            bool kt = nvBLL.XoaNV(nv);
            if (kt)
            {
                MessageBox.Show("Sa thải nhân viên thành công!");
                HienThiDanhSachNhanVien();
            }
            ResetValues();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDanhSach.SelectedRows[0];
                txtMaNV.Text = selectedRow.Cells[0].Value.ToString();
                txtTenNV.Text = selectedRow.Cells[1].Value.ToString();
                if (bool.TryParse(selectedRow.Cells[2].Value.ToString(), out bool gioiTinh))
                {
                    if (gioiTinh)
                    {
                        cboGioiTinh.Text = "Nam";
                    }
                    else
                    {
                        cboGioiTinh.Text = "Nữ";
                    }
                }
                txtNgaySinh.Value = DateTime.ParseExact(selectedRow.Cells[3].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtSDT.Text = selectedRow.Cells[4].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[5].Value.ToString();
                txtTenDangNhap.Text = selectedRow.Cells[6].Value.ToString();
                txtMatKhau.Text = selectedRow.Cells[7].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text.Trim();

            // Tạo đối tượng nvMoi và gán thông tin được chỉnh sửa
            NhanVienDTO nvMoi = new NhanVienDTO();
            nvMoi.MaNV = txtMaNV.Text.Trim();
            nvMoi.TenNV = txtTenNV.Text.Trim();

            if (cboGioiTinh.Text == "Nam")
            {
                nvMoi.GioiTinh = true;
            }
            else
            {
                nvMoi.GioiTinh = false;
            }
            nvMoi.NgaySinh = DateTime.ParseExact(txtNgaySinh.Value.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            nvMoi.SDT = txtSDT.Text.Trim();
            nvMoi.DiaChi = txtDiaChi.Text.Trim();
            nvMoi.TenDangNhap = txtTenDangNhap.Text.Trim();
            nvMoi.MatKhau = txtMatKhau.Text.Trim();

            NhanVienBLL nvBLL = new NhanVienBLL();
            bool kt = nvBLL.SuaNV(nvMoi);
            if (kt)
            {
                MessageBox.Show("Cập nhật nhân viên thành công!");
                HienThiDanhSachNhanVien();
            }
            ResetValues();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            NhanVienBLL timkiemBLL = new NhanVienBLL();
            string MaNV = txtTKMaNV.Text;
            string TenNV = txtTKTenNV.Text;

            List<NhanVienDTO> dsnv = timkiemBLL.TimKiem(MaNV, TenNV);
            dgvDanhSach.Rows.Clear();
            foreach (NhanVienDTO item in dsnv)
            {
                dgvDanhSach.Rows.Add(item.MaNV, item.TenNV, item.GioiTinh, item.NgaySinh, item.SDT, item.DiaChi, item.TenDangNhap, item.MatKhau);
            }
        }
    }
}
