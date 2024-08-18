using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAO nvDAO = new NhanVienDAO();
        public List<NhanVienDTO> HienThiDanhSachNhanVien()
        {
            return nvDAO.HienThiDanhSachNhanVien();
        }

        public bool ThemNV(NhanVienDTO nv)
        {
            return nvDAO.ThemNV(nv);
        }
        public bool XoaNV(NhanVienDTO nv)
        {
            return nvDAO.XoaNV(nv);
        }
        public bool SuaNV(NhanVienDTO nv)
        {
            return nvDAO.SuaNV(nv);
        }
        public List<NhanVienDTO> TimKiem(string MaNV, string TenNV)
        {
            return nvDAO.TimKiem(MaNV, TenNV);
        }



    }
}
