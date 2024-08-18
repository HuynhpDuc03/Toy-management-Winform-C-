using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace BLL
{

    public class HoaDonBLL
    {
        static Database db = new Database();
        static HoaDonDAO hd = new HoaDonDAO();

        public void fillCombo(string sql, ComboBox cbo, string ma, string ten)
        {
            db.FillCombo(sql, cbo, ma, ten);
        }


        public DataTable GetDataToTable(string sql)
        {
            return db.GetDataToTable(sql);
        }
        public string ConvertDateTime(string date)
        {
            return db.ConvertDateTime(date);
        }

        public string GetFieldValues(string sql)
        {
            return db.GetFieldValues(sql);
        }

        public string NumberToText(double number)
        {
            return hd.NumberToText(number);
        }

        public string CreateKey(string tiento)
        {
            return db.CreateKey(tiento);
        }
        public bool CheckKey(string sql)
        {
            return db.CheckKey(sql);
        
        }
        public void RunSQL(string sql)
        {
            db.RunSQL(sql);
        }
        public void RunSqlDel(string sql)
        {
            db.RunSqlDel(sql);
        }
        public bool ThemHD(HoaDonDTO hdDTO)
        {
            return hd.ThemHoaDon(hdDTO);
        }

        public bool ThemHDCT(HoaDonCTDTO hdctDTO)
        {
            return hd.ThemChiTietHoaDon(hdctDTO);
        }

        public DataTable TimKiemHoaDon(string maHD, string thang, string nam, string maNV, string maKH, string tongTien)
        {
            return hd.TimKiemHoaDon(maHD,thang,nam,maNV,maKH,tongTien);
        }

        }

}
