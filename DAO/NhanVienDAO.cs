using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class NhanVienDAO : Database
    {
        public List<NhanVienDTO> HienThiDanhSachNhanVien()
        {
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select MaNV, TenNV, GioiTinh, NgaySinh, SDT, DiaChi, TenDangNhap, MatKhau from tblNhanVien";
            sqlCmd.Connection = Con;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                bool gioiTinh = reader.GetBoolean(2);
                DateTime ngaySinh = reader.GetDateTime(3);
                string sdt = reader.GetString(4);
                string dc = reader.GetString(5);
                string tdn = reader.GetString(6);
                string mk = reader.GetString(7);

                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = ma;
                nv.TenNV = ten;
                //moi them
                nv.GioiTinh = gioiTinh;
                nv.NgaySinh = ngaySinh;
                nv.SDT = sdt;
                nv.DiaChi = dc;
                nv.TenDangNhap = tdn;
                nv.MatKhau = mk;

                ds.Add(nv);
            }
            reader.Close();
            return ds;
        }

        public bool ThemNV(NhanVienDTO nv)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into tblNhanVien (MaNV,TenNV,GioiTinh,NgaySinh,SDT,DiaChi,TenDangNhap,MatKhau) values (@ma, @ten, @gioiTinh, @ngaySinh, @sdt, @dc, @tdn , @mk)";

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = nv.MaNV;
            sqlCmd.Parameters.Add(parMa);

            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = nv.TenNV;
            sqlCmd.Parameters.Add(parTen);

            SqlParameter parGTinh = new SqlParameter("@gioiTinh", SqlDbType.Bit);
            parGTinh.Value = nv.GioiTinh ? 1 : 0;
            sqlCmd.Parameters.Add(parGTinh);

            SqlParameter parNgaySinh = new SqlParameter("@ngaySinh", SqlDbType.DateTime);
            parNgaySinh.Value = nv.NgaySinh;
            sqlCmd.Parameters.Add(parNgaySinh);

            SqlParameter parSDT = new SqlParameter("@sdt", SqlDbType.VarChar);
            parSDT.Value = nv.SDT;
            sqlCmd.Parameters.Add(parSDT);

            SqlParameter parDC = new SqlParameter("@dc", SqlDbType.NVarChar);
            parDC.Value = nv.DiaChi;
            sqlCmd.Parameters.Add(parDC);

            SqlParameter parTDN = new SqlParameter("@tdn", SqlDbType.NVarChar);
            parTDN.Value = nv.TenDangNhap;
            sqlCmd.Parameters.Add(parTDN);

            SqlParameter parMK = new SqlParameter("@mk", SqlDbType.NVarChar);
            parMK.Value = nv.MatKhau;
            sqlCmd.Parameters.Add(parMK);

            sqlCmd.Connection = Con;
            int rowsAffected = sqlCmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool XoaNV(NhanVienDTO nv)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from tblNhanVien where MaNV = @ma ";

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = nv.MaNV;
            sqlCmd.Parameters.Add(parMa);

            sqlCmd.Connection = Con;
            int kt = sqlCmd.ExecuteNonQuery();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SuaNV(NhanVienDTO nv)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update tblNhanVien set TenNV = @ten, GioiTinh = @gioiTinh, NgaySinh = @NgaySinh,  SDT = @sdt, DiaChi = @dc, TenDangNhap = @tdn, MatKhau = @mk where MaNV = @ma ";

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = nv.MaNV;
            sqlCmd.Parameters.Add(parMa);

            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = nv.TenNV;
            sqlCmd.Parameters.Add(parTen);

            SqlParameter parGTinh = new SqlParameter("@gioiTinh", SqlDbType.Bit);
            parGTinh.Value = nv.GioiTinh;
            sqlCmd.Parameters.Add(parGTinh);

            SqlParameter parNgaySinh = new SqlParameter("@ngaySinh", SqlDbType.DateTime);
            parNgaySinh.Value = nv.NgaySinh;
            sqlCmd.Parameters.Add(parNgaySinh);

            SqlParameter parSDT = new SqlParameter("@sdt", SqlDbType.VarChar);
            parSDT.Value = nv.SDT;
            sqlCmd.Parameters.Add(parSDT);

            SqlParameter parDC = new SqlParameter("@dc", SqlDbType.NVarChar);
            parDC.Value = nv.DiaChi;
            sqlCmd.Parameters.Add(parDC);

            SqlParameter parTDN = new SqlParameter("@tdn", SqlDbType.NVarChar);
            parTDN.Value = nv.TenDangNhap;
            sqlCmd.Parameters.Add(parTDN);

            SqlParameter parMK = new SqlParameter("@mk", SqlDbType.NVarChar);
            parMK.Value = nv.MatKhau;
            sqlCmd.Parameters.Add(parMK);


            sqlCmd.Connection = Con;
            int kt = sqlCmd.ExecuteNonQuery();
            if (kt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<NhanVienDTO> TimKiem(string MaNV, string TenNV)
        {
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            Connect();
            string sql;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            sql = "select * from tblNhanVien where 1 = 1 ";
            if (MaNV != "")
                sql += " AND MaNV like @ma";
            if (TenNV != "")
                sql += " AND TenNV like @ten";
            sqlCmd.CommandText = sql;
            sqlCmd.Connection = Con;

            SqlParameter parMaKH = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMaKH.Value = "%" + MaNV + "%";
            sqlCmd.Parameters.Add(parMaKH);

            SqlParameter parTenKH = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTenKH.Value = "%" + TenNV + "%";
            sqlCmd.Parameters.Add(parTenKH);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                bool gioiTinh = reader.GetBoolean(2);
                DateTime ngaySinh = reader.GetDateTime(3);
                string sdt = reader.GetString(4);
                string dc = reader.GetString(5);
                string tdn = reader.GetString(6);
                string mk = reader.GetString(7);

                NhanVienDTO nv = new NhanVienDTO();
                nv.MaNV = ma;
                nv.TenNV = ten;
                nv.GioiTinh = gioiTinh;
                nv.NgaySinh = ngaySinh;
                nv.SDT = sdt;
                nv.DiaChi = dc;
                nv.TenDangNhap = tdn;
                nv.MatKhau = mk;

                ds.Add(nv);
            }
            reader.Close();
            return ds;
        }

    }
}
