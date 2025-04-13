using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriesBLL : BaseBLL
    {
        public CategoriesBLL() : base() { }
        public List<DanhMucSanPham> getDanhSachDanhMuc()
        {
            var lst = context.DanhMucSanPhams;
            return lst.ToList();
        }
        public bool KiemTraDanhMucTonTai(string tenDanhMuc)
        {
            return context.DanhMucSanPhams.Any(dm => dm.TenDanhMuc.Equals(tenDanhMuc, StringComparison.OrdinalIgnoreCase));
        }

        public int LayIDtuTen(string TenDM)
        {
            var danhmuc = context.DanhMucSanPhams.FirstOrDefault(kh => kh.TenDanhMuc == TenDM);
            return danhmuc != null ? danhmuc.MaDanhMuc : -1;
        }

        public void ThemDanhMuc(string TenDM, string ImageDM)
        {
            context.Them_DanhMucSanPham(TenDM, ImageDM);

            context.SubmitChanges();
           
            
             

        }


        public void XoaDanhMuc(int MaDanhMuc)
        {
            var danhmucToRemove = context.DanhMucSanPhams.SingleOrDefault(dv => dv.MaDanhMuc == MaDanhMuc);
            if (danhmucToRemove != null)
            {
                context.DanhMucSanPhams.DeleteOnSubmit(danhmucToRemove);
                context.SubmitChanges();
            }
        }


        public void CapNhatDanhMuc(string TenDM, string ImageDM, int MaDanhMuc)
        {
            var danhmucToUpdate = context.DanhMucSanPhams.SingleOrDefault(kh => kh.MaDanhMuc == MaDanhMuc);
            if (danhmucToUpdate != null)
            {
                danhmucToUpdate.TenDanhMuc = TenDM;
                danhmucToUpdate.ImageDanhMuc = ImageDM;   

                context.SubmitChanges();
            }
        }

        public List<CategoriesDTO> GetDanhMucList_MaDanhMuc(string texttimkiem)
        {
            try
            {
                var danhmucList = (from p in context.DanhMucSanPhams
                                     where p.MaDanhMuc == int.Parse(texttimkiem)
                                     select new CategoriesDTO
                                     {
                                         MaDanhMuc = p.MaDanhMuc,
                                         TenDanhMuc = p.TenDanhMuc,
                                         ImageDanhMuc = p.ImageDanhMuc
                                         

                                     }).ToList();

                return danhmucList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<CategoriesDTO> GetDanhMucList_TenDanhMuc(string texttimkiem)
        {
            try
            {
                var danhmucList = (from p in context.DanhMucSanPhams
                                   where p.TenDanhMuc == texttimkiem
                                   select new CategoriesDTO
                                   {
                                       MaDanhMuc = p.MaDanhMuc,
                                       TenDanhMuc = p.TenDanhMuc,
                                       ImageDanhMuc = p.ImageDanhMuc


                                   }).ToList();

                return danhmucList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
