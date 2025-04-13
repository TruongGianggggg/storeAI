using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BrandBLL : BaseBLL
    {
        public BrandBLL() : base() { }
        public List<ThuongHieu> getDanhSachThuongHieu()
        {
            var lst = context.ThuongHieus.ToList();
            return lst;
        }

        public int LayIDtuTen(string TenTH)
        {
            // Kiểm tra xem số điện thoại có tồn tại không
            var thuongHieu = context.ThuongHieus.FirstOrDefault(kh => kh.TenThuongHieu == TenTH);

            // Nếu khách hàng tồn tại, trả về MaKhachHang, ngược lại trả về giá trị mặc định
            return thuongHieu != null ? thuongHieu.MaThuongHieu : -1;
        }

        public void ThemThuongHieu(string TenTH)
        {
            context.Them_ThuongHieuSanPham(TenTH);

            context.SubmitChanges();


        }


        public void XoaThuongHieu(int MaThuongHieu)
        {
            var thuonghieuToRemove = context.ThuongHieus.SingleOrDefault(dv => dv.MaThuongHieu == MaThuongHieu);
            if (thuonghieuToRemove != null)
            {
                context.ThuongHieus.DeleteOnSubmit(thuonghieuToRemove);
                context.SubmitChanges();
            }
        }


        public void CapNhatThuongHieu(string TenTH, int MaThuongHieu)
        {
            var thuonghieuToUpdate = context.ThuongHieus.SingleOrDefault(kh => kh.MaThuongHieu == MaThuongHieu);
            if (thuonghieuToUpdate != null)
            {
                thuonghieuToUpdate.TenThuongHieu = TenTH;
                context.SubmitChanges();
            }
        }

        public List<BrandDTO> GetThuongHieuList_MaThuongHieu(string texttimkiem)
        {
            try
            {
                var thuonghieuList = (from p in context.ThuongHieus
                                     where p.MaThuongHieu == int.Parse(texttimkiem)
                                     select new BrandDTO
                                     {
                                         MaThuongHieu = p.MaThuongHieu,
                                         TenThuongHieu = p.TenThuongHieu

                                     }).ToList();

                return thuonghieuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<BrandDTO> GetThuongHieuList_TenThuongHieu(string texttimkiem)
        {
            try
            {
                var thuonghieuList = (from p in context.ThuongHieus
                                     where p.TenThuongHieu == texttimkiem
                                     select new BrandDTO
                                     {
                                         MaThuongHieu = p.MaThuongHieu,
                                         TenThuongHieu = p.TenThuongHieu

                                     }).ToList();

                return thuonghieuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
