using DOANno1.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DOANno1.Controllers
{
    public class QLTKController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: QLTK
        public ActionResult Index()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        public ActionResult ThemTK()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult SuaTK()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        //[HttpPost]
        public string Them()
        {
            string tenTK = Request["txt_tentk"];
            string user = Request["txt_user"];
            string password = Request["txt_password"];
            string quyenTC = Request["txt_quyentc"];
            /*string maNV = Request["txt_manv"];*/

            // Validate input
            if (!string.IsNullOrEmpty(tenTK) && !string.IsNullOrEmpty(user) &&
                !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(quyenTC) /*&&
                !string.IsNullOrEmpty(maNV)*/)
            {
                try
                {
                    // Check if both username and password already exist
                    if (db.Taikhoans.Any(o => o.User == user))
                    {
                        return "Tên người dùng đã tồn tại. Vui lòng chọn tên người dùng khác.";
                    }

                    // Insert new NhanVien object
                    Taikhoan tk = new Taikhoan();
                    tk.TenTK = tenTK;
                    tk.User = user;
                    tk.Password = password;
                    tk.QuyenTC = quyenTC;
                    /*tk.MaNV = maNV;*/

                    db.Taikhoans.InsertOnSubmit(tk);
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
        public string get_TK_Info()
        {
            string tenTK = Request["tenTK"];

            //validate input
            if (!string.IsNullOrEmpty(tenTK))
            {
                try
                {
                    //trường hợp lấy được mssv từ trang suaSV
                    var qr = db.Taikhoans.Where(o => o.TenTK == tenTK);
                    if (qr.Any())
                    {
                        //trường hợp có dữ liệu trả về - tìm thấy sv có mssv theo yêu cầu
                        var tk_obj = qr.SingleOrDefault();

                        return JsonConvert.SerializeObject(tk_obj);
                    }
                    else
                    {
                        return "Không tìm thấy tài khoản có tên tài khoản =" + tenTK;
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
        public string get_TK_Edit()
        {
            string tenTK = Request["tenTK"];

            //validate input
            if (!string.IsNullOrEmpty(tenTK))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.Taikhoans.Where(o => o.TenTK == tenTK);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        Taikhoan tk = qrs.SingleOrDefault();

                        return JsonConvert.SerializeObject(tk);
                    }
                    else
                    {
                        return "Không tìm thấy tài khoản có mã tài khoản = " + tenTK;
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
            string id = Request["txt_tentk"];
            string tenTK = Request["txt_tentk"];
            string user = Request["txt_user"];
            string password = Request["txt_password"];
            string quyenTC = Request["txt_quyentc"];
            /*string maNV = Request["txt_manv"];*/

            //validate input
            if (/*!string.IsNullOrEmpty(maNV) &&*/ !string.IsNullOrEmpty(tenTK) &&
                !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password) &&
                !string.IsNullOrEmpty(quyenTC))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.Taikhoans.Where(o => o.TenTK == tenTK);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        Taikhoan tk = qrs.SingleOrDefault();
                        tk.User = user;
                        tk.Password = password;
                        tk.QuyenTC = quyenTC;
                        /*tk.MaNV = maNV;*/

                        db.SubmitChanges();
                        JsonConvert.SerializeObject(tk);
                        return "Cập nhật thông tin tài khoản thành công";

                    }
                    else
                    {
                        return "Không tìm thấy tài khoản có mã tài khoản = " + tenTK;
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
                var qr = db.Taikhoans.Where(o => o.isDetele == null || o.isDetele == 0)

                .Select(tk => new
                {
                    tk.TenTK,
                    tk.User,
                    tk.Password,
                    tk.QuyenTC,
                    /*tk.MaNV*/

                });

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

        //TÌm kiếm tài khoản
        public string Search_TK()
        {
            APIResult_ett<List<object>> rs = new APIResult_ett<List<object>>();
            try
            {
                string search_val = Request["search_val"];
                string search_type = Request["search_type"];

                if (!string.IsNullOrEmpty(search_val) && !string.IsNullOrEmpty(search_type))
                {
                    //truy vấn db để lấy toàn bộ dữ liệu về ds sinh viên
                    IQueryable<Taikhoan> qr = null;

                    switch (search_type)
                    {
                        case "TenTK":
                            qr = db.Taikhoans.Where(o => o.TenTK == search_val && (o.isDetele == null || o.isDetele == 0));
                            break;
                        case "User":
                            qr = db.Taikhoans.Where(o => o.User.Contains(search_val) && (o.isDetele == null || o.isDetele == 0));
                            break;
                        case "QuyenTC":
                            qr = db.Taikhoans.Where(o => o.QuyenTC.Contains(search_val) && (o.isDetele == null || o.isDetele == 0));
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
                    var qr = db.Taikhoans.Where(o => o.isDetele == null || o.isDetele == 0)
                    .Select(tk => new
                    {
                        tk.TenTK,
                        tk.User,
                        tk.Password,
                        tk.QuyenTC,
                        /*tk.MaNV*/

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
        public string Del_TK()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {
                // xử lý trường hợp xóa
                // lấy về mssv cần xóa
                string tenTK = Request["tenTK"].ToString();
                if (!string.IsNullOrEmpty(tenTK))
                {
                    // kiểm tra xem có nhân viên nào có mã chức vụ trùng


                    // thực hiện xóa
                    var qr = db.Taikhoans.Where(o => o.TenTK == tenTK);
                    if (qr.Any())
                    {
                        // trường hợp có dữ liệu
                        Taikhoan del_obj = qr.SingleOrDefault();

                        // Remove the record from the database
                        db.Taikhoans.DeleteOnSubmit(del_obj);
                        db.SubmitChanges();

                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Xóa tài khoản " + tenTK + "thành công";
                        rs.Data = del_obj.User;
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Xóa tài khoản " + tenTK + " thất bại do không tìm thấy";
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
        //public string Del_TK()
        //{
        //    APIResult_ett<string> rs = new APIResult_ett<string>();

        //    try
        //    {
        //        //xử lý trường hợp xóa
        //        //lấy về mssv cần xóa
        //        string tenTK = Request["tenTK"];
        //        if (!string.IsNullOrEmpty(tenTK))
        //        {
        //            //thực hiện xóa và nên xóa mềm
        //            var qr = db.Taikhoans.Where(o => o.TenTK == tenTK);
        //            if (qr.Any())
        //            {
        //                //trường hợp có dữ liệu
        //                Taikhoan del_obj = qr.SingleOrDefault();
        //                del_obj.isDetele = 1;
        //               // del_obj.DeleteTime = DateTime.Now.ToString();

        //                db.SubmitChanges();

        //                rs.ErrCode = EnumErrCode.Success;
        //                rs.ErrDesc = "Xóa tài khoản " + tenTK + " thành công";
        //                rs.Data = del_obj.User;
        //            }
        //            else
        //            {
        //                rs.ErrCode = EnumErrCode.NotExistent;
        //                rs.ErrDesc = "Xóa tài khoản " + tenTK + " thất bại do không tìm thấy";
        //                rs.Data = null;

        //            }
        //        }
        //        else
        //        {
        //            rs.ErrCode = EnumErrCode.Empty;
        //            rs.ErrDesc = "Vui lòng nhập tên tài khoản cần xóa";
        //            rs.Data = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        rs.ErrCode = EnumErrCode.Error;
        //        rs.ErrDesc = "Xóa tài khoản thất bại. Chi tiết lỗi: " + ex.Message;
        //        rs.Data = null;
        //    }

        //    return JsonConvert.SerializeObject(rs);
        //}


        public ActionResult DSTK()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }
    }
}