using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Globalization;


namespace GUI
{
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
        }
        private void fKhachHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSachKhachHang();
        }

        private void HienThiDanhSachKhachHang()
        {
            KhachHangBLL khBLL = new KhachHangBLL();
            List<KhachHangDTO> ds = khBLL.HienThiDanhSachKhachHang();
            dgvDanhSach.Rows.Clear();
            foreach (KhachHangDTO item in ds)
            {
                dgvDanhSach.Rows.Add(item.MaKH, item.TenKH, item.SDT, item.DiaChi, item.Email);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text.Trim();
            kh.TenKH = txtTenKH.Text.Trim();
            kh.SDT = txtSDT.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.Email = txtEmail.Text.Trim();

            KhachHangBLL khBLL = new KhachHangBLL();
            bool kt = khBLL.ThemKH(kh);
            if (kt)
            {
                MessageBox.Show("Thêm khách hàng thành công");
                HienThiDanhSachKhachHang();
            }
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text.Trim();

            KhachHangBLL khBLL = new KhachHangBLL();
            bool kt = khBLL.XoaKH(kh);
            if (kt)
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                HienThiDanhSachKhachHang();
            }
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KhachHangDTO kh = new KhachHangDTO();
            kh.MaKH = txtMaKH.Text.Trim();
            kh.TenKH = txtTenKH.Text.Trim();
            kh.SDT = txtSDT.Text.Trim();
            kh.DiaChi = txtDiaChi.Text.Trim();
            kh.Email = txtEmail.Text.Trim();

            KhachHangBLL suaKhBLL = new KhachHangBLL();
            bool kt = suaKhBLL.SuaKH(kh);
            if (kt)
            {
                MessageBox.Show("Cập nhật khách hàng thành công");
                HienThiDanhSachKhachHang();
            }
            ResetValues();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvDanhSach.SelectedRows[0];
                txtMaKH.Text = selectedRow.Cells[0].Value.ToString();
                txtTenKH.Text = selectedRow.Cells[1].Value.ToString();
                txtSDT.Text = selectedRow.Cells[2].Value.ToString();
                txtDiaChi.Text = selectedRow.Cells[3].Value.ToString();
                txtEmail.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            KhachHangBLL timkiemBLL = new KhachHangBLL();
            string MaKH = txtTKMaKH.Text;
            string TenKH = txtTKTenKH.Text;

            List<KhachHangDTO> dstk = timkiemBLL.TimKiem(MaKH, TenKH);
            dgvDanhSach.Rows.Clear();
            foreach (KhachHangDTO item in dstk)
            {
                dgvDanhSach.Rows.Add(item.MaKH, item.TenKH, item.SDT, item.DiaChi, item.Email);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void ResetValues()
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";


        }

    }
}

