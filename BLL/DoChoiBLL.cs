using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
using System.Windows.Forms;

namespace BLL
{
    public class DoChoiBLL
    {
        static Database db = new Database();
        static DoChoiDAO dc = new DoChoiDAO();
        public void fillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            db.FillCombo(sql, cbo, ma, ten);
        }


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

        public void ThemDoChoi(DoChoiDTO toy)
        {
            dc.ThemDoChoi(toy);
        }
        public void XoaDoChoi(string maDC)
        {
            dc.XoaDoChoi(maDC);
        }

        public DataTable TimKiemDoChoi(string maDC, string tenDC, string maTL)
        {
            return dc.TimKiemDoChoi(maDC,tenDC,maTL);
        }
        public void CapNhatDoChoi(string maDC, string tenDC, string maTL, int soLuong, string anh, string ghiChu)
        {
            dc.CapNhatDoChoi(maDC,tenDC,maTL,soLuong,anh,ghiChu);
        }
        }
}
