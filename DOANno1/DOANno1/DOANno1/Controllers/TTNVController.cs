using System;
using DOANno1.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANno1.Controllers
{
    public class TTNVController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: TTNV
        public ActionResult Index()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }


        public ActionResult AddNV()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        
        public ActionResult EditNv()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public ActionResult DanhSachNV()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public string Add()
        {
            //ví dụ về linq to sql
            //var qr = db.NhanViens; //select * from NhanVien
            //var qr1 = db.NhanViens.Where(o => o.MSSV == "1234"); //select * from NhanVien where mssv == "1234"

            string idnv = Request["val-idnv"];
            string username = Request["val-username"];
            string birthdayString = Request["val-birthday"];
            DateTime birthday;
            DateTime.TryParse(birthdayString, out birthday);
            string gender = Request["val-gender"];
            string email = Request["val-email"];
            string phone = Request["val-phone"];
            string address = Request["val-address"];
            string chucvu = Request["val-chucvu"];

            //validate input
            if (!string.IsNullOrEmpty(username)
                && !string.IsNullOrEmpty(email)
                && !string.IsNullOrEmpty(phone)
                && !string.IsNullOrEmpty(address)
                && !string.IsNullOrEmpty(birthdayString)
                && !string.IsNullOrEmpty(gender)
                && !string.IsNullOrEmpty(chucvu)
                && !string.IsNullOrEmpty(idnv))
            {
                try
                {
                    var existingNhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == idnv);

                    if (existingNhanVien != null)
                    {
                        return "Mã nhân viên đã tồn tại trong cơ sở dữ liệu";
                    }
                    //trường hợp muốn insert
                    else
                    {
                        NhanVien nv = new NhanVien();
                        nv.MaNV = idnv;
                        nv.HoTenNV = username;
                        nv.Gioitinh = gender;
                        nv.Diachi = address;
                        nv.Ngaysinh = birthday;
                        nv.SDT = phone;
                        nv.Email = email;
                        nv.MaCV = chucvu;
                        db.NhanViens.InsertOnSubmit(nv);
                        db.SubmitChanges();
                        return "Thêm mới nhân viên thành công";
                    }
                }
                catch (Exception ex)
                {

                    return "Thêm mới nhân viên thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Vui lòng điền đầy đủ thông tin";
            }

        }

        public string Edit()
        {
            //ví dụ về linq to sql
            //var qr = db.NhanViens; //select * from NhanVien
            //var qr1 = db.NhanViens.Where(o => o.MSSV == "1234"); //select * from NhanVien where mssv == "1234"

            string id = Request["val-idnv"];
            string manv = Request["val-idnv"];
            string username = Request["val-username"];
            string birthdayString = Request["val-birthday"];
            DateTime birthday;
            DateTime.TryParse(birthdayString, out birthday);
            string gender = Request["val-gender"];
            string email = Request["val-email"];
            string phone = Request["val-phone"];
            string address = Request["val-address"];
            string chucvu = Request["val-chucvu"];

            //validate input
            if (!string.IsNullOrEmpty(manv)
                && !string.IsNullOrEmpty(username)
                && !string.IsNullOrEmpty(email)
                && !string.IsNullOrEmpty(phone)
                && !string.IsNullOrEmpty(address)
                && !string.IsNullOrEmpty(birthdayString)
                && !string.IsNullOrEmpty(gender)
                && !string.IsNullOrEmpty(chucvu))
            {
                /*                    if (id == idnv)
                                    {*/
                try
                {
                    //trường hợp muốn update
                    var qrs = db.NhanViens.Where(o => o.MaNV == manv);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        NhanVien nv = qrs.SingleOrDefault();
                        nv.MaNV = manv;
                        nv.HoTenNV = username;
                        nv.Gioitinh = gender;
                        nv.Diachi = address;
                        nv.Ngaysinh = birthday;
                        nv.SDT = phone;
                        nv.Email = email;
                        nv.MaCV = chucvu;

                        db.SubmitChanges();

                        return "Cập nhật thông tin nhân viên thành công";
                    }
                    else
                    {
                        return "KHÔNG tìm thấy nhân viên có MaNV = " + manv;
                    }
                }
                catch (Exception ex)
                {
                    return "Cập nhật thông tin nhân viên thất bại. Chi tiết lỗi: " + ex.Message;
                }
                /*}
                else
                {
                    //trường hợp mssv đã bị sửa
                    return "MaNV không khớp với dữ liệu trong CSDL";
                }*/
            }
            else
            {
                return "Lỗi!";
            }


        }
        public string get_NV_Info()
        {
            string manv = Request["manv"];

            //validate input
            if (!string.IsNullOrEmpty(manv))
            {
                try
                {
                    //trường hợp lấy được manv từ trang danh sach
                    var qr = db.NhanViens.Where(o => o.MaNV == manv);
                    if (qr.Any())
                    {
                        var nv_obj = qr.SingleOrDefault();
                        return JsonConvert.SerializeObject(nv_obj);
                    }
                    else
                    {
                        return "Không tìm thấy";
                    }

                }
                catch (Exception ex)
                {
                    return "Lấy thông tin nhân viên thất bại. Chi tiết lỗi: " + ex.Message;
                }
                //ok
                //return "MSSV: " + mssv + "; Họ tên: " + hoten + "; Mật khẩu: " + mk;

            }
            else
            {
                return "Vui lòng chọn nhân viên để chỉnh sửa";
            }
        }
        public string get_NV_Edit()
        {
            string manv = Request["manv"];

            //validate input
            if (!string.IsNullOrEmpty(manv))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.NhanViens.Where(o => o.MaNV == manv);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        NhanVien nv = qrs.SingleOrDefault();

                        return JsonConvert.SerializeObject(nv);
                    }
                    else
                    {
                        return "Không tìm thấy nhân viên có MaNV = " + manv;
                    }
                }
                catch (Exception ex)
                {
                    return "Cập nhật thông tin nhân viên thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Lỗi!";
            }
        }

        public string Search_NV()
        {
            APIResult_ett<NhanVien> rs = new APIResult_ett<NhanVien>();
            try
            {
                string search_val = Request["search_val"];
                string search_type = Request["search_type"];

                if (!string.IsNullOrEmpty(search_val) && !string.IsNullOrEmpty(search_type))
                {
                    //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
                    IQueryable<NhanVien> qr = null;

                    switch (search_type)
                    {
                        case "MaNV":
                            qr = db.NhanViens.Where(o => o.MaNV == (search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "Email":
                            qr = db.NhanViens.Where(o => o.Email == (search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "SDT":
                            qr = db.NhanViens.Where(o => o.SDT == (search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        default:
                            break;
                    }

                    if (qr.Any())
                    {
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Tìm kiếm nhân viên thành công";
                        rs.Data = qr.SingleOrDefault();
                        //return JsonConvert.SerializeObject(rs.Data);

                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "Không tìm thấy nhân viên thỏa mãn điều kiện tìm kiếm";
                        rs.Data = null;
                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.InputEmpty;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ giá trị và tiêu chí cần tìm kiếm";
                    rs.Data = null;
                }

            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về danh sách nhân viên. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }
            /*return JsonConvert.SerializeObject(rs, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );*/
            return JsonConvert.SerializeObject(rs.Data);
        }

        public string Search_DSNV()
        {
            /*APIResult_ett<List<NhanVien>> rs = new APIResult_ett<List<NhanVien>>();*/
            APIResult_ett<List<object>> rs = new APIResult_ett<List<object>>();
            try
            {
                string search_val = Request["search_val"];
                string search_type = Request["search_type"];

                if (!string.IsNullOrEmpty(search_val) || !string.IsNullOrEmpty(search_type))
                {
                    //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
                    IQueryable<NhanVien> qr = null;

                    switch (search_type)
                    {
                        case "mssv":
                            qr = db.NhanViens.Where(o => o.MaNV == search_val && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "hoten":
                            qr = db.NhanViens.Where(o => o.HoTenNV.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        default:
                            break;
                    }

                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Tìm kiếm nhân viên thành công";
                        rs.Data = qr.Select(nv => new
                        {
                            nv.MaNV,
                            nv.HoTenNV,
                            nv.Ngaysinh,
                            nv.Gioitinh,
                            nv.Diachi,
                            nv.SDT,
                            nv.Email,
                            ChucVu = nv.ChucVu != null ? nv.ChucVu.TenCV : null
                        }).ToList<object>();

                    }
                    else
                    {
                        //không có dữ liệu thỏa mãn
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "Không tìm thấy nhân viên thỏa mãn điều kiện tìm kiếm";
                        rs.Data = null;
                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.InputEmpty;
                    rs.ErrDesc = "Vui lòng nhập đầy đủ giá trị và tiêu chí cần tìm kiếm";
                    rs.Data = null;
                }

            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về danh sách nhân viên. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
        }
        public string get_All()
        {
            APIResult_ett<List<object>> rs = new APIResult_ett<List<object>>();
            try
            {
                var qr = from nv in db.NhanViens
                         join cv in db.ChucVus on nv.MaCV equals cv.MaCV
                         where nv.isDelete == null || nv.isDelete == 0
                         select new
                         {
                             nv.MaNV,
                             nv.HoTenNV,
                             nv.Ngaysinh,
                             nv.Gioitinh,
                             nv.Diachi,
                             nv.SDT,
                             nv.Email,
                             ChucVu = cv.TenCV
                         };

                if (qr.Any())
                {
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy DSNV thành công";
                    rs.Data = qr.ToList<object>();
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "DSNV rỗng";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về danh sách nhân viên. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
        }

        
        public string Del_NV()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {
                //xử lý trường hợp xóa
                //lấy về mssv cần xóa
                string manv = Request["manv"];
                if (!string.IsNullOrEmpty(manv))
                {
                    //thực hiện xóa và nên xóa mềm
                    var qr = db.NhanViens.Where(o => o.MaNV == manv);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu
                        NhanVien del_obj = qr.SingleOrDefault();
                        del_obj.isDelete = 1;
                        del_obj.DeleteTime = DateTime.Now;

                        db.SubmitChanges();

                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Xóa nhân viên có MaNV " + manv + " thành công";
                        rs.Data = del_obj.HoTenNV;
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Xóa nhân viên có MaNV " + manv + " thất bại do không tìm thấy";
                        rs.Data = null;

                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng nhập MaNV cần xóa";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Xóa nhân viên thất bại. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }
    }
}
