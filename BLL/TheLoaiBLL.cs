using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BLL
{
    public class TheLoaiBLL
    {
        static Database db = new Database();
        static TheLoaiDAO TL = new TheLoaiDAO();
        public DataTable GetDataToTable(string sql)
        {
            return db.GetDataToTable(sql);
        }
        public string GetFieldValues(string sql)
        {
            return db.GetFieldValues(sql);
        }

        public void RunSQL(string sql)
        {
            db.RunSQL(sql);
        }
        public void RunSqlDel(string sql)
        {
            db.RunSqlDel(sql);
        }
        public bool CheckKey(string sql)
        {
            return db.CheckKey(sql);

        }

        public void ThemTheLoai(TheLoaiDTO tl)
        {
            TL.ThemTheLoai(tl);
        }
        public DataTable TimKiemTheLoai(string maTL, string tenTL)
        {
            return TL.TimKiemTheLoai(maTL, tenTL);
        }
        public void XoaTheLoai(string maTL)
        {
            TL.XoaTheLoai(maTL);
        }
        public void CapNhatTheLoai(TheLoaiDTO tl)
        {
            TL.CapNhatTheLoai(tl);
        }
        }
}
