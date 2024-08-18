using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class KhachHangDAO : Database
    {
        public List<KhachHangDTO> HienThiDanhSachKhachHang()
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from tblKhachHang";
            sqlCmd.Connection = Con;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                string sdt = reader.GetString(2);
                string diachi = reader.GetString(3);
                string email = reader.GetString(4);

                KhachHangDTO KH = new KhachHangDTO();
                KH.MaKH = ma;
                KH.TenKH = ten;
                KH.SDT = sdt;
                KH.DiaChi = diachi;
                KH.Email = email;

                ds.Add(KH);
            }
            reader.Close();
            return ds;
        }

        public bool TimKiem(KhachHangDTO kh)
        {
            throw new NotImplementedException();
        }

        public bool ThemKH(KhachHangDTO kh)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into tblKhachHang values(@ma, @ten, @sdt, @diachi, @email)";

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = kh.MaKH;
            sqlCmd.Parameters.Add(parMa);

            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = kh.TenKH;
            sqlCmd.Parameters.Add(parTen);

            SqlParameter parSdt = new SqlParameter("@sdt", SqlDbType.NVarChar);
            parSdt.Value = kh.SDT;
            sqlCmd.Parameters.Add(parSdt);

            SqlParameter parDiachi = new SqlParameter("@diachi", SqlDbType.NVarChar);
            parDiachi.Value = kh.DiaChi;
            sqlCmd.Parameters.Add(parDiachi);

            SqlParameter parEmail = new SqlParameter("@email", SqlDbType.NVarChar);
            parEmail.Value = kh.Email;
            sqlCmd.Parameters.Add(parEmail);

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

        public bool XoaKH(KhachHangDTO kh)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from tblKhachHang where MaKH = @ma ";

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = kh.MaKH;
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
        public bool SuaKH(KhachHangDTO kh)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update tblKhachHang set MaKh = @ma, TenKH = @ten, SDT = @sdt, DiaChi = @diachi, Email = @email where MaKH = @ma";

            SqlParameter parMa = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMa.Value = kh.MaKH;
            sqlCmd.Parameters.Add(parMa);

            SqlParameter parTen = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTen.Value = kh.TenKH;
            sqlCmd.Parameters.Add(parTen);

            SqlParameter parSdt = new SqlParameter("@sdt", SqlDbType.NVarChar);
            parSdt.Value = kh.SDT;
            sqlCmd.Parameters.Add(parSdt);

            SqlParameter parDiachi = new SqlParameter("@diachi", SqlDbType.NVarChar);
            parDiachi.Value = kh.DiaChi;
            sqlCmd.Parameters.Add(parDiachi);

            SqlParameter parEmail = new SqlParameter("@email", SqlDbType.NVarChar);
            parEmail.Value = kh.Email;
            sqlCmd.Parameters.Add(parEmail);

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

        public List<KhachHangDTO> TimKiem(string MaKH, string TenKH)
        {
            List<KhachHangDTO> ds = new List<KhachHangDTO>();
            Connect();
            string sql;
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;

            sql = "select * from tblKhachHang where 1 = 1 ";
            if (MaKH != "")
                sql += " AND MaKH like @ma";
            if (TenKH != "")
                sql += " AND TenKH like @ten";
            sqlCmd.CommandText = sql;
            sqlCmd.Connection = Con;

            SqlParameter parMaKH = new SqlParameter("@ma", SqlDbType.NVarChar);
            parMaKH.Value = "%" + MaKH + "%";
            sqlCmd.Parameters.Add(parMaKH);

            SqlParameter parTenKH = new SqlParameter("@ten", SqlDbType.NVarChar);
            parTenKH.Value = "%" + TenKH + "%";
            sqlCmd.Parameters.Add(parTenKH);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                string ma = reader.GetString(0);
                string ten = reader.GetString(1);
                string sdt = reader.GetString(2);
                string diachi = reader.GetString(3);
                string email = reader.GetString(4);

                KhachHangDTO kh = new KhachHangDTO();
                kh.MaKH = ma;
                kh.TenKH = ten;
                kh.SDT = sdt;
                kh.DiaChi = diachi;
                kh.Email = email;

                ds.Add(kh);
            }
            reader.Close();
            return ds;
        }
    }
}
