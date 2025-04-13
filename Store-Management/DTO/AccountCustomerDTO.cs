using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountCustomerDTO
    {
        public int IDTaiKhoan {  get; set; }
        public string TenTK {  get; set; }
        public string Pass { get; set; }
        public int IDKhachHang {  get; set; }
        public string TenKH {  get; set; }
        public string Email { get; set; }
        public string SDT {  get; set; }
        public string HoatDong { get; set;}

    }
}
