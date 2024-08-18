using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class TheLoaiDAO : Database
    {

        public DataTable TimKiemTheLoai(string maTL, string tenTL)
        {
            Connect();
            string sql = "SELECT * FROM tblTheLoai WHERE 1=1";

            if (!string.IsNullOrEmpty(maTL))
                sql += " AND MaTL LIKE N'%" + maTL + "%'";
            if (!string.IsNullOrEmpty(tenTL))
                sql += " AND TenTL LIKE N'%" + tenTL + "%'";
            if (!string.IsNullOrEmpty(maTL) && !string.IsNullOrEmpty(tenTL))
                sql += "AND MATL = N'' AND TenTL = N''";
                
            DataTable dt = GetDataToTable(sql);

            CloseConnection();
            return dt;
        }



        public void ThemTheLoai(TheLoaiDTO tl)
        {
            Connect();
            string sql = "INSERT INTO tblTheLoai VALUES(N'" + tl.MaTL + "',N'" +tl.TenTL + "',N' " + tl.MoTa + "')";
            RunSQL(sql);
            CloseConnection();
        }

        public void XoaTheLoai(string maTL)
        {
            Connect();
            string sql = "DELETE tblTheLoai WHERE MaTL=N'" + maTL + "'";
            RunSqlDel(sql);
            CloseConnection();
        }

        public void CapNhatTheLoai(TheLoaiDTO tl)
        {
            Connect();
            string sql = "UPDATE tblTheLoai SET TenTL=N'" +
               tl.TenTL + "',MoTa=N'" + tl.MoTa +
               "' WHERE MaTL=N'" + tl.MaTL + "'";
            RunSQL(sql);
            CloseConnection();
        }

    }
}
