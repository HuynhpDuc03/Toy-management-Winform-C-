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
    public partial class fTheLoai : Form
    {
        DataTable tblTL;
        TheLoaiBLL tlBLL = new TheLoaiBLL();
        public fTheLoai()
        {
            InitializeComponent();
        }

        private void fTheLoai_Load(object sender, EventArgs e)
        {
            txtMaTL.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }


        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaTL, TenTL, MoTa FROM tblTheLoai";
            tblTL = tlBLL.GetDataToTable(sql); 
            dgvDanhSach.DataSource = tblTL;         
            dgvDanhSach.Columns[0].HeaderText = "Mã thể loại";
            dgvDanhSach.Columns[1].HeaderText = "Tên thể loại";
            dgvDanhSach.Columns[2].HeaderText = "Mô tả";
            dgvDanhSach.Columns[0].Width = 100;
            dgvDanhSach.Columns[1].Width = 300;
            dgvDanhSach.Columns[2].Width = 500;
            dgvDanhSach.AllowUserToAddRows = false; 
            dgvDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically; 
        }

        private void dgvDanhSach_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                return;
            }
            if (tblTL.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaTL.Text = dgvDanhSach.CurrentRow.Cells["MaTL"].Value.ToString();
            txtTenTL.Text = dgvDanhSach.CurrentRow.Cells["TenTL"].Value.ToString();
            txtMoTa.Text = dgvDanhSach.CurrentRow.Cells["MoTa"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue(); //Xoá trắng các textbox
            txtMaTL.Enabled = true; //cho phép nhập mới
            txtMaTL.Focus();
        }
        private void ResetValue()
        {
            txtMaTL.Text = "";
            txtTenTL.Text = "";
            txtMoTa.Text = "";
            txtTkMaTL.Text = "";
            txtTkTenTL.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql; //Lưu lệnh sql
            if (txtMaTL.Text.Trim().Length == 0) //Nếu chưa nhập mã chất liệu
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                return;
            }
            if (txtTenTL.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTL.Focus();
                return;
            }
            if (txtMoTa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mô tả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMoTa.Focus();
                return;
            }

            sql = "Select MaTL From tblTheLoai where MaTL=N'" + txtMaTL.Text.Trim() + "'";
            if (tlBLL.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTL.Focus();
                return;
            }
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTL = txtMaTL.Text;
            tl.TenTL = txtTenTL.Text;
            tl.MoTa = txtMoTa.Text;
            
            tlBLL.ThemTheLoai(tl);
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView(); 
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaTL.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblTL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTL.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenTL.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TheLoaiDTO tl = new TheLoaiDTO();
            tl.MaTL = txtMaTL.Text;
            tl.TenTL = txtTenTL.Text;
            tl.MoTa = txtMoTa.Text;
            tlBLL.CapNhatTheLoai(tl);
            MessageBox.Show("Bạn đã cập nhật thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblTL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTL.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string maTL = txtMaTL.Text;
                tlBLL.XoaTheLoai(maTL);
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void txtMaTL_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if ((txtTkMaTL.Text == "") && (txtTkTenTL.Text == ""))
            {
                MessageBox.Show("Bạn hãy nhập điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDataGridView();
                return;
            }

            string maTL = txtTkMaTL.Text;
            string tenTL = txtTkTenTL.Text;

            tblTL = tlBLL.TimKiemTheLoai(maTL, tenTL);
            if (tblTL.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thoả mãn điều kiện tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Có " + tblTL.Rows.Count + "  bản ghi thoả mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvDanhSach.DataSource = tblTL;
            ResetValue();
        }
    }
}
