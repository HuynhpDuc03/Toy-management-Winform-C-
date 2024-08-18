using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAO khDAO = new KhachHangDAO();
        public List<KhachHangDTO> HienThiDanhSachKhachHang()
        {
            return khDAO.HienThiDanhSachKhachHang();
        }

        public bool ThemKH(KhachHangDTO kh)
        {
            return khDAO.ThemKH(kh);
        }

        public bool XoaKH(KhachHangDTO kh)
        {
            return khDAO.XoaKH(kh);
        }

        public bool SuaKH(KhachHangDTO kh)
        {
            return khDAO.SuaKH(kh);
        }

        public List<KhachHangDTO> TimKiem(string MaKH, string TenKH)
        {
            return khDAO.TimKiem(MaKH, TenKH);
        }
    }
}
