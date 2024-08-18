using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public string MaHD { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }

        public DateTime NgayLap { get; set; }
        public double TongTien { get; set; }
        public int TrangThai { get; set; }
    }
}
