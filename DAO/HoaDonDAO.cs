using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace DAO
{
    public class HoaDonDAO : Database
    {
        public string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }

        public bool ThemHoaDon(HoaDonDTO hoaDonDTO)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO tblHoaDon(MaHD, NgayLap, MaNV, MaKH, TongTien) VALUES (@maHD, @ngayLap, @maNV, @maKH, @tongTien)";

            SqlParameter parMaHD = new SqlParameter("@maHD", SqlDbType.NVarChar);
            parMaHD.Value = hoaDonDTO.MaHD;
            sqlCmd.Parameters.Add(parMaHD);

            SqlParameter parNgayLap = new SqlParameter("@ngayLap", SqlDbType.DateTime);
            parNgayLap.Value = hoaDonDTO.NgayLap;
            sqlCmd.Parameters.Add(parNgayLap);

            SqlParameter parMaNV = new SqlParameter("@maNV", SqlDbType.NVarChar);
            parMaNV.Value = hoaDonDTO.MaNV;
            sqlCmd.Parameters.Add(parMaNV);

            SqlParameter parMaKH = new SqlParameter("@maKH", SqlDbType.NVarChar);
            parMaKH.Value = hoaDonDTO.MaKH;
            sqlCmd.Parameters.Add(parMaKH);

            SqlParameter parTongTien = new SqlParameter("@tongTien", SqlDbType.Float);
            parTongTien.Value = hoaDonDTO.TongTien;
            sqlCmd.Parameters.Add(parTongTien);

            sqlCmd.Connection = Con;
            int result = sqlCmd.ExecuteNonQuery();
            CloseConnection();

            return result > 0;
        }
        public bool ThemChiTietHoaDon(HoaDonCTDTO hd)
        {
            Connect();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO tblChiTietHoaDon(MaHD, MaDC, SoLuong, GiaBan, GiamGia, TongTien) VALUES (@maHD, @maDC, @soLuong, @giaBan, @giamGia, @tongTien)";

            SqlParameter parMaHD = new SqlParameter("@maHD", SqlDbType.NVarChar);
            parMaHD.Value = hd.MaHD;
            sqlCmd.Parameters.Add(parMaHD);

            SqlParameter parMaDC = new SqlParameter("@maDC", SqlDbType.NVarChar);
            parMaDC.Value = hd.MaDC;
            sqlCmd.Parameters.Add(parMaDC);

            SqlParameter parSoLuong = new SqlParameter("@soLuong", SqlDbType.Float);
            parSoLuong.Value = hd.SoLuong;
            sqlCmd.Parameters.Add(parSoLuong);

            SqlParameter parGiaBan = new SqlParameter("@giaBan", SqlDbType.Float);
            parGiaBan.Value = hd.GiaBan;
            sqlCmd.Parameters.Add(parGiaBan);

            SqlParameter parGiamGia = new SqlParameter("@giamGia", SqlDbType.Float);
            parGiamGia.Value = hd.GiamGia;
            sqlCmd.Parameters.Add(parGiamGia);

            SqlParameter parTongTien = new SqlParameter("@tongTien", SqlDbType.Float);
            parTongTien.Value = hd.TongTien;
            sqlCmd.Parameters.Add(parTongTien);

            sqlCmd.Connection = Con;
            int result = sqlCmd.ExecuteNonQuery();
            CloseConnection();

            return result > 0;
        }




        public DataTable TimKiemHoaDon(string maHD, string thang, string nam, string maNV, string maKH, string tongTien)
        {
            Connect();
            string sql = "SELECT * FROM tblHoaDon WHERE 1=1";

            if (!string.IsNullOrEmpty(maHD))
                sql += " AND MaHD Like N'%" + maHD + "%'";
            if (!string.IsNullOrEmpty(thang))
                sql += " AND MONTH(NgayLap) =" + thang;
            if (!string.IsNullOrEmpty(nam))
                sql += " AND YEAR(NgayLap) =" + nam;
            if (!string.IsNullOrEmpty(maNV))
                sql += " AND MaNV Like N'%" + maNV + "%'";
            if (!string.IsNullOrEmpty(maKH))
                sql += " AND MaKH Like N'%" + maKH + "%'";
            if (!string.IsNullOrEmpty(tongTien))
                sql += " AND TongTien <=" + tongTien;

            DataTable dataTable = GetDataToTable(sql);
            CloseConnection();

          return dataTable;
        }



    }

}
