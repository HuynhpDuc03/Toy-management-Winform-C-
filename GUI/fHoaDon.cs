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
using COMExcel = Microsoft.Office.Interop.Excel;


namespace GUI
{
    public partial class fHoaDon : Form
    {
       static HoaDonBLL hdBLL = new HoaDonBLL();
        DataTable tblCTHD;
        public string MaHD
        {
            get { return txtMaHD.Text; }
        }

        public fHoaDon()
        {
            InitializeComponent();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonLabel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHD.ReadOnly = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnIn.Enabled = false;
            txtMaHD.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenKH.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            hdBLL.fillCombo("SELECT MaKH, TenKH FROM tblKhachHang", cbMaKH, "MaKH", "MaKH");
            cbMaKH.SelectedIndex = -1;
            hdBLL.fillCombo("SELECT MaNV, TenNV FROM tblNhanVien", cbMaNV, "MaNV", "MaNV");
            cbMaNV.SelectedIndex = -1;
            hdBLL.fillCombo("SELECT MaDC, TenDC FROM tblDoChoi", cbMaDC, "MaDC", "MaDC");
            cbMaDC.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHD.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadDataGridView();

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaDC, b.TenDC, a.SoLuong, b.GiaBan, a.GiamGia,a.TongTien FROM tblChiTietHoaDon AS a, tblDoChoi AS b WHERE a.MaHD = N'" + txtMaHD.Text + "' AND a.MaDC=b.MaDC";
            tblCTHD = hdBLL.GetDataToTable(sql);
            dgvDanhSach.DataSource = tblCTHD;
            dgvDanhSach.Columns[0].HeaderText = "Mã Đồ Chơi";
            dgvDanhSach.Columns[1].HeaderText = "Tên Đồ Chơi ";
            dgvDanhSach.Columns[2].HeaderText = "Số lượng";
            dgvDanhSach.Columns[3].HeaderText = "Đơn giá";
            dgvDanhSach.Columns[4].HeaderText = "Giảm giá %";
            dgvDanhSach.Columns[5].HeaderText = "Thành tiền";
            dgvDanhSach.Columns[0].Width = 80;
            dgvDanhSach.Columns[1].Width = 130;
            dgvDanhSach.Columns[2].Width = 80;
            dgvDanhSach.Columns[3].Width = 90;
            dgvDanhSach.Columns[4].Width = 90;
            dgvDanhSach.Columns[5].Width = 90;
            dgvDanhSach.AllowUserToAddRows = false;
            dgvDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayLap FROM tblHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            txtNgayBan.Text = hdBLL.ConvertDateTime(hdBLL.GetFieldValues(str));
            str = "SELECT MaNV FROM tblHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            cbMaNV.Text = hdBLL.GetFieldValues(str);
            str = "SELECT MaKH FROM tblHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            cbMaKH.Text = hdBLL.GetFieldValues(str);
            str = "SELECT TongTien FROM tblHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
            txtTongTien.Text = hdBLL.GetFieldValues(str);
            if (txtTongTien.Text != "0")
            {
                lblBangChu.Text = "Bằng chữ: " + hdBLL.NumberToText(double.Parse(txtTongTien.Text));
            }
            lblBangChu.Text = "Bằng chữ: ";


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHD.Text = hdBLL.CreateKey("HDB");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtMaHD.Text = "";
            txtNgayBan.Text = DateTime.Now.ToShortDateString();
            cbMaNV.Text = "";
            cbMaKH.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cbMaDC.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            HoaDonDTO hdDTO = new HoaDonDTO();

            hdDTO.MaHD = txtMaHD.Text.Trim();
            hdDTO.NgayLap = DateTime.Parse(txtNgayBan.Text.Trim());
            hdDTO.MaNV = cbMaNV.SelectedValue.ToString();
            hdDTO.MaKH = cbMaKH.SelectedValue.ToString();
            hdDTO.TongTien = double.Parse(txtTongTien.Text.Trim());

            HoaDonBLL hdBLL = new HoaDonBLL();
            string checkKey = "SELECT MaHD FROM tblHoaDon WHERE MaHD=N'" + txtMaHD.Text + "'";
            if (!hdBLL.CheckKey(checkKey))
            {
                if (hdDTO.NgayLap.ToString().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNgayBan.Focus();
                    return;
                }
                if (hdDTO.MaNV.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaNV.Focus();
                    return;
                }
                if (hdDTO.MaKH.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaKH.Focus();
                    return;
                }

                bool themHoaDonResult = hdBLL.ThemHD(hdDTO);

                if (themHoaDonResult)
                {

                    HoaDonCTDTO hdctDTO = new HoaDonCTDTO();
                    hdctDTO.MaHD = hdDTO.MaHD;
                    hdctDTO.MaDC = cbMaDC.SelectedValue.ToString();
                    hdctDTO.SoLuong = int.Parse(txtSoLuong.Text.Trim());
                    hdctDTO.GiaBan = double.Parse(txtDonGia.Text.Trim());
                    hdctDTO.GiamGia = int.Parse(txtGiamGia.Text.Trim());
                    hdctDTO.TongTien = double.Parse(txtThanhTien.Text.Trim());

                    bool themChiTietHoaDonResult = hdBLL.ThemHDCT(hdctDTO);

                    if (themChiTietHoaDonResult)
                    {
                        MessageBox.Show("Thêm hóa đơn thành công!");
                        LoadDataGridView();

                        double sl = Convert.ToDouble(hdBLL.GetFieldValues("SELECT SoLuong FROM tblDoChoi WHERE MaDC = N'" + hdctDTO.MaDC + "'"));
                        double SLcon = sl - hdctDTO.SoLuong;
                        string sql = "UPDATE tblDoChoi SET SoLuong =" + SLcon + " WHERE MaDC= N'" + hdctDTO.MaDC + "'";
                        hdBLL.RunSQL(sql);

                        double tong = double.Parse(hdBLL.GetFieldValues("SELECT TongTien FROM tblHoaDon WHERE MaHD = N'" + hdDTO.MaHD + "'"));
                        double Tongmoi = tong + hdctDTO.TongTien;
                        sql = "UPDATE tblHoaDon SET TongTien =" + Tongmoi + " WHERE MaHD = N'" + hdDTO.MaHD + "'";
                        hdBLL.RunSQL(sql);

                        txtTongTien.Text = Tongmoi.ToString();
                        lblBangChu.Text = "Bằng chữ: " + hdBLL.NumberToText(Tongmoi);

                        ResetValuesHang();
                        btnXoa.Enabled = true;
                        btnThem.Enabled = true;
                        btnIn.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Thêm chi tiết hóa đơn thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbMaDC.Focus();
            }
        }

        private void ResetValuesHang()
        {
            cbMaDC.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
        }

        private void dgvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            string MaDCxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                MaDCxoa = dgvDanhSach.CurrentRow.Cells["MaDC"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvDanhSach.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvDanhSach.CurrentRow.Cells["TongTien"].Value.ToString());
                sql = "DELETE tblChiTietHoaDon WHERE MaHD=N'" + txtMaHD.Text + "' AND MaDC = N'" + MaDCxoa + "'";
                hdBLL.RunSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(hdBLL.GetFieldValues("SELECT SoLuong FROM tblDoChoi WHERE MaDC = N'" + MaDCxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE tblDoChoi SET SoLuong =" + slcon + " WHERE MaDC= N'" + MaDCxoa + "'";
                hdBLL.RunSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(hdBLL.GetFieldValues("SELECT TongTien FROM tblHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHoaDon SET TongTien =" + tongmoi + " WHERE MaHD = N'" + txtMaHD.Text + "'";
                hdBLL.RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + hdBLL.NumberToText(tongmoi).ToString();
                LoadDataGridView();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaDC,SoLuong FROM tblChiTietHoaDon WHERE MaHD = N'" + txtMaHD.Text + "'";
                DataTable tblDC = hdBLL.GetDataToTable(sql);
                for (int hang = 0; hang <= tblDC.Rows.Count - 1; hang++)
                {
           
                    sl = Convert.ToDouble(hdBLL.GetFieldValues("SELECT SoLuong FROM tblDoChoi WHERE MaDC = N'" + tblDC.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblDC.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE tblDoChoi SET SoLuong =" + slcon + " WHERE MaDC= N'" + tblDC.Rows[hang][0].ToString() + "'";
                    hdBLL.RunSQL(sql);
                }


                sql = "DELETE tblChiTietHoaDon WHERE MaHD=N'" + txtMaHD.Text + "'";
                hdBLL.RunSqlDel(sql);


                sql = "DELETE tblHoaDon WHERE MaHD=N'" + txtMaHD.Text + "'";
                hdBLL.RunSqlDel(sql);
                MessageBox.Show("Đã xóa hóa đơn! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
            }
        }

        private void cbMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaNV.Text == "")
                txtTenNV.Text = "";
            str = "Select TenNV from tblNhanVien where MaNV =N'" + cbMaNV.SelectedValue + "'";
            txtTenNV.Text = hdBLL.GetFieldValues(str);
        }

        private void cbMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaKH.Text == "")
            {
                txtTenKH.Text = "";
                txtDiaChi.Text = "";
                txtSDT.Text = "";
            }
            str = "Select TenKH from tblKhachHang where MaKH = N'" + cbMaKH.SelectedValue + "'";
            txtTenKH.Text = hdBLL.GetFieldValues(str);
            str = "Select DiaChi from tblKhachHang where MaKH = N'" + cbMaKH.SelectedValue + "'";
            txtDiaChi.Text = hdBLL.GetFieldValues(str);
            str = "Select SDT from tblKhachHang where MaKH= N'" + cbMaKH.SelectedValue + "'";
            txtSDT.Text = hdBLL.GetFieldValues(str);
        }

        private void cbMaDC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbMaDC.Text == "")
            {
                txtTenHang.Text = "";
                txtDonGia.Text = "";
            }
        
            str = "SELECT TenDC FROM tblDoChoi WHERE MaDC =N'" + cbMaDC.SelectedValue + "'";
            txtTenHang.Text = hdBLL.GetFieldValues(str);
            str = "SELECT GiaBan FROM tblDoChoi WHERE MaDC =N'" + cbMaDC.SelectedValue + "'";
            txtDonGia.Text = hdBLL.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            HoaDonBLL hdBLL = new HoaDonBLL();
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinDC;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Đồ Chơi Trẻ Em";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Quận 8";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHD, a.NgayLap, a.TongTien, b.TenKH, b.DiaChi, b.SDT, c.TenNV FROM tblHoaDon AS a, tblKhachHang AS b, tblNhanVien AS c WHERE a.MaHD = N'" + txtMaHD.Text + "' AND a.MaKH = b.MaKH AND a.MaNV = c.MaNV";
            tblThongtinHD = hdBLL.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenDC, a.SoLuong, b.GiaBan, a.GiamGia, a.TongTien " +
                  "FROM tblChiTietHoaDon AS a , tblDoChoi AS b WHERE a.MaHD = N'" +
                  txtMaHD.Text + "' AND a.MaDC = b.MaDC";
            tblThongtinDC = hdBLL.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên đồ chơi";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinDC.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinDC.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinDC.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinDC.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + hdBLL.NumberToText(double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "TP HCM, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void fHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetValues();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void cboMaHD_DropDown(object sender, EventArgs e)
        {
            hdBLL.fillCombo("SELECT MaHD FROM tblHoaDon", cboMaHD, "MaHD", "MaHD");
            cboMaHD.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHD.Focus();
                return;
            }
            txtMaHD.Text = cboMaHD.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cboMaHD.SelectedIndex = -1;
        }
    }
}
