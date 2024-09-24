using DOANno1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DOANno1.Controllers
{
    public class TaiKhoanController : Controller
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // GET: TaiKhoan
        public ActionResult DangNhap()
        {
            return View();
        }



        public string DangNhap_action()
        {
            APIResult_ett<UserModel> rs = new APIResult_ett<UserModel>();

            try
            {
                string tk = Request["txt_tk"];
                string mk = Request["txt_mk"];

                if (!string.IsNullOrEmpty(tk) && !string.IsNullOrEmpty(mk))
                {
                    var user = db.Taikhoans.FirstOrDefault(o => o.User == tk && o.Password == mk);

                    if (user != null)
                    {
                        Session["is_login"] = true;
                        Session["MaNV"] = user.MaNV;


                        // Lấy thông tin về quyền của người dùng và trả về
                        rs.ErrCode = EnumErrCode.Success;
                        rs.ErrDesc = "Đăng nhập hệ thống thành công";
                        rs.Data = new UserModel
                        {
                            TenTK = user.TenTK,  //Bảng của dương là id
                            User = user.User,
                            // Lấy quyền từ cơ sở dữ liệu (ví dụ: user.QuyenTC)
                            QuyenTC = user.QuyenTC,
                           /* MaNV = user.MaNV*/
                        };
                    }
                    else
                    {
                        rs.ErrCode = EnumErrCode.NotExistent;
                        rs.ErrDesc = "Đăng nhập thất bại. Nhập sai tài khoản hoặc mật khẩu";
                        rs.Data = null;
                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng nhập tài khoản và mật khẩu";
                    rs.Data = null;
                }
            }
            catch (Exception ex)
            {
                rs.ErrCode = EnumErrCode.Error;
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình đăng nhập hệ thống. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }


        public ActionResult DoiMatKhau()
        {
            return View();
        }


        public string DoiMatKhau_action()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            string tk = Request["txt_tk"];
            string mk = Request["txt_mk"];
            string mkmoi = Request["txt_mkmoi"];
            string nhaclaimk = Request["txt_nhaclaimk"];


            //validate input
            if (!string.IsNullOrEmpty(tk) && !string.IsNullOrEmpty(mk) && !string.IsNullOrEmpty(mkmoi) && !string.IsNullOrEmpty(nhaclaimk))
            {

                if (mkmoi == nhaclaimk)
                {
                    try
                    {
                        //trường hợp muốn update
                        var qrs = db.Taikhoans.Where(o => o.User == tk && o.Password == mk);
                        if (qrs.Any())
                        {
                            //có trả về bản ghi.
                            Taikhoan nv = qrs.SingleOrDefault();
                            nv.User = tk;
                            nv.Password = mkmoi;

                            rs.ErrCode = EnumErrCode.Success;
                            rs.ErrDesc = "Đổi mật khẩu thành công";
                            rs.Data = "";

                            db.SubmitChanges();


                        }
                        else
                        {
                            rs.ErrCode = EnumErrCode.NotExistent;
                            rs.ErrDesc = "Đổi mật khẩu thất bại. Nhập sai tài khoản hoặc mật khẩu";
                            rs.Data = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        rs.ErrCode = EnumErrCode.Error;
                        rs.ErrDesc = "Cập nhật mật khẩu thất bại. Chi tiết lỗi: " + ex.Message;
                        rs.Data = null;
                    }
                }
                else
                {
                    //trường hợp dữ liệu input không hợp lệ
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Mật khẩu nhắc lại không khớp. Vui lòng kiểm tra lại";
                    rs.Data = null;
                }
            }
            else
            {
                rs.ErrCode = EnumErrCode.Empty;
                rs.ErrDesc = "Vui lòng nhập tài khoản và mật khẩu";
                rs.Data = null;
            }
            return JsonConvert.SerializeObject(rs);
        }

        public ActionResult Logout()
        {
            Session.Clear(); // Clear all session variables
            Session.Abandon(); // Abandon the session

            // Redirect to the login page or any desired page after logout
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

    }
}