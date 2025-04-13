using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class WarehouseBLL : BaseBLL
    {
        public WarehouseBLL() : base() { }

        public List<WarehouseDTO> GetListWarehouse()
        {
            var query = from kh in context.KhoHangs
                        join sp in context.SanPhams on kh.MaSanPham equals sp.MaSanPham
                        select new WarehouseDTO
                        {
                            masp = kh.MaSanPham,
                            tensp = sp.TenSanPham,
                            soluong = (int)kh.SoLuongTonKho
                        };

            return query.ToList();
        }
    }
}
