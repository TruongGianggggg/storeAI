using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VoucherBLL : BaseBLL
    {
        public VoucherBLL() : base() { }

        public List<Voucher> GetVoucherList()
        {
            var list = context.Vouchers.ToList();
            return list;
        }
        public void ThemVoucher(string code, int giamgia, DateTime date)
        {
            Voucher voucher = new Voucher();
            voucher.Code = code;
            voucher.GiamGia = giamgia;
            voucher.NgayHetHan = date;
            context.Vouchers.InsertOnSubmit(voucher);
            context.SubmitChanges();
        }
        public void XoaVoucher(int ma)
        {
            var query = context.Vouchers.FirstOrDefault(v => v.MaVoucher == ma);
            if (query != null)
            {
                context.Vouchers.DeleteOnSubmit(query);
                context.SubmitChanges();
            }
        }
        public void SuaVoucher(int ma, string code, int giamgia, DateTime date)
        {
            var query = context.Vouchers.Where(v => v.MaVoucher == ma);
            if (query != null)
            {
                query.FirstOrDefault().Code = code;
                query.FirstOrDefault().GiamGia = giamgia;
                query.FirstOrDefault().NgayHetHan= date;
                context.SubmitChanges();
            }
        }
    }
}
