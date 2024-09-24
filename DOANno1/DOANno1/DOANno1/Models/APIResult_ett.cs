using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANno1.Models
{
    public enum EnumErrCode
    {
        Error = -1,
        Fail = 0,
        Success = 1,
        Empty = 2,
        NotExistent = 3,
        InputEmpty = 4,
        NotAllowed
    }

    public class APIResult_ett<T>
    {
        public EnumErrCode ErrCode { get; set; }
        public string ErrDesc { get; set; }
        public T Data { get; set; }
    }
    public class ChamCongModel
    {
        public string MaCC { get; set; }
        public DateTime ThoiGianCC { get; set; }
        public string MaNV { get; set; }
        // Thêm các thuộc tính khác cần thiết cho thông tin chấm công
        public bool LuuThanhCong { get; set; } // Thêm thuộc tính để xác định xem việc lưu chấm công thành công hay không
        public string Loi { get; set; }
    }
    public class UserModel
    {
        public string TenTK { get; set; }
        public string User { get; set; }
        public string QuyenTC { get; set; }
        public string MaNV { get; set; }
    }
}