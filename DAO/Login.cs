using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;



namespace DAO
{
    public class Login : Database
    {
        NhanVienDTO nv = new NhanVienDTO();


        public bool LoginDAO(string tk, string mk)
        {
            Connect();
            string query = "SELECT COUNT(*) FROM tblNhanVien WHERE TenDangNhap = @Username AND MatKhau = @Password";
            SqlCommand sqlCmd = new SqlCommand(query, Con);
            sqlCmd.Parameters.AddWithValue("@Username", tk);
            sqlCmd.Parameters.AddWithValue("@Password", mk);

            int count = (int)sqlCmd.ExecuteScalar();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
    
        }


    }
}
