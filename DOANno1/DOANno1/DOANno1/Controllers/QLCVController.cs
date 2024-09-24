using DOANno1.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANno1.Controllers
{
    public class QLCVController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();

        // GET: QLCV

        public ActionResult ThemCV()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public ActionResult SuaCV()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public string AddCV()
        {
            string mcv = Request["txt_mcv"];
            string tencv = Request["txt_tencv"];

            if (!string.IsNullOrEmpty(mcv) && !string.IsNullOrEmpty(tencv))
            {
                try
                {
                    ChucVu existingCV = db.ChucVus.SingleOrDefault(c => c.MaCV == mcv);

                    if (existingCV != null)
                    {
                        return "Mã chức vụ đã tồn tại";
                    }

                    ChucVu newCV = new ChucVu();
                    newCV.MaCV = mcv;
                    newCV.TenCV = tencv;

                    db.ChucVus.InsertOnSubmit(newCV);
                    db.SubmitChanges();

                    return "Thêm mới chức vụ thành công";
                }
                catch (Exception ex)
                {
                    return "Thêm mới chức vụ thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "none";
            }
        }

        public string get_CV_Info()
        {
            string mcv = Request["MaCV"];

            if (!string.IsNullOrEmpty(mcv))
            {
                try
                {
                    var qr = db.ChucVus.Where(o => o.MaCV == mcv && (o.isDelete == null || o.isDelete == 0));

                    if (qr.Any())
                    {
                        var cv_obj = qr.SingleOrDefault();

                        var settings = new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        };

                        return JsonConvert.SerializeObject(cv_obj, settings);
                    }
                    else
                    {
                        return "Không tìm thấy mã chức vụ";
                    }
                }
                catch (Exception ex)
                {
                    return "Lấy thông tin thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Vui lòng nhập Mã Chức vụ";
            }
        }


        public string get_All()
        {
            APIResult_ett<List<object>> rs = new APIResult_ett<List<object>>();
            try
            {
                var qr = db.ChucVus
                            .Where(o => o.isDelete == null || o.isDelete == 0)
                            .Select(cv => new
                            {
                                cv.MaCV,
                                cv.TenCV

                            });

                if (qr.Any())
                {
                    rs.ErrCode = EnumErrCode.Success;
                    rs.ErrDesc = "Lấy DSCV thành công";
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
                rs.ErrDesc = "Có lỗi xảy ra trong quá trình lấy về DSCV. Chi tiết lỗi: " + ex.Message;
                rs.Data = null;
            }

            return JsonConvert.SerializeObject(rs);
        }


        public ActionResult DanhSach()
        {
            if (DOANno1.Shared.Utils.check_login(Session))
            {
                return View();
            }
            return RedirectToAction("DangNhap", "TaiKhoan");
        }

        public string Edit()
        {
            string mcv = Request["txt_mcv"];
            string tencv = Request["txt_tencv"];

            if (!string.IsNullOrEmpty(mcv) && !string.IsNullOrEmpty(tencv))
            {
                try
                {
                    //trường hợp muốn update
                    var qrs = db.ChucVus.Where(o => o.MaCV == mcv);
                    if (qrs.Any())
                    {
                        //có trả về bản ghi.
                        ChucVu cv = qrs.SingleOrDefault();
                        cv.TenCV = tencv;

                        db.SubmitChanges();

                        return "Cập nhật thông tin thành công";
                    }
                    else
                    {
                        return "Vui lòng nhập mã chức vụ đúng!!!";
                    }
                }
                catch (Exception ex)
                {
                    return "Cập nhật thông tin thất bại. Chi tiết lỗi: " + ex.Message;
                }
            }
            else
            {
                return "Vui lòng nhập mã chức vụ đúng!!!";
            }
        }

        //public string Del_CV()
        //{
        //    APIResult_ett<string> rs = new APIResult_ett<string>();

        //    try
        //    {
        //        //xử lý trường hợp xóa
        //        //lấy về mssv cần xóa
        //        string mcv = Request["MaCV"];
        //        if (!string.IsNullOrEmpty(mcv))
        //        {
        //            //thực hiện xóa
        //            var qr = db.ChucVus.Where(o => o.MaCV == mcv);
        //            if (qr.Any())
        //            {
        //                //trường hợp có dữ liệu
        //                ChucVu del_obj = qr.SingleOrDefault();

        //                // Remove the record from the database
        //                db.ChucVus.DeleteOnSubmit(del_obj);
        //                db.SubmitChanges();

        //                rs.ErrCode = EnumErrCode.Success;
        //                rs.ErrDesc = "Xóa chức vụ có mã chức vụ " + mcv + " thành công";
        //                rs.Data = del_obj.TenCV;
        //            }
        //            else
        //            {
        //                rs.ErrCode = EnumErrCode.NotExistent;
        //                rs.ErrDesc = "Xóa chức vụ có mã chức vụ " + mcv + " thất bại do không tìm thấy";
        //                rs.Data = null;
        //            }
        //        }
        //        else
        //        {
        //            rs.ErrCode = EnumErrCode.Empty;
        //            rs.ErrDesc = "Vui lòng nhập mã chức vụ cần xóa";
        //            rs.Data = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        rs.ErrCode = EnumErrCode.Error;
        //        rs.ErrDesc = "Xóa thất bại. Chi tiết lỗi: " + ex.Message;
        //        rs.Data = null;
        //    }

        //    return JsonConvert.SerializeObject(rs);
        //}

        public string Del_CV()
        {
            APIResult_ett<string> rs = new APIResult_ett<string>();

            try
            {
                // xử lý trường hợp xóa
                // lấy về mcv cần xóa
                string mcv = Request["MaCV"];
                if (!string.IsNullOrEmpty(mcv))
                {
                    // kiểm tra xem có nhân viên nào có mã chức vụ trùng
                    var NVtrungMaCV = db.NhanViens.Where(nv => nv.MaCV == mcv);
                    if (NVtrungMaCV.Any())
                    {
                        rs.ErrCode = EnumErrCode.NotAllowed;
                        rs.ErrDesc = "Không thể xóa chức vụ có mã chức vụ " + mcv + " vì có nhân viên liên quan. Hãy chỉnh sửa lại mã chức vụ cho nhân viên trước khi xóa chức vụ.";
                        rs.Data = null;
                    }
                    else
                    {
                        // thực hiện xóa
                        var qr = db.ChucVus.Where(o => o.MaCV == mcv);
                        if (qr.Any())
                        {
                            // trường hợp có dữ liệu
                            ChucVu del_obj = qr.SingleOrDefault();

                            // Remove the record from the database
                            db.ChucVus.DeleteOnSubmit(del_obj);
                            db.SubmitChanges();

                            rs.ErrCode = EnumErrCode.Success;
                            rs.ErrDesc = "Xóa chức vụ có mã chức vụ " + mcv + " thành công";
                            rs.Data = del_obj.TenCV;
                        }
                        else
                        {
                            rs.ErrCode = EnumErrCode.NotExistent;
                            rs.ErrDesc = "Xóa chức vụ có mã chức vụ " + mcv + " thất bại do không tìm thấy";
                            rs.Data = null;
                        }
                    }
                }
                else
                {
                    rs.ErrCode = EnumErrCode.Empty;
                    rs.ErrDesc = "Vui lòng nhập mã chức vụ cần xóa";
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

    }
}