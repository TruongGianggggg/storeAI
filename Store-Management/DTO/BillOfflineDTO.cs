using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillOfflineDTO
    {
        public string idhoadon { get; set; }
        public string tennhanvien { get; set; }
        public DateTime ngaylap { get; set; }
        public string trangthai { get; set; }
        public double tongtien { get; set; }
    }
}
