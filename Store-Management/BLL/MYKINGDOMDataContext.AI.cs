using System.Linq;

namespace BLL
{
    public partial class MYKINGDOMDataContext
    {
        public string GetAIText()
        {
            string result = "";
            result += "1. Danh sách đơn hàng:";
            if (DonHangs.Count() > 0)
            {
                result += '\n';
                foreach (var item in DonHangs)
                {
                    result += $"\t- Đơn hàng: {item.MaDonHang}\n\t+ Mã khách hàng: {item.MaKhachHang}\n\t+ Mã nhân viên: {item.MaNhanVien}\n\t+ Ngày đặt hàng: {item.NgayDatHang}\n\t+ Tổng tiền: {item.TongTien}\n\t+ Mã voucher: {item.MaVoucher}\n\t+ Trạng thái: {item.TrangThai}\n\t+ Ghi chú: {item.GhiChu}\n";
                }
            }
            else
                result += " Trống\n";
            result += "2. Danh sách hoá đơn:";
            if (HoaDonOfflines.Count() > 0)
            {
                result += '\n';
                foreach (var item in HoaDonOfflines)
                {
                    result += $"- Hoá đơn: {item.MaHoaDon}\n\t+ Mã nhân viên: {item.MaNhanVien}\n\t+ Ngày lập hoá đơn: {item.NgayLap}\n\t+ Tổng tiền: {item.TongTien}\n\t+ Trạng thái: {item.TrangThai}\n";
                }
            }
            else
                result += " Trống\n";
            //...

            return result;
        }
    }
}
