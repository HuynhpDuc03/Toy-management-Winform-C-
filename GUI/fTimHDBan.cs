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


namespace GUI
{
    public partial class fTimHDBan : Form
    {
        DataTable tblHDB;

        public fTimHDBan()
        {
            InitializeComponent();
        }

        private void fTimHDBan_Load(object sender, EventArgs e)
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtMaHD.Focus();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHD,  thang,  nam,  maNV,  maKH,  tongTien;
            if ((txtMaHD.Text == "") && (txtThang.Text == "") && (txtNam.Text == "") &&
               (txtMaNV.Text == "") && (txtMaKH.Text == "") &&
               (txtTongTien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            maHD = txtMaHD.Text;
            thang = txtThang.Text;
            nam = txtNam.Text;
            maNV = txtMaNV.Text;
            maKH = txtMaKH.Text;
            tongTien = txtTongTien.Text;

            HoaDonBLL hdBLL = new HoaDonBLL();

            tblHDB = hdBLL.TimKiemHoaDon(maHD, thang, nam, maNV, maKH, tongTien);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDanhSach.DataSource = tblHDB;
            LoadDataGridView();
        }



        private void LoadDataGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã Hóa đơn";
            dgvDanhSach.Columns[1].HeaderText = "Mã nhân viên";
            dgvDanhSach.Columns[2].HeaderText = "Mã khách";
            dgvDanhSach.Columns[3].HeaderText = "Ngày bán";
            dgvDanhSach.Columns[4].HeaderText = "Tổng tiền";
            dgvDanhSach.Columns[0].Width = 150;
            dgvDanhSach.Columns[1].Width = 100;
            dgvDanhSach.Columns[2].Width = 80;
            dgvDanhSach.Columns[3].Width = 80;
            dgvDanhSach.Columns[4].Width = 80;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvDanhSach.DataSource = null;
        }
        private void ResetValues()
        {
            txtMaHD.Text = "";
            txtMaKH.Text = "";
            txtMaNV.Text = "";
            txtThang.Text = DateTime.Now.Month.ToString();
            txtNam.Text = DateTime.Now.Year.ToString();
            txtTongTien.Text = "0";
            
        }
        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvDanhSach.CurrentRow.Cells["MaHD"].Value.ToString();
                fHoaDon frm = new fHoaDon();
                frm.txtMaHD.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
