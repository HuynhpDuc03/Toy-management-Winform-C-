using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAO
{
    public class DoChoiDAO : Database
    {
        public void ThemDoChoi(DoChoiDTO toy)
        {
            Connect();
            string sql = "INSERT INTO tblDoChoi(MaDC,TenDC,MaTL,SoLuong,GiaNhap, GiaBan,Anh,GhiChu) VALUES(N'"
                + toy.MaDC + "',N'" + toy.TenDC +
                "',N'" + toy.MaTL +
                "'," + toy.SoLuong.ToString() +
                "," + toy.GiaNhap.ToString() +
                "," + toy.GiaBan.ToString() +
                ",'" + toy.Anh + "',N'" + toy.GhiChu + "')";

            RunSQL(sql);
            CloseConnection();
        }
        public void XoaDoChoi(string maDC)
        {
            Connect();
            string sql = "DELETE FROM tblDoChoi WHERE MaDC=N'" + maDC + "'";
            RunSQL(sql);
            CloseConnection();
        }

        public DataTable TimKiemDoChoi(string maDC, string tenDC, string maTL)
        {
            Connect();
            string sql = "SELECT * FROM tblDoChoi WHERE 1=1";

            if (!string.IsNullOrEmpty(maDC))
                sql += " AND MaDC LIKE N'%" + maDC + "%'";
            if (!string.IsNullOrEmpty(tenDC))
                sql += " AND TenDC LIKE N'%" + tenDC + "%'";
            if (!string.IsNullOrEmpty(maTL))
                sql += " AND MaTL LIKE N'%" + maTL + "%'";

            DataTable dt = GetDataToTable(sql);

            CloseConnection();
            return dt;
        }

        public void CapNhatDoChoi(string maDC, string tenDC, string maTL, int soLuong, string anh, string ghiChu)
        {
            Connect();
            string sql = "UPDATE tblDoChoi SET TenDC=N'" + tenDC + "', MaTL=N'" + maTL + "', SoLuong=" + soLuong + ", Anh='" + anh + "', GhiChu=N'" + ghiChu + "' WHERE MaDC=N'" + maDC + "'";
            RunSQL(sql);
            CloseConnection();
        }

    }
}
