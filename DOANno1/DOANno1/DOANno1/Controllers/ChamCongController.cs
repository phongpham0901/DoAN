using DOANno1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANno1.Controllers
{
    public class ChamCongController : Controller
    {
        public DataClasses1DataContext db = new DataClasses1DataContext();


        public ActionResult QuanLyChamCong()
        {
            if (Shared.Utils.check_login(Session))
            {
                // Lấy danh sách tất cả nhân viên từ CSDL
                var nhanVienList = db.NhanViens.ToList();

                if (nhanVienList != null)
                {
                    ViewBag.NhanVienList = nhanVienList;
                }

                // Lấy danh sách chấm công của nhân viên hiện tại
                string maNhanVien = Session["MaNV"] as string;
                var chamCongList = db.QLChamCongs
                    .Where(cc => cc.MaNV == maNhanVien)
                    .Select(cc => cc.SBChamCong.HasValue ? cc.SBChamCong.Value.Date : (DateTime?)null)
                    .ToList();

                if (chamCongList != null)
                {
                    ViewBag.ChamCongList = JsonConvert.SerializeObject(chamCongList); // Chuyển thành chuỗi JSON
                }

                return View();
            }

            return RedirectToAction("DangNhap", "TaiKhoan");
        }



        public ActionResult ql_chamcong()
        {
            if (Shared.Utils.check_login(Session))
            {
                string maNhanVien = Session["MaNV"] as string;

                // Lấy thông tin nhân viên từ CSDL dựa trên mã nhân viên
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNV == maNhanVien);

                if (nhanVien != null)
                {
                    ViewBag.tenNhanVien = nhanVien.HoTenNV;
                }
                var chamCongList = db.QLChamCongs
                           .Select(cc => cc.SBChamCong.HasValue ? cc.SBChamCong.Value.Date : (DateTime?)null)
                           .ToList();


                if (chamCongList != null)
                {
                    ViewBag.ChamCongList = JsonConvert.SerializeObject(chamCongList); // Chuyển thành chuỗi JSON
                }

                return View();
            }

            return RedirectToAction("DangNhap", "TaiKhoan");
        }
        [HttpPost]
        public ActionResult LuuChamCong(string maNhanVien, string SBChamCong)
        {
            ChamCongModel result = new ChamCongModel();

            try
            {
                if (DateTime.TryParse(SBChamCong, out DateTime thoiGianChamCong))
                {
                    // Kiểm tra xem đã chấm công cho ngày này chưa
                    var existingAttendance = db.QLChamCongs
                        .FirstOrDefault(cc => cc.MaNV == maNhanVien && cc.SBChamCong.HasValue && cc.SBChamCong.Value.Date == thoiGianChamCong.Date);

                    if (existingAttendance != null)
                    {
                        // Thay đổi màu sắc của ngày đã chấm công sang màu xanh
                        result.LuuThanhCong = false;
                        result.Loi = "Ngày đã chấm công trước đó.";
                    }
                    else
                    {
                        // Tạo đối tượng chấm công mới
                        QLChamCong newChamCong = new QLChamCong
                        {
                            MaCC = Guid.NewGuid().ToString().Substring(0, 10),
                            MaNV = maNhanVien,
                            SBChamCong = thoiGianChamCong
                        };

                        // Chèn thông tin chấm công vào CSDL
                        db.QLChamCongs.InsertOnSubmit(newChamCong);
                        db.SubmitChanges();

                        result.LuuThanhCong = true;
                    }
                }
                else
                {
                    result.LuuThanhCong = false;
                    result.Loi = "Ngày chấm công không hợp lệ.";
                }
            }
            catch (Exception ex)
            {
                result.LuuThanhCong = false;
                result.Loi = "Lỗi khi lưu chấm công: " + ex.Message;
            }

            return Json(result);
        }


    }

}




