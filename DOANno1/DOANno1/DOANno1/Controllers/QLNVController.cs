using DOANno1.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace DOANno1.Controllers
{
    public class QLNVController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: QLNV
        public ActionResult Index()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public ActionResult ThemNV()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult SuaNV()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        //[HttpPost]
        public string Add()
        {

            string maNV = Request["txt_manv"];
            string hoTenNV = Request["txt_hotennv"];
            string birthdayString = Request["txt_ngaysinh"];
            DateTime birthday;
            DateTime.TryParse(birthdayString, out birthday);

            string gioitinh = Request["txt_gioitinh"];
            string diachi = Request["txt_diachi"];
            string sDT = Request["txt_sdt"];
            string email = Request["txt_email"];
            string maCV = Request["txt_macv"]; ;

            // Validate input
            if (!string.IsNullOrEmpty(maNV) && !string.IsNullOrEmpty(hoTenNV) &&
                !string.IsNullOrEmpty(birthdayString) && !string.IsNullOrEmpty(diachi) &&
                !string.IsNullOrEmpty(gioitinh) && !string.IsNullOrEmpty(sDT) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(maCV))
            {
                try
                {

                    // Insert new NhanVien object
                    NhanVien nv = new NhanVien();
                    nv.MaNV = maNV;
                    nv.HoTenNV = hoTenNV;
                    nv.Ngaysinh = birthday;
                    nv.Gioitinh = gioitinh;
                    nv.Diachi = diachi;
                    nv.SDT = sDT;
                    nv.Email = email;
                    nv.MaCV = maCV;

                    db.NhanViens.InsertOnSubmit(nv);
                    db.SubmitChanges();

                    return "Thêm mới tài khoản thành công";
                }
                catch (Exception ex)
                {
                    return "Thêm mới tài khoản thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Vui lòng điền đầy đủ thông tin";
            }
        }


        //[HttpPost]
        //Sửa tài khoản
        public string get_NV_Info()
        {
            string maNV = Request["maNV"];

            //validate input
            if (!string.IsNullOrEmpty(maNV))
            {
                try
                {
                    //trường hợp lấy được mssv từ trang suaSV
                    var qr = db.NhanViens.Where(o => o.MaNV == maNV);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu trả về - tìm thấy sv có mssv theo yêu cầu
                        var nv_obj = qr.SingleOrDefault();

                        return JsonConvert.SerializeObject(nv_obj);
                    }
                    else
                    {
                        return "Không tìm thấy tài khoản có tên tài khoản =" + maNV;
                    }

                }
                catch (Exception ex)
                {
                    return "Lấy thông tin tài khoản thất bại. Chi tiết lỗi: " + ex.Message;
                }
                //ok
                //return "MSSV: " + mssv + "; Họ tên: " + hoten + "; Mật khẩu: " + mk;

            }
            else
            {
                return "Vui lòng chọn tài khoản để chỉnh sửa";
            }
        }
        //[HttpPost]
        public string get_NV_Edit()
        {
            string maNV = Request["maNV"];

            //validate input
            if (!string.IsNullOrEmpty(maNV))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.NhanViens.Where(o => o.MaNV == maNV);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        NhanVien nv = qrs.SingleOrDefault();

                        return JsonConvert.SerializeObject(nv);
                    }
                    else
                    {
                        return "Không tìm thấy tài khoản có mã tài khoản = " + maNV;
                    }
                }
                catch (Exception ex)
                {
                    return "Cập nhật thông tin tài khoản thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Tên tài khoản không tồn tại";
            }
        }
        //[HttpPost]
        public string Edit()
        {
            //ví dụ về linq to sql
            //var qr = db.tbl_SVs; //select * from tbl_SV
            //var qr1 = db.tbl_SVs.Where(o => o.MSSV == "1234"); //select * from tbl_SV where mssv == "1234"
            string id = Request["txt_manv"];
            string maNV = Request["txt_manv"];
            string hoTenNV = Request["txt_hotennv"];
            string birthdayString = Request["txt_ngaysinh"];
            DateTime birthday;
            DateTime.TryParse(birthdayString, out birthday);
            string gioitinh = Request["txt_gioitinh"];
            string diachi = Request["txt_diachi"];
            string sDT = Request["txt_sdt"];
            string email = Request["txt_email"];
            string maCV = Request["txt_macv"];

            //validate input
            if (!string.IsNullOrEmpty(maNV) && !string.IsNullOrEmpty(hoTenNV) &&
                !string.IsNullOrEmpty(birthdayString) && !string.IsNullOrEmpty(diachi) &&
                !string.IsNullOrEmpty(gioitinh) && !string.IsNullOrEmpty(sDT) &&
                !string.IsNullOrEmpty(email) &&
                !string.IsNullOrEmpty(maCV))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.NhanViens.Where(o => o.MaNV == maNV);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        NhanVien nv = qrs.SingleOrDefault();
                        //nv.MaNV= maNV;
                        nv.HoTenNV = hoTenNV;
                        nv.Ngaysinh = birthday;
                        nv.Gioitinh = gioitinh;
                        nv.Diachi = diachi;
                        nv.SDT = sDT;
                        nv.Email = email;
                        nv.MaCV = maCV;

                        db.SubmitChanges();
                        JsonConvert.SerializeObject(nv);
                        return "Cập nhật thông tin tài khoản thành công";

                    }
                    else
                    {
                        return "Không tìm thấy tài khoản có mã tài khoản = " + maNV;
                    }
                }
                catch (Exception ex)
                {
                    return "Cập nhật thông tin tài khoản thất bại. Chi tiết lỗi: " + ex.Message;
                }


            }
            else
            {
                //trường hợp mssv đã bị sửa
                return "Tên tài khoản không khớp với dữ liệu trong CSDL";
            }
        }




        //Hiện danh sách tài khoản
        public string get_All()
        {
            APIResult_ett<List<object>> rs = new APIResult_ett<List<object>>();
            try
            {
                var qr = db.NhanViens.Where(o => o.isDelete == null || o.isDelete == 0)

                .Select(nv => new
                {
                    nv.MaNV,
                    nv.HoTenNV,
                    nv.Ngaysinh,
                    nv.Gioitinh,
                    nv.Diachi,
                    nv.SDT,
                    nv.Email,
                    nv.MaCV

                }); ;

                if (qr.Any())
                {
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy danh sách tài khoản thành công";
                    rs.Data = qr.ToList<object>();
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "DSCV rỗng";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về danh sách tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }

        //Tìm kiếm nhân viên
        public string Search_NV()
        {
            APIResult_ett<List<object>> rs = new APIResult_ett<List<object>>();
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
                            qr = db.NhanViens.Where(o => o.MaNV == search_val && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "HoTenNV":
                            qr = db.NhanViens.Where(o => o.HoTenNV.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "Ngaysinh":
                            DateTime searchDate = DateTime.Parse(search_val);
                            qr = db.NhanViens.Where(o => o.Ngaysinh == searchDate && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "Gioitinh":
                            qr = db.NhanViens.Where(o => o.Gioitinh.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "Diachi":
                            qr = db.NhanViens.Where(o => o.Diachi.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "SDT":
                            qr = db.NhanViens.Where(o => o.SDT.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        case "Email":
                            qr = db.NhanViens.Where(o => o.Email.Contains(search_val) && (o.isDelete == null || o.isDelete == 0));
                            break;
                        default:
                            break;
                    }

                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Tìm kiếm tài khoản thành công";
                        rs.Data = qr.ToList<object>();
                    }
                    else
                    {
                        //không có dữ liệu thỏa mãn
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "Không tìm thấy tài khoản thỏa mãn điều kiện tìm kiếm";
                        rs.Data = null;
                    }
                }
                else
                {
                    //get all
                    var qr = db.NhanViens.Where(o => o.isDelete == null || o.isDelete == 0)
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTenNV,
                        nv.Ngaysinh,
                        nv.Gioitinh,
                        nv.Diachi,
                        nv.SDT,
                        nv.Email,
                        nv.MaCV

                    });

                    if (qr.Any())
                    {
                        //có dữ liệu => chính là dssv
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Lấy danh sách tài khoản thành công";
                        rs.Data = qr.ToList<object>();
                    }
                    else
                    {
                        //không có dữ liệu thỏa mãn
                        rs.ErrCode = EnumErrCode.Empty;
                        rs.ErrDesc = "Danh sách tài khoản trống";
                        rs.Data = null;
                    }

                    //rs.ErrCode = EnumErrCode.InputEmpty;
                    //rs.ErrDesc = "Vui lòng nhập đầy đủ giá trị và tiêu chí cần tìm kiếm";
                    //rs.Data = null;
                }

            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về danh sách tài khoản. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }

        //Xóa tài khoản
        public string Del_NV()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {
                // xử lý trường hợp xóa
                // lấy về mssv cần xóa
                string maNV = Request["maNV"].ToString();
                if (!string.IsNullOrEmpty(maNV))
                {
                    // kiểm tra xem có nhân viên nào có mã chức vụ trùng


                    // thực hiện xóa
                    var qr = db.NhanViens.Where(o => o.MaNV == maNV);
                    if (qr.Any())
                    {
                        // trường hợp có dữ liệu
                        NhanVien del_obj = qr.SingleOrDefault();

                        // Remove the record from the database
                        db.NhanViens.DeleteOnSubmit(del_obj);
                        db.SubmitChanges();

                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Xóa tài khoản " + maNV + "thành công";
                        rs.Data = del_obj.HoTenNV;
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Xóa tài khoản " + maNV + " thất bại do không tìm thấy";
                        rs.Data = null;
                    }
                }

                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng nhập tên tài khoản cần xóa";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Xóa thất bại. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }


        public ActionResult DSNV()
        {
            if (Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
    }
}